using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

//Using: https://www.nuget.org/packages/System.Net.FtpClient/1.0.5824.34026
using System.Net.FtpClient;

namespace Synker
{
    public partial class Connections : Form
    {
        public Connections()
        {
            InitializeComponent();
        }
        private void Loaded(object sender, EventArgs e)
        {
            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            if (FTP.Default.connected)
            {
                Synchronization.CallbackToMain += CatchCallback;
                Synchronization.Initialize();
            }
        }
        private void CatchCallback(string s_Title, string s_Message,bool b_isError)
        {
            if (b_isError) {
                this.eSynkerMenu.ShowBalloonTip(2000, s_Title, s_Message, ToolTipIcon.Error);
            }else {
                this.eSynkerMenu.ShowBalloonTip(100, s_Title, s_Message, ToolTipIcon.Info);
            }
        }
        private void Connect(object sender, EventArgs e)
        {
            Exception e_Valid;
            if (Credentials.Validate(eServerInput.Text, eUserInput.Text, ePasswordInput.Text,out e_Valid))
            {
                Credentials.Connect(eServerInput.Text, eUserInput.Text, ePasswordInput.Text);

                Synchronization.Initialize();

                eConnectionError.Clear();
                Display(sender, e);
            }
            else
            {
                eConnectionOkay.Clear();
                eConnectionError.SetError(eConnectButton,e_Valid.Message);
            }
        }
        private void Disconnect(object sender, EventArgs e)
        {
            Credentials.Disconnect();
            eServerInput.Text = "";
            eUserInput.Text = "";
            ePasswordInput.Text = "";

            Display(sender,e);
        }
        private void Display(object sender, EventArgs e)
        {
            eConnectionOkay.Clear();
            eConnectionError.Clear();
            if (Credentials.Check())
            {
                eConnectButton.Hide();
                eDisconnectButton.Show();

                eServerInput.Text = FTP.Default.server;
                eUserInput.Text = FTP.Default.user;
                ePasswordInput.Text = Credentials.Security.Decrypt(FTP.Default.password);

                eConnectionOkay.SetError(eDisconnectButton, "Connected");
            }
            else
            {
                eConnectButton.Show();
                eDisconnectButton.Hide();
            }
        }
        private void Open(object sender, EventArgs e)
        {
            this.Show();
        }
        private void Abort(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}


/*
            Console.WriteLine(o_Connection.IsConnected);

            //Stream o_SourceFile = File.OpenRead("test.txt");
            //using (Stream o_DestinyStream = o_Connection.OpenWrite("test.txt") )
            //{
            //    o_SourceFile.CopyTo(o_DestinyStream);
            //}
            Stream  o_DestinyStream = File.OpenWrite("Download.jpg");
            using (Stream o_SourceFile = o_Connection.OpenRead("Download.jpg"))
            {
                Console.WriteLine("Start");
                o_SourceFile.CopyTo(o_DestinyStream);
                Console.WriteLine("Stop");

            }
*/
