namespace Synker
{
    partial class Installdialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installdialog));
            this.edesktopicoLabel = new System.Windows.Forms.Label();
            this.eStatusLabel = new System.Windows.Forms.Label();
            this.eLogo = new System.Windows.Forms.Button();
            this.eDesktopicoToggle = new System.Windows.Forms.CheckBox();
            this.eWinexToggle = new System.Windows.Forms.CheckBox();
            this.eWinexLabel = new System.Windows.Forms.Label();
            this.eDisconnectButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.eInstallpathLabel = new System.Windows.Forms.Label();
            this.eLinkLabel = new System.Windows.Forms.LinkLabel();
            this.eHelpLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // edesktopicoLabel
            // 
            this.edesktopicoLabel.AutoSize = true;
            this.edesktopicoLabel.BackColor = System.Drawing.Color.Transparent;
            this.edesktopicoLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edesktopicoLabel.ForeColor = System.Drawing.Color.White;
            this.edesktopicoLabel.Location = new System.Drawing.Point(12, 40);
            this.edesktopicoLabel.Name = "edesktopicoLabel";
            this.edesktopicoLabel.Size = new System.Drawing.Size(158, 18);
            this.edesktopicoLabel.TabIndex = 2;
            this.edesktopicoLabel.Text = "Would you like a Desktop icon?";
            // 
            // eStatusLabel
            // 
            this.eStatusLabel.AutoSize = true;
            this.eStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.eStatusLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eStatusLabel.ForeColor = System.Drawing.Color.White;
            this.eStatusLabel.Location = new System.Drawing.Point(43, 12);
            this.eStatusLabel.Name = "eStatusLabel";
            this.eStatusLabel.Size = new System.Drawing.Size(94, 23);
            this.eStatusLabel.TabIndex = 14;
            this.eStatusLabel.Text = "Synker Setup";
            // 
            // eLogo
            // 
            this.eLogo.BackColor = System.Drawing.Color.Transparent;
            this.eLogo.BackgroundImage = global::Synker.Properties.Resources.Logo;
            this.eLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eLogo.FlatAppearance.BorderSize = 0;
            this.eLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.eLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.eLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eLogo.ForeColor = System.Drawing.Color.Transparent;
            this.eLogo.Location = new System.Drawing.Point(12, 12);
            this.eLogo.Name = "eLogo";
            this.eLogo.Size = new System.Drawing.Size(25, 25);
            this.eLogo.TabIndex = 13;
            this.eLogo.UseVisualStyleBackColor = false;
            // 
            // eDesktopicoToggle
            // 
            this.eDesktopicoToggle.AutoSize = true;
            this.eDesktopicoToggle.Checked = true;
            this.eDesktopicoToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eDesktopicoToggle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eDesktopicoToggle.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eDesktopicoToggle.Location = new System.Drawing.Point(15, 61);
            this.eDesktopicoToggle.Name = "eDesktopicoToggle";
            this.eDesktopicoToggle.Size = new System.Drawing.Size(109, 20);
            this.eDesktopicoToggle.TabIndex = 15;
            this.eDesktopicoToggle.Text = "Create Desktop Icon";
            this.eDesktopicoToggle.UseVisualStyleBackColor = true;
            // 
            // eWinexToggle
            // 
            this.eWinexToggle.AutoSize = true;
            this.eWinexToggle.Checked = true;
            this.eWinexToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eWinexToggle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eWinexToggle.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9.75F);
            this.eWinexToggle.Location = new System.Drawing.Point(15, 109);
            this.eWinexToggle.Name = "eWinexToggle";
            this.eWinexToggle.Size = new System.Drawing.Size(161, 20);
            this.eWinexToggle.TabIndex = 15;
            this.eWinexToggle.Text = "Create Windows Explorer Folder";
            this.eWinexToggle.UseVisualStyleBackColor = true;
            // 
            // eWinexLabel
            // 
            this.eWinexLabel.AutoSize = true;
            this.eWinexLabel.BackColor = System.Drawing.Color.Transparent;
            this.eWinexLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eWinexLabel.ForeColor = System.Drawing.Color.White;
            this.eWinexLabel.Location = new System.Drawing.Point(12, 88);
            this.eWinexLabel.Name = "eWinexLabel";
            this.eWinexLabel.Size = new System.Drawing.Size(358, 18);
            this.eWinexLabel.TabIndex = 2;
            this.eWinexLabel.Text = "Would you like a pinned quick access folder in your Windows Explorer?";
            // 
            // eDisconnectButton
            // 
            this.eDisconnectButton.BackColor = System.Drawing.Color.Transparent;
            this.eDisconnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.eDisconnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.eDisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eDisconnectButton.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eDisconnectButton.ForeColor = System.Drawing.Color.White;
            this.eDisconnectButton.Location = new System.Drawing.Point(291, 139);
            this.eDisconnectButton.Name = "eDisconnectButton";
            this.eDisconnectButton.Size = new System.Drawing.Size(100, 24);
            this.eDisconnectButton.TabIndex = 16;
            this.eDisconnectButton.Text = "Finish";
            this.eDisconnectButton.UseVisualStyleBackColor = false;
            this.eDisconnectButton.Click += new System.EventHandler(this.Finish);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(185, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 24);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Cancel);
            // 
            // eInstallpathLabel
            // 
            this.eInstallpathLabel.AutoSize = true;
            this.eInstallpathLabel.BackColor = System.Drawing.Color.Transparent;
            this.eInstallpathLabel.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eInstallpathLabel.ForeColor = System.Drawing.Color.White;
            this.eInstallpathLabel.Location = new System.Drawing.Point(135, 22);
            this.eInstallpathLabel.Name = "eInstallpathLabel";
            this.eInstallpathLabel.Size = new System.Drawing.Size(7, 13);
            this.eInstallpathLabel.TabIndex = 17;
            this.eInstallpathLabel.Text = "\r\n";
            // 
            // eLinkLabel
            // 
            this.eLinkLabel.AutoSize = true;
            this.eLinkLabel.Location = new System.Drawing.Point(12, 150);
            this.eLinkLabel.Name = "eLinkLabel";
            this.eLinkLabel.Size = new System.Drawing.Size(112, 13);
            this.eLinkLabel.TabIndex = 18;
            this.eLinkLabel.TabStop = true;
            this.eLinkLabel.Text = "www.ucpsystems.com";
            this.eLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenLink);
            // 
            // eHelpLabel
            // 
            this.eHelpLabel.AutoSize = true;
            this.eHelpLabel.BackColor = System.Drawing.Color.Transparent;
            this.eHelpLabel.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eHelpLabel.ForeColor = System.Drawing.Color.White;
            this.eHelpLabel.Location = new System.Drawing.Point(12, 136);
            this.eHelpLabel.Name = "eHelpLabel";
            this.eHelpLabel.Size = new System.Drawing.Size(92, 14);
            this.eHelpLabel.TabIndex = 19;
            this.eHelpLabel.Text = "For help please vistit:";
            // 
            // Installdialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(403, 178);
            this.Controls.Add(this.eHelpLabel);
            this.Controls.Add(this.eLinkLabel);
            this.Controls.Add(this.eInstallpathLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.eDisconnectButton);
            this.Controls.Add(this.eWinexToggle);
            this.Controls.Add(this.eDesktopicoToggle);
            this.Controls.Add(this.eStatusLabel);
            this.Controls.Add(this.eLogo);
            this.Controls.Add(this.eWinexLabel);
            this.Controls.Add(this.edesktopicoLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Installdialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label edesktopicoLabel;
        private System.Windows.Forms.Label eStatusLabel;
        private System.Windows.Forms.Button eLogo;
        private System.Windows.Forms.CheckBox eDesktopicoToggle;
        private System.Windows.Forms.CheckBox eWinexToggle;
        private System.Windows.Forms.Label eWinexLabel;
        private System.Windows.Forms.Button eDisconnectButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label eInstallpathLabel;
        private System.Windows.Forms.LinkLabel eLinkLabel;
        private System.Windows.Forms.Label eHelpLabel;
    }
}