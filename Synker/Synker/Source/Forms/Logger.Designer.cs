namespace Synker
{
    partial class Loaddialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loaddialog));
            this.eCloseButton = new System.Windows.Forms.Button();
            this.eBG = new System.Windows.Forms.Panel();
            this.eSaveButton = new System.Windows.Forms.Button();
            this.eLogTextbox = new System.Windows.Forms.RichTextBox();
            this.eBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // eCloseButton
            // 
            this.eCloseButton.BackColor = System.Drawing.Color.Transparent;
            this.eCloseButton.BackgroundImage = global::Synker.Properties.Resources.Close;
            this.eCloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eCloseButton.FlatAppearance.BorderSize = 0;
            this.eCloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.eCloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.eCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eCloseButton.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eCloseButton.ForeColor = System.Drawing.Color.White;
            this.eCloseButton.Location = new System.Drawing.Point(493, 11);
            this.eCloseButton.Name = "eCloseButton";
            this.eCloseButton.Size = new System.Drawing.Size(24, 24);
            this.eCloseButton.TabIndex = 16;
            this.eCloseButton.TabStop = false;
            this.eCloseButton.UseVisualStyleBackColor = false;
            this.eCloseButton.Click += new System.EventHandler(this.CloseWindow);
            // 
            // eBG
            // 
            this.eBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.eBG.Controls.Add(this.eSaveButton);
            this.eBG.Controls.Add(this.eCloseButton);
            this.eBG.Controls.Add(this.eLogTextbox);
            this.eBG.Location = new System.Drawing.Point(1, 1);
            this.eBG.Name = "eBG";
            this.eBG.Size = new System.Drawing.Size(550, 245);
            this.eBG.TabIndex = 21;
            // 
            // eSaveButton
            // 
            this.eSaveButton.BackColor = System.Drawing.Color.Transparent;
            this.eSaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.eSaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.eSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eSaveButton.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eSaveButton.ForeColor = System.Drawing.Color.White;
            this.eSaveButton.Location = new System.Drawing.Point(387, 11);
            this.eSaveButton.Name = "eSaveButton";
            this.eSaveButton.Size = new System.Drawing.Size(100, 24);
            this.eSaveButton.TabIndex = 19;
            this.eSaveButton.Text = "Save as .log";
            this.eSaveButton.UseVisualStyleBackColor = false;
            this.eSaveButton.Click += new System.EventHandler(this.SaveLog);
            // 
            // eLogTextbox
            // 
            this.eLogTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(26)))));
            this.eLogTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eLogTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eLogTextbox.ForeColor = System.Drawing.Color.White;
            this.eLogTextbox.Location = new System.Drawing.Point(3, 3);
            this.eLogTextbox.Name = "eLogTextbox";
            this.eLogTextbox.ReadOnly = true;
            this.eLogTextbox.Size = new System.Drawing.Size(544, 239);
            this.eLogTextbox.TabIndex = 18;
            this.eLogTextbox.Text = "";
            this.eLogTextbox.WordWrap = false;
            // 
            // Loaddialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(552, 247);
            this.Controls.Add(this.eBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loaddialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loaddialog";
            this.TopMost = true;
            this.eBG.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button eCloseButton;
        private System.Windows.Forms.Panel eBG;
        private System.Windows.Forms.RichTextBox eLogTextbox;
        private System.Windows.Forms.Button eSaveButton;
    }
}