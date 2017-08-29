using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace WMICTest
{
    public partial class Form2 : Form
    {       
        private List<NetworkInterface> listlocalinter = new List<NetworkInterface>();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //button: accept, "set IPandHost.localinterface 屬性"
        {
            if(listBox1.SelectedIndex == (-1))
            {
                MessageBox.Show("Select a Network Interface");
            }
            else
            {
                int i = listBox1.SelectedIndex;
                IPandHost.LocalInterface = listlocalinter[i]; // set IPandHost.LocalInterface
                IPandHost.SetLocalIP();                     //  set IPandHost.LocalIP
                this.Close();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void listBox1_AddItem()
        {
            listBox1.Items.Clear();

            NetworkInterface[] allinter = NetworkInterface.GetAllNetworkInterfaces(); //獲取本機所有network interface
            foreach (var i in allinter)                                               //遍曆network interface
            {
                if( i.OperationalStatus != OperationalStatus.Down &&                  // 判斷有效interface
                    i.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    i.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                        int count = 0;
                        foreach (var l in this.listlocalinter)
                        {
                            if (l.Id == i.Id)
                            {
                                ++count;
                            }
                        }
                        if (count == 0)
                        {
                            listlocalinter.Add(i);
                        }
                    listBox1.Items.Add(i.Description);    //form2.listbox1 add item 
                }
            }
           
        }


    }
}
