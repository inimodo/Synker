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
            this.eLinkLabel = new System.Windows.Forms.LinkLabel();
            this.eHelpLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ePathButton = new System.Windows.Forms.Button();
            this.ePathTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // edesktopicoLabel
            // 
            this.edesktopicoLabel.AutoSize = true;
            this.edesktopicoLabel.BackColor = System.Drawing.Color.Transparent;
            this.edesktopicoLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edesktopicoLabel.ForeColor = System.Drawing.Color.White;
            this.edesktopicoLabel.Location = new System.Drawing.Point(11, 100);
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
            this.eDesktopicoToggle.Location = new System.Drawing.Point(14, 121);
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
            this.eWinexToggle.Location = new System.Drawing.Point(14, 62);
            this.eWinexToggle.Name = "eWinexToggle";
            this.eWinexToggle.Size = new System.Drawing.Size(129, 20);
            this.eWinexToggle.TabIndex = 15;
            this.eWinexToggle.Text = "Pin in Windows Explorer";
            this.eWinexToggle.UseVisualStyleBackColor = true;
            // 
            // eWinexLabel
            // 
            this.eWinexLabel.AutoSize = true;
            this.eWinexLabel.BackColor = System.Drawing.Color.Transparent;
            this.eWinexLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eWinexLabel.ForeColor = System.Drawing.Color.White;
            this.eWinexLabel.Location = new System.Drawing.Point(11, 41);
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
            this.eDisconnectButton.Location = new System.Drawing.Point(281, 220);
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
            this.eLinkLabel.Location = new System.Drawing.Point(11, 231);
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
            this.eHelpLabel.Location = new System.Drawing.Point(11, 217);
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
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.eStatusLabel);
            this.panel1.Controls.Add(this.eHelpLabel);
            this.panel1.Controls.Add(this.edesktopicoLabel);
            this.panel1.Controls.Add(this.eLinkLabel);
            this.panel1.Controls.Add(this.eWinexLabel);
            this.panel1.Controls.Add(this.eLogo);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.eDesktopicoToggle);
            this.panel1.Controls.Add(this.eDisconnectButton);
            this.panel1.Controls.Add(this.eWinexToggle);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 255);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Synker.Properties.Resources.Winex;
            this.pictureBox1.Location = new System.Drawing.Point(207, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(175, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 24);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Cancel);
            // 
            // ePathButton
            // 
            this.ePathButton.BackColor = System.Drawing.Color.Transparent;
            this.ePathButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.ePathButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ePathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ePathButton.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ePathButton.ForeColor = System.Drawing.Color.White;
            this.ePathButton.Location = new System.Drawing.Point(324, 180);
            this.ePathButton.Name = "ePathButton";
            this.ePathButton.Size = new System.Drawing.Size(57, 24);
            this.ePathButton.TabIndex = 21;
            this.ePathButton.Text = "...";
            this.ePathButton.UseVisualStyleBackColor = false;
            this.ePathButton.Click += new System.EventHandler(this.OpenFolder);
            // 
            // ePathTextbox
            // 
            this.ePathTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.ePathTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ePathTextbox.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ePathTextbox.ForeColor = System.Drawing.Color.White;
            this.ePathTextbox.Location = new System.Drawing.Point(16, 182);
            this.ePathTextbox.Name = "ePathTextbox";
            this.ePathTextbox.ReadOnly = true;
            this.ePathTextbox.Size = new System.Drawing.Size(302, 19);
            this.ePathTextbox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Where should the working folder be?";
            // 
            // Installdialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 257);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Installdialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label edesktopicoLabel;
        private System.Windows.Forms.Label eStatusLabel;
        private System.Windows.Forms.Button eLogo;
        private System.Windows.Forms.CheckBox eDesktopicoToggle;
        private System.Windows.Forms.CheckBox eWinexToggle;
        private System.Windows.Forms.Label eWinexLabel;
        private System.Windows.Forms.Button eDisconnectButton;
        private System.Windows.Forms.LinkLabel eLinkLabel;
        private System.Windows.Forms.Label eHelpLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ePathTextbox;
        private System.Windows.Forms.Button ePathButton;
        private System.Windows.Forms.Button button1;
    }
}