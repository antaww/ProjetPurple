﻿using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace Projet_PURPLE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _marioLocation = mario.Location;
            _enemyTwoLocation = enemy2.Location;
            _enemyThreeLocation = enemy3.Location;
            _blockLabelLocation = blockLabel.Location;
            _blockLabel2Location = blockLabel2.Location;
            scoreLabel.Location = scoreLabel.Location with { X = (Width - scoreLabel.Width) / 2 };
            scoreCoin.Location = scoreCoin.Location with { X = (Width - scoreCoin.Width * 4) / 2 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public bool IsLeft;
        public bool IsRight;
        private bool _isGameOver;
        public bool BlockLabelMoving;
        private bool _isGameWon;
        private bool _isGameLost;

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


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
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

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.Space && _isGameOver)
            {
                ResetGame();
            }
        }


        private void ResetGame()
        {
            endLabel.Visible = false;
            scoreLabel.Visible = true;

            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag != "door")
                {
                    x.Visible = true;
                }

                if (x is PictureBox && (string)x.Tag == "door")
                {
                    x.Visible = false;
                }
            }

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
            plateformTimer.Start();
        }

        private void plateformTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _index++;

            var pfc = new PrivateFontCollection();
            pfc.AddFontFile("../../Resources/SuperMario256.ttf");
            blockLabel.Font = new Font(pfc.Families[0], 13);
            blockLabel2.Font =
                new Font(pfc.Families[0], 17); //+ is not managed by the font, so I had to use a bigger font size

            scoreLabel.Font = new Font(pfc.Families[0], 15);
            endLabel.Font = new Font(pfc.Families[0], 30);


            if (!CheckCoins())
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

            mario.Fall(_index);

            var isOnTemporaryGround = false;
            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform")
                {
                    if (mario.HandleCollisions(x, this)) isOnTemporaryGround = true;

                    x.BringToFront();
                }

                if (x is not PictureBox || (string)x.Tag != "coin") continue;
                if (!mario.Bounds.IntersectsWith(x.Bounds) || !x.Visible) continue;

                x.Visible = false;
                Score++;
                mario.PlayCoinSound();
            }

            mario.IsOnGround = isOnTemporaryGround;
        }

        private void ResetMario()
        {
            mario.IsJumping = false;
            mario.Force = 0;
            mario.Location = _marioLocation;
        }

        private bool CheckCoins() => Controls
            .Cast<Control>()
            .Where(x => x is PictureBox && (string)x.Tag == "coin")
            .Any(x => x.Visible);

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
            if (enemy2.Left - 2 >= enemyPlatform2.Left && enemy2.Right + 2 <= enemyPlatform2.Right)
            {
                enemy2.Left += _enemySpeed2;
            }
            else
            {
                _enemySpeed2 = -_enemySpeed2;
                enemy2.Left += _enemySpeed2;
            }

            if (enemy3.Left - 2 >= enemyPlatform3.Left && enemy3.Right + 2 <= enemyPlatform3.Right)
            {
                enemy3.Left += _enemySpeed3;
            }
            else
            {
                _enemySpeed3 = -_enemySpeed3;
                enemy3.Left += _enemySpeed3;
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

            plateformTimer.Stop();
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

        private void enemiesTimer_Elapsed(object sender, ElapsedEventArgs e) => MoveEnemies();

        private void movingPlatformTimer_Elapsed(object sender, ElapsedEventArgs e) => MovePlatform();
    }
}