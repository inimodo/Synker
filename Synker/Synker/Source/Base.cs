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
    public static partial class Synchronization
    {
        private static class Base
        {
            public static bool DeleteOnLocal(FileObj s_Source)
            {
                if (!OpenConnection()) return false;
                try
                {
                    if (s_Source.b_Folder)
                    {
                        if (Directory.Exists(Config.PrePath + s_Source.s_File))
                        {
                            Directory.Delete(Config.PrePath + s_Source.s_File, true);
                        }
                    }
                    else
                    {
                        if (File.Exists(Config.PrePath + s_Source.s_File))
                        {
                            File.Delete(Config.PrePath + s_Source.s_File);
                        }
                    }
                }
                catch (Exception e_Info)
                {
                    Console.WriteLine(e_Info);
                    e_Error = e_Info;
                    if (!CloseConnection()) return false;
                    return false;
                }
                if (!CloseConnection()) return false;
                return true;
            }
            public static bool DeleteFromServer(FileObj s_Source)
            {
                if (!OpenConnection()) return false;

                try
                {
                    if (s_Source.b_Folder)
                    {
                        if (o_Connection.DirectoryExists(s_Source.s_File.Replace("\\", "/")))
                        {
                            o_Connection.DeleteDirectory(s_Source.s_File.Replace("\\", "/"),true);
                        }
                    }
                    else
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
                    e_Error = e_Info;
                    if (!CloseConnection()) return false;
                    return false;
                }
                if (!CloseConnection()) return false;
                return true;
            }

            public static bool DownloadFile(FileObj s_Source)
            {
                if (!OpenConnection()) return false;

                if (s_Source.b_Folder)
                {
                    if (!Directory.Exists(Config.PrePath + s_Source.s_File))
                    {
                        Directory.CreateDirectory(Config.PrePath + s_Source.s_File);
                    }
                }
                else
                {
                    Stream o_SourceFile = null, o_DestinyStream = null;
                    try
                    {
                        o_DestinyStream = o_Connection.OpenRead(s_Source.s_File.Replace("\\", "/"));
                        
                        o_SourceFile = File.OpenWrite(Config.PrePath + s_Source.s_File);

                        o_DestinyStream.CopyTo(o_SourceFile);

                        o_DestinyStream.Close();
                        o_DestinyStream.Dispose();

                        o_SourceFile.Close();
                        o_SourceFile.Dispose();
                    }
                    catch (Exception e_Info)
                    {
                        if (o_SourceFile != null)
                        {
                            o_SourceFile.Close();
                            o_SourceFile.Dispose();
                        }
                        if (o_DestinyStream != null)
                        {
                            o_DestinyStream.Close();
                            o_DestinyStream.Dispose();
                        }

                        Console.WriteLine(e_Info);
                        e_Error = e_Info;
                        if (!CloseConnection()) return false;
                        return false;
                    }
                }
                if (!CloseConnection()) return false;
                return true;
            }

            public static bool UploadFile(FileObj s_Source)
            {
                if (!OpenConnection()) return false;

                if (s_Source.b_Folder)
                {
                    o_Connection.CreateDirectory(s_Source.s_File.Replace("\\", "/"));
                }
                else
                {
                    Stream o_SourceFile = null, o_DestinyStream = null;
                    try
                    {
                        o_SourceFile = File.OpenRead(Config.PrePath + s_Source.s_File);
                        o_DestinyStream = o_Connection.OpenWrite(s_Source.s_File.Replace("\\", "/"));

                        o_SourceFile.CopyTo(o_DestinyStream);

                        Thread.Sleep(1000);//Only works with delay for some reason

                        o_SourceFile.Close();
                        o_SourceFile.Dispose();
                        
                        o_SourceFile.Close();
                        o_SourceFile.Dispose();

                        
                    }
                    catch (Exception e_Info)
                    {

                        if (o_SourceFile != null)
                        {
                            o_SourceFile.Close();
                            o_SourceFile.Dispose();
                        }
                        if (o_DestinyStream != null)
                        {
                            o_DestinyStream.Close();
                            o_DestinyStream.Dispose();
                        }

                        Console.WriteLine(e_Info);
                        e_Error = e_Info;
                        if (!CloseConnection()) return false;
                        return false;
                    }
                }
                if (!CloseConnection()) return false;
                return true;
            }
            public static FileObj[] FetchServer()
            {
                if (!OpenConnection()) return null;

                List<FileObj> s_Files = new List<FileObj>();

                FileObj[] InternalFetch(string s_Folder)
                {
                    Console.WriteLine("F: "+s_Folder);
                    List<FileObj> s_InternalFiles = new List<FileObj>();
                    foreach (FtpListItem o_Item in o_Connection.GetListing(s_Folder))
                    {
                        s_InternalFiles.Add(new FileObj(o_Item.Name,o_Item.FullName.Replace("/", "\\"), o_Item.Modified, o_Item.Type == FtpFileSystemObjectType.Directory));

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
                        if (o_Item.Name == Config.Name)
                        {
                            s_Files.Add(new FileObj("","\\" + o_Item.Name, o_Item.Modified, true));
                        }
                    }

                    o_Connection.SetWorkingDirectory(Config.Name);

                    foreach (FtpListItem o_Item in o_Connection.GetListing())
                    {
                        s_Files.Add(new FileObj(o_Item.Name,o_Item.FullName.Replace("/", "\\"), o_Item.Modified, o_Item.Type == FtpFileSystemObjectType.Directory));
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
                    Thread.Sleep(1000);
                    if (!CloseConnection()) return null;
                    e_Error = e_Info;
                    return null;
                }
                if (!CloseConnection()) return null;
                return s_Files.ToArray();
            }
            public static FileObj[] FetchLocal()
            {
                string[] s_Files = Directory.GetFileSystemEntries(Config.Path, "*", SearchOption.AllDirectories);
                List<FileObj> o_Files = new List<FileObj>();

                FileInfo o_Info = new FileInfo(Config.Path);
                o_Files.Add(new FileObj("","\\Synker", o_Info.LastWriteTime, true));
                for (int i_Index = 0; i_Index < s_Files.Length; i_Index++)
                {
                    o_Info = new FileInfo(s_Files[i_Index]);
                    if (!o_Info.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        o_Files.Add(new FileObj(o_Info.Name,"\\Synker\\" + s_Files[i_Index].Remove(0, Config.Path.Length), o_Info.LastWriteTime, Directory.Exists(s_Files[i_Index])));
                    }
                }
                return o_Files.ToArray();
            }

            public static bool FetchData()
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

            public static bool DownloadBackup(string s_Source)
            {
                if (!OpenConnection()) return false;

                Stream o_SourceFile = null, o_DestinyStream = null;
                try
                {
                    o_SourceFile = File.OpenWrite(Config.PrePath + "\\" + s_Source);
                    o_DestinyStream = o_Connection.OpenRead(Config.BackupName+"/"+s_Source);

                    o_DestinyStream.CopyTo(o_SourceFile);

                    o_DestinyStream.Close();
                    o_DestinyStream.Dispose();

                    o_SourceFile.Close();
                    o_SourceFile.Dispose();
                }
                catch (Exception e_Info)
                {
                    if (o_SourceFile != null)
                    {
                        o_SourceFile.Close();
                        o_SourceFile.Dispose();
                    }
                    if (o_DestinyStream != null)
                    {
                        o_DestinyStream.Close();
                        o_DestinyStream.Dispose();
                    }

                    Console.WriteLine(e_Info);
                    e_Error = e_Info;
                    if (!CloseConnection()) return false;
                    return false;
                }
                if (!CloseConnection()) return false;
                return true;
            }

            public static bool UploadBackup(string s_Source)
            {
                if (!OpenConnection()) return false;

                Stream o_SourceFile = null, o_DestinyStream = null;
                try
                {
                    o_SourceFile = File.OpenRead(Config.PrePath + "\\" + s_Source);
                    o_DestinyStream = o_Connection.OpenWrite(Config.BackupName + "/" + s_Source);

                    o_SourceFile.CopyTo(o_DestinyStream);

                    Thread.Sleep(1000);//Only works with delay for some reason

                    o_SourceFile.Close();
                    o_SourceFile.Dispose();

                    o_SourceFile.Close();
                    o_SourceFile.Dispose();
                }
                catch (Exception e_Info)
                {

                    if (o_SourceFile != null)
                    {
                        o_SourceFile.Close();
                        o_SourceFile.Dispose();
                    }
                    if (o_DestinyStream != null)
                    {
                        o_DestinyStream.Close();
                        o_DestinyStream.Dispose();
                    }

                    Console.WriteLine(e_Info);
                    e_Error = e_Info;
                    if (!CloseConnection()) return false;
                    return false;
                }
                if (!CloseConnection()) return false;
                return true;
            }
            public static bool FetchBackups(out string[] s_Backups)
            {
                if (!OpenConnection())
                {
                    s_Backups = null;
                    return false;
                }

                List<string> s_Data = new List<string>();
                try
                {
                    foreach (FtpListItem o_Item in o_Connection.GetListing(Config.BackupName))
                    {
                        if (o_Item.Type == FtpFileSystemObjectType.File)
                        {
                            s_Data.Add(o_Item.Name);
                        }
                    }
                    s_Backups = s_Data.ToArray();
                }
                catch (Exception e_Info)
                {
                    Console.WriteLine(e_Info);
                    e_Error = e_Info;
                    s_Backups = null;
                    if (!CloseConnection())
                    {
                        s_Backups = null;
                        return false;
                    }

                    return false;
                }
                if (!CloseConnection())
                {
                    s_Backups = null;
                    return false;
                }
                return true;
            }
            public static bool DeleteBackup(string s_Source)
            {
                if (!OpenConnection()) return false;

                try
                {
                    if (o_Connection.FileExists(Config.BackupName + "/" + s_Source))
                    {
                        o_Connection.DeleteFile(Config.BackupName + "/" +s_Source);
                    }
                }
                catch (Exception e_Info)
                {
                    Console.WriteLine(e_Info);
                    e_Error = e_Info;
                    if (!CloseConnection()) return false;
                    return false;
                }
                if (!CloseConnection()) return false;
                return true;
            }
        }

    }
}
