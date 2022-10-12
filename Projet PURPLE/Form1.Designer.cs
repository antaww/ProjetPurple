namespace Projet_PURPLE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.scoreLabel = new System.Windows.Forms.Label();
            this.mario = new System.Windows.Forms.PictureBox();
            this.coin4 = new System.Windows.Forms.PictureBox();
            this.coin7 = new System.Windows.Forms.PictureBox();
            this.coin5 = new System.Windows.Forms.PictureBox();
            this.coin8 = new System.Windows.Forms.PictureBox();
            this.coin9 = new System.Windows.Forms.PictureBox();
            this.coin10 = new System.Windows.Forms.PictureBox();
            this.coin11 = new System.Windows.Forms.PictureBox();
            this.coin6 = new System.Windows.Forms.PictureBox();
            this.coin1 = new System.Windows.Forms.PictureBox();
            this.coin2 = new System.Windows.Forms.PictureBox();
            this.coin3 = new System.Windows.Forms.PictureBox();
            this.enemy2 = new System.Windows.Forms.PictureBox();
            this.plateformTimer = new System.Timers.Timer();
            this.enemy3 = new System.Windows.Forms.PictureBox();
            this.enemyPlatform1 = new System.Windows.Forms.PictureBox();
            this.pictureBox28 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.enemyPlatform2 = new System.Windows.Forms.PictureBox();
            this.enemyPlatform3 = new System.Windows.Forms.PictureBox();
            this.endLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.enemiesTimer = new System.Timers.Timer();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plateformTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPlatform1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPlatform2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPlatform3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemiesTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(680, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(100, 25);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "Score : 0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mario
            // 
            this.mario.BackColor = System.Drawing.Color.Transparent;
            this.mario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mario.Image = global::Projet_PURPLE.Properties.Resources.mario_right;
            this.mario.Location = new System.Drawing.Point(18, 616);
            this.mario.Name = "mario";
            this.mario.Size = new System.Drawing.Size(41, 70);
            this.mario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mario.TabIndex = 20;
            this.mario.TabStop = false;
            // 
            // coin4
            // 
            this.coin4.BackColor = System.Drawing.Color.Transparent;
            this.coin4.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin4.Location = new System.Drawing.Point(738, 401);
            this.coin4.Name = "coin4";
            this.coin4.Size = new System.Drawing.Size(34, 31);
            this.coin4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin4.TabIndex = 31;
            this.coin4.TabStop = false;
            this.coin4.Tag = "coin";
            // 
            // coin7
            // 
            this.coin7.BackColor = System.Drawing.Color.Transparent;
            this.coin7.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin7.Location = new System.Drawing.Point(434, 118);
            this.coin7.Name = "coin7";
            this.coin7.Size = new System.Drawing.Size(34, 31);
            this.coin7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin7.TabIndex = 32;
            this.coin7.TabStop = false;
            this.coin7.Tag = "coin";
            // 
            // coin5
            // 
            this.coin5.BackColor = System.Drawing.Color.Transparent;
            this.coin5.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin5.Location = new System.Drawing.Point(379, 332);
            this.coin5.Name = "coin5";
            this.coin5.Size = new System.Drawing.Size(34, 31);
            this.coin5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin5.TabIndex = 33;
            this.coin5.TabStop = false;
            this.coin5.Tag = "coin";
            // 
            // coin8
            // 
            this.coin8.BackColor = System.Drawing.Color.Transparent;
            this.coin8.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin8.Location = new System.Drawing.Point(25, 177);
            this.coin8.Name = "coin8";
            this.coin8.Size = new System.Drawing.Size(34, 31);
            this.coin8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin8.TabIndex = 34;
            this.coin8.TabStop = false;
            this.coin8.Tag = "coin";
            // 
            // coin9
            // 
            this.coin9.BackColor = System.Drawing.Color.Transparent;
            this.coin9.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin9.Location = new System.Drawing.Point(601, 71);
            this.coin9.Name = "coin9";
            this.coin9.Size = new System.Drawing.Size(34, 31);
            this.coin9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin9.TabIndex = 35;
            this.coin9.TabStop = false;
            this.coin9.Tag = "coin";
            // 
            // coin10
            // 
            this.coin10.BackColor = System.Drawing.Color.Transparent;
            this.coin10.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin10.Location = new System.Drawing.Point(12, 6);
            this.coin10.Name = "coin10";
            this.coin10.Size = new System.Drawing.Size(34, 31);
            this.coin10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin10.TabIndex = 36;
            this.coin10.TabStop = false;
            this.coin10.Tag = "coin";
            // 
            // coin11
            // 
            this.coin11.BackColor = System.Drawing.Color.Transparent;
            this.coin11.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin11.Location = new System.Drawing.Point(82, 50);
            this.coin11.Name = "coin11";
            this.coin11.Size = new System.Drawing.Size(34, 31);
            this.coin11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin11.TabIndex = 37;
            this.coin11.TabStop = false;
            this.coin11.Tag = "coin";
            // 
            // coin6
            // 
            this.coin6.BackColor = System.Drawing.Color.Transparent;
            this.coin6.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin6.Location = new System.Drawing.Point(689, 266);
            this.coin6.Name = "coin6";
            this.coin6.Size = new System.Drawing.Size(34, 31);
            this.coin6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin6.TabIndex = 38;
            this.coin6.TabStop = false;
            this.coin6.Tag = "coin";
            // 
            // coin1
            // 
            this.coin1.BackColor = System.Drawing.Color.Transparent;
            this.coin1.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin1.Location = new System.Drawing.Point(122, 645);
            this.coin1.Name = "coin1";
            this.coin1.Size = new System.Drawing.Size(34, 31);
            this.coin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin1.TabIndex = 39;
            this.coin1.TabStop = false;
            this.coin1.Tag = "coin";
            // 
            // coin2
            // 
            this.coin2.BackColor = System.Drawing.Color.Transparent;
            this.coin2.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin2.Location = new System.Drawing.Point(434, 536);
            this.coin2.Name = "coin2";
            this.coin2.Size = new System.Drawing.Size(34, 31);
            this.coin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin2.TabIndex = 40;
            this.coin2.TabStop = false;
            this.coin2.Tag = "coin";
            // 
            // coin3
            // 
            this.coin3.BackColor = System.Drawing.Color.Transparent;
            this.coin3.Image = global::Projet_PURPLE.Properties.Resources.coin;
            this.coin3.Location = new System.Drawing.Point(501, 536);
            this.coin3.Name = "coin3";
            this.coin3.Size = new System.Drawing.Size(34, 31);
            this.coin3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coin3.TabIndex = 41;
            this.coin3.TabStop = false;
            this.coin3.Tag = "coin";
            // 
            // enemy2
            // 
            this.enemy2.BackColor = System.Drawing.Color.Red;
            this.enemy2.Location = new System.Drawing.Point(695, 392);
            this.enemy2.Name = "enemy2";
            this.enemy2.Size = new System.Drawing.Size(28, 50);
            this.enemy2.TabIndex = 42;
            this.enemy2.TabStop = false;
            this.enemy2.Tag = "enemy";
            // 
            // plateformTimer
            // 
            this.plateformTimer.Enabled = true;
            this.plateformTimer.Interval = 10D;
            this.plateformTimer.SynchronizingObject = this;
            this.plateformTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.plateformTimer_Elapsed);
            // 
            // enemy3
            // 
            this.enemy3.BackColor = System.Drawing.Color.Red;
            this.enemy3.Location = new System.Drawing.Point(25, 43);
            this.enemy3.Name = "enemy3";
            this.enemy3.Size = new System.Drawing.Size(28, 50);
            this.enemy3.TabIndex = 44;
            this.enemy3.TabStop = false;
            this.enemy3.Tag = "enemy";
            // 
            // enemyPlatform1
            // 
            this.enemyPlatform1.BackColor = System.Drawing.Color.Transparent;
            this.enemyPlatform1.Image = global::Projet_PURPLE.Properties.Resources.platform_long;
            this.enemyPlatform1.Location = new System.Drawing.Point(39, 479);
            this.enemyPlatform1.Name = "enemyPlatform1";
            this.enemyPlatform1.Size = new System.Drawing.Size(165, 41);
            this.enemyPlatform1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemyPlatform1.TabIndex = 64;
            this.enemyPlatform1.TabStop = false;
            this.enemyPlatform1.Tag = "platform";
            // 
            // pictureBox28
            // 
            this.pictureBox28.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox28.Image = global::Projet_PURPLE.Properties.Resources.platform_long;
            this.pictureBox28.Location = new System.Drawing.Point(16, 684);
            this.pictureBox28.Name = "pictureBox28";
            this.pictureBox28.Size = new System.Drawing.Size(166, 41);
            this.pictureBox28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox28.TabIndex = 67;
            this.pictureBox28.TabStop = false;
            this.pictureBox28.Tag = "platform";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::Projet_PURPLE.Properties.Resources.platform_short;
            this.pictureBox7.Location = new System.Drawing.Point(256, 616);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(42, 41);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 71;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Tag = "platform";
            // 
            // enemyPlatform2
            // 
            this.enemyPlatform2.BackColor = System.Drawing.Color.Transparent;
            this.enemyPlatform2.Image = global::Projet_PURPLE.Properties.Resources.platform_long;
            this.enemyPlatform2.Location = new System.Drawing.Point(620, 438);
            this.enemyPlatform2.Name = "enemyPlatform2";
            this.enemyPlatform2.Size = new System.Drawing.Size(160, 41);
            this.enemyPlatform2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemyPlatform2.TabIndex = 75;
            this.enemyPlatform2.TabStop = false;
            this.enemyPlatform2.Tag = "platform";
            // 
            // enemyPlatform3
            // 
            this.enemyPlatform3.BackColor = System.Drawing.Color.Transparent;
            this.enemyPlatform3.Image = global::Projet_PURPLE.Properties.Resources.platform_long;
            this.enemyPlatform3.Location = new System.Drawing.Point(18, 87);
            this.enemyPlatform3.Name = "enemyPlatform3";
            this.enemyPlatform3.Size = new System.Drawing.Size(186, 41);
            this.enemyPlatform3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.enemyPlatform3.TabIndex = 85;
            this.enemyPlatform3.TabStop = false;
            this.enemyPlatform3.Tag = "platform";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.BackColor = System.Drawing.Color.Transparent;
            this.endLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endLabel.Location = new System.Drawing.Point(738, 673);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(60, 69);
            this.endLabel.TabIndex = 91;
            this.endLabel.Text = "x";
            this.endLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.endLabel.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Projet_PURPLE.Properties.Resources.platform_long;
            this.pictureBox2.Location = new System.Drawing.Point(411, 573);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(146, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 92;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "platform";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Projet_PURPLE.Properties.Resources.platform_long;
            this.pictureBox3.Location = new System.Drawing.Point(344, 411);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(146, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 94;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "platform";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Projet_PURPLE.Properties.Resources.platform_short;
            this.pictureBox4.Location = new System.Drawing.Point(226, 362);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(42, 41);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 95;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "platform";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Projet_PURPLE.Properties.Resources.platform_short;
            this.pictureBox5.Location = new System.Drawing.Point(558, 332);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(42, 41);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 96;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "platform";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = global::Projet_PURPLE.Properties.Resources.platform_short;
            this.pictureBox6.Location = new System.Drawing.Point(344, 285);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(42, 41);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 97;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Tag = "platform";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::Projet_PURPLE.Properties.Resources.platform_short;
            this.pictureBox8.Location = new System.Drawing.Point(322, 167);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(42, 41);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 98;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Tag = "platform";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = global::Projet_PURPLE.Properties.Resources.platform_long;
            this.pictureBox9.Location = new System.Drawing.Point(548, 108);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(146, 41);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 99;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Tag = "platform";
            // 
            // enemiesTimer
            // 
            this.enemiesTimer.Enabled = true;
            this.enemiesTimer.Interval = 30D;
            this.enemiesTimer.SynchronizingObject = this;
            this.enemiesTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.enemiesTimer_Elapsed);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::Projet_PURPLE.Properties.Resources.spike;
            this.pictureBox10.Location = new System.Drawing.Point(148, 448);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(34, 31);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 100;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Tag = "spike";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 737);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.enemyPlatform3);
            this.Controls.Add(this.enemyPlatform2);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox28);
            this.Controls.Add(this.enemyPlatform1);
            this.Controls.Add(this.enemy3);
            this.Controls.Add(this.enemy2);
            this.Controls.Add(this.coin3);
            this.Controls.Add(this.coin2);
            this.Controls.Add(this.coin1);
            this.Controls.Add(this.coin6);
            this.Controls.Add(this.coin11);
            this.Controls.Add(this.coin10);
            this.Controls.Add(this.coin9);
            this.Controls.Add(this.coin8);
            this.Controls.Add(this.coin5);
            this.Controls.Add(this.coin7);
            this.Controls.Add(this.coin4);
            this.Controls.Add(this.mario);
            this.Controls.Add(this.scoreLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "mario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.mario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plateformTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPlatform1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPlatform2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPlatform3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemiesTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox pictureBox10;

        private System.Timers.Timer enemiesTimer;

        private System.Windows.Forms.PictureBox pictureBox9;

        private System.Windows.Forms.PictureBox pictureBox8;

        private System.Windows.Forms.PictureBox pictureBox6;

        private System.Windows.Forms.PictureBox pictureBox5;

        private System.Windows.Forms.PictureBox pictureBox4;

        private System.Windows.Forms.PictureBox pictureBox3;

        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.Label endLabel;

        private System.Windows.Forms.PictureBox pictureBox24;

        private System.Windows.Forms.PictureBox enemyPlatform3;

        private System.Windows.Forms.PictureBox enemyPlatform2;

        private System.Windows.Forms.PictureBox pictureBox7;

        private System.Windows.Forms.PictureBox pictureBox28;

        private System.Windows.Forms.PictureBox enemyPlatform1;

        private System.Windows.Forms.PictureBox enemy3;

        private System.Timers.Timer plateformTimer;

        private System.Windows.Forms.PictureBox enemy2;

        private System.Windows.Forms.PictureBox coin3;

        private System.Windows.Forms.PictureBox coin2;

        private System.Windows.Forms.PictureBox coin1;

        private System.Windows.Forms.PictureBox coin6;

        private System.Windows.Forms.PictureBox coin11;

        private System.Windows.Forms.PictureBox coin10;

        private System.Windows.Forms.PictureBox coin9;

        private System.Windows.Forms.PictureBox coin8;

        private System.Windows.Forms.PictureBox coin5;

        private System.Windows.Forms.PictureBox coin7;

        private System.Windows.Forms.PictureBox coin4;

        private System.Windows.Forms.PictureBox mario;

        private System.Windows.Forms.Label scoreLabel;

        #endregion
    }
}