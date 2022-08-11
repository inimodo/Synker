using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Synker
{
    // Responsible for proper folder/file setup
    public static class Management
    {

        public static string Path { get { return "C:\\Users\\" + Environment.UserName + "\\Synker\\"; } }
        public static bool FirstTime()
        {
            if (Directory.Exists(Path))
            {
                return false;
            }
            return true;
        }
        public static bool CreateFolder()
        {
            DirectoryInfo o_Dir = Directory.CreateDirectory(Path);
            o_Dir.Attributes =  FileAttributes.System;
            Icon o_Exeico = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            using (FileStream o_IcoStream = new FileStream(Path+"ico.ico",FileMode.Create))
            {
                o_Exeico.Save(o_IcoStream);
            }
            FileInfo o_IcoInfo = new FileInfo(Path + "ico.ico");
            o_IcoInfo.Attributes = FileAttributes.Hidden | FileAttributes.Archive | FileAttributes.System;

            FileStream o_FStream = File.Create(Path + "desktop.ini");
            FileInfo o_File = new FileInfo(Path + "desktop.ini");
            StreamWriter o_ini = new StreamWriter(o_FStream);
            o_ini.WriteLine("[.ShellClassInfo]");
            o_ini.WriteLine("IconFile=ico.ico");
            o_ini.WriteLine("IconIndex=0");
            o_ini.WriteLine("InfoTip=Synker User Files");
            o_ini.Flush();
            o_ini.Close();
            o_FStream.Close();

            o_File.Attributes = FileAttributes.Hidden | FileAttributes.Archive | FileAttributes.System;
            return true;
        }
        public static bool CreateDesktopIscon()
        {

            /*
             
            Implementation not possiple unless .exe is at a fixed placed ... mor thinking requierd
             
            */
            return true;
        }
        public static bool CreateWinexIcon()
        {

            /*
            
            Dangerous play with WinReg... think about it! Needing more knowledge on subject!
             
            */
            return true;
        }
    }
}
