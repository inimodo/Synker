using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

//Using: https://www.nuget.org/packages/System.Net.FtpClient/
using System.Net.FtpClient;
using System.Net;

namespace Synker
{
    public class FileObj {
        public FileObj(string s_File, DateTime o_Modified,bool b_Folder) {
            this.s_File = s_File;
            this.b_Folder = b_Folder;
            this.o_Modified = o_Modified;
        }
        public bool b_Folder;
        public string s_File;
        public DateTime o_Modified; 
    }
    // Responsible for file synchronization
    public static class Synchronization
    {
        public delegate void Callback(string s_Title, string s_Message, bool b_isError);
        public static event Callback CallbackToMain;

        private static Thread o_Thread;

        public static Exception LastError { get => e_Error;  }
        private static Exception e_Error;

        private static FtpClient o_Connection;

        private readonly static string Dir = "Synker";

        private static FileSystemWatcher o_Watcher;

        private static FileObj[] s_Server, s_Local;
        public static FileObj[] Server { get => s_Server; }
        public static FileObj[] Local { get => s_Local; }

        public static bool Initialize()
        {
            o_Connection = new FtpClient();
            o_Connection.Host = FTP.Default.server;
            o_Connection.Credentials = new NetworkCredential(FTP.Default.user, Credentials.Security.Decrypt(FTP.Default.password));
            o_Connection.SocketKeepAlive = true;
            o_Connection.DataConnectionType = FtpDataConnectionType.EPSV;
            o_Connection.EnableThreadSafeDataConnections = true;
            o_Connection.ConnectTimeout = 30000;
            o_Connection.DataConnectionReadTimeout = 30000;
            o_Connection.DataConnectionConnectTimeout = 30000;
            o_Connection.SocketPollInterval = 3000;

            try
            {
                o_Connection.Connect();
                if (!o_Connection.IsConnected) return false ;
            }
            catch (Exception) { return false; }

            if (!o_Connection.DirectoryExists(Dir))
            {
                o_Connection.CreateDirectory(Dir);
            }

            o_Watcher = new FileSystemWatcher(Management.Path);
            o_Watcher.NotifyFilter = NotifyFilters.Attributes| NotifyFilters.CreationTime| NotifyFilters.DirectoryName| NotifyFilters.FileName
                                 | NotifyFilters.LastAccess| NotifyFilters.LastWrite| NotifyFilters.Security| NotifyFilters.Size;
            o_Watcher.IncludeSubdirectories = true;
            o_Watcher.EnableRaisingEvents = true;
            o_Watcher.Changed += Action.Change;
            o_Watcher.Created += Action.Create;
            o_Watcher.Deleted += Action.Delete;
            o_Watcher.Renamed += Action.Rename;

            o_Thread = new Thread(new ThreadStart(PushCycle));
            return true;
        }
        public static void StartSync() => o_Thread.Start();
        public static void StopSync() => o_Thread.Abort();
        private static void PushCycle()
        {
            Callback Message = CallbackToMain;
            Message("Autopush Enabled", "Automatic Synchronization Enabled.", false);
            while (FTP.Default.connected)
            {
                if (Action.Changed)
                {
                    int i_Trys;
                    if (UpdateListing(out i_Trys))
                    {
                        if (Push(out i_Trys))
                        {
                            Message("Push", "Upload was successful after " + i_Trys + " attempt(s).", false);
                        }
                        else
                        {
                            Message("Push", "Upload failed: " + LastError.GetType(), true);
                        }
                    }
                    else
                    {
                        Message("Listing failed ", "Listing failed: " + LastError.GetType(), true);
                    }
                    Action.Changed = false;
                }
                Thread.Sleep(5*60*1000);
            }
        }
        private static class Action
        {
            public static bool Changed = false;
            public static void Change(object o_Sender, FileSystemEventArgs o_Args) => Changed = true;
            public static void Create(object o_Sender, FileSystemEventArgs o_Args) => Changed = true;
            public static void Delete(object o_Sender, FileSystemEventArgs o_Args) => Changed = true;
            public static void Rename(object o_Sender, RenamedEventArgs o_Args) => Changed = true;
        }
        
        private static bool DeleteLocal(FileObj s_Source)
        {
            try
            {
                if (s_Source.b_Folder)
                {
                    if (Directory.Exists(Management.PrePath + s_Source.s_File))
                    {
                        Directory.Delete(Management.PrePath + s_Source.s_File, true);
                    }
                }
                else
                {
                    if (File.Exists(Management.PrePath + s_Source.s_File))
                    {
                        File.Delete(Management.PrePath + s_Source.s_File);
                    }
                }
            }
            catch (Exception e_Info)
            {
                e_Error = e_Info;
                return false;
            }

            return true;

        }
        private static bool DeleteServer(FileObj s_Source)
        {
            try { 
                if (s_Source.b_Folder)
                {
                    if (o_Connection.DirectoryExists(s_Source.s_File.Replace("\\", "/")))
                    {
                        o_Connection.DeleteDirectory(s_Source.s_File.Replace("\\", "/"),true);
                    }
                } else
                {
                    if (o_Connection.FileExists(s_Source.s_File.Replace("\\", "/")))
                    {
                        o_Connection.DeleteFile(s_Source.s_File.Replace("\\", "/"));
                    }
                }
            }
            catch (Exception e_Info)
            {
                e_Error = e_Info;
                return false; 
            }
            return true;
        }
        private static bool DownloadFile(FileObj s_Source)
        {
            try
            {
                if (s_Source.b_Folder)
                {
                    if (!Directory.Exists(Management.PrePath + s_Source.s_File))
                    {
                        Directory.CreateDirectory(Management.PrePath + s_Source.s_File);
                    }
                }
                else
                {
                    Stream o_SourceFile = File.OpenWrite(Management.PrePath + s_Source.s_File);
                    using (Stream o_DestinyStream = o_Connection.OpenRead(s_Source.s_File.Replace("\\", "/")))
                    {
                        o_DestinyStream.CopyTo(o_SourceFile);
                        o_DestinyStream.Close();
                        o_DestinyStream.Dispose();
                    }
                    o_SourceFile.Close();
                    o_SourceFile.Dispose();
                }
            }
            catch (Exception e_Info)
            {
                e_Error = e_Info;
                return false;
            }


            return true;

        }
        private static bool UploadFile(FileObj s_Source)
        {
            try
            {
                if (s_Source.b_Folder)
                {
                    o_Connection.CreateDirectory(s_Source.s_File.Replace("\\", "/"));
                }
                else
                {
                    Stream o_SourceFile = File.OpenRead(Management.PrePath + s_Source.s_File);
                    using (Stream o_DestinyStream = o_Connection.OpenWrite(s_Source.s_File.Replace("\\", "/"),FtpDataType.Binary))
                    {

                        o_SourceFile.CopyTo(o_DestinyStream);
                        o_SourceFile.Close();
                        o_SourceFile.Dispose();
                    }
                    o_SourceFile.Close();
                    o_SourceFile.Dispose();
                }
            }
            catch (Exception e_Info)
            {
                e_Error = e_Info;
                return false;
            }            
            return true;
        }
        private static FileObj[] FetchServer()
        {
            List<FileObj> s_Files = new List<FileObj>();

            FileObj[] InternalFetch(string s_Folder)
            {
                List<FileObj> s_InternalFiles = new List<FileObj>();
                foreach (FtpListItem o_Item in o_Connection.GetListing(s_Folder))
                {
                    s_InternalFiles.Add(new FileObj(o_Item.FullName.Replace("/", "\\"), o_Item.Modified, o_Item.Type == FtpFileSystemObjectType.Directory));

                    if (o_Item.Type == FtpFileSystemObjectType.Directory)
                    {
                        s_InternalFiles.AddRange(InternalFetch(o_Item.FullName));
                    }
                }
                return s_InternalFiles.ToArray();
            }

            try
            {
                foreach (FtpListItem o_Item in o_Connection.GetListing())
                {
                    if (o_Item.Name == Dir)
                    {
                        s_Files.Add(new FileObj("\\" + o_Item.Name, o_Item.Modified, true));
                    }
                }

                o_Connection.SetWorkingDirectory(Dir);

                foreach (FtpListItem o_Item in o_Connection.GetListing())
                {
                    s_Files.Add(new FileObj(o_Item.FullName.Replace("/", "\\"), o_Item.Modified, o_Item.Type == FtpFileSystemObjectType.Directory));
                    if (o_Item.Type == FtpFileSystemObjectType.Directory)
                    {
                        s_Files.AddRange(InternalFetch(o_Item.FullName));
                    }
                }

                o_Connection.SetWorkingDirectory("../");
            }
            catch (Exception e_Info)
            {
                e_Error = e_Info;
                return null;
            }

            return s_Files.ToArray();
        }
        private static FileObj[] FetchLocal()
        {
            string[] s_Files = Directory.GetFileSystemEntries(Management.Path, "*", SearchOption.AllDirectories);
            List<FileObj> o_Files = new List<FileObj>();

            FileInfo o_Info = new FileInfo(Management.Path);
            o_Files.Add(new FileObj("\\Synker" ,o_Info.LastWriteTime,true));
            for (int i_Index = 0; i_Index < s_Files.Length; i_Index++)
            {
                o_Info = new FileInfo(s_Files[i_Index]);
                if (!o_Info.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    o_Files.Add(new FileObj("\\Synker\\" + s_Files[i_Index].Remove(0, Management.Path.Length), o_Info.LastWriteTime, Directory.Exists(s_Files[i_Index])));
                }
            }
            return o_Files.ToArray();
        }
        public static bool Pull(out int i_Trys)
        {
            for (i_Trys = 1; i_Trys < 4; i_Trys++)
            {
                if (ForcePull() == true) return true;
                Thread.Sleep(500);
            }
            return false;
        }
        private static bool ForcePull()
        {
            // Checks if a file is present on server: if false delete it because it is no longer needed

            if (s_Server.Length != 1)
            {
                for (int i_LocalIndex = 1; i_LocalIndex < s_Local.Length; i_LocalIndex++)
                {
                    bool b_IsOnLocal = false;
                    for (int i_ServerIndex = 1; i_ServerIndex < s_Server.Length; i_ServerIndex++)
                    {
                        if (s_Local[i_LocalIndex].s_File == s_Server[i_ServerIndex].s_File)
                        {
                            b_IsOnLocal = true;
                            break;
                        }
                    }
                    if (!b_IsOnLocal)
                    {
                        if (!DeleteLocal(s_Local[i_LocalIndex])) return false;
                    }
                }
            }

            // Check if server file is on local: if true: check if needs to be updated, if false: download file directly

            for (int i_ServerIndex = 1; i_ServerIndex < s_Server.Length; i_ServerIndex++)
            {
                int i_IsOnLocal = -1;
                if (s_Server.Length != 1)
                {
                    for (int i_LocalIndex = 1; i_LocalIndex < s_Local.Length; i_LocalIndex++)
                    {
                        if (s_Local[i_LocalIndex].s_File == s_Server[i_ServerIndex].s_File)
                        {
                            i_IsOnLocal = i_LocalIndex;
                            break;
                        }
                    }
                }
                if (i_IsOnLocal == -1)
                {
                    if (!DownloadFile(s_Server[i_ServerIndex])) return false;
                }
                else if (DateTime.Compare(s_Server[i_ServerIndex].o_Modified, s_Local[i_IsOnLocal].o_Modified) > 0)
                {
                    if (!DownloadFile(s_Server[i_IsOnLocal])) return false;
                }
            }
            return true;
        }
        public static bool Push(out int i_Trys)
        {
            for (i_Trys = 1; i_Trys < 3; i_Trys++)
            {
                if (ForcePush() == true) return true;
                Thread.Sleep(500);
            }
            return false;
        }
        private static bool ForcePush()
        {
            // Checks if a file is present on local: if false delete it because it is no longer needed

            if (s_Server.Length != 1)
            {
                for (int i_ServerIndex = 1; i_ServerIndex < s_Server.Length; i_ServerIndex++)
                {
                    bool b_IsOnLocal = false;
                    for (int i_LocalIndex = 1; i_LocalIndex < s_Local.Length; i_LocalIndex++)
                    {
                        if (s_Local[i_LocalIndex].s_File == s_Server[i_ServerIndex].s_File)
                        {
                            b_IsOnLocal = true;
                            break;
                        }
                    }
                    if (!b_IsOnLocal)
                    {
                        if (!DeleteServer(s_Server[i_ServerIndex])) return false;
                    }
                }
            }

            // Check if local file is on server: if true: check if needs to be updated, if false: upload file directly

            for (int i_LocalIndex = 1; i_LocalIndex < s_Local.Length; i_LocalIndex++)
            {
                int i_IsOnServer = -1;
                if (s_Server.Length != 1)
                {
                    for (int i_ServerIndex = 1; i_ServerIndex < s_Server.Length; i_ServerIndex++)
                    {
                        if (s_Local[i_LocalIndex].s_File == s_Server[i_ServerIndex].s_File)//
                        {
                            i_IsOnServer = i_ServerIndex;
                            break;
                        }
                    }
                }
                if (i_IsOnServer == -1)
                {
                    if (!UploadFile(s_Local[i_LocalIndex])) return false;
                }
                else if (DateTime.Compare(s_Local[i_LocalIndex].o_Modified, s_Server[i_IsOnServer].o_Modified) < 0)
                {
                    if (!UploadFile(s_Local[i_LocalIndex])) return false;
                }
            }
            return true;
        }
        public static bool UpdateListing(out int i_Trys)
        {
            for (i_Trys = 1; i_Trys < 4; i_Trys++)
            {
                if (FetchData() == true) return true;
                Thread.Sleep(500);
            }
            return false;
        }
        private static bool FetchData()
        {
            FileObj[] s_ServerTemp = FetchServer();
            FileObj[] s_LocalTemp = FetchLocal();

            if (s_LocalTemp != null && s_ServerTemp != null)
            {
                s_Local = s_LocalTemp;
                s_Server = s_ServerTemp;
                return true;
            }
            return false;
        }
    }
}
