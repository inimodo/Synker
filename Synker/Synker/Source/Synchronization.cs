using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Security.Authentication;
using System.Net.Security;

//Using: https://www.nuget.org/packages/System.Net.FtpClient/
using System.Net.FtpClient;

namespace Synker
{
    public class FileObj {
        public FileObj(string s_Name,string s_File, DateTime o_Modified,bool b_Folder) {
            this.s_File = s_File;
            this.b_Folder = b_Folder;
            this.o_Modified = o_Modified;
            this.s_Name = s_Name;
        }
        public bool b_Folder;
        public string s_File;
        public string s_Name;
        public DateTime o_Modified; 
    }
    // Responsible for file synchronization
    public static partial class Synchronization
    {
        private static FtpClient o_Connection;

        public delegate void Callback(string s_Title, string s_Message, bool b_isError);
        public static event Callback Message;

        public delegate void Logging(string s_Message, bool b_Nobreak = false, bool b_Nodate = false, int i_Status = 0);
        public static event Logging Log;


        public static Exception LastError { get => e_Error;  }
        private static Exception e_Error;



        private static FileObj[] s_Server, s_Local;
        public static FileObj[] Server { get => s_Server; }
        public static FileObj[] Local { get => s_Local; }

        public static void InitializeConnection()
        {
            o_Connection = new FtpClient();
            o_Connection.Host = FTP.Default.server;
            o_Connection.Credentials = new NetworkCredential(FTP.Default.user, Credentials.Security.Decrypt(FTP.Default.password));
            o_Connection.SocketKeepAlive = false;
            o_Connection.DataConnectionType = FtpDataConnectionType.EPSV;
            o_Connection.EnableThreadSafeDataConnections = false;
            o_Connection.EncryptionMode = FtpEncryptionMode.Explicit;
            o_Connection.SslProtocols = SslProtocols.Default | SslProtocols.Tls11 | SslProtocols.Tls12;
            o_Connection.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);



            //if (!o_Connection.DirectoryExists(Config.Name))
            //{
            //    o_Connection.CreateDirectory(Config.Name);
            //}
            //if (!o_Connection.DirectoryExists(Config.BackupName))
            //{
            //    o_Connection.CreateDirectory(Config.BackupName);
            //}
        }
        public static bool OpenConnection()
        {
            try
            {
                o_Connection.Connect();

                if (!o_Connection.IsConnected) return false;
            }
            catch (Exception) { return false; }
            return true;
        }
        static void OnValidateCertificate(FtpClient o_Control, FtpSslValidationEventArgs o_Args)
        {
            if (o_Args.PolicyErrors != SslPolicyErrors.None)
            {
                Log("SSL Certificate was not accepted: " + o_Args.PolicyErrors, false, false, 2);
            }
            else
            {
                o_Args.Accept = true;
            }
        }
        public static bool CloseConnection()
        {
            try
            {
                o_Connection.Disconnect();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
