using System;
using System.Windows.Forms;

namespace Projet_PURPLE
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Application.OpenForms["Menu"] == null)
            {
                Application.Run(new Menu());
            }
        }
    }
}