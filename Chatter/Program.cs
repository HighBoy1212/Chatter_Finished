using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatter {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Check command-line arguments, to determine whether this instance is a server
            // (no arguments) or client (argument "client").
            string[] astrCLArgs = Environment.GetCommandLineArgs();
            Application.Run(new MainForm(astrCLArgs.Length > 1 && astrCLArgs[1] == "client"));
        }
    }
}
