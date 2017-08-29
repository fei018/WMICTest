using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Management;


namespace WMICTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Enabled = true;
        }

        private void radioButtonRange_CheckedChanged(object sender, EventArgs e)
        {
            this.listView1.Enabled = true;
            this.labelInterface.Text = null;
            this.labelInterface.Enabled = false;
        }

        private void buttonScan_Click(object sender, EventArgs e)       //================================= 按下 Scan button
        {
            this.listSelectedIndexIPinfo.Clear();   //清空 listView1 選中 items index

            int radioSwitch = 0;
            if (!this.radioButtonLocal.Checked && !radioButtonRange.Checked)  //radioButtonLocal and radioButtonRange 都未選
            { radioSwitch = 1; }
            if (this.radioButtonLocal.Checked)                               //radioButtonLocal 選中
            { radioSwitch = 2; }
            if (this.radioButtonRange.Checked && this.textBoxIPend.Text != string.Empty)                               //radioButtonRange 選中
            { radioSwitch = 3; }
            if (this.radioButtonRange.Checked && this.textBoxIPend.Text == string.Empty)                               //radioButtonRange 選中
            { radioSwitch = 4; }

            switch (radioSwitch)
            {
                case 1:
                    MessageBox.Show("Select a radioButton");
                    break;

                case 2:
                    if (this.threadScanLocal != null)
                    {
                        if (this.threadScanLocal.ThreadState == ThreadState.Stopped && this.threadProgressBar1.ThreadState == ThreadState.Stopped)
                        {
                            this.ButtonScanCase2();
                        }
                        else
                        { MessageBox.Show("Scanning !"); }
                    }
                    else
                    {
                        this.ButtonScanCase2();
                    }
                    break;

                case 3:
                    if (this.taskScanIPRange != null)
                    {
                        if (this.taskScanIPRange.IsCompleted && this.taskProgressBar1.IsCompleted)
                        { this.ButtonScanCase3(); }
                        else { MessageBox.Show("Scanning !"); }
                    }
                    else { this.ButtonScanCase3(); }
                    break;
                
                case 4:

                    if (this.taskScanIPRange != null)
                    {
                        if (this.taskScanIPRange.IsCompleted && this.taskProgressBar1.IsCompleted)
                        { this.ButtonScanCase4(); }
                        else { MessageBox.Show("Scanning !"); }
                    }
                    else { this.ButtonScanCase4(); }
                    break;

                default:
                    break;
            }
        }

        private void buttonSelectInter_Click(object sender, EventArgs e) //================= "彈出form2", 按鈕: select interface
        {
            if (this.radioButtonLocal.Checked)
            {
                using (Form2 form2 = new Form2())
                {
                    form2.listBox1_AddItem();

                    if (form2.ShowDialog() == DialogResult.OK)
                    {
                        this.labelInterface.Enabled = true;
                        this.labelInterface.Text = IPandHost.LocalInterface.Description; //lable 顯示interface name 
                    }
                }
            }
        }

        private void buttonOutPutClear_Click(object sender, EventArgs e)    //================ 按下 OutPut Clear
        {
            this.textBoxOutPut.Clear();
        }

        private List<int> listSelectedIndexIPinfo = new List<int>();    //listView1 選中的item index List
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)     //=============== 觸發 listView1 item 選中事件
        {
            listSelectedIndexIPinfo.Clear();
            foreach (var ic in listView1.SelectedIndices)
            {
                this.listSelectedIndexIPinfo.Add(Convert.ToInt32(ic.ToString()));
            }
        }

        private void radioButtonFixIP_CheckedChanged(object sender, EventArgs e)    //======= 選中 IP Address radioButton 事件
        {
            this.listView1.Items.Clear();
            this.listSelectedIndexIPinfo.Clear();
            this.listView1.Enabled = false;
        }

        private void buttonShowProcess_Click(object sender, EventArgs e)        //============= 按下 Show Processes button
        {
            if (this.listSelectedIndexIPinfo.Count == 1)
            {
                this.textBoxOutPut.Clear();
                ButtonShowProcess();
            }
            else
            { MessageBox.Show("One IP Address only"); }
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)      //================ 按下 Change Password button
        {
            using (FormContinue formcontinue = new FormContinue())
            {
                if (formcontinue.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }

            if (this.listSelectedIndexIPinfo.Count > 0)
            {
                this.textBoxOutPut.Clear();
                ButtonChangePassword();
            }
            else
            {
                MessageBox.Show("Invalid IP Address or New Password");
            }
        }

        private void buttonRenameComputer_Click(object sender, EventArgs e)     //==================按下 Rename Computer button
        {
            using (FormContinue formcontinue = new FormContinue())
            {
                if (formcontinue.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }

            if (this.listSelectedIndexIPinfo.Count == 1 && Regex.IsMatch(this.textBoxNewComputerName.Text, IPandHost.RegexComputerName))
            {
                this.textBoxOutPut.Clear();
                ButtonRenameComputer();
            }
            else
            {
                MessageBox.Show("One IP Address only or Valid Computer Name\r\nComputer Name include only: \"0-9,a-z,A-Z,-\"");
            }
        }

        private void buttonReboot_Click(object sender, EventArgs e)     //==============按下  Reboot Computer
        {
            using (FormContinue formcontinue = new FormContinue())
            {
                if (formcontinue.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }

            if (this.listSelectedIndexIPinfo.Count > 0)
            {
                this.textBoxOutPut.Clear();
                ButtonReboot();
            }
            else
            { MessageBox.Show("Invalid IP Address"); }
        }

        private void buttonJoinDomain_Click(object sender, EventArgs e)     //=============按下 Join Domain
        {
            if (this.listSelectedIndexIPinfo.Count > 0 && this.textBoxDomainName.Text != "")
            {
                this.textBoxOutPut.Clear();
                ButtonJoinDomain();
            }
            else
            { MessageBox.Show("Invalid IP Address or Null Domain Name"); }
        }

        private void buttonSendCommand_Click(object sender, EventArgs e)        //==============按下 Send Command
        {
            using (FormContinue formcontinue = new FormContinue())
            {
                if (formcontinue.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }

            if (this.listSelectedIndexIPinfo.Count > 0 && this.textBoxCommandLine.Text != "")
            {
                this.textBoxOutPut.Clear();
                ButtonSendCommand();
            }
            else
            {
                MessageBox.Show("Invalid IP Address or Command Line");
            }
        }

        private void buttonExportIPList_Click(object sender, EventArgs e)   //=========按下 Export IP List
        {
            if (this.listView1.Items.Count > 0)
            {
                string logPath = System.IO.Directory.GetCurrentDirectory() + "\\List_IPandHost.txt";
                if (System.IO.File.Exists(logPath))
                {
                    System.IO.File.Delete(logPath);
                }
                foreach (var item1 in IPandHost.ListIPinfo)
                {
                    System.IO.File.AppendAllText(logPath, string.Format("{0}    {1}\r\n", item1.ip.ToString(), item1.hostName));
                }
                MessageBox.Show("File Name: List_IPandHost.txt");
            }
            else
            { MessageBox.Show("Null Item"); }
        }

        private void checkBoxLocalUser_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxLocalUser.Checked)
            {
                this.checkBoxDomainUser.CheckState = CheckState.Unchecked;
            }
        }

        private void checkBoxDomainUser_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxDomainUser.Checked)
            {
                this.checkBoxLocalUser.CheckState = CheckState.Unchecked;
            }
        }


        //=======================================Functions=======================================================================================================================Functions=

        private Thread threadScanLocal;
        private Thread threadProgressBar1;
        private void ButtonScanCase2()      //==================== radioButtonLocal 選中 開始Scan
        {
            if (IPandHost.LocalIP != null && labelInterface.Enabled)
            {
                this.listView1.Items.Clear(); //掃描開始，清空 listView1 items
                this.groupBox2.Enabled = false;
                this.textBoxOutPut.Text = "Scanning Local Network...\r\n";
                IPandHost.ProgressBarCount = 0; // ProgressBar1.Value 清零
                this.progressBar1.Value = 0;
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 255;

                this.threadScanLocal = new Thread(() =>     // ScanIP() 線程
                    {
                        IPandHost ipANDhost = new IPandHost(); //new 一個 IPandHost 實例
                        ipANDhost.ScanIPs(IPandHost.LocalIP, 1, 255);
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("IP Address Sorting...\r\n");
                        }));
                        IPandHost.ListIPinfo.Sort(); // ip排序
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("Scan Done!\r\n");
                        }));

                        if (IPandHost.ListIPinfo.Count > 0)
                        {
                            this.Invoke(new Action(() =>
                            {
                                foreach (var i in IPandHost.ListIPinfo)
                                {
                                    ListViewItem lvi = new ListViewItem(new string[] { i.ip.ToString(), i.hostName });
                                    this.listView1.Items.Add(lvi);
                                }
                                this.groupBox2.Enabled = true;
                            }));
                        }
                    });

                this.threadProgressBar1 = new Thread(() =>     //建立 ProgressBar1 滾動任務 
                {
                    while (this.threadScanLocal.ThreadState != ThreadState.Stopped)
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (this.progressBar1.Value < IPandHost.ProgressBarCount)
                            {
                                ++this.progressBar1.Value;
                            }
                        }));
                    }
                    this.Invoke(new Action(() =>
                        {
                            this.progressBar1.Value = 255;
                        }));
                });

                this.threadScanLocal.Start();
                this.threadProgressBar1.Start();
            }
            else
            {
                MessageBox.Show("Select a valid interface");
            }
        }

        private Task taskScanIPRange;
        private Task taskProgressBar1;
        private void ButtonScanCase3()      //============================= radioButtonRange 選中 開始 Scan
        {
            IPAddress IPstart;
            IPandHost.ProgressBarCount = 0;
            this.progressBar1.Value = 0;
            this.progressBar1.Minimum = 0;

            if (Regex.IsMatch(this.textBoxIPstart.Text, IPandHost.RegexIP) && Regex.IsMatch(this.textBoxIPend.Text, @"(25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|[1-9])"))
            {
                IPstart = IPAddress.Parse(this.textBoxIPstart.Text);
                string[] arrayIPstart = this.textBoxIPstart.Text.Split(new char[] { '.' });
                int tmp1 = Convert.ToInt32(arrayIPstart[3]);
                int tmp2 = Convert.ToInt32(this.textBoxIPend.Text);

                if (tmp1 <= tmp2 && tmp2 <= 255)
                {
                    this.groupBox2.Enabled = false;
                    this.progressBar1.Maximum = ++tmp2;
                    this.textBoxOutPut.Text = "Scanning a Range Network...\r\n";
                    this.listView1.Items.Clear(); //掃描開始，清空 listView1 items

                    this.taskScanIPRange = Task.Factory.StartNew(() =>
                    {
                        IPandHost ipANDhost = new IPandHost(); //new 一個 IPandHost 實例
                        ipANDhost.ScanIPs(IPstart, tmp1, tmp2);
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("IP Address Sorting...\r\n");
                        }));
                        IPandHost.ListIPinfo.Sort(); // ip排序
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("Scan Done!\r\n");
                        }));

                        if (IPandHost.ListIPinfo.Count > 0)
                        {
                            this.Invoke(new Action(() =>
                            {
                                foreach (var i in IPandHost.ListIPinfo)
                                {
                                    ListViewItem lvi = new ListViewItem(new string[] { i.ip.ToString(), i.hostName });
                                    this.listView1.Items.Add(lvi);
                                }
                                this.groupBox2.Enabled = true;
                            }));
                        }                        
                    });

                    this.taskProgressBar1 = Task.Factory.StartNew(() =>     //建立 ProgressBar1 滾動任務 
                    {
                        while (!(this.taskScanIPRange.IsCompleted))
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (this.progressBar1.Value < IPandHost.ProgressBarCount)
                                {
                                    ++this.progressBar1.Value;
                                }
                            }));
                        }
                        this.Invoke(new Action(() =>
                        {
                            this.progressBar1.Value = tmp2;
                        }));
                    });
                }
                else
                {
                    MessageBox.Show("Type a valid IP Address");
                }
            }
            else
            {
                MessageBox.Show("Type a valid IP Address");
            }
        }

        private void ButtonScanCase4()      //================ 掃描單一IP
        {
            if (Regex.IsMatch(this.textBoxIPstart.Text, IPandHost.RegexIP))
            {
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = 100;
                this.progressBar1.Value = 0;

                IPAddress ip1 = IPAddress.Parse(this.textBoxIPstart.Text);
                this.textBoxOutPut.Text = "Scanning...\r\n";
                this.listView1.Items.Clear(); //掃描開始，清空 listView1 items                                

                this.taskScanIPRange = Task.Factory.StartNew(() =>
                {                                        
                    IPandHost ipANDhost = new IPandHost(); //new 一個 IPandHost 實例
                    ipANDhost.ScanOneIP(ip1);                   

                    this.Invoke(new Action(() =>
                    {
                        this.textBoxOutPut.AppendText("Scan Done!\r\n");
                    }));

                    if (IPandHost.ListIPinfo.Count > 0)
                    {
                        this.Invoke(new Action(() =>
                        {
                            foreach (var i in IPandHost.ListIPinfo)
                            {
                                ListViewItem lvi = new ListViewItem(new string[] { i.ip.ToString(), i.hostName });
                                this.listView1.Items.Add(lvi);
                            }
                        })); 
                    }                    
                });

                this.taskProgressBar1 = Task.Factory.StartNew(() =>     //建立 ProgressBar1 滾動任務 
                {                    
                    Task.WaitAny(taskScanIPRange);
                    this.Invoke(new Action(() =>
                    {
                        this.progressBar1.Value = 100;
                    }));
                });
            }
            else
            {
                MessageBox.Show("Type a valid IP Address");
            }
        }

        private void ButtonShowProcess()    //=============================== Show Process button 方法
        {
            this.textBoxOutPut.AppendText("Start...\r\n\r\n");
            Task taskShowProcess = Task.Factory.StartNew(() =>
                {
                    string node = IPandHost.ListIPinfo[listSelectedIndexIPinfo[0]].ip.ToString();
                    
                    WMIOptions wmiOption = new WMIOptions();
                    if (this.checkBoxLocalUser.Checked)
                    {
                        wmiOption.IsLocalUser = true;
                        wmiOption.IsDomainUser = false;
                    }
                    if (this.checkBoxDomainUser.Checked)
                    {
                        wmiOption.IsDomainUser = true;
                        wmiOption.IsLocalUser = false;
                    }
                    
                    ManagementScope manageScope = wmiOption.GetManageScope(node, this.textBoxUserName.Text, this.textBoxAdminPasswd.Text, this.textBoxDomainName.Text);
                    ObjectQuery obQuery = new ObjectQuery("select * from Win32_Process");
                    ManagementObjectSearcher manageObSearcher = new ManagementObjectSearcher(manageScope, obQuery);
                    try
                    {
                        manageScope.Connect();
                        ManagementObjectCollection manageObCollection = manageObSearcher.Get();
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.Text = node + "\r\nProcessID\t\t" + "Name\r\n";
                        }));

                        foreach (ManagementObject itemproc in manageObCollection)
                        {
                            this.Invoke(new Action(() =>
                                {
                                    this.textBoxOutPut.AppendText(itemproc["ProcessID"] + "\t\t" + itemproc["Name"] + "\r\n");
                                }));
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("Fail: " + node + " " + ex.Message + "\r\n\r\n");
                        }));
                    }
                });
        }

        private void ButtonChangePassword()     //================================= Change Password button 方法
        {
            //---------------------------------委託
            Func<string, bool> funcChangePasswd = new Func<string, bool>((node2) =>
            {
                WMIOptions wmiOption = new WMIOptions();
                if (this.checkBoxLocalUser.Checked)
                {
                    wmiOption.IsLocalUser = true;
                    wmiOption.IsDomainUser = false;
                }
                if (this.checkBoxDomainUser.Checked)
                {
                    wmiOption.IsDomainUser = true;
                    wmiOption.IsLocalUser = false;
                }
                ManagementScope manageScope = wmiOption.GetManageScope(node2, this.textBoxUserName.Text, this.textBoxAdminPasswd.Text, this.textBoxDomainName.Text);
                ManagementPath managePath = new ManagementPath("Win32_Process");
                ManagementClass manageClass = new ManagementClass(manageScope, managePath, null);
                try
                {
                    manageScope.Connect();

                    ManagementBaseObject inParams = manageClass.GetMethodParameters("Create");
                    string cmd = string.Format("net.exe user {0} {1}", this.textBoxUserName.Text, this.textBoxNewPassword.Text);
                    inParams["CommandLine"] = cmd;
                    ManagementBaseObject outParams = manageClass.InvokeMethod("Create", inParams, null);
                    if (Convert.ToInt32(outParams["ReturnValue"]) == 0)
                    {
                        this.Invoke(new Action(() =>
                            {
                                this.textBoxOutPut.AppendText("Success: " + node2 + " Password Changed\r\n\r\n");
                            }));
                    }
                    manageClass.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.textBoxOutPut.AppendText("Fail: " + node2 + " " + ex.Message + "\r\n\r\n");
                    }));
                    return false;
                }
            });
            //---------------------------------------|
            this.groupBox2.Enabled = false;
            this.textBoxOutPut.AppendText("Start...\r\n\r\n");
            Task taskChangePasswd = Task.Factory.StartNew(() =>
                {
                    string node = string.Empty;
                    foreach (var indexSelectItem in this.listSelectedIndexIPinfo)
                    {
                        node = IPandHost.ListIPinfo[indexSelectItem].ip.ToString();
                        funcChangePasswd(node);
                    }
                    this.Invoke(new Action(() =>
                        {
                            this.groupBox2.Enabled = true;
                            this.textBoxOutPut.AppendText("End.\r\n");
                        }));
                });
        }

        private void ButtonRenameComputer()     //============================ Rename Computer 方法
        {
            this.textBoxOutPut.AppendText("Start...\r\n\r\n");
            Task taskRenameComputer = Task.Factory.StartNew(() =>
                {
                    string node = IPandHost.ListIPinfo[listSelectedIndexIPinfo[0]].ip.ToString();

                    WMIOptions wmiOption = new WMIOptions();
                    if (this.checkBoxLocalUser.Checked)
                    {
                        wmiOption.IsLocalUser = true;
                        wmiOption.IsDomainUser = false;
                    }
                    if (this.checkBoxDomainUser.Checked)
                    {
                        wmiOption.IsDomainUser = true;
                        wmiOption.IsLocalUser = false;
                    }
                    ManagementScope manageScope = wmiOption.GetManageScope(node, this.textBoxUserName.Text, this.textBoxAdminPasswd.Text, this.textBoxDomainName.Text);

                    ObjectQuery ObQuery = new ObjectQuery("select Name from Win32_ComputerSystem");
                    ManagementObjectSearcher manageObSearcher = new ManagementObjectSearcher(manageScope, ObQuery);
                    try
                    {
                        manageScope.Connect();

                        ManagementObjectCollection manageObCollection = manageObSearcher.Get();
                        int outValue = -2;
                        foreach (ManagementObject item1 in manageObCollection)
                        {
                            ManagementBaseObject inParams = item1.GetMethodParameters("Rename");
                            inParams["Name"] = this.textBoxNewComputerName.Text;
                            ManagementBaseObject outParams = item1.InvokeMethod("Rename", inParams, null);
                            outValue = Convert.ToInt32(outParams["ReturnValue"]);
                        }

                        if (outValue == 0)
                        {
                            this.Invoke(new Action(() =>
                                {
                                    this.textBoxOutPut.Text = string.Format("Success: {0} Rename {1} , please reboot the computer.", node, this.textBoxNewComputerName.Text);
                                }));                                
                        }
                        else
                        {
                            this.Invoke(new Action(() =>
                            {
                                this.textBoxOutPut.Text = string.Format("Fail: Pls check the error ReturnValue: {0}\r\nCode Link: https://msdn.microsoft.com/en-us/library/ms681381(v=vs.85).aspx", outValue);
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("Fail: " + ex.Message + "\r\n\r\n");
                        }));
                    }
                });

        }

        private void ButtonReboot()     //================================================= Reboot 方法
        {
            //----------------------------------------委託
            Func<string, bool> funcReboot = new Func<string, bool>(node2 =>
            {
                WMIOptions wmiOption = new WMIOptions();
                if (this.checkBoxLocalUser.Checked)
                {
                    wmiOption.IsLocalUser = true;
                    wmiOption.IsDomainUser = false;
                }
                if (this.checkBoxDomainUser.Checked)
                {
                    wmiOption.IsDomainUser = true;
                    wmiOption.IsLocalUser = false;
                }
                ManagementScope manageScope = wmiOption.GetManageScope(node2, this.textBoxUserName.Text, this.textBoxAdminPasswd.Text, this.textBoxDomainName.Text);
                ObjectQuery ObQuery = new ObjectQuery("select * from Win32_OperatingSystem Where Primary=TRUE");
                ManagementObjectSearcher manageObSearcher = new ManagementObjectSearcher(manageScope, ObQuery);
                try
                {
                    manageScope.Connect();

                    foreach (ManagementObject itemreboot in manageObSearcher.Get())
                    {
                        itemreboot.InvokeMethod("Reboot", null);
                    }
                    this.Invoke(new Action(() =>
                    {
                        this.textBoxOutPut.AppendText("Success: " + node2 + " Rebooting...\r\n\r\n");
                    }));                    
                    return true;
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.textBoxOutPut.AppendText("Fail: " + node2 + " " + ex.Message + "\r\n\r\n");
                    }));                    
                    return false;
                }
            });
            //-------------------------------------------
            this.groupBox2.Enabled = false;
            this.textBoxOutPut.AppendText("Start...\r\n\r\n");

            Task taskReboot = Task.Factory.StartNew(() =>
                {
                    string node = string.Empty;

                    foreach (var itemIndex in this.listSelectedIndexIPinfo)
                    {
                        node = IPandHost.ListIPinfo[itemIndex].ip.ToString();
                        funcReboot(node);
                    }

                    this.Invoke(new Action(() =>
                    {
                        this.groupBox2.Enabled = true;
                        this.textBoxOutPut.AppendText("End.\r\n");
                    }));
                });
        }

        private void ButtonJoinDomain()     //====================================== Join Domain 方法
        {
            //---------------------------委託
            Func<string, bool> funcJoinDomain = new Func<string, bool>(node2 =>
            {
                WMIOptions wmiOption = new WMIOptions();
                if (this.checkBoxLocalUser.Checked)
                {
                    wmiOption.IsLocalUser = true;
                    wmiOption.IsDomainUser = false;
                }
                if (this.checkBoxDomainUser.Checked)
                {
                    wmiOption.IsDomainUser = true;
                    wmiOption.IsLocalUser = false;
                }
                ManagementScope manageScope = wmiOption.GetManageScope(node2, this.textBoxUserName.Text, this.textBoxAdminPasswd.Text, this.textBoxDomainName.Text);
                ObjectQuery ObQuery = new ObjectQuery("select Name from Win32_ComputerSystem");
                ManagementObjectSearcher manageObSearcher = new ManagementObjectSearcher(manageScope, ObQuery);
                try
                {
                    manageScope.Connect();

                    int outValue = -2;
                    foreach (ManagementObject itemJoin in manageObSearcher.Get())
                    {
                        ManagementBaseObject inParams = itemJoin.GetMethodParameters("JoinDomainOrWorkgroup");
                        inParams["Name"] = this.textBoxDomainName.Text;
                        inParams["Password"] = WMIOptions.DomainPassword;
                        inParams["UserName"] = string.Format("{0}@{1}", WMIOptions.DomainUserName, this.textBoxDomainName.Text);
                        inParams["FJoinOptions"] = 3;
                        ManagementBaseObject outParams = itemJoin.InvokeMethod("JoinDomainOrWorkgroup", inParams, null);
                        outValue = Convert.ToInt32(outParams["ReturnValue"]);
                    }
                    if (outValue == 0)
                    {
                        this.Invoke(new Action(() =>
                            {
                                this.textBoxOutPut.AppendText(string.Format("Success: {0} Join in {1}.\r\n\r\n", node2, this.textBoxDomainName.Text));
                            }));                        
                        return true;
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("Fail: " + node2 + " ReturnValue(" + outValue + ")" + "\r\n\r\n");
                        }));                        
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("Fail: " + node2 + " " + ex.Message + "\r\n\r\n");
                        }));                    
                    return false;
                }
            });
            //------------------------------

            FormDomainInfo formdomain = new FormDomainInfo();
            if (formdomain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.groupBox2.Enabled = false;
                this.textBoxOutPut.AppendText("Start...\r\n\r\n");

                Task taskJoinDomain = Task.Factory.StartNew(() =>
                {
                    string node = string.Empty;

                    foreach (var itemIndex in this.listSelectedIndexIPinfo)
                    {
                        node = IPandHost.ListIPinfo[itemIndex].ip.ToString();
                        funcJoinDomain(node);
                    }

                    this.Invoke(new Action(() =>
                    {
                        this.groupBox2.Enabled = true;
                        this.textBoxOutPut.AppendText("End.\r\n");
                    }));
                    formdomain.Dispose();
                });
            }
            else
            {
                formdomain.Dispose();
            }
        }

        private delegate void DelegateWMIC(string node);  
        private void ButtonSendCommand()    //========================== Send Command 方法
        {
            //---------------------------------委託
            DelegateWMIC DelegateSendCommand = delegate(string node2)
            {
                WMIOptions wmiOption = new WMIOptions();
                if (this.checkBoxLocalUser.Checked)
                {
                    wmiOption.IsLocalUser = true;
                    wmiOption.IsDomainUser = false;
                }
                if (this.checkBoxDomainUser.Checked)
                {
                    wmiOption.IsDomainUser = true;
                    wmiOption.IsLocalUser = false;
                }
                ManagementScope manageScope = wmiOption.GetManageScope(node2, this.textBoxUserName.Text, this.textBoxAdminPasswd.Text, this.textBoxDomainName.Text);
                ManagementPath managePath = new ManagementPath("Win32_Process");
                ManagementClass manageClass = new ManagementClass(manageScope, managePath, null);

                try
                {
                    manageScope.Connect();                    
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("Fail: " + node2 + " " + ex.Message + "\r\n\r\n");
                        }));                    
                    return;                    
                }

                string[] cmdLines = this.textBoxCommandLine.Lines;
                foreach (var cmd in cmdLines)
                {
                    try
                    {
                        ManagementBaseObject inParams = manageClass.GetMethodParameters("Create");
                        inParams["CommandLine"] = cmd;
                        ManagementBaseObject outParams = manageClass.InvokeMethod("Create", inParams, null);
                        if (Convert.ToInt32(outParams["ReturnValue"]) == 0)
                        {
                            this.Invoke(new Action(() =>
                                {
                                    this.textBoxOutPut.AppendText("Success: " + node2 + " Command Sent.\r\n");
                                }));                                                                                   
                        }
                        else
                        {
                            this.Invoke(new Action(() =>
                            {
                                this.textBoxOutPut.AppendText("Fail: " + node2 + " ReturnValue(" + Convert.ToInt32(outParams["ReturnValue"]) + ")\r\n");
                            }));                                                        
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.textBoxOutPut.AppendText("Fail: " + node2 + " " + ex.Message + "\r\n");
                        }));                        
                    }                    
                }
                this.Invoke(new Action(() =>
                {
                    this.textBoxOutPut.AppendText("\r\n");
                })); 
                manageClass.Dispose();
            };            
            //---------------------------------------|
            this.groupBox2.Enabled = false;
            this.textBoxOutPut.AppendText("Start...\r\n\r\n");
            Task taskSendCommand = Task.Factory.StartNew(() =>
            {
                string node = string.Empty;

                foreach (var indexSelectItem in this.listSelectedIndexIPinfo)
                {
                    node = IPandHost.ListIPinfo[indexSelectItem].ip.ToString();

                    DelegateSendCommand(node);
                }

                this.Invoke(new Action(() =>
                {
                    this.groupBox2.Enabled = true;
                    this.textBoxOutPut.AppendText("\r\nEnd.\r\n");
                }));
            });
        }


        


    }
}
