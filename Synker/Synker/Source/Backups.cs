using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Threading;

namespace Synker
{
    public static partial class Synchronization
    {
        public static bool CreateBackup()
        {
            string s_Name =  DateTime.Now.Minute + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".zip";
            Log("Creating Backup "+s_Name,true,false);
            try
            {
                ZipFile.CreateFromDirectory(Config.Path, Config.PrePath + "\\" + s_Name);
                Log(" ... OKAY", false, true, 1);
            }
            catch (Exception e_Info)
            {
                Console.WriteLine(e_Info);
                e_Error = e_Info;
                Log(" ... ERROR", false, true, 2);

                return false;
            }
            Thread.Sleep(1000);
            Log("Started Uploading Backup.");
            if (!UploadBackupFile(s_Name))
            {
                Log("Failed Uploading Backup.", false, false, 2);
                if(File.Exists(Config.PrePath + "\\" + s_Name))File.Delete(Config.PrePath + "\\" + s_Name);
                return false;
            }
            if (File.Exists(Config.PrePath + "\\" + s_Name)) File.Delete(Config.PrePath + "\\" + s_Name);
            Log("Finished Uploading Backup.", false, false, 1);
            return true;
        }
        public static bool DeleteBackup(string s_Source)
        {
            Log("Deleting Backup: " + s_Source, true, false);
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.DeleteBackup(s_Source) == true)
                {
                    Log(" ... OKAY", false, true, 1);
                    return true;
                }
                Log(" ... A(" + i_Trys + ")", true, true, 2);
                Thread.Sleep(Config.RetryDelay);
            }
            Log(" ... FAILED!", false, true, 2);
            Log(LastError.Source + "->" + LastError.GetType() + ":\n" + LastError.StackTrace, false, false, 2);

            return false;
        }
        public static bool LoadBackup(string s_Source)
        {
            if (!DownloadBackupFile(s_Source))
            {
                if (File.Exists(Config.PrePath + "\\" + s_Source)) File.Delete(Config.PrePath + "\\" + s_Source);
                Log("Failed Downloading Backup.", false, false, 2);
                return false;
            }

            Log("Preparing folder(s)", true, false);
            try
            {
                foreach (string s_File in Directory.GetFileSystemEntries(Config.Path, "*", SearchOption.TopDirectoryOnly))
                {
                    if (Directory.Exists(s_File))
                    {
                        Directory.Delete(s_File,true);
                    }
                    if (File.Exists(s_File))
                    {
                        FileInfo o_Info = new FileInfo(s_File);
                        if (!o_Info.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            o_Info.Delete();
                        }
                    }
                }
                if (!Directory.Exists(Config.PrePath + "\\"+Config.BackupTemp))
                {
                    Directory.CreateDirectory(Config.PrePath + "\\"+Config.BackupTemp);
                }
                Log(" ... OKAY", false, true, 1);
            }
            catch (Exception e_Info)
            {
                Console.WriteLine(e_Info);
                e_Error = e_Info;
                Log(" ... ERROR", false, true, 2);
                return false;
            }

            Log("Unzipping Backup " + s_Source, true, false);
            try
            {
                ZipFile.ExtractToDirectory(Config.PrePath + "\\" + s_Source, Config.PrePath + "\\synker_temp");
                Log(" ... OKAY", false, true, 1);
            }
            catch (Exception e_Info)
            {
                Console.WriteLine(e_Info);
                e_Error = e_Info;
                Log(" ... ERROR", false, true, 2);
                return false;
            }

            Log("Moving files"+ s_Source, true, false);
            try
            {
                foreach (string s_File in Directory.GetFileSystemEntries(Config.PrePath + "\\" + Config.BackupTemp, "*", SearchOption.TopDirectoryOnly))
                {
                    if (Directory.Exists(s_File))
                    {
                        Directory.Move(s_File, s_File.Replace(Config.BackupTemp, Config.Name));
                    }
                    if (File.Exists(s_File))
                    {
                        if (!File.Exists(s_File.Replace(Config.BackupTemp, Config.Name)))
                        {
                            File.Move(s_File, s_File.Replace(Config.BackupTemp, Config.Name));
                        }
                    }
                }
                Log(" ... OKAY", false, true, 1);
            }
            catch (Exception e_Info)
            {
                Console.WriteLine(e_Info);
                e_Error = e_Info;
                Log(" ... ERROR", false, true, 2);
                return false;
            }

            if (File.Exists(Config.PrePath + "\\" + s_Source))
            {
                File.Delete(Config.PrePath + "\\" + s_Source);
            }
            if (Directory.Exists(Config.PrePath + "\\" + Config.BackupTemp))
            {
                Directory.Delete(Config.PrePath + "\\" + Config.BackupTemp, true);
            }
            return true;
        }
        public static bool ListBackups(out string[] s_Backups)
        {
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.FetchBackups(out s_Backups) == true)
                {
                    return true;
                }
                Thread.Sleep(Config.RetryDelay);
            }
            s_Backups = null;
            return false;
        }

        private static bool DownloadBackupFile(string s_Source)
        {
            Log("Downloading Backup: " + s_Source, true, false);
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.DownloadBackup(s_Source) == true)
                {
                    Log(" ... OKAY", false, true, 1);
                    return true;
                }
                Log(" ... A(" + i_Trys + ")", true, true, 2);
                Thread.Sleep(Config.RetryDelay);
            }
            Log(" ... FAILED!", false, true, 2);
            Log(LastError.Source + "->" + LastError.GetType() + ":\n" + LastError.StackTrace, false, false, 2);

            return false;
        }
        private static bool UploadBackupFile(string s_Source)
        {
            Log("Uploading Backup: " + s_Source, true, false);
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.UploadBackup(s_Source) == true)
                {
                    Log(" ... OKAY", false, true, 1);
                    return true;
                }
                Log(" ... A(" + i_Trys + ")", true, true, 2);
                Thread.Sleep(Config.RetryDelay);
            }
            Log(" ... FAILED!", false, true, 2);
            Log(LastError.Source + "->" + LastError.GetType() + ":\n" + LastError.StackTrace, false, false, 2);

            return false;
        }

    }
}
