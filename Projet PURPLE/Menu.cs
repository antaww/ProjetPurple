using System;
using System.Windows.Forms;

namespace Projet_PURPLE;

public partial class Menu : Form
{
    public Menu()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var form1 = new Form1();
        form1.Show();
        Hide();
    }
}