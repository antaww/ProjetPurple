using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        bool isLeft, isRight, isJumping, isGameOver, isOnGround;

        int jumpSpeed;
        int force;

        int gravity = 10;
        int score = 0;
        int marioSpeed = 3;
        int enemySpeed1 = 2, enemySpeed2 = 2, enemySpeed3 = 2;

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
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "coin")
                {
                    x.Visible = true;
                }
            }

            isGameOver = false;
            isRight = false;
            isLeft = false;
            isJumping = false;
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

            scoreLabel.Text = "Score : " + score;

            foreach (Control x in this.Controls)
            {
                if (mario.Bounds.IntersectsWith(x.Bounds) && x.Tag == "enemy")
                {
                    isGameOver = true;
                    EndGame();
                }

                if (mario.Bounds.IntersectsWith(x.Bounds) && x.Tag == "spike")
                {
                    isGameOver = true;
                    EndGame();
                }
            }

            if (mario.Top > this.ClientSize.Height)
            {
                isGameOver = true;
                EndGame();
            }

            if (isLeft)
            {
                if (mario.Left > 0)
                {
                    mario.Left -= marioSpeed;
                    if (index % 12 == 0)
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
                    if (index % 12 == 0)
                    {
                        mario.Image = Properties.Resources.mario_run;
                    }
                }
            }

            if (!isOnGround)
            {
                mario.Top -= force;
                if (index % 3 == 0 && force > -10)
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
                            mario.Top = x.Bottom + 1;
                            force = 0;
                        }
                        else if (mario.Right > x.Left && mario.Right < x.Left + 10)
                        {
                            mario.Left = x.Left - 5 - mario.Width;
                        }
                        else if (mario.Left < x.Right && mario.Left > x.Right - 10)
                        {
                            mario.Left = x.Right + 5;
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

        private void EndGame()
        {
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
            endLabel.Text = "Game Over ! \n Your score is : " + score + "\n Press Space to restart";
        }

        private void enemiesTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MoveEnemies();
        }
    }
}