using System;
using System.Drawing;
using System.Drawing.Text;
using System.Timers;
using System.Windows.Forms;
using NAudio.Wave;

namespace Projet_PURPLE;

public partial class Menu : Form
{
    /// <summary> The Menu function is the main function of the game. It creates all of the objects and sets up
    /// their initial locations, then starts a timer that moves them.</summary>
    /// <returns> A form.</returns>
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

    /// <summary>
    /// > If the control is the selected label, set the color to yellow, otherwise set it to white
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="ElapsedEventArgs">The event arguments for the Elapsed event.</param>
    private void menuTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        foreach (Control control in Controls)
        {
            control.ForeColor = Equals(control, Controls[_selectedLabel])
                ? ColorTranslator.FromHtml("#eec905")
                : Color.White;
        }
    }

    /// <summary>
    /// When the timer elapses, stop the main theme and play the menu theme
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="ElapsedEventArgs">The ElapsedEventArgs class contains the event data associated with an Elapsed
    /// event.</param>
    private void musicTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        _mainThemeOut.Stop();
        PlayMenuTheme();
    }

    //
    //KEYBOARD EVENTS
    //

    /// <summary>
    /// When a key is pressed, move the arrow and play the fireball sound
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="KeyEventArgs">A KeyEventArgs that contains the event data.</param>
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

    /// <summary>
    /// > When the quitLabel is clicked, the LeaveApp() function is called
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">This is a class that contains the event data.</param>
    private void quitLabel_Click(object sender, EventArgs e)
    {
        LeaveApp();
    }

    /// <summary>
    /// When the startLabel is clicked, the StartGame() function is called
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">This is a class that contains information about the event.</param>
    private void startLabel_Click(object sender, EventArgs e)
    {
        StartGame();
    }

    /// <summary>
    /// When the user clicks on the help label, the HelpDisplay function is called
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">This is the class that contains the event data.</param>
    private void helpLabel_Click(object sender, EventArgs e)
    {
        HelpDisplay();
    }

    /// <summary>
    /// When the left arrow is clicked, the help menu is hidden and the main menu is shown
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">This is a class that contains the event data.</param>
    private void arrowLeft_Click(object sender, EventArgs e)
    {
        _isHelpSelected = false;
        ShowMenu();
        HideHelpKeys();
    }

    //
    //METHODS
    //

    /// <summary>
    /// It displays the help menu
    /// </summary>
    private void HelpDisplay()
    {
        explicationLabel.Text = "hover a key!";
        _isHelpSelected = true;
        HideMenu();
        ShowHelpKeys();
    }

    /// <summary>
    /// It makes the help keys visible
    /// </summary>
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

    /// <summary>
    /// It hides the help keys and the explanation label
    /// </summary>
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

    /// <summary>
    /// This function hides the menu labels and the menu arrow
    /// </summary>
    private void HideMenu()
    {
        startLabel.Visible = false;
        quitLabel.Visible = false;
        helpLabel.Visible = false;
        menuArrow.Visible = false;
    }

    /// <summary>
    /// This function makes the menu visible
    /// </summary>
    private void ShowMenu()
    {
        startLabel.Visible = true;
        quitLabel.Visible = true;
        helpLabel.Visible = true;
        menuArrow.Visible = true;
    }

    /// <summary>
    /// It closes the application
    /// </summary>
    private static void LeaveApp()
    {
        Application.Exit();
    }

    /// <summary>
    /// It stops the music timer, stops the main theme music, creates a new instance of the game form, shows the game form,
    /// and hides the main menu form
    /// </summary>
    private void StartGame()
    {
        musicTimer.Stop();
        _mainThemeOut.Stop();
        var form1 = new Form1();
        form1.Show();
        Hide();
    }

    /// <summary>
    /// If the fireballOut sound is playing, stop it, set the fireball sound to the beginning, and play it
    /// </summary>
    private void PlaySwitchSound()
    {
        if (_fireballOut.PlaybackState == PlaybackState.Playing) _fireballOut.Stop();
        _fireball.CurrentTime = new TimeSpan(0L);
        _fireballOut.Play();
    }

    /// <summary>
    /// If the main theme is playing, stop it, set the main theme to the beginning, and play it
    /// </summary>
    private void PlayMenuTheme()
    {
        if (_mainThemeOut.PlaybackState == PlaybackState.Playing) _mainThemeOut.Stop();
        _mainTheme.CurrentTime = new TimeSpan(0L);
        _mainThemeOut.Play();
    }

    //
    //HOVER EVENTS
    //

    /// <summary>
    /// When the mouse hovers over the startLabel, the menuArrow is moved to the left of the startLabel
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void startLabel_MouseHover(object sender, EventArgs e)
    {
        menuArrow.Location = new Point(startLabel.Location.X - menuArrow.Width,
            startLabel.Location.Y + startLabel.Height / 2 - menuArrow.Height / 2);
        _selectedLabel = "startLabel";
    }

    /// <summary>
    /// When the mouse hovers over the helpLabel, the menuArrow is moved to the left of the helpLabel
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void helpLabel_MouseHover(object sender, EventArgs e)
    {
        menuArrow.Location = new Point(helpLabel.Location.X - menuArrow.Width,
            helpLabel.Location.Y + helpLabel.Height / 2 - menuArrow.Height / 2);
        _selectedLabel = "helpLabel";
    }

    /// <summary>
    /// When the mouse hovers over the quitLabel, the menuArrow moves to the left of the quitLabel
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void quitLabel_MouseHover(object sender, EventArgs e)
    {
        menuArrow.Location = new Point(quitLabel.Location.X - menuArrow.Width,
            quitLabel.Location.Y + quitLabel.Height / 2 - menuArrow.Height / 2);
        _selectedLabel = "quitLabel";
    }

    /// <summary>
    /// It changes the text of the explicationLabel when the mouse is over the arrowLeft button
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The event arguments.</param>
    private void arrowLeft_Hover(object sender, EventArgs e)
    {
        explicationLabel.Text = "- Go back to the menu\n- Move left";
    }

    /// <summary>
    /// When the mouse hovers over the arrowUp pictureBox, the explicationLabel text will change to the text in the
    /// quotation marks
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void arrowUp_MouseHover(object sender, EventArgs e)
    {
        explicationLabel.Text = "- Navigate through \nthe menus\n- Jump";
    }


    /// <summary>
    /// When the mouse hovers over the arrowDown button, the text in the explicationLabel changes to "Navigate through the
    /// menus"
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void arrowDown_MouseHover(object sender, EventArgs e)
    {
        explicationLabel.Text = "- Navigate through \nthe menus";
    }

    /// <summary>
    /// When the mouse hovers over the arrowRight pictureBox, the explicationLabel text will change to "Move right"
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void arrowRight_MouseHover(object sender, EventArgs e)
    {
        explicationLabel.Text = "- Move right";
    }

    /// <summary>
    /// When the mouse hovers over the escape button, the text in the explication label changes to the text in the quotes.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void escape_MouseHover(object sender, EventArgs e)
    {
        explicationLabel.Text = "- Close the menu\n- Pause the game";
    }

    /// <summary>
    /// When the mouse leaves the enter button, the text in the explication label is set to the text in the quotation marks
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void enter_MouseLeave(object sender, EventArgs e)
    {
        explicationLabel.Text = "- Select the highlighted \noption in menus";
    }

    /// <summary>
    /// When the mouse hovers over the space bar, the text in the explication label changes to "Restart/next level"
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="EventArgs">The EventArgs class is the base class for classes containing event data.</param>
    private void space_MouseHover(object sender, EventArgs e)
    {
        explicationLabel.Text = "- Restart/next level";
    }
}