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
using IWshRuntimeLibrary;
using Microsoft.Win32;
using System.Reflection;

namespace Synker
{
    // Responsible for proper folder/file setup
    public static class Management
    {

        public static string Path { get { return "C:\\Users\\" + Environment.UserName + "\\Synker\\"; } }
        public static string PrePath { get { return "C:\\Users\\" + Environment.UserName; } }
        public static string Name { get { return "Synker"; } }
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
            try
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

                FileStream o_FStream = System.IO.File.Create(Path + "desktop.ini");
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

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static bool CreateDesktopIscon()
        {
            try
            {
                WshShell o_WSHShell = new WshShell();
                IWshShortcut o_Shortcut = (IWshShortcut)o_WSHShell.CreateShortcut(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Management.Name + ".lnk"
                    );
                o_Shortcut.IconLocation = Application.ExecutablePath;
                o_Shortcut.TargetPath = Application.ExecutablePath;
                o_Shortcut.Save();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        //Credit: https://docs.microsoft.com/de-de/windows/win32/shell/integrate-cloud-storage?redirectedfrom=MSDN
        public static bool CreateWinexIcon()
        {
            try
            {
                string s_GUID = Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value.ToUpper();
                RegistryKey o_User = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
                RegistryKey o_GUID = o_User.CreateSubKey("Software\\Classes\\CLSID\\{" + s_GUID + "}");
                o_GUID.SetValue("", Name, RegistryValueKind.String);
                o_GUID.SetValue("System.IsPinnedToNameSpaceTree", unchecked((int)0x1), RegistryValueKind.DWord);
                o_GUID.SetValue("SortOrderIndex", unchecked((int)0x42), RegistryValueKind.DWord);

                RegistryKey o_Temp = o_GUID.CreateSubKey("DefaultIcon");
                o_Temp.SetValue("", Path + "ico.ico", RegistryValueKind.ExpandString);
                o_Temp.Close();

                o_Temp = o_GUID.CreateSubKey("InProcServer32");
                o_Temp.SetValue("", "%systemroot%\\system32\\shell32.dll", RegistryValueKind.ExpandString);
                o_Temp.Close();

                o_Temp = o_GUID.CreateSubKey("Instance");
                o_Temp.SetValue("CLSID", "{0E5AAE11-A475-4c5b-AB00-C66DE400274E}", RegistryValueKind.String);
                o_Temp.Close();

                o_Temp = o_GUID.CreateSubKey("Instance\\InitPropertyBag");
                o_Temp.SetValue("Attributes", unchecked((int)0x11), RegistryValueKind.DWord);
                o_Temp.SetValue("TargetFolderPath", Path, RegistryValueKind.ExpandString);

                o_Temp = o_GUID.CreateSubKey("ShellFolder");
                o_Temp.SetValue("FolderValueFlags", unchecked((int)0x28), RegistryValueKind.DWord);
                o_Temp.SetValue("Attributes", unchecked((int)0xF080004D), RegistryValueKind.DWord);
                o_Temp.Close();

                o_GUID.Close();

                o_Temp = o_User.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\{" + s_GUID + "}");
                o_Temp.SetValue("", Name, RegistryValueKind.String);
                o_Temp.Close();

                o_Temp = o_User.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel");
                o_Temp.SetValue("{" + s_GUID + "}", unchecked((int)0x1), RegistryValueKind.DWord);
                o_Temp.Close();

                o_User.Close();
            }
            catch (Exception)
            {

                return false; ;
            }
            return true;
        }
    }
}
