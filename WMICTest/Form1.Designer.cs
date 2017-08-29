namespace WMICTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonLocal = new System.Windows.Forms.RadioButton();
            this.radioButtonRange = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOutPut = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxIPstart = new System.Windows.Forms.TextBox();
            this.textBoxIPend = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAdminPasswd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.buttonScan = new System.Windows.Forms.Button();
            this.labelInterface = new System.Windows.Forms.Label();
            this.buttonSelectInter = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonOutPutClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonExportIPList = new System.Windows.Forms.Button();
            this.textBoxDomainName = new System.Windows.Forms.TextBox();
            this.labelDomainName = new System.Windows.Forms.Label();
            this.buttonSendCommand = new System.Windows.Forms.Button();
            this.textBoxCommandLine = new System.Windows.Forms.TextBox();
            this.labelCommandLine = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelComputeName = new System.Windows.Forms.Label();
            this.textBoxNewComputerName = new System.Windows.Forms.TextBox();
            this.buttonRenameComputer = new System.Windows.Forms.Button();
            this.buttonJoinDomain = new System.Windows.Forms.Button();
            this.buttonShowProcess = new System.Windows.Forms.Button();
            this.buttonReboot = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.checkBoxLocalUser = new System.Windows.Forms.CheckBox();
            this.checkBoxDomainUser = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonLocal
            // 
            this.radioButtonLocal.AutoSize = true;
            this.radioButtonLocal.Location = new System.Drawing.Point(12, 12);
            this.radioButtonLocal.Name = "radioButtonLocal";
            this.radioButtonLocal.Size = new System.Drawing.Size(77, 16);
            this.radioButtonLocal.TabIndex = 0;
            this.radioButtonLocal.Text = "Local Lan";
            this.radioButtonLocal.UseVisualStyleBackColor = true;
            this.radioButtonLocal.CheckedChanged += new System.EventHandler(this.radioButtonLocal_CheckedChanged);
            // 
            // radioButtonRange
            // 
            this.radioButtonRange.AutoSize = true;
            this.radioButtonRange.Location = new System.Drawing.Point(12, 40);
            this.radioButtonRange.Name = "radioButtonRange";
            this.radioButtonRange.Size = new System.Drawing.Size(83, 16);
            this.radioButtonRange.TabIndex = 3;
            this.radioButtonRange.Text = "IP Range :";
            this.radioButtonRange.UseVisualStyleBackColor = true;
            this.radioButtonRange.CheckedChanged += new System.EventHandler(this.radioButtonRange_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxOutPut);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 579);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "OutPut";
            // 
            // textBoxOutPut
            // 
            this.textBoxOutPut.Location = new System.Drawing.Point(6, 291);
            this.textBoxOutPut.Multiline = true;
            this.textBoxOutPut.Name = "textBoxOutPut";
            this.textBoxOutPut.ReadOnly = true;
            this.textBoxOutPut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutPut.Size = new System.Drawing.Size(569, 282);
            this.textBoxOutPut.TabIndex = 2;
            this.textBoxOutPut.WordWrap = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnIP,
            this.columnPC});
            this.listView1.Font = new System.Drawing.Font("宋体", 10F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(569, 253);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnIP
            // 
            this.columnIP.Text = "IP Address";
            this.columnIP.Width = 217;
            // 
            // columnPC
            // 
            this.columnPC.Text = "Computer Name";
            this.columnPC.Width = 346;
            // 
            // textBoxIPstart
            // 
            this.textBoxIPstart.Location = new System.Drawing.Point(101, 39);
            this.textBoxIPstart.MaxLength = 15;
            this.textBoxIPstart.Name = "textBoxIPstart";
            this.textBoxIPstart.Size = new System.Drawing.Size(107, 21);
            this.textBoxIPstart.TabIndex = 4;
            // 
            // textBoxIPend
            // 
            this.textBoxIPend.Location = new System.Drawing.Point(231, 39);
            this.textBoxIPend.MaxLength = 3;
            this.textBoxIPend.Name = "textBoxIPend";
            this.textBoxIPend.Size = new System.Drawing.Size(31, 21);
            this.textBoxIPend.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "User Password:";
            // 
            // textBoxAdminPasswd
            // 
            this.textBoxAdminPasswd.Location = new System.Drawing.Point(770, 79);
            this.textBoxAdminPasswd.MaxLength = 40;
            this.textBoxAdminPasswd.Name = "textBoxAdminPasswd";
            this.textBoxAdminPasswd.Size = new System.Drawing.Size(200, 21);
            this.textBoxAdminPasswd.TabIndex = 15;
            this.textBoxAdminPasswd.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "New Password:";
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(157, 32);
            this.textBoxNewPassword.MaxLength = 40;
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(178, 21);
            this.textBoxNewPassword.TabIndex = 4;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(157, 59);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(116, 23);
            this.buttonChangePassword.TabIndex = 5;
            this.buttonChangePassword.Text = "Change Password";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(268, 37);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(81, 23);
            this.buttonScan.TabIndex = 7;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // labelInterface
            // 
            this.labelInterface.AutoSize = true;
            this.labelInterface.Location = new System.Drawing.Point(241, 12);
            this.labelInterface.Name = "labelInterface";
            this.labelInterface.Size = new System.Drawing.Size(0, 12);
            this.labelInterface.TabIndex = 2;
            // 
            // buttonSelectInter
            // 
            this.buttonSelectInter.Location = new System.Drawing.Point(101, 12);
            this.buttonSelectInter.Name = "buttonSelectInter";
            this.buttonSelectInter.Size = new System.Drawing.Size(134, 20);
            this.buttonSelectInter.TabIndex = 1;
            this.buttonSelectInter.Text = "Select Network Card";
            this.buttonSelectInter.UseVisualStyleBackColor = true;
            this.buttonSelectInter.Click += new System.EventHandler(this.buttonSelectInter_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 647);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(474, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 9;
            // 
            // buttonOutPutClear
            // 
            this.buttonOutPutClear.Location = new System.Drawing.Point(492, 647);
            this.buttonOutPutClear.Name = "buttonOutPutClear";
            this.buttonOutPutClear.Size = new System.Drawing.Size(95, 23);
            this.buttonOutPutClear.TabIndex = 10;
            this.buttonOutPutClear.Text = "OutPut Clear";
            this.buttonOutPutClear.UseVisualStyleBackColor = true;
            this.buttonOutPutClear.Click += new System.EventHandler(this.buttonOutPutClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonExportIPList);
            this.groupBox2.Controls.Add(this.textBoxDomainName);
            this.groupBox2.Controls.Add(this.labelDomainName);
            this.groupBox2.Controls.Add(this.buttonSendCommand);
            this.groupBox2.Controls.Add(this.textBoxCommandLine);
            this.groupBox2.Controls.Add(this.labelCommandLine);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxNewPassword);
            this.groupBox2.Controls.Add(this.labelComputeName);
            this.groupBox2.Controls.Add(this.textBoxNewComputerName);
            this.groupBox2.Controls.Add(this.buttonRenameComputer);
            this.groupBox2.Controls.Add(this.buttonJoinDomain);
            this.groupBox2.Controls.Add(this.buttonShowProcess);
            this.groupBox2.Controls.Add(this.buttonReboot);
            this.groupBox2.Controls.Add(this.buttonChangePassword);
            this.groupBox2.Location = new System.Drawing.Point(618, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 490);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command Box";
            // 
            // buttonExportIPList
            // 
            this.buttonExportIPList.Location = new System.Drawing.Point(8, 20);
            this.buttonExportIPList.Name = "buttonExportIPList";
            this.buttonExportIPList.Size = new System.Drawing.Size(114, 23);
            this.buttonExportIPList.TabIndex = 0;
            this.buttonExportIPList.Text = "Export IP List";
            this.buttonExportIPList.UseVisualStyleBackColor = true;
            this.buttonExportIPList.Click += new System.EventHandler(this.buttonExportIPList_Click);
            // 
            // textBoxDomainName
            // 
            this.textBoxDomainName.Location = new System.Drawing.Point(157, 191);
            this.textBoxDomainName.MaxLength = 40;
            this.textBoxDomainName.Name = "textBoxDomainName";
            this.textBoxDomainName.Size = new System.Drawing.Size(178, 21);
            this.textBoxDomainName.TabIndex = 10;
            // 
            // labelDomainName
            // 
            this.labelDomainName.AutoSize = true;
            this.labelDomainName.Location = new System.Drawing.Point(155, 176);
            this.labelDomainName.Name = "labelDomainName";
            this.labelDomainName.Size = new System.Drawing.Size(77, 12);
            this.labelDomainName.TabIndex = 9;
            this.labelDomainName.Text = "Domain Name:";
            // 
            // buttonSendCommand
            // 
            this.buttonSendCommand.Location = new System.Drawing.Point(118, 448);
            this.buttonSendCommand.Name = "buttonSendCommand";
            this.buttonSendCommand.Size = new System.Drawing.Size(114, 23);
            this.buttonSendCommand.TabIndex = 15;
            this.buttonSendCommand.Text = "Send Command";
            this.buttonSendCommand.UseVisualStyleBackColor = true;
            this.buttonSendCommand.Click += new System.EventHandler(this.buttonSendCommand_Click);
            // 
            // textBoxCommandLine
            // 
            this.textBoxCommandLine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCommandLine.Location = new System.Drawing.Point(6, 284);
            this.textBoxCommandLine.Multiline = true;
            this.textBoxCommandLine.Name = "textBoxCommandLine";
            this.textBoxCommandLine.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCommandLine.Size = new System.Drawing.Size(340, 158);
            this.textBoxCommandLine.TabIndex = 14;
            this.textBoxCommandLine.WordWrap = false;
            // 
            // labelCommandLine
            // 
            this.labelCommandLine.AutoSize = true;
            this.labelCommandLine.Location = new System.Drawing.Point(6, 269);
            this.labelCommandLine.Name = "labelCommandLine";
            this.labelCommandLine.Size = new System.Drawing.Size(89, 12);
            this.labelCommandLine.TabIndex = 13;
            this.labelCommandLine.Text = "Command Line :";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(6, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 3);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            // 
            // labelComputeName
            // 
            this.labelComputeName.AutoSize = true;
            this.labelComputeName.Location = new System.Drawing.Point(155, 99);
            this.labelComputeName.Name = "labelComputeName";
            this.labelComputeName.Size = new System.Drawing.Size(113, 12);
            this.labelComputeName.TabIndex = 6;
            this.labelComputeName.Text = "New Computer Name:";
            // 
            // textBoxNewComputerName
            // 
            this.textBoxNewComputerName.Location = new System.Drawing.Point(157, 114);
            this.textBoxNewComputerName.MaxLength = 15;
            this.textBoxNewComputerName.Name = "textBoxNewComputerName";
            this.textBoxNewComputerName.Size = new System.Drawing.Size(178, 21);
            this.textBoxNewComputerName.TabIndex = 7;
            // 
            // buttonRenameComputer
            // 
            this.buttonRenameComputer.Location = new System.Drawing.Point(157, 141);
            this.buttonRenameComputer.Name = "buttonRenameComputer";
            this.buttonRenameComputer.Size = new System.Drawing.Size(116, 23);
            this.buttonRenameComputer.TabIndex = 8;
            this.buttonRenameComputer.Text = "Rename Computer";
            this.buttonRenameComputer.UseVisualStyleBackColor = true;
            this.buttonRenameComputer.Click += new System.EventHandler(this.buttonRenameComputer_Click);
            // 
            // buttonJoinDomain
            // 
            this.buttonJoinDomain.Location = new System.Drawing.Point(157, 217);
            this.buttonJoinDomain.Name = "buttonJoinDomain";
            this.buttonJoinDomain.Size = new System.Drawing.Size(116, 23);
            this.buttonJoinDomain.TabIndex = 11;
            this.buttonJoinDomain.Text = "Join Domain";
            this.buttonJoinDomain.UseVisualStyleBackColor = true;
            this.buttonJoinDomain.Click += new System.EventHandler(this.buttonJoinDomain_Click);
            // 
            // buttonShowProcess
            // 
            this.buttonShowProcess.Location = new System.Drawing.Point(8, 59);
            this.buttonShowProcess.Name = "buttonShowProcess";
            this.buttonShowProcess.Size = new System.Drawing.Size(116, 23);
            this.buttonShowProcess.TabIndex = 1;
            this.buttonShowProcess.Text = "Show Processes";
            this.buttonShowProcess.UseVisualStyleBackColor = true;
            this.buttonShowProcess.Click += new System.EventHandler(this.buttonShowProcess_Click);
            // 
            // buttonReboot
            // 
            this.buttonReboot.Location = new System.Drawing.Point(8, 94);
            this.buttonReboot.Name = "buttonReboot";
            this.buttonReboot.Size = new System.Drawing.Size(116, 23);
            this.buttonReboot.TabIndex = 2;
            this.buttonReboot.Text = "Reboot Computer";
            this.buttonReboot.UseVisualStyleBackColor = true;
            this.buttonReboot.Click += new System.EventHandler(this.buttonReboot_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(699, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "User Name:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(770, 42);
            this.textBoxUserName.MaxLength = 40;
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(200, 21);
            this.textBoxUserName.TabIndex = 13;
            // 
            // checkBoxLocalUser
            // 
            this.checkBoxLocalUser.AutoSize = true;
            this.checkBoxLocalUser.Location = new System.Drawing.Point(770, 20);
            this.checkBoxLocalUser.Name = "checkBoxLocalUser";
            this.checkBoxLocalUser.Size = new System.Drawing.Size(78, 16);
            this.checkBoxLocalUser.TabIndex = 11;
            this.checkBoxLocalUser.Text = "LocalUser";
            this.checkBoxLocalUser.UseVisualStyleBackColor = true;
            this.checkBoxLocalUser.CheckedChanged += new System.EventHandler(this.checkBoxLocalUser_CheckedChanged);
            // 
            // checkBoxDomainUser
            // 
            this.checkBoxDomainUser.AutoSize = true;
            this.checkBoxDomainUser.Location = new System.Drawing.Point(854, 20);
            this.checkBoxDomainUser.Name = "checkBoxDomainUser";
            this.checkBoxDomainUser.Size = new System.Drawing.Size(84, 16);
            this.checkBoxDomainUser.TabIndex = 17;
            this.checkBoxDomainUser.Text = "DomainUser";
            this.checkBoxDomainUser.UseVisualStyleBackColor = true;
            this.checkBoxDomainUser.CheckedChanged += new System.EventHandler(this.checkBoxDomainUser_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 682);
            this.Controls.Add(this.checkBoxDomainUser);
            this.Controls.Add(this.checkBoxLocalUser);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonOutPutClear);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonSelectInter);
            this.Controls.Add(this.labelInterface);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.textBoxAdminPasswd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIPend);
            this.Controls.Add(this.textBoxIPstart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonRange);
            this.Controls.Add(this.radioButtonLocal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMICTest  v0.2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonLocal;
        private System.Windows.Forms.RadioButton radioButtonRange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOutPut;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnIP;
        private System.Windows.Forms.ColumnHeader columnPC;
        private System.Windows.Forms.TextBox textBoxIPstart;
        private System.Windows.Forms.TextBox textBoxIPend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAdminPasswd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Button buttonScan;
        public System.Windows.Forms.Label labelInterface;
        private System.Windows.Forms.Button buttonSelectInter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonOutPutClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonJoinDomain;
        private System.Windows.Forms.Button buttonShowProcess;
        private System.Windows.Forms.Button buttonReboot;
        private System.Windows.Forms.Button buttonRenameComputer;
        private System.Windows.Forms.Label labelComputeName;
        private System.Windows.Forms.TextBox textBoxNewComputerName;
        private System.Windows.Forms.Button buttonSendCommand;
        private System.Windows.Forms.TextBox textBoxCommandLine;
        private System.Windows.Forms.Label labelCommandLine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDomainName;
        private System.Windows.Forms.Label labelDomainName;
        private System.Windows.Forms.Button buttonExportIPList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxLocalUser;
        private System.Windows.Forms.CheckBox checkBoxDomainUser;
    }
}

