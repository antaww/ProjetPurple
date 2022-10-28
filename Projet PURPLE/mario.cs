using System;
using System.Media;
using System.Windows.Forms;
using NAudio.Wave;

namespace Projet_PURPLE
{
    public class Mario : PictureBox
    {
        public bool IsOnGround, IsJumping;
        public int Force;
        private const int Gravity = 11;
        public const int MarioSpeed = 5;

        private WaveStream _bump;
        private WaveOut _bumpOut;
        private WaveStream _jump;
        private WaveOut _jumpOut;
        private WaveStream _coin;
        private WaveOut _coinOut;
        private WaveStream _death;
        private WaveOut _deathOut;
        private WaveStream _gameOver;
        private WaveOut _gameOverOut;
        private WaveStream _win;
        private WaveOut _winOut;


        /// <summary>
        /// If the player is not jumping and is on the ground, then set the player to jumping, set the player to not on the
        /// ground, set the force to the gravity, and play the jump sound
        /// </summary>
        /// <returns>
        /// Nothing is being returned.
        /// </returns>
        public void Jump()
        {
            if (IsJumping || !IsOnGround) return;
            IsJumping = true;
            IsOnGround = false;
            Force = Gravity;
            PlayJumpSound();
        }

        /// <summary>
        /// This function sets the image of the player to the left facing image
        /// </summary>
        public void SetLeftAnimation()
        {
            Image = Properties.Resources.mario_left;
        }

        /// <summary>
        /// This function sets the image of the player to the right facing image
        /// </summary>
        public void SetRightAnimation()
        {
            Image = Properties.Resources.mario_right;
        }

        /// <summary>
        /// If the player collides with a block, the player will stop moving in that direction
        /// </summary>
        /// <param name="Control">The control that the player is colliding with.</param>
        /// <param name="Form1">The form that the game is running on.</param>
        /// <returns>
        /// A boolean value.
        /// </returns>
        public bool HandleCollisions(Control x, Form1 form)
        {
            if (!Bounds.IntersectsWith(x.Bounds)) return false;
            if (Bottom > x.Top && Bottom < x.Top + x.Height)
            {
                Top = x.Top + 1 - Height;
                IsJumping = false;
                return true;
            }

            if (Top < x.Bottom && Top > x.Bottom - x.Height)
            {
                if (x.Name == "questionBlock")
                {
                    if (x.BackgroundImage == null)
                    {
                        form.Score += 1;
                        form.coinBlock.Visible = false;
                        form.questionBlock.Image = Properties.Resources.question_block_empty;
                        form.questionBlock.BackgroundImage = Properties.Resources.question_block_empty;
                        x.BackgroundImageLayout = ImageLayout.Stretch;
                        form.blockLabel.Visible = true;
                        form.blockLabel2.Visible = true;
                        form.Counter = 0;
                        form.BlockLabelMoving = true;
                        PlayCoinSound();
                    }
                }

                Top = x.Bottom;
                Force = 0;
                PlayBumpSound();
            }
            else if (Right > x.Left && Right < x.Left + Width)
            {
                Left = x.Left - 1 - Width;
                form.IsRight = false;
                PlayBumpSound();
            }
            else if (Left < x.Right && Left > x.Right - Width)
            {
                Left = x.Right + 1;
                form.IsLeft = false;
                PlayBumpSound();
            }

            return false;
        }

        /// <summary>
        /// If the player collides with a block, the player will stop moving in that direction
        /// </summary>
        /// <param name="Control">The control that the player is colliding with.</param>
        /// <param name="Form2">The form that the game is running on.</param>
        /// <returns>
        /// A boolean value.
        /// </returns>
        public bool HandleCollisions2(Control x, Form2 form)
        {
            if (!Bounds.IntersectsWith(x.Bounds)) return false;
            if (Bottom > x.Top && Bottom < x.Top + x.Height)
            {
                Top = x.Top + 1 - Height;
                IsJumping = false;

                return true;
            }

            if (Top < x.Bottom && Top > x.Bottom - x.Height)
            {
                if (x.Name == "questionBlock")
                {
                    if (x.BackgroundImage == null)
                    {
                        form.Score += 1;
                        form.coinBlock.Visible = false;
                        form.questionBlock.Image = Properties.Resources.question_block_empty;
                        form.questionBlock.BackgroundImage = Properties.Resources.question_block_empty;
                        x.BackgroundImageLayout = ImageLayout.Stretch;
                        form.blockLabel.Visible = true;
                        form.blockLabel2.Visible = true;
                        form.Counter = 0;
                        form.BlockLabelMoving = true;
                        PlayCoinSound();
                    }
                }

                Top = x.Bottom;
                Force = 0;
                PlayBumpSound();
            }
            else if (Right > x.Left && Right < x.Left + Width)
            {
                Left = x.Left - 1 - Width;
                form.IsRight = false;
                PlayBumpSound();
            }
            else if (Left < x.Right && Left > x.Right - Width)
            {
                Left = x.Right + 1;
                form.IsLeft = false;
                PlayBumpSound();
            }

            return false;
        }
        
        /// <summary>
        /// If the player is not on the ground, then the player will fall down until they hit the ground
        /// </summary>
        public void Fall()
        {
            if (!IsOnGround)
            {
                Top -= Force;
                if (Force > -9)
                {
                    Force -= 1;
                }
            }
            else
            {
                Force = 0;
            }
        }

        /// <summary>
        /// > Play the sound file "smb_bump.wav" from the Resources folder
        /// </summary>
        private void PlayBumpSound()
        {
            _bump = new AudioFileReader(@"../../Resources/smb_bump.wav");
            _bumpOut = new();
            _bumpOut.Init(_bump);
            if (_bumpOut.PlaybackState == PlaybackState.Playing) _bumpOut.Stop();
            _bump.CurrentTime = new TimeSpan(0L);
            _bumpOut.Play();
        }

        /// <summary>
        /// > Play the sound file "smb_coin.wav" from the Resources folder
        /// </summary>
        public void PlayCoinSound()
        {
            _coin = new AudioFileReader(@"../../Resources/smb_coin.wav");
            _coinOut = new();
            _coinOut.Init(_coin);
            if (_coinOut.PlaybackState == PlaybackState.Playing) _coinOut.Stop();
            _coin.CurrentTime = new TimeSpan(0L);
            _coinOut.Play();
        }

        /// <summary>
        /// > Play the sound file "smb_jump-small.wav" from the Resources folder
        /// </summary>
        private void PlayJumpSound()
        {
            _jump = new AudioFileReader(@"../../Resources/smb_jump-small.wav");
            _jumpOut = new();
            _jumpOut.Init(_jump);
            if (_jumpOut.PlaybackState == PlaybackState.Playing) _jumpOut.Stop();
            _jump.CurrentTime = new TimeSpan(0L);
            _jumpOut.Play();
        }

        /// <summary>
        /// > Play the sound file "smb_marioedie.wav" from the Resources folder
        /// </summary>
        public void PlayDieSound()
        {
            _death = new AudioFileReader(@"../../Resources/smb_mariodie.wav");
            _deathOut = new();
            _deathOut.Init(_death);
            if (_deathOut.PlaybackState == PlaybackState.Playing) _deathOut.Stop();
            _death.CurrentTime = new TimeSpan(0L);
            _deathOut.Play();
        }

        /// <summary>
        /// > Play the sound file "smb_gameover.wav" from the Resources folder
        /// </summary>
        public void PlayGameOverSound()
        {
            _gameOver = new AudioFileReader(@"../../Resources/smb_gameover.wav");
            _gameOverOut = new();
            _gameOverOut.Init(_gameOver);
            if (_gameOverOut.PlaybackState == PlaybackState.Playing) _gameOverOut.Stop();
            _gameOver.CurrentTime = new TimeSpan(0L);
            _gameOverOut.Play();
        }
        
        /// <summary>
        /// > Play the sound file "smb_stage_clear.wav" from the Resources folder
        /// </summary>
        public void PlayWinSound()
        {
            _win = new AudioFileReader(@"../../Resources/smb_stage_clear.wav");
            _winOut = new();
            _winOut.Init(_win);
            if (_winOut.PlaybackState == PlaybackState.Playing) _winOut.Stop();
            _win.CurrentTime = new TimeSpan(0L);
            _winOut.Play();
        }
    }
}