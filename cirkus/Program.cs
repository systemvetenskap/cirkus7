using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cirkus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Medans man är utloggad ska programmet loopa koden.
            bool loggedOut = true;
            while(loggedOut)
            {
                loggedOut = false;

                // Om man har loggat in visas nästa steg i programmet.
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    if (new MainForm(loginForm.auth, loginForm.fname, loginForm.lname, loginForm.staffUserId).ShowDialog() == DialogResult.OK)
                    {
                        loggedOut = true;
                    }
                }
            }

        }
    }
}
