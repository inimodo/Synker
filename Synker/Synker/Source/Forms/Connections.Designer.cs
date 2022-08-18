namespace Synker
{
    partial class Connections
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connections));
            this.eSynkerMenu = new System.Windows.Forms.NotifyIcon(this.components);
            this.eServerInput = new System.Windows.Forms.TextBox();
            this.eServerLabel = new System.Windows.Forms.Label();
            this.eUserLabel = new System.Windows.Forms.Label();
            this.eUserInput = new System.Windows.Forms.TextBox();
            this.ePasswordLabel = new System.Windows.Forms.Label();
            this.ePasswordInput = new System.Windows.Forms.TextBox();
            this.eConnectButton = new System.Windows.Forms.Button();
            this.eStatusLabel = new System.Windows.Forms.Label();
            this.eConnectionError = new System.Windows.Forms.ErrorProvider(this.components);
            this.eLogo = new System.Windows.Forms.Button();
            this.eConnectionOkay = new System.Windows.Forms.ErrorProvider(this.components);
            this.eDisconnectButton = new System.Windows.Forms.Button();
            this.ePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.eConnectionError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eConnectionOkay)).BeginInit();
            this.ePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // eSynkerMenu
            // 
            this.eSynkerMenu.Icon = ((System.Drawing.Icon)(resources.GetObject("eSynkerMenu.Icon")));
            this.eSynkerMenu.Text = "Synker";
            this.eSynkerMenu.Visible = true;
            // 
            // eServerInput
            // 
            this.eServerInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.eServerInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eServerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eServerInput.ForeColor = System.Drawing.Color.White;
            this.eServerInput.Location = new System.Drawing.Point(72, 44);
            this.eServerInput.Name = "eServerInput";
            this.eServerInput.Size = new System.Drawing.Size(147, 21);
            this.eServerInput.TabIndex = 0;
            // 
            // eServerLabel
            // 
            this.eServerLabel.AutoSize = true;
            this.eServerLabel.BackColor = System.Drawing.Color.Transparent;
            this.eServerLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eServerLabel.ForeColor = System.Drawing.Color.White;
            this.eServerLabel.Location = new System.Drawing.Point(10, 46);
            this.eServerLabel.Name = "eServerLabel";
            this.eServerLabel.Size = new System.Drawing.Size(42, 18);
            this.eServerLabel.TabIndex = 1;
            this.eServerLabel.Text = "Server";
            // 
            // eUserLabel
            // 
            this.eUserLabel.AutoSize = true;
            this.eUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.eUserLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold);
            this.eUserLabel.ForeColor = System.Drawing.Color.White;
            this.eUserLabel.Location = new System.Drawing.Point(10, 73);
            this.eUserLabel.Name = "eUserLabel";
            this.eUserLabel.Size = new System.Drawing.Size(30, 18);
            this.eUserLabel.TabIndex = 3;
            this.eUserLabel.Text = "User";
            // 
            // eUserInput
            // 
            this.eUserInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.eUserInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eUserInput.ForeColor = System.Drawing.Color.White;
            this.eUserInput.Location = new System.Drawing.Point(72, 71);
            this.eUserInput.Name = "eUserInput";
            this.eUserInput.Size = new System.Drawing.Size(147, 21);
            this.eUserInput.TabIndex = 2;
            // 
            // ePasswordLabel
            // 
            this.ePasswordLabel.AutoSize = true;
            this.ePasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.ePasswordLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold);
            this.ePasswordLabel.ForeColor = System.Drawing.Color.White;
            this.ePasswordLabel.Location = new System.Drawing.Point(10, 100);
            this.ePasswordLabel.Name = "ePasswordLabel";
            this.ePasswordLabel.Size = new System.Drawing.Size(57, 18);
            this.ePasswordLabel.TabIndex = 5;
            this.ePasswordLabel.Text = "Password";
            // 
            // ePasswordInput
            // 
            this.ePasswordInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.ePasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ePasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ePasswordInput.ForeColor = System.Drawing.Color.White;
            this.ePasswordInput.Location = new System.Drawing.Point(72, 98);
            this.ePasswordInput.Name = "ePasswordInput";
            this.ePasswordInput.PasswordChar = '*';
            this.ePasswordInput.Size = new System.Drawing.Size(147, 21);
            this.ePasswordInput.TabIndex = 4;
            // 
            // eConnectButton
            // 
            this.eConnectButton.BackColor = System.Drawing.Color.Transparent;
            this.eConnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.eConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.eConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eConnectButton.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eConnectButton.ForeColor = System.Drawing.Color.White;
            this.eConnectButton.Location = new System.Drawing.Point(119, 125);
            this.eConnectButton.Name = "eConnectButton";
            this.eConnectButton.Size = new System.Drawing.Size(100, 24);
            this.eConnectButton.TabIndex = 8;
            this.eConnectButton.Text = "Connect";
            this.eConnectButton.UseVisualStyleBackColor = false;
            this.eConnectButton.Click += new System.EventHandler(this.Connect);
            // 
            // eStatusLabel
            // 
            this.eStatusLabel.AutoSize = true;
            this.eStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.eStatusLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eStatusLabel.ForeColor = System.Drawing.Color.White;
            this.eStatusLabel.Location = new System.Drawing.Point(44, 13);
            this.eStatusLabel.Name = "eStatusLabel";
            this.eStatusLabel.Size = new System.Drawing.Size(54, 23);
            this.eStatusLabel.TabIndex = 12;
            this.eStatusLabel.Text = "Synker";
            // 
            // eConnectionError
            // 
            this.eConnectionError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.eConnectionError.ContainerControl = this;
            this.eConnectionError.Icon = ((System.Drawing.Icon)(resources.GetObject("eConnectionError.Icon")));
            this.eConnectionError.RightToLeft = true;
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
            this.eLogo.Location = new System.Drawing.Point(13, 13);
            this.eLogo.Name = "eLogo";
            this.eLogo.Size = new System.Drawing.Size(25, 25);
            this.eLogo.TabIndex = 11;
            this.eLogo.UseVisualStyleBackColor = false;
            this.eLogo.Click += new System.EventHandler(this.Abort);
            // 
            // eConnectionOkay
            // 
            this.eConnectionOkay.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.eConnectionOkay.ContainerControl = this;
            this.eConnectionOkay.Icon = ((System.Drawing.Icon)(resources.GetObject("eConnectionOkay.Icon")));
            this.eConnectionOkay.RightToLeft = true;
            // 
            // eDisconnectButton
            // 
            this.eDisconnectButton.BackColor = System.Drawing.Color.Transparent;
            this.eDisconnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.eDisconnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.eDisconnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eDisconnectButton.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eDisconnectButton.ForeColor = System.Drawing.Color.White;
            this.eDisconnectButton.Location = new System.Drawing.Point(119, 125);
            this.eDisconnectButton.Name = "eDisconnectButton";
            this.eDisconnectButton.Size = new System.Drawing.Size(100, 24);
            this.eDisconnectButton.TabIndex = 8;
            this.eDisconnectButton.Text = "Disconnect";
            this.eDisconnectButton.UseVisualStyleBackColor = false;
            this.eDisconnectButton.Click += new System.EventHandler(this.Disconnect);
            // 
            // ePanel
            // 
            this.ePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.ePanel.Controls.Add(this.eLogo);
            this.ePanel.Controls.Add(this.eStatusLabel);
            this.ePanel.Controls.Add(this.eServerInput);
            this.ePanel.Controls.Add(this.eServerLabel);
            this.ePanel.Controls.Add(this.eDisconnectButton);
            this.ePanel.Controls.Add(this.eUserInput);
            this.ePanel.Controls.Add(this.eConnectButton);
            this.ePanel.Controls.Add(this.eUserLabel);
            this.ePanel.Controls.Add(this.ePasswordLabel);
            this.ePanel.Controls.Add(this.ePasswordInput);
            this.ePanel.Location = new System.Drawing.Point(1, 1);
            this.ePanel.Name = "ePanel";
            this.ePanel.Size = new System.Drawing.Size(231, 160);
            this.ePanel.TabIndex = 13;
            // 
            // Connections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(232, 162);
            this.Controls.Add(this.ePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connections";
            this.ShowInTaskbar = false;
            this.Text = "FTP Connection";
            this.Deactivate += new System.EventHandler(this.Abort);
            this.Load += new System.EventHandler(this.Loaded);
            this.Shown += new System.EventHandler(this.Display);
            this.VisibleChanged += new System.EventHandler(this.Display);
            this.Leave += new System.EventHandler(this.Abort);
            ((System.ComponentModel.ISupportInitialize)(this.eConnectionError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eConnectionOkay)).EndInit();
            this.ePanel.ResumeLayout(false);
            this.ePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon eSynkerMenu;
        private System.Windows.Forms.TextBox eServerInput;
        private System.Windows.Forms.Label eServerLabel;
        private System.Windows.Forms.Label eUserLabel;
        private System.Windows.Forms.TextBox eUserInput;
        private System.Windows.Forms.Label ePasswordLabel;
        private System.Windows.Forms.TextBox ePasswordInput;
        private System.Windows.Forms.Button eConnectButton;
        private System.Windows.Forms.Button eLogo;
        private System.Windows.Forms.Label eStatusLabel;
        private System.Windows.Forms.ErrorProvider eConnectionError;
        private System.Windows.Forms.ErrorProvider eConnectionOkay;
        private System.Windows.Forms.Button eDisconnectButton;
        private System.Windows.Forms.Panel ePanel;
    }
}