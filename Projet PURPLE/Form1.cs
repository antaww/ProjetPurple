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
        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 5;
        int enemyThreeSpeed = 5;

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

            //todo:respawn every coins
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

            scoreLabel.Text = "Score : " + score;
            mario.Top += jumpSpeed;


            if (mario.Top < 0 || mario.Top + mario.Height > this.ClientSize.Height)
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
                        force = 7;
                        mario.Top = x.Top + 1 - mario.Height;
                        jumpSpeed = 0;
                    }

                    x.BringToFront();
                }

                if (x is PictureBox && x.Tag == "coin")
                {
                    if (mario.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        score++;
                    }
                }
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
    }
}