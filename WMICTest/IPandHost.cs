using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WMICTest
{
    class IPandHost
    {
        private static readonly Object locker1 = new Object();
        private static readonly Object locker2 = new Object();
        private static readonly Object locker3 = new Object();
        public static int ProgressBarCount;

        public static NetworkInterface LocalInterface;
        public static IPAddress LocalIP;

        //public static List<IPAddress> ListIP = new List<IPAddress>();
        public static List<IPHostInfo> ListIPinfo = new List<IPHostInfo>();

        public static readonly string RegexIP = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"; //ip正則表達式 (0~255.0~255.0~255.0~255)
        public static readonly string RegexComputerName = @"^[a-zA-Z0-9_-]{1,}$"; // 主機名稱 正則表達式

        public struct IPHostInfo : IComparable
        {
            public IPAddress ip;
            public string hostName;

            public int CompareTo(object obj)
            {
                if (obj != null)
                {
                    IPHostInfo info = (IPHostInfo)obj;
                    string[] arraryIP = ip.ToString().Split(new char[] { '.' });
                    string[] arraryIPinfo = info.ip.ToString().Split(new char[] { '.' });
                    return Convert.ToInt32(arraryIP[3]).CompareTo(Convert.ToInt32(arraryIPinfo[3]));
                }
                else
                {
                    return 0;
                    //throw new ArgumentException("IPHostInfo.CompareTo()..error");
                }
            }
        }

        public static void SetLocalIP() //獲取選定interface ip address To IPandHost.LocalIP 字段
        {
            UnicastIPAddressInformationCollection ipco = IPandHost.LocalInterface.GetIPProperties().UnicastAddresses;
            foreach (var i in ipco)
            {
                if (i.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPandHost.LocalIP = i.Address;
                }
            }
        }

        public static bool CheckIPFormat(string ip)
        {
            return Regex.IsMatch(ip, IPandHost.RegexIP);
        }

        public bool TryPingOK(IPAddress ip)  //判斷目標ip地址 是否能ping通
        {
            try
            {
                IPStatus ipPingStatus = new IPStatus();
                ipPingStatus = IPStatus.Unknown;

                Ping ping = new Ping();
                ipPingStatus = ping.Send(ip, 3000).Status;

                if (ipPingStatus == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("IPandHost.TryPingOK()...\r\n" + ex.Message);
                return false;
            }
        }

        public void ScanOneIP(IPAddress ip)
        {
            if (IPandHost.ListIPinfo != null)        //清除 List<IPHostInfo> ListIPinfo 所有元素
            {
                IPandHost.ListIPinfo.Clear();
            }
            try
            {
                IPandHost ipandhost = new IPandHost();
                if (ipandhost.TryPingOK(ip))
                {
                    IPHostInfo ipinfo = new IPHostInfo(); //ping通IP and HostName 入 IPandHost.ListIPinfo
                    ipinfo.ip = ip;
                    ipinfo.hostName = Dns.GetHostEntry(ip).HostName;
                    lock (IPandHost.locker1)
                    {
                        IPandHost.ListIPinfo.Add(ipinfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ScanIPs(IPAddress ip, int start, int end) //並行 ping IP Range (xxx.xxx.xxx.start - xxx.xxx.xxx.end)
        {
            string logPath = System.IO.Directory.GetCurrentDirectory() + "\\Log_ScanIP.txt";
            if (IPandHost.ListIPinfo != null)        //清除 List<IPHostInfo> ListIPinfo 所有元素
            {
                IPandHost.ListIPinfo.Clear();
            }
            string failIP = "failIP";
            string strIP = ip.ToString();
            int i = strIP.LastIndexOf('.');
            string strIP1 = strIP.Remove(i);
            Parallel.For(start, end, item =>
            {
                try
                {
                    IPandHost ipandhost = new IPandHost();
                    string strIP2 = strIP1 + "." + item.ToString();
                    IPAddress newIP = IPAddress.Parse(strIP2);
                    failIP = newIP.ToString();
                    bool pingOK = ipandhost.TryPingOK(newIP);

                    if (pingOK)
                    {
                        IPHostInfo ipinfo = new IPHostInfo(); //ping通IP and HostName 入 IPandHost.ListIPinfo
                        ipinfo.ip = newIP;
                        ipinfo.hostName = Dns.GetHostEntry(newIP).HostName;
                        lock (IPandHost.locker1)
                        {
                            IPandHost.ListIPinfo.Add(ipinfo);
                        }
                    }
                    lock (IPandHost.locker2)
                    {
                        ++IPandHost.ProgressBarCount;
                    }
                }
                catch (Exception ex)
                {
                    lock (IPandHost.locker3)
                    {
                        System.IO.File.AppendAllText(logPath, failIP + " : " + ex.Message + "\r\n");
                    }
                }
            });

            if (System.IO.File.Exists(logPath))
            {
                System.IO.File.AppendAllText(logPath, "===== " + DateTime.Now.ToString() + " =====\r\n\r\n");
            }
        }


        //public static void GatewayPingOK(NetworkInterface interfa, out IPAddress gateway)
        //{
        //    GatewayIPAddressInformationCollection gateways = interfa.GetIPProperties().GatewayAddresses; //獲取 gaways of interface
        //    int countgateway = gateways.Count;
        //    foreach (var g in gateways)
        //    {


        //    }
        //    gateway = g.Address;
        //}

    }
}
