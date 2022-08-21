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


namespace Synker
{
    public static partial class Synchronization
    {

        private static bool Pull()
        {
            // Checks if a file is present on server: if false delete it because it is no longer needed

            if (s_Server.Length != 1)
            {
                Thread.Sleep(Config.RetryDelay);
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
                Thread.Sleep(Config.RetryDelay);
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
                    if (!Download(s_Server[i_ServerIndex])) return false;
                }
                else if (DateTime.Compare(s_Server[i_ServerIndex].o_Modified, s_Local[i_IsOnLocal].o_Modified) > 0)
                {
                    if (!Download(s_Server[i_IsOnLocal])) return false;
                }
            }
            return true;
        }
        private static bool Push()
        {
            // Checks if a file is present on local: if false delete it because it is no longer needed

            if (s_Server.Length != 1)
            {
                Thread.Sleep(Config.RetryDelay);
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
                Thread.Sleep(Config.RetryDelay);
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
                    if (!Upload(s_Local[i_LocalIndex])) return false;
                }
                else if (DateTime.Compare(s_Local[i_LocalIndex].o_Modified, s_Server[i_IsOnServer].o_Modified) > 0)
                {
                    if (!Upload(s_Local[i_LocalIndex])) return false;
                }
            }
            return true;
        }
        private static bool DeleteLocal(FileObj s_Source)
        {
            Log("Delete Loacalfile: " + s_Source.s_File, true, false);
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.DeleteOnLocal(s_Source) == true)
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
        private static bool DeleteServer(FileObj s_Source)
        {
            Log("Delete Serverfile: " + s_Source.s_File, true, false);
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.DeleteFromServer(s_Source) == true)
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
        private static bool Download(FileObj s_Source)
        {
            Log("Downloading: " + s_Source.s_File, true, false);
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.DownloadFile(s_Source) == true)
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
        private static bool Upload(FileObj s_Source)
        {
            Log("Uploading: " + s_Source.s_File, true, false);
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.UploadFile(s_Source) == true)
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
        public static bool ForcePull()
        {
            Log("Started Downloading.");
            if (Pull())
            {
                Log("Finished Downloading.", false, false, 1);
                return true;
            }
            Log("Failed Downloading.", false, false, 2);
            return false;
        }

        public static bool ForcePush()
        {
            Log("Started Uploading.");
            if (Push())
            {
                Log("Finished Uploading.", false, false, 1);
                return true;
            }
            Log("Failed Uploading.", false, false, 2);
            return false;
        }
        public static bool UpdateListing()
        {
            Log("Started Listing", true, false);
            for (int i_Trys = 1; i_Trys < Config.Retries + 1; i_Trys++)
            {
                if (Base.FetchData() == true)
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
