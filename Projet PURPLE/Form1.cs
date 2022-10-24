using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Timers;
using System.Windows.Forms;
using NAudio.Wave;

namespace Projet_PURPLE;

public partial class Form1 : Form
{
    
    private readonly PrivateFontCollection _pfc = new();
    public Form1()
    {
        _pfc.AddFontFile("../../Resources/SuperMario256.ttf");
        InitializeComponent();
        movingPlatformTimer.Enabled = true;
        enemiesTimer.Enabled = true;
        globalTimer.Enabled = true;
        pauseMenuTimer.Enabled = true;

        _marioLocation = mario.Location;
        _enemyTwoLocation = enemy2.Location;
        _enemyThreeLocation = enemy3.Location;
        _blockLabelLocation = blockLabel.Location;
        _blockLabel2Location = blockLabel2.Location;
        scoreLabel.Location = scoreLabel.Location with { X = (Width - scoreLabel.Width) / 2 };
        scoreCoin.Location = scoreCoin.Location with { X = (Width - scoreCoin.Width * 4) / 2 };

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


        CheckLose();

        if (mario.Top > ClientSize.Height)
        {
            _isGameLost = true;
            mario.PlayDieSound();
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

        mario.Fall(_index);

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

    private void enemiesTimer_Elapsed(object sender, ElapsedEventArgs e) => MoveEnemies();

    private void movingPlatformTimer_Elapsed(object sender, ElapsedEventArgs e) => MovePlatform();

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

    //
    //KEYBOARD EVENTS
    //

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

    private void pauseResumeLabel_Click(object sender, EventArgs e)
    {
        ResumeGame();
    }

    private void pauseQuitLabel_Click(object sender, EventArgs e)
    {
        QuitGame();
    }

    //
    //METHODS
    //

    private void LoadLevel2()
    {
        var form2 = new Form2();
        form2.Show();
        Hide();
    }

    private void PlayMainTheme()
    {
        if(_mainThemeOut.PlaybackState == PlaybackState.Playing) _mainThemeOut.Stop();
        _mainTheme.CurrentTime = new TimeSpan(0L);
        _mainThemeOut.Play();
    }
    
    private void PlaySwitchSound()
    {
        if (_fireballOut.PlaybackState == PlaybackState.Playing) _fireballOut.Stop();
        _fireball.CurrentTime = new TimeSpan(0L);
        _fireballOut.Play();
    }
    
    private void PlayPauseSound()
    {
        if(_pauseSoundOut.PlaybackState == PlaybackState.Playing) _pauseSoundOut.Stop();
        _pauseSound.CurrentTime = new TimeSpan(0L);
        _pauseSoundOut.Play();
    }

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

    private void ResetGame()
    {
        _mainThemeOut.Stop();
        _mainTheme.CurrentTime = new TimeSpan(0L);
        _mainThemeOut.Play();
        
        endLabel.Visible = false;
        scoreLabel.Visible = true;

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
        enemy2.Location = _enemyTwoLocation;
        enemy3.Location = _enemyThreeLocation;
        blockLabel.Location = _blockLabelLocation;
        blockLabel2.Location = _blockLabel2Location;
        scoreLabel.Text = Score < 10 ? "x0" + Score : "x" + Score;
        globalTimer.Start();
    }

    private void SetFont()
    {
        blockLabel.Font = new Font(_pfc.Families[0], 13);
        blockLabel2.Font =
            new Font(_pfc.Families[0], 17); //+ is not managed by the font, so I had to use a bigger font size
        scoreLabel.Font = new Font(_pfc.Families[0], 15);
        endLabel.Font = new Font(_pfc.Families[0], 30);
        pauseResumeLabel.Font = new Font(_pfc.Families[0], 20);
        pauseQuitLabel.Font = new Font(_pfc.Families[0], 20);
    }

    private void ResetMario()
    {
        mario.IsJumping = false;
        mario.Force = 0;
        mario.Location = _marioLocation;
    }

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

    private void CheckLose()
    {
        foreach (Control x in Controls)
        {
            if (mario.Bounds.IntersectsWith(x.Bounds) && (string)x.Tag == "enemy")
            {
                _isGameLost = true;
                mario.PlayDieSound();
                EndGame();
            }

            if (!mario.Bounds.IntersectsWith(x.Bounds) || (string)x.Tag != "spike") continue;
            _isGameLost = true;
            mario.PlayDieSound();
            EndGame();
        }
    }

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

    private void EndGame()
    {
        _mainThemeOut.Stop();
        scoreLabel.Visible = false;
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
            endLabel.Text = "Game Over ! \n Your score is : " + Score + "\n Press Space to restart";
        }
        else if (_isGameWon)
        {
            endLabel.Text = "You won ! \n Press Space to play next level";
        }
    }

    private static void QuitGame()
    {
        Application.Exit();
    }

    //
    //HOVER EVENTS
    //

    private void pauseResumeLabel_MouseHover(object sender, EventArgs e)
    {
        _selectedLabel = "pauseResumeLabel";
    }

    private void pauseQuitLabel_MouseHover(object sender, EventArgs e)
    {
        _selectedLabel = "pauseQuitLabel";
    }
}