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
    class WMIOptions
    {
        public static string DomainUserName;
        public static string DomainPassword;

        public bool IsLocalUser = false;
        public bool IsDomainUser = false;

        public ManagementScope GetManageScope(string node, string username, string password, string domainName)
        {
            ConnectionOptions connOptions = new ConnectionOptions();
            connOptions.Username = username;
            connOptions.Password = password;
            connOptions.Authentication = AuthenticationLevel.PacketPrivacy;
            if (this.IsLocalUser)
            {
                connOptions.Authority = string.Format("ntlmdomain:{0}", node);
            }
            if (this.IsDomainUser)
            {
                connOptions.Authority = string.Format("ntlmdomain:{0}", domainName);
            }
            string scope = string.Format( @"\\{0}\root\cimv2",node);
            ManagementScope manageScope = new ManagementScope(scope, connOptions);
            return manageScope;
        }
    }
}
