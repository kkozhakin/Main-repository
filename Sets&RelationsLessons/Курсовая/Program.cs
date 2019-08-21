using System;
using System.Windows.Forms;

namespace Sets_RelationsLessons
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Properties.Settings.Default.login == "")
            {
                Application.Run(new Login());
            }
            else
            {
                Application.Run(new General());
            }
        }
    }
}
