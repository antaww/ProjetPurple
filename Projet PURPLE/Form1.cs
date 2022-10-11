﻿using System;
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
        }

        bool isLeft, isRight, isUp, isGameOver;

        int jumpSpeed, force;
        int score = 0;
        int marioSpeed = 6;
        int horizontalSpeed = 8;
        private int verticalSpeed = 3;
        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 5;
        int enemyThreeSpeed = 5;

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
            }

            if (e.KeyCode == Keys.Right)
            {
                isRight = false;
            }

            if (isUp)
            {
                isUp = false;
            }
            if (!isUp)
            {
                jumpSpeed = 15;
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
            isGameOver = false;
            score = 0;
            isLeft = false;
            isRight = false;
            isUp = false;
            scoreLabel.Text = "Score : " + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            mario.Left = 5;
            mario.Top = 612;
            enemy1.Left = 289;
            enemy2.Top = 527;
            enemy2.Left = 638;
            enemy2.Top = 391;
            enemy3.Left = 25;
            enemy3.Top = 33;

            plateformTimer.Start();
        }


        private void plateformTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            scoreLabel.Text = "Score : " + score;

            mario.Top += jumpSpeed;
            
            if (isLeft)
            {
                mario.Left -= marioSpeed;
                mario.Image = Properties.Resources.mario_left;
            }
            if(isRight)
            {
                mario.Left += marioSpeed;
                mario.Image = Properties.Resources.mario_right;
            }
            if(isUp && force < 0)
            {
                isUp = false;
            }
            //mario transparent background bug
            if(isUp) 
            {
                jumpSpeed = -15;
                force -= 1;
            }
            else
            {
                jumpSpeed = 15;
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "platform")
                {
                    if (mario.Bounds.IntersectsWith(x.Bounds) && !isUp)
                    {
                        force = 8;
                        mario.Top = x.Top - mario.Height;
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
    }
}