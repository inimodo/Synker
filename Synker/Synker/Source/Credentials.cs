using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

//Using: https://www.nuget.org/packages/System.Security.Cryptography.ProtectedData/
using System.Security.Cryptography;


//Using: https://www.nuget.org/packages/System.Net.FtpClient/
using System.Net.FtpClient;

namespace Synker
{
    // Responsible for security and storing/loading user FTP login credentials
    public static class Credentials
    {
        public static bool Validate(string s_Server, string s_User, string s_Password, out Exception e_Error)
        {
            if (String.IsNullOrEmpty(s_Server) || String.IsNullOrEmpty(s_User) || String.IsNullOrEmpty(s_Password))
            {
                e_Error = new Exception("Empty field");
                return false;
            }

            FtpClient o_Connection = new FtpClient();
            o_Connection.Host = s_Server;
            o_Connection.Credentials = new NetworkCredential(s_User, s_Password);
            try
            {
                o_Connection.Connect();
                if (!o_Connection.DirectoryExists(Config.Name))
                {
                    o_Connection.CreateDirectory(Config.Name);
                }
                if (!o_Connection.DirectoryExists(Config.BackupName))
                {
                    o_Connection.CreateDirectory(Config.BackupName);
                }
            }
            catch (Exception e_ConnectionError)
            {
                e_Error = e_ConnectionError;
                return false;
            }

            if (!o_Connection.IsConnected)
            {
                e_Error = new Exception("No Connection");
                return false;
            }
            
            o_Connection.Disconnect();
            e_Error = null;
            return true;

        }
        public static void Connect(string s_Server, string s_User, string s_Password)
        {
            FTP.Default.connected = true;
            FTP.Default.server = s_Server;
            FTP.Default.user = s_User;
            FTP.Default.password = Security.Encrypt(s_Password);
            FTP.Default.Save();
        }
        public static void Disconnect()
        {
            FTP.Default.connected = false;
            FTP.Default.server = "";
            FTP.Default.user = "";
            FTP.Default.password = "";
            FTP.Default.Save();
        }
        public static bool Check()
        {
            Exception o_Error;
            if (String.IsNullOrEmpty(FTP.Default.password))
            {
                Disconnect();
                return false;
            }
            if (!Validate(FTP.Default.server, FTP.Default.user, Security.Decrypt(FTP.Default.password), out o_Error))
            {
                Disconnect();
                return false;
            }
            return true;
        }

        public static class Security
        {
            private readonly static byte[] b_Entropy = { 4, 6, 7, 8, 9, 3, 1, 5, 6, 4, 8, 9, 4, 6 };
            public static string Encrypt(string s_Input)
            {
                byte[] b_Data = new byte[s_Input.Length];
                char[] c_Input = s_Input.ToCharArray();
                for (int i_Index = 0; i_Index < c_Input.Length; i_Index++)
                {
                    b_Data[i_Index] = Convert.ToByte(c_Input[i_Index]);
                }
                byte[] b_Output = ProtectedData.Protect(b_Data, b_Entropy, DataProtectionScope.CurrentUser);
                string s_Return = "";
                foreach (byte b_Byte in b_Output)
                {
                    s_Return += Convert.ToChar(b_Byte);
                }
                return s_Return;
            }
            public static string Decrypt(string s_Input)
            {
                byte[] b_Data = new byte[s_Input.Length];
                char[] c_Input = s_Input.ToCharArray();
                for (int i_Index = 0; i_Index < c_Input.Length; i_Index++)
                {
                    b_Data[i_Index] = Convert.ToByte(c_Input[i_Index]);
                }
                byte[] b_Output = ProtectedData.Unprotect(b_Data, b_Entropy, DataProtectionScope.CurrentUser);
                string s_Return = "";
                foreach (byte b_Byte in b_Output)
                {
                    s_Return += Convert.ToChar(b_Byte);
                }
                return s_Return;
            }
        }
    }
}
