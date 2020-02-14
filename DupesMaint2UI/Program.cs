using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DupesMaint2UI
{
    static class Program
    {
        internal static readonly string targetRootFolder = @"C:\Users\User\Google Drive\OneDriveDupes";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DisplayPhotos4SHA());
        }
    }
}
