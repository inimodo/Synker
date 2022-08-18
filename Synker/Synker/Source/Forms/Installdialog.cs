using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synker
{
    public partial class Installdialog : Form
    {
        public bool Success { get { return b_Success; } }
        private bool b_Success = false;
        public Installdialog()
        {
            InitializeComponent();
            this.eInstallpathLabel.Text ="@"+Management.Path;
        }

        private void Finish(object sender, EventArgs e)
        {
            b_Success = true;
            if (!Management.CreateFolder())
            {
                b_Success = false;
                MessageBox.Show("Something went wrong whilst creating the working directory! Closing", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (eDesktopicoToggle.Checked)
            {
                if (!Management.CreateDesktopIscon())
                {
                    MessageBox.Show("Something went wrong whilst creating the desktop icon! Continuing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (eWinexToggle.Checked)
            {
                if (!Management.CreateWinexIcon())
                {
                    MessageBox.Show("Something went wrong whilst creating the 'Windows Explorer' link! Continuing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
  
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            b_Success = false;
            this.Close();
        }

        private void OpenLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.ucpsystems.com/");
        }
    }
}
