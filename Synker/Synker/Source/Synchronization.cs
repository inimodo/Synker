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
        private static FtpClient o_Connection;

        private readonly static string Dir = "Synker";
        public delegate void Callback(string s_Title,string s_Message, bool b_isError);

        public static event Callback CallbackToMain;

        private static Thread o_SyncThread;

        public static void Initialize()
        {
            o_Connection = new FtpClient();
            o_Connection.Host = FTP.Default.server;
            o_Connection.Credentials = new NetworkCredential(FTP.Default.user, Credentials.Security.Decrypt(FTP.Default.password));
            o_Connection.SocketKeepAlive = true;
            o_Connection.DataConnectionConnectTimeout = 30000;
            o_Connection.DataConnectionReadTimeout = 30000;
            o_Connection.ReadTimeout = 30000;
            o_Connection.DataConnectionType = FtpDataConnectionType.EPSV;
            o_Connection.EnableThreadSafeDataConnections = false;
            o_Connection.SocketPollInterval = 30000;
            try
            {
                o_Connection.Connect();
                if (!o_Connection.IsConnected) return ;
            }
            catch (Exception) { return ; }

            if (!o_Connection.DirectoryExists(Dir))
            {
                o_Connection.CreateDirectory(Dir);
            }

            o_SyncThread = new Thread(new ThreadStart(Routine));
            o_SyncThread.Start();
        }


        private static bool DeleteLocal(FileObj s_Source)
        {
            Console.WriteLine("Del Local: "+ s_Source.s_File);
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
                Console.WriteLine(e_Info);
                return false;
            }

            return true;

        }
        private static bool DeleteServer(FileObj s_Source)
        {
            Console.WriteLine("Del Server: "+ s_Source.s_File);
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
                Console.WriteLine(e_Info);
                return false;
            }
            return true;
        }

        private static bool DownloadFile(FileObj s_Source)
        {
            Console.WriteLine("Download: "+ s_Source.s_File);

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
                Console.WriteLine(e_Info);
                return false;
            }


            return true;

        }

        private static bool UploadFile(FileObj s_Source)
        {
            Console.WriteLine("Upload: "+s_Source.s_File);
            try
            {
                if (s_Source.b_Folder)
                {
                    o_Connection.CreateDirectory(s_Source.s_File.Replace("\\", "/"));
                }
                else
                {
                    Stream o_SourceFile = File.OpenRead(Management.PrePath + s_Source.s_File);
                    using (Stream o_DestinyStream = o_Connection.OpenWrite(s_Source.s_File.Replace("\\", "/")))
                    {

                        o_SourceFile.CopyTo(o_DestinyStream);
                    }
                    o_SourceFile.Close();
                    o_SourceFile.Dispose();
                }
            }
            catch (Exception e_Info)
            {
                Console.WriteLine(e_Info);
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
                Console.WriteLine(e_Info);
                return null;
            }

            //o_Connection.Disconnect();
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
        private static bool Compare(FileObj[] s_Server, FileObj[] s_Local)
        {
            if (DateTime.Compare(s_Server[0].o_Modified, s_Local[0].o_Modified)>0)//Download data from server
            {
                Console.WriteLine("\nDONWLOAD:");

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
            }
            else // Upload data to server 
            {
                Console.WriteLine("\nUPLOAD: "+s_Server.Length+" "+s_Local.Length);

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
                    }else if (DateTime.Compare(s_Local[i_LocalIndex].o_Modified, s_Server[i_IsOnServer].o_Modified) < 0)
                    {
                        if (!UploadFile(s_Local[i_LocalIndex])) return false;
                    }
                }

            }
            return true;
        }
        private static void Routine()
        {
            Callback Message = CallbackToMain;
            FileObj[] s_Server, s_Local;
            Thread.Sleep(1000);

            while (FTP.Default.connected)
            {
                Console.WriteLine("Connected: "+o_Connection.IsConnected);
                s_Server = FetchServer();
                s_Local = FetchLocal();
                if (s_Local != null && s_Server != null)
                {

                    Console.WriteLine("\nSERVER:");
                    foreach (FileObj item in s_Server)
                    {
                        Console.WriteLine(item.b_Folder+"\t"+item.o_Modified + " " + item.s_File);
                    }
                    Console.WriteLine("\nLOCAL: ");

                    foreach (FileObj item in s_Local)
                    {
                        Console.WriteLine(item.b_Folder + "\t" + item.o_Modified + " "+ item.s_File);
                    }
                    Console.WriteLine("Success: "+Compare(s_Server,s_Local));
                }
                Thread.Sleep(5000);
            }
        }
    }
}
