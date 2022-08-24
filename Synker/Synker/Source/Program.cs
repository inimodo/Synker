using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Config.ReadConfig())
            {
                Installdialog o_Installer = new Installdialog();
                Application.Run(o_Installer);
                if (!o_Installer.Success)
                {
                    return;
                }
            }
            Application.Run(new Connections());
        }
    }
}
