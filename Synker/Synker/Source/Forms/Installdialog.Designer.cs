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
            this.eStatusLabel = new System.Windows.Forms.Label();
            this.eLogo = new System.Windows.Forms.Button();
            this.eDesktopicoToggle = new System.Windows.Forms.CheckBox();
            this.eWinexToggle = new System.Windows.Forms.CheckBox();
            this.eDisconnectButton = new System.Windows.Forms.Button();
            this.eLinkLabel = new System.Windows.Forms.LinkLabel();
            this.eHelpLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ePathTextbox = new System.Windows.Forms.TextBox();
            this.ePathButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eStatusLabel
            // 
            this.eStatusLabel.AutoSize = true;
            this.eStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.eStatusLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eStatusLabel.ForeColor = System.Drawing.Color.White;
            this.eStatusLabel.Location = new System.Drawing.Point(47, 13);
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
            this.eLogo.Location = new System.Drawing.Point(16, 13);
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
            this.eDesktopicoToggle.Location = new System.Drawing.Point(14, 111);
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
            this.eWinexToggle.Location = new System.Drawing.Point(14, 85);
            this.eWinexToggle.Name = "eWinexToggle";
            this.eWinexToggle.Size = new System.Drawing.Size(129, 20);
            this.eWinexToggle.TabIndex = 15;
            this.eWinexToggle.Text = "Pin in Windows Explorer";
            this.eWinexToggle.UseVisualStyleBackColor = true;
            // 
            // eDisconnectButton
            // 
            this.eDisconnectButton.BackColor = System.Drawing.Color.Transparent;
            this.eDisconnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.eDisconnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.eDisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eDisconnectButton.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eDisconnectButton.ForeColor = System.Drawing.Color.White;
            this.eDisconnectButton.Location = new System.Drawing.Point(279, 164);
            this.eDisconnectButton.Name = "eDisconnectButton";
            this.eDisconnectButton.Size = new System.Drawing.Size(100, 24);
            this.eDisconnectButton.TabIndex = 16;
            this.eDisconnectButton.Text = "Finish";
            this.eDisconnectButton.UseVisualStyleBackColor = false;
            this.eDisconnectButton.Click += new System.EventHandler(this.Finish);
            // 
            // eLinkLabel
            // 
            this.eLinkLabel.AutoSize = true;
            this.eLinkLabel.Location = new System.Drawing.Point(9, 175);
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
            this.eHelpLabel.Location = new System.Drawing.Point(9, 161);
            this.eHelpLabel.Name = "eHelpLabel";
            this.eHelpLabel.Size = new System.Drawing.Size(92, 14);
            this.eHelpLabel.TabIndex = 19;
            this.eHelpLabel.Text = "For help please vistit:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ePathTextbox);
            this.panel1.Controls.Add(this.ePathButton);
            this.panel1.Controls.Add(this.eStatusLabel);
            this.panel1.Controls.Add(this.eHelpLabel);
            this.panel1.Controls.Add(this.eLinkLabel);
            this.panel1.Controls.Add(this.eLogo);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.eDesktopicoToggle);
            this.panel1.Controls.Add(this.eDisconnectButton);
            this.panel1.Controls.Add(this.eWinexToggle);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 205);
            this.panel1.TabIndex = 20;
            // 
            // ePathTextbox
            // 
            this.ePathTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.ePathTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePathTextbox.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ePathTextbox.ForeColor = System.Drawing.Color.White;
            this.ePathTextbox.Location = new System.Drawing.Point(14, 58);
            this.ePathTextbox.Name = "ePathTextbox";
            this.ePathTextbox.ReadOnly = true;
            this.ePathTextbox.Size = new System.Drawing.Size(302, 26);
            this.ePathTextbox.TabIndex = 22;
            // 
            // ePathButton
            // 
            this.ePathButton.BackColor = System.Drawing.Color.Transparent;
            this.ePathButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ePathButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ePathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ePathButton.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ePathButton.ForeColor = System.Drawing.Color.White;
            this.ePathButton.Location = new System.Drawing.Point(322, 58);
            this.ePathButton.Name = "ePathButton";
            this.ePathButton.Size = new System.Drawing.Size(57, 26);
            this.ePathButton.TabIndex = 21;
            this.ePathButton.Text = "...";
            this.ePathButton.UseVisualStyleBackColor = false;
            this.ePathButton.Click += new System.EventHandler(this.OpenFolder);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(173, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 24);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Cancel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Working Directory";
            // 
            // Installdialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 207);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Installdialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label eStatusLabel;
        private System.Windows.Forms.Button eLogo;
        private System.Windows.Forms.CheckBox eDesktopicoToggle;
        private System.Windows.Forms.CheckBox eWinexToggle;
        private System.Windows.Forms.Button eDisconnectButton;
        private System.Windows.Forms.LinkLabel eLinkLabel;
        private System.Windows.Forms.Label eHelpLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ePathTextbox;
        private System.Windows.Forms.Button ePathButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}