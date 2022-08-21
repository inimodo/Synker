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
using System.Threading;



namespace Synker
{
    public partial class Connections : Form
    {
        private Loaddialog Logger = new Loaddialog();
        private ContextMenuStrip o_Menu = new ContextMenuStrip();
        private ToolStripMenuItem o_BackupList = new ToolStripMenuItem("Backups");

        public Connections()
        {
            InitializeComponent();
            InitializeMenu();
            Synchronization.Message += Message;
            Synchronization.Log += Logger.Log;
        }
        private void InitializeMenu()
        {         
            eSynkerMenu.ContextMenuStrip = new ContextMenuStrip();
            eSynkerMenu.ContextMenuStrip.Items.Add("Synker", Synker.Properties.Resources.Logo, new EventHandler(Show));
            eSynkerMenu.ContextMenuStrip.Items.Add("Create new Backup", null, new EventHandler(CreateBackup));
            eSynkerMenu.ContextMenuStrip.Items.Add(o_BackupList);
            eSynkerMenu.ContextMenuStrip.Items.Add("Force Push", Synker.Properties.Resources.Upload1, new EventHandler(ForcePush));
            eSynkerMenu.ContextMenuStrip.Items.Add("Force Pull", Synker.Properties.Resources.Download1, new EventHandler(ForcePull));
            eSynkerMenu.ContextMenuStrip.Items.Add("Close", Synker.Properties.Resources.Quit, new EventHandler(Close));
            eSynkerMenu.ContextMenuStrip.Items[0].Font = new Font(eSynkerMenu.ContextMenuStrip.Items[0].Font, FontStyle.Bold);
            eSynkerMenu.ContextMenuStrip.Items[5].Font = new Font(eSynkerMenu.ContextMenuStrip.Items[4].Font, FontStyle.Bold);
        }
        private  void LoadBackupList()
        {
            string[] s_Backups;
            if (Synchronization.ListBackups(out s_Backups))
            {
                if (s_Backups != null)
                {
                    o_BackupList.DropDownItems.Clear();
                    foreach (string s_Backup in s_Backups)
                    {
                        ToolStripMenuItem o_Menu = new ToolStripMenuItem(s_Backup);
                        o_BackupList.DropDownItems.Add(o_Menu);
                        o_Menu.DropDownItems.Add("Pull", Synker.Properties.Resources.Download1, new EventHandler(LoadBackup));
                        o_Menu.DropDownItems.Add("Delete", Synker.Properties.Resources.Quit, new EventHandler(DeleteBackup));
                    }
                }
            }
            else
            {
                Message("Backup Listing", "Listing failed: " + Synchronization.LastError.GetType(), true);
            }
        }

        private async void DeleteBackup(object o_Sender, EventArgs o_Args)
        {
            string s_Name = (o_Sender as ToolStripMenuItem).OwnerItem.ToString();
            Logger.OpenWindow();
            await Task.Run(() =>
            {
                if (Synchronization.DeleteBackup(s_Name))
                {
                    Message("Deleting Backup", "Backup deletion was successful!", false);
                }
                else
                {
                    Message("Deleting Backup", "Backup deletion failed: " + Synchronization.LastError.GetType(), true);
                }
            });
            LoadBackupList();
        }
        private async void LoadBackup(object o_Sender, EventArgs o_Args)
        {
            string s_Name = (o_Sender as ToolStripMenuItem).OwnerItem.ToString();
            Logger.OpenWindow();
            await Task.Run(() =>
            {
                if (Synchronization.LoadBackup(s_Name))
                {
                    Message("Loading Backup", "Backup was loaded successful!", false);
                }
                else
                {
                    Message("Loading Backup", "Backup loading failed: " + Synchronization.LastError.GetType(), true);
                }
            });
        }
        private async void CreateBackup(object o_Sender, EventArgs o_Args)
        {
            Logger.OpenWindow();
            await Task.Run(() => {
                if (Synchronization.CreateBackup())
                {
                    Message("Create Backup", "Backup creation was successful!", false);
                }
                else
                {
                    Message("Create Backup", "Backup creation failed: " + Synchronization.LastError.GetType(), true);
                }
            });
            LoadBackupList();
        }

        private async void ForcePull(object o_Sender, EventArgs o_Args)
        {
            Logger.OpenWindow();
            await Task.Run(() => {
                if (Synchronization.UpdateListing())
                {
                    if (Synchronization.ForcePull())
                    {
                        Message("Force Pull", "Download was successful!", false);
                    }
                    else
                    {
                        Message("Force Pull failed", "Download failed: " + Synchronization.LastError.GetType(), true);
                    }
                }
                else
                {
                    Message("Listing failed ", "Listing failed: " + Synchronization.LastError.GetType(), true);
                }
            });
        }
        private async void ForcePush(object o_Sender, EventArgs o_Args)
        {
            Logger.OpenWindow();
            await Task.Run(() => {
                if (Synchronization.UpdateListing())
                {
                    if (Synchronization.ForcePush())
                    {
                        Message("Force Push", "Upload was successful!", false);
                    }
                    else
                    {
                        Message("Force Push", "Upload failed: " + Synchronization.LastError.GetType(), true);
                    }
                }
                else
                {
                    Message("Listing failed ", "Listing failed: " + Synchronization.LastError.GetType(), true);
                }
            });
        }

        private void Close(object o_Sender, EventArgs o_Args)
        {
            Application.Exit();
        }

        private void Loaded(object o_Sender, EventArgs o_Args)
        {
            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            if (FTP.Default.connected)
            {
                Synchronization.InitializeConnection();
                LoadBackupList();
            }
        }
        private void Message(string s_Title, string s_Message,bool b_isError)
        {
            if (b_isError) {
                this.eSynkerMenu.ShowBalloonTip(1000, s_Title, s_Message, ToolTipIcon.Error);
            }else {
                this.eSynkerMenu.ShowBalloonTip(1000, s_Title, s_Message, ToolTipIcon.Info);
            }
        }
        private void Connect(object o_Sender, EventArgs o_Args)
        {
            Exception e_Valid;
            if (Credentials.Validate(eServerInput.Text, eUserInput.Text, ePasswordInput.Text,out e_Valid))
            {
                Credentials.Connect(eServerInput.Text, eUserInput.Text, ePasswordInput.Text);

                if (FTP.Default.connected)
                {
                    Synchronization.InitializeConnection();
                }
                eConnectionError.Clear();
                Display(o_Sender, o_Args);
            }
            else
            {
                eConnectionOkay.Clear();
                eConnectionError.SetError(eConnectButton,e_Valid.Message);
            }
        }
        private void Disconnect(object o_Sender, EventArgs o_Args)
        {
            Credentials.Disconnect();
            eServerInput.Text = "";
            eUserInput.Text = "";
            ePasswordInput.Text = "";

            Display(o_Sender, o_Args);
        }
        private void Display(object o_Sender, EventArgs o_Args)
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

                eSynkerMenu.ContextMenuStrip.Items[1].Enabled = true;
                eSynkerMenu.ContextMenuStrip.Items[2].Enabled = true;
                eSynkerMenu.ContextMenuStrip.Items[3].Enabled = true;
            }
            else
            {
                eSynkerMenu.ContextMenuStrip.Items[1].Enabled = false;
                eSynkerMenu.ContextMenuStrip.Items[2].Enabled = false;
                eSynkerMenu.ContextMenuStrip.Items[3].Enabled = false;
                eConnectButton.Show();
                eDisconnectButton.Hide();
            }
        }
 
        private void Abort(object o_Sender, EventArgs o_Args)
        {
            this.Hide();
        }
        private void Show(object o_Sender, EventArgs o_Args)
        {
            this.Show();
        }


    }
}