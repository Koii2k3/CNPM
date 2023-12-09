using System;
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

            //FT_43819_IT
            //FT_96418_IT 123456 QLDA
            //FT_25426_HR 25426 QLNS
            //IN_50821_IT 50821 Staff
            //IN_00682_HR 00682
            //FT_77945_IT test QLDA
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new PageControl());
            //Application.Run(new TimeLineForm("AD996AF183"));
            Application.Run(new LoginForm());
        }
    }
}
