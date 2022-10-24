using System;
using System.Drawing;
using System.Drawing.Text;
using System.Media;
using System.Timers;
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
        menuArrow.Location = new Point(startLabel.Location.X - menuArrow.Width,
            startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2);
        _selectedLabel = "startLabel";
    }

    Point _startLabelLocation;
    Point _quitLabelLocation;
    Point _helpLabelLocation;

    private string _selectedLabel;

    //
    //TIMER
    //

    private void menuTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        foreach (Control control in Controls)
        {
            control.ForeColor = Equals(control, Controls[_selectedLabel])
                ? ColorTranslator.FromHtml("#eec905")
                : Color.White;
        }
    }

    //
    //KEYBOARD EVENTS
    //

    private void Menu_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            Application.Exit();
        }

        if (e.KeyCode == Keys.Enter && _selectedLabel != null)
        {
            switch (_selectedLabel)
            {
                case "startLabel":
                    StartGame();
                    break;
                case "quitLabel":
                    LeaveApp();
                    break;
                case "helpLabel":
                    HelpDisplay();
                    break;
            }
        }

        //TODO: menu music + game music

        if (e.KeyCode == Keys.Down)
        {
            if (menuArrow.Location.Y == startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(helpLabel.Location.X - menuArrow.Width,
                    helpLabel.Location.Y + helpLabel.Height / 2 - menuArrow.Height / 2);
                _selectedLabel = "helpLabel";
            }
            else if (menuArrow.Location.Y == helpLabel.Location.Y + helpLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(quitLabel.Location.X - menuArrow.Width,
                    quitLabel.Location.Y + quitLabel.Height / 2 - menuArrow.Height / 2);
                _selectedLabel = "quitLabel";
            }
            else if (menuArrow.Location.Y == quitLabel.Location.Y + quitLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(startLabel.Location.X - menuArrow.Width,
                    startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2);
                _selectedLabel = "startLabel";
            }

            PlaySwitchSound();
        }

        if (e.KeyCode == Keys.Up)
        {
            if (menuArrow.Location.Y == startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(quitLabel.Location.X - menuArrow.Width,
                    quitLabel.Location.Y + quitLabel.Height / 2 - menuArrow.Height / 2);
                _selectedLabel = "quitLabel";
            }
            else if (menuArrow.Location.Y == helpLabel.Location.Y + helpLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(startLabel.Location.X - menuArrow.Width,
                    startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2);
                _selectedLabel = "startLabel";
            }
            else if (menuArrow.Location.Y == quitLabel.Location.Y + quitLabel.Height / 2 - menuArrow.Height / 2)
            {
                menuArrow.Location = new Point(helpLabel.Location.X - menuArrow.Width,
                    helpLabel.Location.Y + helpLabel.Height / 2 - menuArrow.Height / 2);
                _selectedLabel = "helpLabel";
            }

            PlaySwitchSound();
        }
    }

    //
    //CLICK EVENTS
    //

    private void quitLabel_Click(object sender, EventArgs e)
    {
        LeaveApp();
    }

    private void startLabel_Click(object sender, EventArgs e)
    {
        StartGame();
    }

    private void helpLabel_Click(object sender, EventArgs e)
    {
        HelpDisplay();
    }

    //
    //METHODS
    //

    private static void HelpDisplay()
    {
        MessageBox.Show("help btn");
    }

    private static void LeaveApp()
    {
        Application.Exit();
    }

    private void StartGame()
    {
        // var form1 = new Form1();
        // form1.Show();
        var form2 = new Form2();
        form2.Show();
        Hide();
    }

    private static void PlaySwitchSound()
    {
        var player = new SoundPlayer(@"../../Resources/smb_fireball.wav");
        player.Play();
    }

    //
    //HOVER EVENTS
    //

    private void startLabel_MouseHover(object sender, EventArgs e)
    {
        menuArrow.Location = new Point(startLabel.Location.X - menuArrow.Width,
            startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2);
        _selectedLabel = "startLabel";
    }

    private void helpLabel_MouseHover(object sender, EventArgs e)
    {
        menuArrow.Location = new Point(helpLabel.Location.X - menuArrow.Width,
            helpLabel.Location.Y + helpLabel.Height / 2 - menuArrow.Height / 2);
        _selectedLabel = "helpLabel";
    }

    private void quitLabel_MouseHover(object sender, EventArgs e)
    {
        menuArrow.Location = new Point(quitLabel.Location.X - menuArrow.Width,
            quitLabel.Location.Y + quitLabel.Height / 2 - menuArrow.Height / 2);
        _selectedLabel = "quitLabel";
    }
}