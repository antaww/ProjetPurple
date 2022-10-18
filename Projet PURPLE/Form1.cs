using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Projet_PURPLE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            marioLocation = mario.Location;
            enemyTwoLocation = enemy2.Location;
            enemyThreeLocation = enemy3.Location;
            scoreLabel.Location = new Point((this.Width - scoreLabel.Width) / 2, scoreLabel.Location.Y);
        }

        bool isLeft, isRight, isJumping, isGameOver, isOnGround;

        int jumpSpeed;
        int force;
        
        bool blockLabelMoving = false;
        int counter;

        bool isGameWon = false;
        bool isGameLost = false;

        int gravity = 11;
        int score = 0;
        int marioSpeed = 5;
        int enemySpeed1 = 2, enemySpeed2 = 2, enemySpeed3 = 2;
        int movingPlatformSpeed = 1;

        Point marioLocation;
        Point enemyOneLocation;
        Point enemyTwoLocation;
        Point enemyThreeLocation;


        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                isLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                isRight = true;
            }

            if (e.KeyCode == Keys.Up && !isJumping && isOnGround)
            {
                isJumping = true;
                isOnGround = false;
                force = gravity;
                if (!CheckCoins())
                {
                    foreach (Control x in this.Controls)
                    {
                        if (mario.Bounds.IntersectsWith(x.Bounds) && x.Tag == "door" && x.Visible == true)
                        {
                            isJumping = false;
                            isGameWon = true;
                            EndGame();
                        }
                        x.BringToFront();
                    }
                }
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                isLeft = false;
                mario.Image = Properties.Resources.mario_left;
            }

            if (e.KeyCode == Keys.Right)
            {
                isRight = false;
                mario.Image = Properties.Resources.mario_right;
            }

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.Space && isGameOver)
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            endLabel.Visible = false;
            scoreLabel.Visible = true;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag != "door")
                {
                    x.Visible = true;
                }
            }

            questionBlock.Image = Properties.Resources.question_block;
            questionBlock.BackgroundImage = null;
            isGameOver = false;
            isRight = false;
            isLeft = false;
            isJumping = false;
            isGameLost = false;
            isGameWon = false;
            blockLabel.Visible = false;
            force = 0;
            score = 0;
            mario.Location = marioLocation;
            enemy2.Location = enemyTwoLocation;
            enemy3.Location = enemyThreeLocation;
            scoreLabel.Text = "Score: " + score;
            plateformTimer.Start();
        }


        private int index;

        private void plateformTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            index++;

            if (!CheckCoins())
            {
                door1.Visible = true;
            }
            
            if (counter == 15)
            {
                blockLabelMoving = false;
                blockLabel.Visible = false;
            }
            if(blockLabelMoving)
            {
                if(index % 2 == 0)
                {
                    counter++;
                }
                blockLabel.Location = new Point(blockLabel.Location.X, blockLabel.Location.Y - 1);
            }


            scoreLabel.Text = "Score : " + score;

            CheckLose();

            if (mario.Top > this.ClientSize.Height)
            {
                isGameLost = true;
                EndGame();
            }

            if (isLeft)
            {
                if (mario.Left > 0)
                {
                    mario.Left -= marioSpeed;
                    if (index % 9 == 0)
                    {
                        mario.Image = Properties.Resources.mario_run_left;
                    }
                }
            }

            if (isRight)
            {
                if (mario.Right < this.ClientSize.Width)
                {
                    mario.Left += marioSpeed;
                    if (index % 9 == 0)
                    {
                        mario.Image = Properties.Resources.mario_run;
                    }
                }
            }

            if (!isOnGround)
            {
                mario.Top -= force;
                if (index % 2 == 0 && force > -9)
                {
                    force -= 1;
                }
            }
            else
            {
                force = 0;
            }

            var isOnTemporaryGround = false;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (mario.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (mario.Bottom > x.Top && mario.Bottom < x.Top + 10)
                        {
                            isOnTemporaryGround = true;
                            mario.Top = x.Top + 1 - mario.Height;
                            isJumping = false;
                        }
                        else if (mario.Top < x.Bottom && mario.Top > x.Bottom - 10)
                        {
                            if (x == questionBlock)
                            {
                                if(x.BackgroundImage == null)
                                {
                                    score += 1;
                                    coinBlock.Visible = false;
                                    questionBlock.Image = Properties.Resources.question_block_empty;
                                    questionBlock.BackgroundImage = Properties.Resources.question_block_empty;
                                    x.BackgroundImageLayout = ImageLayout.Stretch;
                                    blockLabel.Visible = true;
                                    counter = 0;
                                    blockLabelMoving = true;
                                    
                                }
                            }
                            mario.Top = x.Bottom + 1;
                            force = 0;
                        }
                        else if (mario.Right > x.Left && mario.Right < x.Left + 10)
                        {
                            mario.Left = x.Left - 1 - mario.Width;
                            isRight = false;
                        }
                        else if (mario.Left < x.Right && mario.Left > x.Right - 10)
                        {
                            mario.Left = x.Right + 1;
                            isLeft = false;
                        }
                    }

                    x.BringToFront();
                }

                if (x is PictureBox && x.Tag == "coin")
                {
                    if (mario.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                    {
                        x.Visible = false;
                        score++;
                    }
                }
            }

            this.isOnGround = isOnTemporaryGround;
        }

        private bool CheckCoins()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "coin")
                {
                    if (x.Visible == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CheckLose()
        {
            foreach (Control x in this.Controls)
            {
                if (mario.Bounds.IntersectsWith(x.Bounds) && x.Tag == "enemy")
                {
                    isGameLost = true;
                    EndGame();
                }

                if (mario.Bounds.IntersectsWith(x.Bounds) && x.Tag == "spike")
                {
                    isGameLost = true;
                    EndGame();
                }
            }
        }

        private void MoveEnemies()
        {
            if (enemy2.Left - 2 >= enemyPlatform2.Left && enemy2.Right + 2 <= enemyPlatform2.Right)
            {
                enemy2.Left += enemySpeed2;
            }
            else
            {
                enemySpeed2 = -enemySpeed2;
                enemy2.Left += enemySpeed2;
            }

            if (enemy3.Left - 2 >= enemyPlatform3.Left && enemy3.Right + 2 <= enemyPlatform3.Right)
            {
                enemy3.Left += enemySpeed3;
            }
            else
            {
                enemySpeed3 = -enemySpeed3;
                enemy3.Left += enemySpeed3;
            }
        }

        private void MovePlatform()
        {
            if (movingPlatform.Top - 2 >= movingPlatformArea.Top && movingPlatform.Bottom + 2 <= movingPlatformArea.Bottom)
            {
                movingPlatform.Top += movingPlatformSpeed;
            }
            else
            {
                movingPlatformSpeed = -movingPlatformSpeed;
                movingPlatform.Top += movingPlatformSpeed;
            }
        }

        private void EndGame()
        {
            scoreLabel.Visible = false;
            isGameOver = true;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = false;
                }
            }

            plateformTimer.Stop();
            endLabel.Visible = true;
            endLabel.AutoSize = false;
            endLabel.TextAlign = ContentAlignment.MiddleCenter;
            endLabel.Dock = DockStyle.Fill;

            if (isGameLost)
            {
                endLabel.Text = "Game Over ! \n Your score is : " + score + "\n Press Space to restart";
            }
            else if (isGameWon)
            {
                endLabel.Text = "You won ! \n Press Space to play next level";
            }
        }

        private void enemiesTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MoveEnemies();
        }

        private void movingPlatformTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MovePlatform();
        }

    }
}