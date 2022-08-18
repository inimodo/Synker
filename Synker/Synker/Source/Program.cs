using System;
using System.Collections.Generic;
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
            using (WindowsIdentity o_thisid = WindowsIdentity.GetCurrent())
            {

                WindowsPrincipal o_Principal = new WindowsPrincipal(o_thisid);
                if (o_Principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    if (Management.FirstTime())
                    {
                        Installdialog o_Installer = new Installdialog();
                        Application.Run(o_Installer);
                        if (o_Installer.Success)
                        {
                            Application.Run(new Connections());
                        }
                    }
                    else
                    {
                        Application.Run(new Connections());
                    }
                }
                else
                {
                    MessageBox.Show("Synker needs administrator rights for operation. Please restart as administrator!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
