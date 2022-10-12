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
            enemyOneLocation = enemy1.Location;
            enemyTwoLocation = enemy2.Location;
            enemyThreeLocation = enemy3.Location;
        }

        bool isLeft, isRight, isUp, isGameOver;

        int jumpSpeed, force;
        int jumpHeight = -6;
        int gravity = 6;
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
                // mario.Image = Properties.Resources.mario_run_left;
            }

            if (e.KeyCode == Keys.Right)
            {
                isRight = true;
                // mario.Image = Properties.Resources.mario_run;
            }

            if (e.KeyCode == Keys.Up && !isUp)
            {
                isUp = true;
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

            if (isUp)
            {
                isUp = false;
            }

            if (!isUp)
            {
                jumpSpeed = jumpHeight;
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
            score = 0;
            mario.Location = marioLocation;
            enemy1.Location = enemyOneLocation;
            enemy2.Location = enemyTwoLocation;
            enemy3.Location = enemyThreeLocation;
            scoreLabel.Text = "Score: " + score;
            plateformTimer.Start();
        }


        private int index;

        private void plateformTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            index++;
            
            MoveEnemies();

            
            scoreLabel.Text = "Score : " + score;
            mario.Top += jumpSpeed;
            
            foreach (Control x in this.Controls)
            {
                if (mario.Bounds.IntersectsWith(x.Bounds) && x.Tag == "enemy")
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

            if (isUp && force < 0)
            {
                isUp = false;
            }

            if (isUp)
            {
                mario.Top += jumpSpeed;
                jumpSpeed = jumpHeight;
                force -= 1;
            }
            else
            {
                jumpSpeed = gravity;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (mario.Bounds.IntersectsWith(x.Bounds) && !isUp)
                    {
                        //Mario is on the platform
                        if(mario.Bottom > x.Top && mario.Bottom < x.Top + 10)
                        {
                            force = 7;
                            mario.Top = x.Top + 1 - mario.Height;
                            jumpSpeed = 0;
                        }
                        //Mario is under the platform
                        else if(mario.Top < x.Bottom && mario.Top > x.Bottom - 10)
                        {
                            jumpSpeed = 0;
                            mario.Top = x.Bottom + 10;
                            // force = 7;
                        }
                        else if(mario.Right > x.Left && mario.Right < x.Left + 10)
                        {
                            mario.Left = x.Left-5 - mario.Width;
                            // force = 7;
                            jumpSpeed = 0;

                        }
                        else if(mario.Left < x.Right && mario.Left > x.Right - 10)
                        {
                            mario.Left = x.Right+5;
                            // force = 7;
                            jumpSpeed = 0;

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
        }

        private void MoveEnemies()
        {
            if (enemy1.Left - 2 >= enemyPlatform1.Left && enemy1.Right + 2 <= enemyPlatform1.Right)
            {
                enemy1.Left += enemySpeed1;
            }
            else
            {
                enemySpeed1 = -enemySpeed1;
                enemy1.Left += enemySpeed1;
            }
            
            // if (enemy2.Left - 2 >= enemyPlatform2.Left && enemy2.Right + 2 <= enemyPlatform2.Right)
            // {
            //     enemy2.Left += enemySpeed2;
            // }
            // else
            // {
            //     enemySpeed2 = -enemySpeed2;
            //     enemy2.Left += enemySpeed2;
            // }
            //
            // if (enemy3.Left - 2 >= enemyPlatform3.Left && enemy3.Right + 2 <= enemyPlatform3.Right)
            // {
            //     enemy3.Left += enemySpeed3;
            // }
            // else
            // {
            //     enemySpeed3 = -enemySpeed3;
            //     enemy3.Left += enemySpeed3;
            // }
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

    }
}