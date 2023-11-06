using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

namespace CNPM_ver3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var language = ConfigurationManager.AppSettings["language"];

            //PT_40393_HR 40393 QLNS
            //IN_50821_IT 50821 Staff
            //FT_77945_IT test QLDA
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new PageControl());
            Application.Run(new LoginForm());

            //Application.Run(new AddUserForm());
        }
    }
}
