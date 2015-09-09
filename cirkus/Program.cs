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

            bool loggedOut = true;

            while (loggedOut)
            {
                loggedOut = false;

                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {

                    MainForm mainForm = new MainForm(loginForm.auth, loginForm.fname, loginForm.lname, loginForm.staffUserId);
                    Application.Run(mainForm);

                    if (mainForm.DialogResult == DialogResult.OK)
                    {
                        loggedOut = true;
                    }

                }
            }

        }
    }
}