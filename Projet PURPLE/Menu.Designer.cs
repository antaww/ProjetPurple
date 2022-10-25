using System.ComponentModel;

namespace Projet_PURPLE;

partial class Menu
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
        this.quitLabel = new System.Windows.Forms.Label();
        this.menuTimer = new System.Timers.Timer();
        this.helpLabel = new System.Windows.Forms.Label();
        this.startLabel = new System.Windows.Forms.Label();
        this.menuArrow = new System.Windows.Forms.PictureBox();
        this.arrowUp = new System.Windows.Forms.PictureBox();
        this.arrowLeft = new System.Windows.Forms.PictureBox();
        this.arrowRight = new System.Windows.Forms.PictureBox();
        this.arrowDown = new System.Windows.Forms.PictureBox();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.musicTimer = new System.Timers.Timer();
        ((System.ComponentModel.ISupportInitialize)(this.menuTimer)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.menuArrow)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.arrowUp)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.arrowDown)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.musicTimer)).BeginInit();
        this.SuspendLayout();
        // 
        // quitLabel
        // 
        this.quitLabel.AutoSize = true;
        this.quitLabel.BackColor = System.Drawing.Color.Transparent;
        this.quitLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.quitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.quitLabel.ForeColor = System.Drawing.Color.White;
        this.quitLabel.Location = new System.Drawing.Point(712, 407);
        this.quitLabel.Margin = new System.Windows.Forms.Padding(0);
        this.quitLabel.Name = "quitLabel";
        this.quitLabel.Size = new System.Drawing.Size(67, 45);
        this.quitLabel.TabIndex = 0;
        this.quitLabel.Text = "quit";
        this.quitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.quitLabel.UseCompatibleTextRendering = true;
        this.quitLabel.Click += new System.EventHandler(this.quitLabel_Click);
        this.quitLabel.MouseHover += new System.EventHandler(this.quitLabel_MouseHover);
        // 
        // menuTimer
        // 
        this.menuTimer.Enabled = true;
        this.menuTimer.Interval = 20D;
        this.menuTimer.SynchronizingObject = this;
        this.menuTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.menuTimer_Elapsed);
        // 
        // helpLabel
        // 
        this.helpLabel.AutoSize = true;
        this.helpLabel.BackColor = System.Drawing.Color.Transparent;
        this.helpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.helpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.helpLabel.ForeColor = System.Drawing.Color.White;
        this.helpLabel.Location = new System.Drawing.Point(712, 340);
        this.helpLabel.Margin = new System.Windows.Forms.Padding(0);
        this.helpLabel.Name = "helpLabel";
        this.helpLabel.Size = new System.Drawing.Size(77, 45);
        this.helpLabel.TabIndex = 1;
        this.helpLabel.Text = "help";
        this.helpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.helpLabel.UseCompatibleTextRendering = true;
        this.helpLabel.Click += new System.EventHandler(this.helpLabel_Click);
        this.helpLabel.MouseHover += new System.EventHandler(this.helpLabel_MouseHover);
        // 
        // startLabel
        // 
        this.startLabel.AutoSize = true;
        this.startLabel.BackColor = System.Drawing.Color.Transparent;
        this.startLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.startLabel.ForeColor = System.Drawing.Color.White;
        this.startLabel.Location = new System.Drawing.Point(712, 277);
        this.startLabel.Margin = new System.Windows.Forms.Padding(0);
        this.startLabel.Name = "startLabel";
        this.startLabel.Size = new System.Drawing.Size(173, 45);
        this.startLabel.TabIndex = 2;
        this.startLabel.Text = "start game";
        this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.startLabel.UseCompatibleTextRendering = true;
        this.startLabel.Click += new System.EventHandler(this.startLabel_Click);
        this.startLabel.MouseHover += new System.EventHandler(this.startLabel_MouseHover);
        // 
        // menuArrow
        // 
        this.menuArrow.BackColor = System.Drawing.Color.Transparent;
        this.menuArrow.Image = global::Projet_PURPLE.Properties.Resources.arrow;
        this.menuArrow.Location = new System.Drawing.Point(675, 285);
        this.menuArrow.Name = "menuArrow";
        this.menuArrow.Size = new System.Drawing.Size(30, 25);
        this.menuArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.menuArrow.TabIndex = 3;
        this.menuArrow.TabStop = false;
        // 
        // arrowUp
        // 
        this.arrowUp.BackColor = System.Drawing.Color.Transparent;
        this.arrowUp.Image = global::Projet_PURPLE.Properties.Resources.keyboard_arrow_up2;
        this.arrowUp.Location = new System.Drawing.Point(134, 47);
        this.arrowUp.Name = "arrowUp";
        this.arrowUp.Size = new System.Drawing.Size(61, 55);
        this.arrowUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.arrowUp.TabIndex = 105;
        this.arrowUp.TabStop = false;
        this.arrowUp.Tag = "helpKey";
        this.arrowUp.Visible = false;
        // 
        // arrowLeft
        // 
        this.arrowLeft.BackColor = System.Drawing.Color.Transparent;
        this.arrowLeft.Image = global::Projet_PURPLE.Properties.Resources.keyboard_arrow_left;
        this.arrowLeft.Location = new System.Drawing.Point(72, 104);
        this.arrowLeft.Name = "arrowLeft";
        this.arrowLeft.Size = new System.Drawing.Size(61, 55);
        this.arrowLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.arrowLeft.TabIndex = 106;
        this.arrowLeft.TabStop = false;
        this.arrowLeft.Tag = "helpKey";
        this.arrowLeft.Visible = false;
        // 
        // arrowRight
        // 
        this.arrowRight.BackColor = System.Drawing.Color.Transparent;
        this.arrowRight.Image = global::Projet_PURPLE.Properties.Resources.keyboard_arrow_right;
        this.arrowRight.Location = new System.Drawing.Point(196, 104);
        this.arrowRight.Name = "arrowRight";
        this.arrowRight.Size = new System.Drawing.Size(61, 55);
        this.arrowRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.arrowRight.TabIndex = 107;
        this.arrowRight.TabStop = false;
        this.arrowRight.Tag = "helpKey";
        this.arrowRight.Visible = false;
        // 
        // arrowDown
        // 
        this.arrowDown.BackColor = System.Drawing.Color.Transparent;
        this.arrowDown.Image = global::Projet_PURPLE.Properties.Resources.keyboard_arrow_down;
        this.arrowDown.Location = new System.Drawing.Point(134, 104);
        this.arrowDown.Name = "arrowDown";
        this.arrowDown.Size = new System.Drawing.Size(61, 55);
        this.arrowDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.arrowDown.TabIndex = 108;
        this.arrowDown.TabStop = false;
        this.arrowDown.Tag = "helpKey";
        this.arrowDown.Visible = false;
        // 
        // pictureBox1
        // 
        this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
        this.pictureBox1.Location = new System.Drawing.Point(310, 104);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(61, 55);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pictureBox1.TabIndex = 109;
        this.pictureBox1.TabStop = false;
        this.pictureBox1.Tag = "helpKey";
        this.pictureBox1.Visible = false;
        // 
        // musicTimer
        // 
        this.musicTimer.Enabled = true;
        this.musicTimer.SynchronizingObject = this;
        this.musicTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.musicTimer_Elapsed);
        // 
        // Menu
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.BackgroundImage = global::Projet_PURPLE.Properties.Resources.start_screen3;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.ClientSize = new System.Drawing.Size(1087, 737);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.arrowDown);
        this.Controls.Add(this.arrowRight);
        this.Controls.Add(this.arrowLeft);
        this.Controls.Add(this.arrowUp);
        this.Controls.Add(this.menuArrow);
        this.Controls.Add(this.startLabel);
        this.Controls.Add(this.helpLabel);
        this.Controls.Add(this.quitLabel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Location = new System.Drawing.Point(15, 15);
        this.Name = "Menu";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyDown);
        ((System.ComponentModel.ISupportInitialize)(this.menuTimer)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.menuArrow)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.arrowUp)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.arrowRight)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.arrowDown)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.musicTimer)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Timers.Timer musicTimer;

    private System.Windows.Forms.PictureBox pictureBox1;

    private System.Windows.Forms.PictureBox arrowDown;

    private System.Windows.Forms.PictureBox arrowRight;

    private System.Windows.Forms.PictureBox arrowLeft;

    private System.Windows.Forms.PictureBox arrowUp;

    private System.Windows.Forms.PictureBox menuArrow;

    private System.Windows.Forms.Label startLabel;

    private System.Windows.Forms.Label helpLabel;

    private System.Timers.Timer menuTimer;

    private System.Windows.Forms.Label quitLabel;

    #endregion
}