using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMICTest
{
    public partial class FormDomainInfo : Form
    {
        public FormDomainInfo()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            WMIOptions.DomainUserName = null;
            WMIOptions.DomainPassword = null;

            WMIOptions.DomainUserName = this.textBoxDomainUser.Text;
            WMIOptions.DomainPassword = this.textBoxDomainPassword.Text;

            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
