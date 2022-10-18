using System.Windows.Forms;

namespace Projet_PURPLE
{
    public class Mario : PictureBox
    {
        public bool IsOnGround, IsJumping;
        public int Force;
        private const int Gravity = 11;
        public const int MarioSpeed = 5;

        public void Jump()
        {
            if (IsJumping || !IsOnGround) return;
            IsJumping = true;
            IsOnGround = false;
            Force = Gravity;
        }
        
        public void SetLeftAnimation()
        {
            Image = Properties.Resources.mario_left;
        }
        
        public void SetRightAnimation()
        {
            Image = Properties.Resources.mario_right;
        }

        public bool HandleCollisions(Control x, Form1 form)
        {
            if (!Bounds.IntersectsWith(x.Bounds)) return false;
            if (Bottom > x.Top && Bottom < x.Top + 10)
            {
                Top = x.Top + 1 - Height;
                IsJumping = false;

                return true;
            }
                
            if (Top < x.Bottom && Top > x.Bottom - 10)
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
                        form.Counter = 0;
                        form.BlockLabelMoving = true;
                    }
                }

                Top = x.Bottom + 1;
                Force = 0;
            }
            else if (Right > x.Left && Right < x.Left + 10)
            {
                Left = x.Left - 1 - Width;
                form.IsRight = false;
            }
            else if (Left < x.Right && Left > x.Right - 10)
            {
                Left = x.Right + 1;
                form.IsLeft = false;
            }

            return false;
        }
        
        public void Fall(int index)
        {
            if (!IsOnGround)
            {
                Top -= Force;
                if (index % 2 == 0 && Force > -9)
                {
                    Force -= 1;
                }
            }
            else
            {
                Force = 0;
            }
        }
    }
}
