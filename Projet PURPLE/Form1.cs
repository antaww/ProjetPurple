using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using NAudio.Wave;

namespace Projet_PURPLE;

public partial class Form1 : Form
{
    private readonly PrivateFontCollection _pfc = new();

    /// <summary> The Form1 function is the main function of the game. It creates all of the objects and sets up
    /// their initial locations, then starts a timer that moves them.</summary>
    /// <returns> A form.</returns>
    public Form1()
    {
        _pfc.AddFontFile("../../Resources/SuperMario256.ttf");
        InitializeComponent();
        movingPlatformTimer.Enabled = true;
        enemiesTimer.Enabled = true;
        globalTimer.Enabled = true;
        pauseMenuTimer.Enabled = true;
        musicTimer.Enabled = true;

        _marioLocation = mario.Location;
        _enemyTwoLocation = enemy2.Location;
        _enemyThreeLocation = enemy3.Location;
        _blockLabelLocation = blockLabel.Location;
        _blockLabel2Location = blockLabel2.Location;
        scoreLabel.Location = scoreLabel.Location with { X = (Width - scoreLabel.Width) / 2 };
        scoreCoin.Location = scoreCoin.Location with { X = (Width - scoreCoin.Width * 4) / 2 };
        lifeLabel.Location = lifeLabel.Location with
        {
            X = (Width - lifeLabel.Width) / 2 + (scoreLabel.Width + scoreCoin.Width + 50)
        };
        lifeHead.Location = lifeHead.Location with
        {
            X = (Width - lifeHead.Width * 4) / 2 + (scoreLabel.Width + scoreCoin.Width + 50)
        };

        pauseQuitLabel.Padding = new Padding(pauseResumeLabel.Width - pauseQuitLabel.Width / 2, 0,
            pauseResumeLabel.Width - pauseQuitLabel.Width / 2, 0);

        pauseResumeLabel.Padding = new Padding(pauseResumeLabel.Width - pauseQuitLabel.Width + 46, 0,
            pauseResumeLabel.Width - pauseQuitLabel.Width + 46, 0);

        pauseResumeLabel.Visible = false;
        pauseQuitLabel.Visible = false;
        pauseResumeLabel.BackColor = Color.FromArgb(128, 0, 0, 0);
        pauseQuitLabel.BackColor = Color.FromArgb(128, 0, 0, 0);
        pauseResumeLabel.Location = pauseResumeLabel.Location with { X = (Width - pauseResumeLabel.Width * 2) / 2 };
        pauseResumeLabel.Location = pauseResumeLabel.Location with { Y = (Height - pauseResumeLabel.Height) / 2 };
        pauseQuitLabel.Location = pauseResumeLabel.Location with
        {
            Y = pauseResumeLabel.Location.Y + pauseResumeLabel.Height + 10
        };

        door1.Visible = false;

        _fireball = new AudioFileReader(@"../../Resources/smb_fireball.wav");
        _fireballOut = new();
        _fireballOut.Init(_fireball);
        _mainTheme = new AudioFileReader(@"../../Resources/Overworld_Theme.wav");
        _mainThemeOut = new();
        _mainThemeOut.Init(_mainTheme);
        _pauseSound = new AudioFileReader(@"../../Resources/smb_pause.wav");
        _pauseSoundOut = new();
        _pauseSoundOut.Init(_pauseSound);

        movingPlatform.SendToBack();
        musicTimer.Interval = (int)_mainTheme.TotalTime.TotalMilliseconds;
        PlayMainTheme();
    }

    private WaveStream _fireball;
    private WaveOut _fireballOut;
    private WaveStream _mainTheme;
    private WaveOut _mainThemeOut;
    private WaveStream _pauseSound;
    private WaveOut _pauseSoundOut;

    private bool _isGamePaused;
    public bool IsLeft;
    public bool IsRight;
    public bool BlockLabelMoving;
    private bool _isGameOver;
    private bool _isGameWon;
    private bool _isGameLost;
    private bool _enemy2Left;
    private bool _enemy3Left;
    private bool _enemy2AnimLeft;
    private bool _enemy2AnimRight;
    private bool _enemy3AnimLeft;
    private bool _enemy3AnimRight;

    private string _selectedLabel;

    public int Counter;
    private int _index;
    public int Score;
    private int _life = 2;
    private int _enemySpeed2 = 2, _enemySpeed3 = 2;
    private int _movingPlatformSpeed = 1;

    private readonly Point _marioLocation;
    private readonly Point _enemyTwoLocation;
    private readonly Point _enemyThreeLocation;
    private readonly Point _blockLabelLocation;
    private readonly Point _blockLabel2Location;

    //
    //TIMERS
    //

    /// <summary>
    /// It is the main timer of the game. It is used to update the game every globalTimer.Interval milliseconds.
    /// </summary>
    /// <param name="sender"> The object that raised the event. </param>
    /// <param name="ElapsedEventArgs">This is the event that is triggered when the timer has elapsed.</param>
    private void globalTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        _index++;
        
        if (!_isGameWon)
        {
            door1.Visible = false;
        }

        foreach (var label in Controls.OfType<Label>())
        {
            if (label.Font.Name != "Super Mario 256")
            {
                SetFont();
                break;
            }
        }

        if (!CheckCoins() && !endLabel.Visible)
        {
            door1.Visible = true;
        }

        if (Counter == 15)
        {
            BlockLabelMoving = false;
            blockLabel.Visible = false;
            blockLabel2.Visible = false;
        }

        if (BlockLabelMoving)
        {
            if (_index % 2 == 0)
            {
                Counter++;
            }

            blockLabel.Location = blockLabel.Location with { Y = blockLabel.Location.Y - 1 };
            blockLabel2.Location = blockLabel2.Location with { Y = blockLabel2.Location.Y - 1 };
        }


        scoreLabel.Text = Score < 10 ? "x0" + Score : "x" + Score;
        lifeLabel.Text = _life < 10 ? "x0" + _life : "x" + _life;


        CheckLose();

        if (mario.Top > ClientSize.Height)
        {
            _isGameLost = true;
            EndGame();
        }

        if (IsLeft)
        {
            if (mario.Left > 0)
            {
                mario.Left -= Mario.MarioSpeed;
                if (_index % 9 == 0)
                {
                    mario.Image = Properties.Resources.mario_run_left;
                }
            }
        }

        if (IsRight)
        {
            if (mario.Right < ClientSize.Width)
            {
                mario.Left += Mario.MarioSpeed;
                if (_index % 9 == 0)
                {
                    mario.Image = Properties.Resources.mario_run;
                }
            }
        }

        AnimEnemies();

        mario.Fall();

        var isOnTemporaryGround = false;
        foreach (Control x in Controls)
        {
            if (x is PictureBox && (string)x.Tag == "platform")
            {
                if (mario.HandleCollisions(x, this)) isOnTemporaryGround = true;

                x.BringToFront();
                pauseQuitLabel.BringToFront();
                pauseResumeLabel.BringToFront();
            }

            if (x is not PictureBox || (string)x.Tag != "coin") continue;
            if (!mario.Bounds.IntersectsWith(x.Bounds) || !x.Visible) continue;

            x.Visible = false;
            Score++;
            mario.PlayCoinSound();
        }

        mario.IsOnGround = isOnTemporaryGround;
    }

    /// <summary>
    /// > The `MoveEnemies()` function is called every time the `enemiesTimer` ticks
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="ElapsedEventArgs">This is the event that is triggered when the timer has elapsed.</param>
    private void enemiesTimer_Elapsed(object sender, ElapsedEventArgs e) => MoveEnemies();

    /// <summary>
    /// > The function `MovePlatform()` is called every time the timer `movingPlatformTimer` elapses
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="ElapsedEventArgs">The event arguments for the Elapsed event.</param>
    private void movingPlatformTimer_Elapsed(object sender, ElapsedEventArgs e) => MovePlatform();

    /// <summary>
    /// It sets the font of the labels in the pause menu to the font that was selected in the options menu
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="ElapsedEventArgs">The event arguments for the Elapsed event.</param>
    private void pauseMenuTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        SetFont();
        foreach (Control control in Controls)
        {
            control.ForeColor = Equals(control, Controls[_selectedLabel])
                ? ColorTranslator.FromHtml("#eec905")
                : Color.White;
        }
    }
    
    /// <summary>
    /// When the timer elapses, stop the current main theme and play a new one
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="ElapsedEventArgs">The event arguments that are passed to the event handler.</param>
    private void musicTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        _mainThemeOut.Stop();
        PlayMainTheme();
    }

    //
    //KEYBOARD EVENTS
    //

    /// <summary>
    /// If the game is paused, the user can press the up and down arrow keys to select the resume or quit option, and then
    /// press enter to resume or quit the game. If the game is not paused, the user can press the left and right arrow keys
    /// to move Mario left or right, and the up arrow key to make Mario jump
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="KeyEventArgs">The KeyEventArgs class contains information about a key press.</param>
    /// <returns>
    /// The method is returning the value of the variable _isGameWon.
    /// </returns>
    private void KeyIsDown(object sender, KeyEventArgs e)
    {
        if (_isGamePaused)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_selectedLabel == pauseResumeLabel.Name)
                    ResumeGame();
                else if (_selectedLabel == pauseQuitLabel.Name)
                    QuitGame();
            }

            if (e.KeyCode == Keys.Up)
            {
                if (_selectedLabel == pauseQuitLabel.Name)
                    _selectedLabel = pauseResumeLabel.Name;
                else
                {
                    _selectedLabel = pauseQuitLabel.Name;
                }

                PlaySwitchSound();
            }

            if (e.KeyCode == Keys.Down)
            {
                if (_selectedLabel == pauseResumeLabel.Name)
                    _selectedLabel = pauseQuitLabel.Name;
                else
                {
                    _selectedLabel = pauseResumeLabel.Name;
                }

                PlaySwitchSound();
            }

            return;
        }

        if (e.KeyCode == Keys.Left)
        {
            IsLeft = true;
        }

        if (e.KeyCode == Keys.Right)
        {
            IsRight = true;
        }

        if (e.KeyCode == Keys.Up)
        {
            mario.Jump();
            if (CheckCoins()) return;
            foreach (Control x in Controls)
            {
                if (!mario.Bounds.IntersectsWith(x.Bounds) || (string)x.Tag != "door" || !x.Visible) continue;
                mario.IsJumping = false;
                _isGameWon = true;
                EndGame();
                x.BringToFront();
            }
        }
    }

    /// <summary>
    /// If the game is not paused, and the left or right arrow keys are released, then set the corresponding boolean to
    /// false and set the animation to the corresponding direction. If the escape key is released, then pause or resume the
    /// game depending on whether or not the game is already paused. If the space bar is released and the game is over, then
    /// reset the game
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="KeyEventArgs">This is the event that is triggered when a key is pressed.</param>
    private void KeyIsUp(object sender, KeyEventArgs e)
    {
        if (!_isGamePaused)
        {
            if (e.KeyCode == Keys.Left)
            {
                IsLeft = false;
                mario.SetLeftAnimation();
            }

            if (e.KeyCode == Keys.Right)
            {
                IsRight = false;
                mario.SetRightAnimation();
            }
        }

        if (e.KeyCode == Keys.Escape)
        {
            if (!_isGameOver)
            {
                if (!_isGamePaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }

        if (e.KeyCode == Keys.Space && _isGameOver)
        {
            if (_isGameWon)
            {
                LoadLevel2();
            }
            else
            {
                ResetGame();
            }
        }
    }

    //
    //CLICK EVENTS
    //

    /// <summary>
    /// When the user clicks on the pauseResumeLabel, the ResumeGame() function is called
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">This is a class that contains information about the event.</param>
    private void pauseResumeLabel_Click(object sender, EventArgs e)
    {
        ResumeGame();
    }

    /// <summary>
    /// When the user clicks on the pauseQuitLabel, the QuitGame() function is called
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">This is a class that contains information about the event.</param>
    private void pauseQuitLabel_Click(object sender, EventArgs e)
    {
        QuitGame();
    }

    //
    //METHODS
    //

    /// <summary>
    /// Loads the level 2 of the game
    /// </summary>
    private void LoadLevel2()
    {
        musicTimer.Stop();
        var form2 = new Form2();
        form2.Show();
        Hide();
    }

    /// <summary>
    /// If the main theme is playing, stop it, set the current time to 0, and play it
    /// </summary>
    private void PlayMainTheme()
    {
        if (_mainThemeOut.PlaybackState == PlaybackState.Playing) _mainThemeOut.Stop();
        _mainTheme.CurrentTime = new TimeSpan(0L);
        _mainThemeOut.Play();
    }

    /// <summary>
    /// If the fireballOut sound is playing, stop it, set the fireball sound to the beginning, and play it
    /// </summary>
    private void PlaySwitchSound()
    {
        if (_fireballOut.PlaybackState == PlaybackState.Playing) _fireballOut.Stop();
        _fireball.CurrentTime = new TimeSpan(0L);
        _fireballOut.Play();
    }

    /// <summary>
    /// If the pause sound is playing, stop it, set the current time to 0, and play it
    /// </summary>
    private void PlayPauseSound()
    {
        if (_pauseSoundOut.PlaybackState == PlaybackState.Playing) _pauseSoundOut.Stop();
        _pauseSound.CurrentTime = new TimeSpan(0L);
        _pauseSoundOut.Play();
    }

    /// <summary>
    /// It pauses the game, plays a sound, and displays the pause menu
    /// </summary>
    private void PauseGame()
    {
        PlayPauseSound();
        _mainThemeOut.Pause();
        _selectedLabel = "pauseResumeLabel";
        _isGamePaused = true;
        pauseQuitLabel.Visible = true;
        pauseResumeLabel.Visible = true;
        globalTimer.Stop();
        enemiesTimer.Stop();
        movingPlatformTimer.Stop();
        pauseMenuTimer.Start();
    }

    /// <summary>
    /// This function resumes the game by playing the main theme out, setting the game to unpaused, hiding the pause menu
    /// labels, starting the global timer, enemies timer, and moving platform timer, and stopping the pause menu timer
    /// </summary>
    private void ResumeGame()
    {
        _mainThemeOut.Play();
        _isGamePaused = false;
        pauseQuitLabel.Visible = false;
        pauseResumeLabel.Visible = false;
        globalTimer.Start();
        enemiesTimer.Start();
        movingPlatformTimer.Start();
        pauseMenuTimer.Stop();
    }

    /// <summary>
    /// This function resets the game to its original state
    /// </summary>
    private void ResetGame()
    {
        _mainThemeOut.Stop();
        _mainTheme.CurrentTime = new TimeSpan(0L);
        _mainThemeOut.Play();

        endLabel.Visible = false;
        scoreLabel.Visible = true;
        lifeLabel.Visible = true;

        foreach (Control x in Controls)
        {
            if (x is PictureBox)
            {
                x.Visible = true;
            }
        }

        door1.Visible = false;

        questionBlock.Image = Properties.Resources.question_block;
        questionBlock.BackgroundImage = null;
        _isGameOver = false;
        IsRight = false;
        IsLeft = false;
        _isGameLost = false;
        _isGameWon = false;
        blockLabel.Visible = false;
        blockLabel2.Visible = false;
        ResetMario();
        Score = 0;
        _life = 2;
        enemy2.Location = _enemyTwoLocation;
        enemy3.Location = _enemyThreeLocation;
        blockLabel.Location = _blockLabelLocation;
        blockLabel2.Location = _blockLabel2Location;
        scoreLabel.Text = Score < 10 ? "x0" + Score : "x" + Score;
        globalTimer.Start();
    }

    /// <summary>
    /// It sets the font of the labels to the font I downloaded
    /// </summary>
    private void SetFont()
    {
        blockLabel.Font = new Font(_pfc.Families[0], 13);
        blockLabel2.Font =
            new Font(_pfc.Families[0], 17); //+ is not managed by the font, so I had to use a bigger font size
        scoreLabel.Font = new Font(_pfc.Families[0], 15);
        endLabel.Font = new Font(_pfc.Families[0], 30);
        pauseResumeLabel.Font = new Font(_pfc.Families[0], 20);
        pauseQuitLabel.Font = new Font(_pfc.Families[0], 20);
        lifeLabel.Font = new Font(_pfc.Families[0], 15);
    }

    /// <summary>
    /// > ResetMario() resets Mario's location and state
    /// </summary>
    private void ResetMario()
    {
        mario.IsJumping = false;
        mario.Force = 0;
        mario.Location = _marioLocation;
    }

    /// <summary>
    /// If there is a picturebox with a tag of "coin" and it is visible, return true. Otherwise, return false
    /// </summary>
    /// <returns>
    /// A boolean value.
    /// </returns>
    private bool CheckCoins()
    {
        foreach (Control x in Controls)
        {
            if (x is PictureBox && (string)x.Tag == "coin" && x.Visible)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// If Mario intersects with an enemy or a spike, the game is lost
    /// </summary>
    private void CheckLose()
    {
        foreach (Control x in Controls)
        {
            if (mario.Bounds.IntersectsWith(x.Bounds) && (string)x.Tag == "enemy")
            {
                _isGameLost = true;
                EndGame();
            }

            if (!mario.Bounds.IntersectsWith(x.Bounds) || (string)x.Tag != "spike") continue;
            _isGameLost = true;
            EndGame();
        }
    }

    /// <summary>
    /// If the enemy is moving left, move it left, and if it's moving right, move it right
    /// </summary>
    private void MoveEnemies()
    {
        if (_enemy2Left)
        {
            enemy2.Left -= _enemySpeed2;
            if (enemy2.Left < enemyPlatform2.Left)
            {
                _enemy2Left = false;
            }
        }
        else
        {
            enemy2.Left += _enemySpeed2;
            if (enemy2.Left + enemy2.Width > enemyPlatform2.Left + enemyPlatform2.Width)
            {
                _enemy2Left = true;
            }
        }

        if (_enemy3Left)
        {
            enemy3.Left -= _enemySpeed3;
            if (enemy3.Left < enemyPlatform3.Left)
            {
                _enemy3Left = false;
            }
        }
        else
        {
            enemy3.Left += _enemySpeed3;
            if (enemy3.Left + enemy3.Width > enemyPlatform3.Left + enemyPlatform3.Width)
            {
                _enemy3Left = true;
            }
        }
    }

    /// <summary>
    /// If the enemy is moving left, and the enemy is not already animating left, then animate the enemy left
    /// </summary>
    private void AnimEnemies()
    {
        if (_enemy2Left)
        {
            if (!_enemy2AnimLeft)
            {
                _enemy2AnimLeft = true;
                _enemy2AnimRight = false;
                enemy2.Image = Properties.Resources.goomba_walking;
            }
        }
        else
        {
            if (!_enemy2AnimRight)
            {
                _enemy2AnimLeft = false;
                _enemy2AnimRight = true;
                enemy2.Image = Properties.Resources.goomba_walking_right;
            }
        }

        if (_enemy3Left)
        {
            if (!_enemy3AnimLeft)
            {
                _enemy3AnimLeft = true;
                _enemy3AnimRight = false;
                enemy3.Image = Properties.Resources.goomba_walking;
            }
        }
        else
        {
            if (!_enemy3AnimRight)
            {
                _enemy3AnimLeft = false;
                _enemy3AnimRight = true;
                enemy3.Image = Properties.Resources.goomba_walking_right;
            }
        }
    }


    /// <summary>
    /// If the platform is within the area, move it, otherwise change the direction of the platform and move it
    /// </summary>
    private void MovePlatform()
    {
        if (movingPlatform.Top - 2 >= movingPlatformArea.Top &&
            movingPlatform.Bottom + 2 <= movingPlatformArea.Bottom)
        {
            movingPlatform.Top += _movingPlatformSpeed;
        }
        else
        {
            _movingPlatformSpeed = -_movingPlatformSpeed;
            movingPlatform.Top += _movingPlatformSpeed;
        }
    }

    /// <summary>
    /// This function is called when the game is over, it stops the game and displays the end screen
    /// </summary>
    private void EndGame()
    {
        if (_life > 0 && !_isGameWon)
        {
            mario.PlayDieSound();
            _life--;
            ResetMario();
            _isGameLost = false;
        }
        else
        {
            _mainThemeOut.Stop();
            scoreLabel.Visible = false;
            lifeLabel.Visible = false;
            _isGameOver = true;
            foreach (Control x in Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = false;
                }
            }

            door1.Visible = false;

            globalTimer.Stop();
            endLabel.Visible = true;
            endLabel.BackColor = Color.Black;
            endLabel.AutoSize = false;
            endLabel.TextAlign = ContentAlignment.MiddleCenter;
            endLabel.Dock = DockStyle.Fill;

            if (_isGameLost)
            {
                mario.PlayGameOverSound();
                endLabel.Text = "Game Over ! \n Your score is : " + Score + "\n Press Space to restart";
            }
            else if (_isGameWon)
            {
                mario.PlayWinSound();
                endLabel.Text = "You won ! \n Press Space to play next level";
            }
        }
    }

    /// <summary>
    /// QuitGame() is a function that quits the game
    /// </summary>
    private static void QuitGame()
    {
        Application.Exit();
    }

    //
    //HOVER EVENTS
    //

    /// <summary>
    /// When the mouse hovers over the pauseResumeLabel, the _selectedLabel variable is set to "pauseResumeLabel"
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void pauseResumeLabel_MouseHover(object sender, EventArgs e)
    {
        _selectedLabel = "pauseResumeLabel";
    }

    /// <summary>
    /// When the mouse hovers over the pauseQuitLabel, the _selectedLabel variable is set to "pauseQuitLabel"
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void pauseQuitLabel_MouseHover(object sender, EventArgs e)
    {
        _selectedLabel = "pauseQuitLabel";
    }
}