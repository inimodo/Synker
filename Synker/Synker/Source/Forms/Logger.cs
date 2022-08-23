using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Synker
{
    public partial class Loaddialog : Form
    {
        public Loaddialog()
        {
            InitializeComponent();
        }
        public void CloseWindow()
        {
            try
            {
                this.Hide();
            }
            catch (Exception) { }
        }
        public void OpenWindow()
        {
            eLogTextbox.Text = "";
            this.Show();
            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        private void CloseWindow(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void Log(string s_Message,bool b_Nobreak = false,bool b_Nodate = false,int i_Status=0)
        {
            if (Config.ShowLog)
            {
                string s_Text = s_Message;
                if (!b_Nodate)
                {
                    DateTime o_Now = DateTime.Now;
                    AppendLog("[" + o_Now.ToLongTimeString() + "." + o_Now.Millisecond + "] ", Color.Yellow);
                }

                switch (i_Status)// 0 = Normal, 1 = Okay, 2 = Error
                {
                    case 0:
                        AppendLog(s_Text, Color.White);
                        break;
                    case 1:
                        AppendLog(s_Text, Color.FromArgb(0, 255, 0));
                        break;
                    case 2:
                        AppendLog(s_Text, Color.FromArgb(255, 0, 0));
                        break;
                }

                if (!b_Nobreak)
                {
                    AppendLog("\n", Color.White);
                }
            }
           
        }
        private void AppendLog(string s_Text, Color c_Color)
        {
            eLogTextbox.Invoke(new Action(() => {
                eLogTextbox.SelectionStart = eLogTextbox.TextLength;
                eLogTextbox.SelectionLength = 0;
                eLogTextbox.SelectionColor = c_Color;
                eLogTextbox.AppendText(s_Text);
                eLogTextbox.SelectionColor = eLogTextbox.ForeColor;
                eLogTextbox.ScrollToCaret();
            }));
        }
        private void SaveLog(object sender, EventArgs e)
        {
            SaveFileDialog o_Save = new SaveFileDialog();
            o_Save.DefaultExt = "log";
            o_Save.Title = "Save .log file";
            o_Save.FileName = DateTime.Now.Minute + "" + DateTime.Now.Hour + "" + DateTime.Now.Day + "" + DateTime.Now.Month + "" + DateTime.Now.Year + ".log";
            if (o_Save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter s_Writer = new StreamWriter(o_Save.FileName))
                {
                    s_Writer.Write(eLogTextbox.Text);
                    s_Writer.Flush();
                    s_Writer.Close();
                }
            }
        }
    }
}
