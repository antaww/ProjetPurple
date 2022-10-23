using System.ComponentModel;

namespace Projet_PURPLE;

partial class Form2
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
        this.mario = new Projet_PURPLE.Mario();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.pictureBox3 = new System.Windows.Forms.PictureBox();
        this.beginPlatform = new System.Windows.Forms.PictureBox();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.pictureBox4 = new System.Windows.Forms.PictureBox();
        this.pictureBox5 = new System.Windows.Forms.PictureBox();
        this.pictureBox6 = new System.Windows.Forms.PictureBox();
        this.pictureBox7 = new System.Windows.Forms.PictureBox();
        this.pictureBox8 = new System.Windows.Forms.PictureBox();
        this.coin2 = new System.Windows.Forms.PictureBox();
        this.pictureBox9 = new System.Windows.Forms.PictureBox();
        this.pictureBox10 = new System.Windows.Forms.PictureBox();
        this.pictureBox11 = new System.Windows.Forms.PictureBox();
        this.pictureBox12 = new System.Windows.Forms.PictureBox();
        this.pictureBox13 = new System.Windows.Forms.PictureBox();
        this.pictureBox14 = new System.Windows.Forms.PictureBox();
        this.pictureBox15 = new System.Windows.Forms.PictureBox();
        this.pauseQuitLabel = new System.Windows.Forms.Label();
        this.pauseResumeLabel = new System.Windows.Forms.Label();
        this.scoreCoin = new System.Windows.Forms.PictureBox();
        this.scoreLabel = new System.Windows.Forms.Label();
        this.endLabel = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.mario)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.beginPlatform)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.coin2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.scoreCoin)).BeginInit();
        this.SuspendLayout();
        // 
        // mario
        // 
        this.mario.BackColor = System.Drawing.Color.Transparent;
        this.mario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.mario.Image = global::Projet_PURPLE.Properties.Resources.mario_right;
        this.mario.Location = new System.Drawing.Point(51, 409);
        this.mario.Name = "mario";
        this.mario.Size = new System.Drawing.Size(41, 70);
        this.mario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.mario.TabIndex = 21;
        this.mario.TabStop = false;
        // 
        // pictureBox2
        // 
        this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox2.Image = global::Projet_PURPLE.Properties.Resources.lava_bottom;
        this.pictureBox2.Location = new System.Drawing.Point(-3, 631);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(591, 151);
        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox2.TabIndex = 66;
        this.pictureBox2.TabStop = false;
        this.pictureBox2.Tag = "lava";
        // 
        // pictureBox3
        // 
        this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox3.Image = global::Projet_PURPLE.Properties.Resources.lava_bottom;
        this.pictureBox3.Location = new System.Drawing.Point(578, 631);
        this.pictureBox3.Name = "pictureBox3";
        this.pictureBox3.Size = new System.Drawing.Size(515, 151);
        this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox3.TabIndex = 67;
        this.pictureBox3.TabStop = false;
        this.pictureBox3.Tag = "lava";
        // 
        // beginPlatform
        // 
        this.beginPlatform.BackColor = System.Drawing.Color.Transparent;
        this.beginPlatform.Image = global::Projet_PURPLE.Properties.Resources.lava_high_column;
        this.beginPlatform.Location = new System.Drawing.Point(51, 475);
        this.beginPlatform.Name = "beginPlatform";
        this.beginPlatform.Size = new System.Drawing.Size(150, 250);
        this.beginPlatform.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.beginPlatform.TabIndex = 68;
        this.beginPlatform.TabStop = false;
        this.beginPlatform.Tag = "platform";
        // 
        // pictureBox1
        // 
        this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox1.Image = global::Projet_PURPLE.Properties.Resources.bottom_brick2;
        this.pictureBox1.Location = new System.Drawing.Point(51, 723);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(150, 14);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox1.TabIndex = 69;
        this.pictureBox1.TabStop = false;
        this.pictureBox1.Tag = "platform";
        // 
        // pictureBox4
        // 
        this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox4.Image = global::Projet_PURPLE.Properties.Resources.lava_platform_short;
        this.pictureBox4.Location = new System.Drawing.Point(346, 434);
        this.pictureBox4.Name = "pictureBox4";
        this.pictureBox4.Size = new System.Drawing.Size(203, 54);
        this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox4.TabIndex = 70;
        this.pictureBox4.TabStop = false;
        this.pictureBox4.Tag = "platform";
        // 
        // pictureBox5
        // 
        this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox5.Image = global::Projet_PURPLE.Properties.Resources.lava_platform_short;
        this.pictureBox5.Location = new System.Drawing.Point(385, 571);
        this.pictureBox5.Name = "pictureBox5";
        this.pictureBox5.Size = new System.Drawing.Size(203, 54);
        this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox5.TabIndex = 71;
        this.pictureBox5.TabStop = false;
        this.pictureBox5.Tag = "platform";
        // 
        // pictureBox6
        // 
        this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox6.Image = global::Projet_PURPLE.Properties.Resources.lava_platform_short;
        this.pictureBox6.Location = new System.Drawing.Point(732, 380);
        this.pictureBox6.Name = "pictureBox6";
        this.pictureBox6.Size = new System.Drawing.Size(203, 54);
        this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox6.TabIndex = 72;
        this.pictureBox6.TabStop = false;
        this.pictureBox6.Tag = "platform";
        // 
        // pictureBox7
        // 
        this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox7.Image = global::Projet_PURPLE.Properties.Resources.lava_platform_short;
        this.pictureBox7.Location = new System.Drawing.Point(732, 202);
        this.pictureBox7.Name = "pictureBox7";
        this.pictureBox7.Size = new System.Drawing.Size(203, 54);
        this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox7.TabIndex = 73;
        this.pictureBox7.TabStop = false;
        this.pictureBox7.Tag = "platform";
        // 
        // pictureBox8
        // 
        this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox8.Image = global::Projet_PURPLE.Properties.Resources.lava_platform_short;
        this.pictureBox8.Location = new System.Drawing.Point(282, 137);
        this.pictureBox8.Name = "pictureBox8";
        this.pictureBox8.Size = new System.Drawing.Size(203, 54);
        this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox8.TabIndex = 74;
        this.pictureBox8.TabStop = false;
        this.pictureBox8.Tag = "platform";
        // 
        // coin2
        // 
        this.coin2.BackColor = System.Drawing.Color.Transparent;
        this.coin2.Image = global::Projet_PURPLE.Properties.Resources.coin3;
        this.coin2.Location = new System.Drawing.Point(143, 438);
        this.coin2.Name = "coin2";
        this.coin2.Size = new System.Drawing.Size(34, 31);
        this.coin2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.coin2.TabIndex = 75;
        this.coin2.TabStop = false;
        this.coin2.Tag = "coin";
        // 
        // pictureBox9
        // 
        this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox9.Image = global::Projet_PURPLE.Properties.Resources.coin3;
        this.pictureBox9.Location = new System.Drawing.Point(816, 165);
        this.pictureBox9.Name = "pictureBox9";
        this.pictureBox9.Size = new System.Drawing.Size(34, 31);
        this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox9.TabIndex = 76;
        this.pictureBox9.TabStop = false;
        this.pictureBox9.Tag = "coin";
        // 
        // pictureBox10
        // 
        this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox10.Image = global::Projet_PURPLE.Properties.Resources.coin3;
        this.pictureBox10.Location = new System.Drawing.Point(471, 534);
        this.pictureBox10.Name = "pictureBox10";
        this.pictureBox10.Size = new System.Drawing.Size(34, 31);
        this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox10.TabIndex = 77;
        this.pictureBox10.TabStop = false;
        this.pictureBox10.Tag = "coin";
        // 
        // pictureBox11
        // 
        this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox11.Image = global::Projet_PURPLE.Properties.Resources.coin3;
        this.pictureBox11.Location = new System.Drawing.Point(1028, 21);
        this.pictureBox11.Name = "pictureBox11";
        this.pictureBox11.Size = new System.Drawing.Size(34, 31);
        this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox11.TabIndex = 78;
        this.pictureBox11.TabStop = false;
        this.pictureBox11.Tag = "coin";
        // 
        // pictureBox12
        // 
        this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox12.Image = global::Projet_PURPLE.Properties.Resources.coin3;
        this.pictureBox12.Location = new System.Drawing.Point(282, 235);
        this.pictureBox12.Name = "pictureBox12";
        this.pictureBox12.Size = new System.Drawing.Size(34, 31);
        this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox12.TabIndex = 79;
        this.pictureBox12.TabStop = false;
        this.pictureBox12.Tag = "coin";
        // 
        // pictureBox13
        // 
        this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox13.Image = global::Projet_PURPLE.Properties.Resources.coin3;
        this.pictureBox13.Location = new System.Drawing.Point(367, 100);
        this.pictureBox13.Name = "pictureBox13";
        this.pictureBox13.Size = new System.Drawing.Size(34, 31);
        this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox13.TabIndex = 80;
        this.pictureBox13.TabStop = false;
        this.pictureBox13.Tag = "coin";
        // 
        // pictureBox14
        // 
        this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox14.Image = global::Projet_PURPLE.Properties.Resources.lava_spike;
        this.pictureBox14.Location = new System.Drawing.Point(332, 190);
        this.pictureBox14.Name = "pictureBox14";
        this.pictureBox14.Size = new System.Drawing.Size(50, 25);
        this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox14.TabIndex = 101;
        this.pictureBox14.TabStop = false;
        this.pictureBox14.Tag = "spike";
        // 
        // pictureBox15
        // 
        this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox15.Image = global::Projet_PURPLE.Properties.Resources.lava_spike;
        this.pictureBox15.Location = new System.Drawing.Point(418, 488);
        this.pictureBox15.Name = "pictureBox15";
        this.pictureBox15.Size = new System.Drawing.Size(50, 25);
        this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox15.TabIndex = 102;
        this.pictureBox15.TabStop = false;
        this.pictureBox15.Tag = "spike";
        // 
        // pauseQuitLabel
        // 
        this.pauseQuitLabel.AutoSize = true;
        this.pauseQuitLabel.BackColor = System.Drawing.Color.Black;
        this.pauseQuitLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.pauseQuitLabel.ForeColor = System.Drawing.Color.White;
        this.pauseQuitLabel.Location = new System.Drawing.Point(516, 374);
        this.pauseQuitLabel.Name = "pauseQuitLabel";
        this.pauseQuitLabel.Size = new System.Drawing.Size(31, 17);
        this.pauseQuitLabel.TabIndex = 117;
        this.pauseQuitLabel.Text = "quit";
        // 
        // pauseResumeLabel
        // 
        this.pauseResumeLabel.AutoSize = true;
        this.pauseResumeLabel.BackColor = System.Drawing.Color.Black;
        this.pauseResumeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.pauseResumeLabel.ForeColor = System.Drawing.Color.White;
        this.pauseResumeLabel.Location = new System.Drawing.Point(516, 345);
        this.pauseResumeLabel.Name = "pauseResumeLabel";
        this.pauseResumeLabel.Size = new System.Drawing.Size(55, 17);
        this.pauseResumeLabel.TabIndex = 116;
        this.pauseResumeLabel.Text = "resume";
        // 
        // scoreCoin
        // 
        this.scoreCoin.BackColor = System.Drawing.Color.Transparent;
        this.scoreCoin.Image = global::Projet_PURPLE.Properties.Resources.scoreCoin;
        this.scoreCoin.Location = new System.Drawing.Point(428, 3);
        this.scoreCoin.Name = "scoreCoin";
        this.scoreCoin.Size = new System.Drawing.Size(34, 31);
        this.scoreCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.scoreCoin.TabIndex = 119;
        this.scoreCoin.TabStop = false;
        this.scoreCoin.Tag = "";
        // 
        // scoreLabel
        // 
        this.scoreLabel.AutoSize = true;
        this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
        this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.scoreLabel.ForeColor = System.Drawing.Color.White;
        this.scoreLabel.Location = new System.Drawing.Point(458, 9);
        this.scoreLabel.Name = "scoreLabel";
        this.scoreLabel.Size = new System.Drawing.Size(53, 25);
        this.scoreLabel.TabIndex = 118;
        this.scoreLabel.Text = "x 00";
        this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // endLabel
        // 
        this.endLabel.AutoSize = true;
        this.endLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.endLabel.ForeColor = System.Drawing.Color.White;
        this.endLabel.Location = new System.Drawing.Point(634, 651);
        this.endLabel.Name = "endLabel";
        this.endLabel.Padding = new System.Windows.Forms.Padding(4);
        this.endLabel.Size = new System.Drawing.Size(68, 77);
        this.endLabel.TabIndex = 120;
        this.endLabel.Text = "x";
        this.endLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.endLabel.Visible = false;
        // 
        // Form2
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.BackgroundImage = global::Projet_PURPLE.Properties.Resources.lava_background;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.ClientSize = new System.Drawing.Size(1087, 737);
        this.Controls.Add(this.endLabel);
        this.Controls.Add(this.scoreCoin);
        this.Controls.Add(this.scoreLabel);
        this.Controls.Add(this.pauseQuitLabel);
        this.Controls.Add(this.pauseResumeLabel);
        this.Controls.Add(this.pictureBox15);
        this.Controls.Add(this.pictureBox14);
        this.Controls.Add(this.pictureBox13);
        this.Controls.Add(this.pictureBox12);
        this.Controls.Add(this.pictureBox11);
        this.Controls.Add(this.pictureBox10);
        this.Controls.Add(this.pictureBox9);
        this.Controls.Add(this.coin2);
        this.Controls.Add(this.pictureBox8);
        this.Controls.Add(this.pictureBox7);
        this.Controls.Add(this.pictureBox6);
        this.Controls.Add(this.pictureBox5);
        this.Controls.Add(this.pictureBox4);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.beginPlatform);
        this.Controls.Add(this.pictureBox3);
        this.Controls.Add(this.pictureBox2);
        this.Controls.Add(this.mario);
        this.DoubleBuffered = true;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "Form2";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        ((System.ComponentModel.ISupportInitialize)(this.mario)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.beginPlatform)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.coin2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.scoreCoin)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label endLabel;

    private System.Windows.Forms.PictureBox scoreCoin;
    private System.Windows.Forms.Label scoreLabel;

    private System.Windows.Forms.Label pauseQuitLabel;
    private System.Windows.Forms.Label pauseResumeLabel;

    private System.Windows.Forms.PictureBox pictureBox15;

    private System.Windows.Forms.PictureBox pictureBox14;

    private System.Windows.Forms.PictureBox pictureBox13;

    private System.Windows.Forms.PictureBox pictureBox12;

    private System.Windows.Forms.PictureBox pictureBox11;

    private System.Windows.Forms.PictureBox pictureBox10;

    private System.Windows.Forms.PictureBox pictureBox9;

    private System.Windows.Forms.PictureBox coin2;

    private System.Windows.Forms.PictureBox pictureBox8;

    private System.Windows.Forms.PictureBox pictureBox7;

    private System.Windows.Forms.PictureBox pictureBox6;

    private System.Windows.Forms.PictureBox pictureBox5;

    private System.Windows.Forms.PictureBox pictureBox4;

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.PictureBox beginPlatform;

    private System.Windows.Forms.PictureBox pictureBox3;

    private System.Windows.Forms.PictureBox pictureBox2;

    private Projet_PURPLE.Mario mario;

    #endregion
}