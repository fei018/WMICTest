namespace WMICTest
{
    partial class FormDomainInfo
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
            this.labelDomainUserName = new System.Windows.Forms.Label();
            this.labelDomainPassword = new System.Windows.Forms.Label();
            this.textBoxDomainUser = new System.Windows.Forms.TextBox();
            this.textBoxDomainPassword = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelDomainUserName
            // 
            this.labelDomainUserName.AutoSize = true;
            this.labelDomainUserName.Location = new System.Drawing.Point(5, 77);
            this.labelDomainUserName.Name = "labelDomainUserName";
            this.labelDomainUserName.Size = new System.Drawing.Size(65, 12);
            this.labelDomainUserName.TabIndex = 0;
            this.labelDomainUserName.Text = "User Name:";
            // 
            // labelDomainPassword
            // 
            this.labelDomainPassword.AutoSize = true;
            this.labelDomainPassword.Location = new System.Drawing.Point(5, 117);
            this.labelDomainPassword.Name = "labelDomainPassword";
            this.labelDomainPassword.Size = new System.Drawing.Size(59, 12);
            this.labelDomainPassword.TabIndex = 1;
            this.labelDomainPassword.Text = "Password:";
            // 
            // textBoxDomainUser
            // 
            this.textBoxDomainUser.Location = new System.Drawing.Point(76, 68);
            this.textBoxDomainUser.Name = "textBoxDomainUser";
            this.textBoxDomainUser.Size = new System.Drawing.Size(143, 21);
            this.textBoxDomainUser.TabIndex = 3;
            // 
            // textBoxDomainPassword
            // 
            this.textBoxDomainPassword.Location = new System.Drawing.Point(76, 108);
            this.textBoxDomainPassword.MaxLength = 40;
            this.textBoxDomainPassword.Name = "textBoxDomainPassword";
            this.textBoxDomainPassword.Size = new System.Drawing.Size(143, 21);
            this.textBoxDomainPassword.TabIndex = 4;
            this.textBoxDomainPassword.UseSystemPasswordChar = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(250, 152);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(354, 152);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(7, 12);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(422, 50);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "Enter the name and password of an account with permission to join the domain.";
            // 
            // FormDomainInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 187);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxDomainPassword);
            this.Controls.Add(this.textBoxDomainUser);
            this.Controls.Add(this.labelDomainPassword);
            this.Controls.Add(this.labelDomainUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormDomainInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Domain Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDomainUserName;
        private System.Windows.Forms.Label labelDomainPassword;
        private System.Windows.Forms.TextBox textBoxDomainUser;
        private System.Windows.Forms.TextBox textBoxDomainPassword;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBox3;
    }
}