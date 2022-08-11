using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Using: https://www.nuget.org/packages/System.Net.FtpClient/
using System.Net.FtpClient;
using System.Threading;

namespace Synker
{

    // Responsible for file synchronization
    public static class Synchronization
    {

        public delegate void Callback(string s_Title,string s_Message, bool b_isError);

        public static event Callback CallbackToMain;

        private static FileSystemWatcher o_Watcher;
        private static Thread o_SyncThread;

        public static void Initialize()
        {
            o_Watcher = new FileSystemWatcher(Management.Path);
            o_SyncThread = new Thread(new ThreadStart(Routine));
            o_SyncThread.Start();
        }
        private static void Routine()
        {
            Callback Message = CallbackToMain;
            Message("Connected!", "Synchronization is now starting",false);
            while (FTP.Default.connected)
            {

                Thread.Sleep(1000);
            }
            
        }
    }
}
