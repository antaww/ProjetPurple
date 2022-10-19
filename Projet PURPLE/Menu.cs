using System;
using System.Drawing;
using System.Drawing.Text;
using System.Media;
using System.Windows.Forms;

namespace Projet_PURPLE;

public partial class Menu : Form
{
    public Menu()
    {
        InitializeComponent();
        var pfc = new PrivateFontCollection();
        pfc.AddFontFile("../../Resources/Super Mario Bros. 2.ttf");
        quitLabel.Font = new Font(pfc.Families[0], 18);
        startLabel.Font = new Font(pfc.Families[0], 18);
        helpLabel.Font = new Font(pfc.Families[0], 18);
        _startLabelLocation = startLabel.Location;
        _quitLabelLocation = quitLabel.Location;
        _helpLabelLocation = helpLabel.Location;
        menuArrow.Location = new Point(startLabel.Location.X - menuArrow.Width, startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2);
    }
    
    Point _startLabelLocation;
    Point _quitLabelLocation;
    Point _helpLabelLocation;
    
    private void Menu_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            Application.Exit();
        }
        
        //TODO: if enter, call the function corresponding to the selected label (var selectedLabel)
        //TODO: up arrow, move the arrow up
        //TODO: highlight the selected label (arrow + hover)
        //TODO: menu music + game music
        


        if (e.KeyCode == Keys.Down)
        {
            if (menuArrow.Location.Y == startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(helpLabel.Location.X - menuArrow.Width, helpLabel.Location.Y + helpLabel.Height / 2 - menuArrow.Height / 2);
            }
            else if (menuArrow.Location.Y == helpLabel.Location.Y + helpLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(quitLabel.Location.X - menuArrow.Width, quitLabel.Location.Y + quitLabel.Height / 2 - menuArrow.Height / 2);
            }
            else if (menuArrow.Location.Y == quitLabel.Location.Y + quitLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(startLabel.Location.X - menuArrow.Width, startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2);
            }
            PlaySwitchSound();
        }
        
        
        
        
    }

    private void quitLabel_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void startLabel_Click(object sender, EventArgs e)
    {
        var form1 = new Form1();
        form1.Show();
        Hide();
    }

    private void helpLabel_Click(object sender, EventArgs e)
    {
        MessageBox.Show("help btn");
    }
    
    private static void PlaySwitchSound()
    {
        var player = new SoundPlayer(@"../../Resources/smb_fireball.wav");
        player.Play();
    }
}