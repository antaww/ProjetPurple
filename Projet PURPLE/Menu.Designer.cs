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
        ((System.ComponentModel.ISupportInitialize)(this.menuTimer)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.menuArrow)).BeginInit();
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
        // Menu
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Control;
        this.BackgroundImage = global::Projet_PURPLE.Properties.Resources.start_screen3;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.ClientSize = new System.Drawing.Size(1087, 737);
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
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.PictureBox menuArrow;

    private System.Windows.Forms.Label startLabel;

    private System.Windows.Forms.Label helpLabel;

    private System.Timers.Timer menuTimer;

    private System.Windows.Forms.Label quitLabel;

    #endregion
}