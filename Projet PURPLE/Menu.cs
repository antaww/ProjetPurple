using System;
using System.Drawing;
using System.Drawing.Text;
using System.Timers;
using System.Windows.Forms;
using NAudio.Wave;

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
        explicationLabel.Font = new Font(pfc.Families[0], 10);
        _startLabelLocation = startLabel.Location;
        _quitLabelLocation = quitLabel.Location;
        _helpLabelLocation = helpLabel.Location;
        menuArrow.Location = new Point(startLabel.Location.X - menuArrow.Width,
            startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2);
        _selectedLabel = "startLabel";
        
        menuTimer.Enabled = true;
        musicTimer.Enabled = true;

        _fireball = new AudioFileReader(@"../../Resources/smb_fireball.wav");
        _fireballOut = new();
        _fireballOut.Init(_fireball);
        _mainTheme = new AudioFileReader(@"../../Resources/Menu_Theme.wav");
        _mainThemeOut = new();
        _mainThemeOut.Init(_mainTheme);
        
        musicTimer.Interval = (int)_mainTheme.TotalTime.TotalMilliseconds;
        PlayMenuTheme();
    }
    
    private WaveStream _fireball;
    private WaveOut _fireballOut;
    private WaveStream _mainTheme;
    private WaveOut _mainThemeOut;

    Point _startLabelLocation;
    Point _quitLabelLocation;
    Point _helpLabelLocation;

    private string _selectedLabel;
    
    private bool _isHelpSelected;

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
    
    private void musicTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        _mainThemeOut.Stop();
        PlayMenuTheme();
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

        if (_isHelpSelected && e.KeyCode == Keys.Left)
        {
            _isHelpSelected = false;
            ShowMenu();
            HideHelpKeys();
        }

        if (_isHelpSelected) return;
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
    
    private void arrowLeft_Click(object sender, EventArgs e)
    {
        _isHelpSelected = false;
        ShowMenu();
        HideHelpKeys();
    }

    //
    //METHODS
    //

    private void HelpDisplay()
    {
        _isHelpSelected = true;
        HideMenu();
        ShowHelpKeys();
    }

    private void ShowHelpKeys()
    {
        explicationLabel.Visible = true;
        foreach (Control control in Controls)
        {
            if (control is PictureBox && !Equals(control, menuArrow))
            {
                control.Visible = true;
            }
        }
    }
    
    private void HideHelpKeys()
    {
        explicationLabel.Visible = false;
        foreach (Control control in Controls)
        {
            if (control is PictureBox && !Equals(control, menuArrow))
            {
                control.Visible = false;
            }
        }
    }

    private void HideMenu()
    {
        startLabel.Visible = false;
        quitLabel.Visible = false;
        helpLabel.Visible = false;
        menuArrow.Visible = false;
    }
    
    private void ShowMenu()
    {
        startLabel.Visible = true;
        quitLabel.Visible = true;
        helpLabel.Visible = true;
        menuArrow.Visible = true;
    }

    private static void LeaveApp()
    {
        Application.Exit();
    }

    private void StartGame()
    {
        musicTimer.Stop();
        _mainThemeOut.Stop();
        var form1 = new Form1();
        form1.Show();
        // var form2 = new Form2();
        // form2.Show();
        Hide();
    }

    private void PlaySwitchSound()
    {
        if (_fireballOut.PlaybackState == PlaybackState.Playing) _fireballOut.Stop();
        _fireball.CurrentTime = new TimeSpan(0L);
        _fireballOut.Play();
    }

    private void PlayMenuTheme()
    {
        if(_mainThemeOut.PlaybackState == PlaybackState.Playing) _mainThemeOut.Stop();
        _mainTheme.CurrentTime = new TimeSpan(0L);
        _mainThemeOut.Play();
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

    private void arrowLeft_Hover(object sender, EventArgs e)
    {
        explicationLabel.Text = "- Go back to the menu\n- Move left";
    }
}