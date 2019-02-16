using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Drawing2D;

namespace Uart_Net
{
    public partial class Form1 : Form
    {
        bool Seriallistening = false;

        UInt64 Srx = 0, Stx = 0, Nrx = 0, Ntx = 0;
        private byte[] SerialDataBuf = new byte[1024];
        private byte[] NetDataBuf = new byte[1024];
        private StringBuilder Serialbuilder = new StringBuilder();//数据类型（编码方式）转换构造器
        private StringBuilder Netbuilder = new StringBuilder();//数据类型（编码方式）转换构造器
        SerialPort Serialport = new SerialPort();
        TcpListener NetServer;
        private List<Socket> NetClients = new List<Socket>(6);
        Socket NetClient;
        UdpClient NetLocalUdp;

        private byte[] SerialAutoSendBuf;
        private byte[] NetAutoSendBuf;

        int UIMode = 1;
  
        
        bool NetServerExit = false;
        int NetCurrentMode = 0;
        EndPoint NetCurEP = null;


        public Form1()
        {
            InitializeComponent();

            SerialBaudBox.SelectedIndex = 3;
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                SerialPortBox.Items.Add(s);
            }
            if (SerialPortBox.Items.Count != 0)
                SerialPortBox.SelectedIndex = 0;
            else
                SerialInfo.Text = "没有可用串口";
            Control.CheckForIllegalCrossThreadCalls = false;    //这个类中我们不检查跨线程的调用是否合法(因为.net 2.0以后加强了安全机制,，不允许在winform中直接跨线程访问控件的属性)
            Serialport.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);
            Serialport.ReceivedBytesThreshold = 1;

            //准备就绪      
             Serialport.DtrEnable = true;
             Serialport.RtsEnable = true;
            //设置数据读取超时为1秒
            Serialport.ReadTimeout = 1000;
            Serialport.Close();

            NetModeBox.SelectedIndex = 0;
            NetClientList.SelectedIndex = 0;
            NetIPTextBox.Text = GetLocalIP();
            

        }

        #region **串口刷新**
        //串口刷新
        private void SerailRfrshBtn_Click(object sender, EventArgs e)
        {
            string[] allPorts = SerialPort.GetPortNames();
            StringBuilder tmpBuilder = new StringBuilder();
            tmpBuilder.Clear();

            for (int i = 0; i < SerialPortBox.Items.Count; i++)
            {
                string ex = SerialPortBox.Items[i].ToString();
                if (allPorts.Contains(ex) == false)
                {                    
                    tmpBuilder.Append(SerialPortBox.Items[i].ToString()+"移除 ");
                    SerialPortBox.Items.RemoveAt(i);
                    i--;
                }
            }
            foreach (string s in allPorts)
            {
                if (SerialPortBox.Items.Contains(s) == false)
                {
                    SerialPortBox.Items.Add(s);
                    tmpBuilder.Append("新添" + s +" ");
                }
            }
            if (SerialPortBox.SelectedIndex == -1 && SerialPortBox.Items.Count != 0)
            {
                SerialPortBox.SelectedIndex = 0;
            }
            if(SerialPortBox.Items.Count == 0)
            {
                tmpBuilder.Append("没有可用串口");                
            }
            SerialInfo.Text = tmpBuilder.ToString();
        }
        #endregion

        #region**网络获取IP**
        //网络获取IP
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                foreach (IPAddress ip in IpEntry.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        return ip.ToString();
                }

                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取本机IP出错:" + ex.Message);
                return "";
            }
        }
        #endregion


        #region **串口打开与关闭**
        //串口打开
        private void SerialOpenBtn_Click(object sender, EventArgs e)
        {
            #region**打开**
            if (SerialOpenBtn.Text=="打开" )
            {
                try
                {
                    Serialport.PortName = SerialPortBox.SelectedItem.ToString();
                    Serialport.BaudRate = Convert.ToInt32(SerialBaudBox.SelectedItem.ToString());
                    Serialport.DataBits = 8;
                    Serialport.StopBits = StopBits.One;
                    Serialport.Parity = Parity.None;

                    Serialport.Open();

                    //互斥项状态改变
                    SerialOpenBtn.Text = "关闭";
                    SerialOpenBtn.BackColor = Color.FromArgb(127, 0, 255, 0);// Color.Green;
                    SerialRfrshBtn.Enabled = false;
                    SerialSndBtn.Enabled = true;
                    SerialInfo.Text = "串口打开";

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SerialInfo.Text = "串口打开失败";       
                    return;
                }
            }
            #endregion

            #region**关闭**
            else//关闭port
            {
                SerialOpenBtn.Text = "打开";
                SerialOpenBtn.BackColor = Color.Gainsboro;
                SerialRfrshBtn.Enabled = true;
                SerialSndBtn.Enabled = false;
                SerialAutoSendBuf = null;
                if (Seriallistening) Serialport.DiscardInBuffer();//如果接收线程仍有数据就扔掉数据

                Serialport.Close();
                SerialInfo.Text = "串口关闭";
            }
            #endregion
        }
        #endregion

        #region**网络连接或断开**
        private void NetConnectBtn_Click(object sender, EventArgs e)
        {
            #region**Tcp服务器**
            if (NetCurrentMode == 1)
            {
                if (NetConnectBtn.Text == "监听")
                {
                    try
                    {
                        IPAddress ip = IPAddress.Parse(NetIPTextBox.Text);
                        IPEndPoint ep = new IPEndPoint(ip, Convert.ToInt16(NetPortTextBox.Text));
                        NetServer = new TcpListener(ep);
                        NetServer.Start(10);

                        NetInformLog("服务器开始监听");
                        NetConnectBtn.Text = "断开";
                        NetSndBtn.Enabled = true;
                        NetConnectBtn.BackColor = Color.FromArgb(127, 0, 255, 0);// Color.Green;
                        NetIPTextBox.ReadOnly = true;
                        NetPortTextBox.ReadOnly = true;
                        NetServerExit = false;

                        Thread thread = new Thread(NetServerListen);
                        thread.IsBackground = true;
                        thread.Start(NetServer);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    NetCurEP = null;
                    NetSndBtn.Enabled = false;
                    NetConnectBtn.BackColor = Color.Gainsboro;
                    NetConnectBtn.Text = "监听";
                    NetIPTextBox.ReadOnly = false;
                    NetPortTextBox.ReadOnly = false;
                    NetServerExit = true;
                    NetAutoSendBuf = null;
                    foreach (Socket client in NetClients)
                    {
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }
                    NetClients.Clear();

                    NetClientList.Items.Clear();
                    NetClientList.Items.Add("All");
                    NetClientList.SelectedIndex = 0;
                    NetInformLog("服务器关闭");

                    NetServer.Stop();
                }
            }
            #endregion

            #region**TcpClient**
            else if (NetCurrentMode == 2)
            {
                if (NetConnectBtn.Text == "连接")
                {
                    NetConnectBtn.Enabled = false;
                    NetInformLog("正在连接...");
                    NetClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Thread NetConnect = new Thread(NetClientConnect);
                    NetConnect.IsBackground = true;
                    NetConnect.Start();

                }
                else
                {
                    NetConnectBtn.BackColor = Color.Gainsboro;
                    NetConnectBtn.Text = "连接";

                    label8.Text = "客户端";
                    NetHideIPBox.Text = "127.0.0.1";
                    NetHidePortBox.Text = "8888";
                    NetHideIPBox.ReadOnly = false;
                    NetHidePortBox.ReadOnly = false;
                    NetIPTextBox.ReadOnly = false;
                    NetPortTextBox.ReadOnly = false;
                    label8.Hide();
                    label9.Hide();
                    NetHideIPBox.Hide();
                    NetHidePortBox.Hide();
                    NetRcvTextBox.Height = 347;
                    NetAutoSendBuf = null;

                    NetClient.Shutdown(SocketShutdown.Both);
                    NetClient.Close();
                    NetInformLog("连接关闭");
                    NetSndBtn.Enabled = false;
                }
            }
            #endregion

            #region**UDP**
            else
            {
                if (NetConnectBtn.Text == "连接")
                {
                    try
                    {
                        NetLocalUdp = new UdpClient(Convert.ToInt16(NetPortTextBox.Text));

                        //创建一个线程接收远程主机发来的信息
                        Thread thread = new Thread(NetUdpRcv);
                        //将线程设为后台运行
                        thread.IsBackground = true;
                        thread.Start();
                        NetSndTextBox.Focus();

                        NetConnectBtn.Text = "关闭";
                        NetSndBtn.Enabled = true;
                        NetConnectBtn.BackColor = Color.FromArgb(127, 0, 255, 0);

                        NetRcvTextBox.Height = 326;
                        label8.Show();
                        label9.Show();
                        NetHideIPBox.Show();
                        NetHidePortBox.Show();
                        label8.Text = "目标IP";

                        NetInformLog("本地UDP开启成功");
                    }
                    catch (Exception ex)
                    {
                        NetInformLog(ex.Message);
                    }
                }
                else
                {

                    NetLocalUdp.Close();
                    NetConnectBtn.BackColor = Color.Gainsboro;
                    NetConnectBtn.Text = "连接";

                    label8.Text = "客户端";
                    label8.Hide();
                    label9.Hide();
                    NetHideIPBox.Hide();
                    NetHidePortBox.Hide();
                    NetRcvTextBox.Height = 347;
                    NetAutoSendBuf = null;

                    NetInformLog("连接关闭");
                    NetSndBtn.Enabled = false;
                }
            }
            #endregion
        }
        #region**TCP客户端连接线程**
        private void NetClientConnect()
        {
            try
            {
                NetClient.Connect(IPAddress.Parse(NetIPTextBox.Text), Convert.ToInt16(NetPortTextBox.Text));

                Thread th = new Thread(NetClientRcv);
                th.IsBackground = true;
                th.Start();

                NetConnectBtn.Text = "关闭";
                NetSndBtn.Enabled = true;
                NetConnectBtn.BackColor = Color.FromArgb(127, 0, 255, 0);

                NetRcvTextBox.Height = 325;
                label8.Show();
                label9.Show();
                NetHideIPBox.Show();
                NetHidePortBox.Show();
                label8.Text = "本机IP";
                NetHideIPBox.Text = NetClient.LocalEndPoint.ToString().Split(':')[0];
                NetHidePortBox.Text = NetClient.LocalEndPoint.ToString().Split(':')[1];
                NetHideIPBox.ReadOnly = true;
                NetHidePortBox.ReadOnly = true;
                NetIPTextBox.ReadOnly = true;
                NetPortTextBox.ReadOnly = true;

                NetInformLog("服务器连接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                NetInformLog("服务器连接失败");
            }
            NetConnectBtn.Enabled = true;
        }
        #endregion

        #region**网络Server监听客户端请求**
        private void NetServerListen(object obj)
        {
            TcpListener server = obj as TcpListener;
            Socket client = null;
            while (true)
            {
                try
                {
                    client = server.AcceptSocket();
                }
                catch
                {
                    //当单击“停止监听”或者退出此窗体时AcceptTcpClient()会产生异常
                    //因此可以利用此异常退出循环
                    break;
                }

                string point = client.RemoteEndPoint.ToString();
                //通知连接
                NetInformLog(point + "连接成功");
                //用户组添加
                NetClients.Add(client);
                //用户组框添加
                NetClientList.Items.Add(point);
                NetClientList.SelectedIndex++;
                //接收消息
                Thread th = new Thread(NetServerRcv);
                th.IsBackground = true;
                th.Start(client);
            }
        }
        #endregion

        #endregion


        #region **串口数据保存**
        //串口数据保存
        private void SerialSaveBtn_Click(object sender, EventArgs e)
        {
            string path =  "\\Serial" + DateTime.Now.ToString("HH-mm-ss") + ".txt";
            // 创建文件
            FileStream fs = new FileStream(Environment.CurrentDirectory + path, FileMode.Append, FileAccess.Write); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
            StreamWriter sw = new StreamWriter(fs); // 创建写入流
            sw.Write(SerialRcvTextBox.Text);
            sw.Close(); //关闭文件
            fs.Dispose();
            SerialInfo.Text = "数据已保存至 ." +path;

        }
        #endregion

        #region **网络数据保存**
        private void NetSaveBtn_Click(object sender, EventArgs e)
        {
            string path = "\\Net" + DateTime.Now.ToString("HH-mm-ss") + ".txt";
            // 创建文件
            FileStream fs = new FileStream(Environment.CurrentDirectory + path, FileMode.Append, FileAccess.Write); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
            StreamWriter sw = new StreamWriter(fs); // 创建写入流
            sw.Write(NetRcvTextBox.Text);
            sw.Close(); //关闭文件
            fs.Dispose();
            NetInfo.Text = "数据已保存至 ." + path;

        }
        #endregion


        #region **串口发送Hex数据预处理**
        //串口发送处理
        private void SerialSndTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SerialSndHEX.Checked == true)
            {
                //正则匹配 
                Regex r = new Regex("[0-9a-fA-F]| |\b|\r|\n");
                Match m = r.Match(e.KeyChar.ToString());

                if (m.Success)
                {
                    e.Handled = false;      //将事件传递到box中去，下同
                }
                else
                {
                    e.Handled = true;       //将事件在这里截止
                }
            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion

        #region**网络发送Hex数据预处理**
        private void NetSndTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NetSndHEX.Checked == true)
            {
                //正则匹配 
                Regex r = new Regex("[0-9a-fA-F]| |\b|\r|\n");
                Match m = r.Match(e.KeyChar.ToString());

                if (m.Success)
                {
                    e.Handled = false;      //将事件传递到box中去，下同
                }
                else
                {
                    e.Handled = true;       //将事件在这里截止
                }
            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion


        #region **串口发送**
        //串口发送
        private void SerialSndBtn_Click(object sender, EventArgs e)
        {
            if (SerialSndHEX.Checked == true)	//“HEX发送” 按钮 
            {
                string sndStr = SerialSndTextBox.Text.Replace(" ", "");
                sndStr = sndStr.Replace("\r\n", "");
                sndStr=sndStr.ToUpper();
                if (sndStr.Length % 2 != 0)
                {
                    MessageBox.Show("HEX发送模式下，字符数量\r\n应为偶数，请注意补零！", "输入错误",
                        MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }


                int len = sndStr.Length/2;
                byte[] tmp1 = new byte[len*2];
                byte[] tmp2 = new byte[len];
                for (int i = 0; i < len*2; i++)
                {
                    if (sndStr[i] >= '0' && sndStr[i] <= '9')
                        tmp1[i] = Convert.ToByte(sndStr[i] - '0');           //0~9
                    else
                        tmp1[i] = Convert.ToByte(sndStr[i] - 'A' + 10);      //10~15
                }
                for(int i=0;i<len;i++)
                {
                    tmp2[i] = Convert.ToByte(tmp1[i * 2] * 16 + tmp1[i * 2 + 1]);
                }

                Serialport.Write(tmp2, 0, len);
                SerialAutoSendBuf = tmp2;
                Stx += Convert.ToUInt64(len);

                if (SerialRcvShowSend.Checked)
                {
                    Serialbuilder.Clear();
                    foreach (byte b in tmp2)
                    {
                        Serialbuilder.Append(b.ToString("X2") + " ");
                    }
                
                    SerialRcvTextBox.AppendText(Serialbuilder.ToString());
                }

            }
            else		//以字符串形式发送时 
            {
                SerialAutoSendBuf = Encoding.Default.GetBytes(SerialSndTextBox.Text);
                Serialport.Write(SerialAutoSendBuf, 0, SerialAutoSendBuf.Length);    //写入数据
                //SerialAutoSendBuf = buffer;
                Stx += Convert.ToUInt64(SerialAutoSendBuf.Length);
                //显示发送
                if (SerialRcvShowSend.Checked)
                {
                    SerialRcvTextBox.AppendText(SerialSndTextBox.Text);
                }
                //如果发送新行
                if (SerialSndNewLine.Checked)
                {
                    Serialport.Write("\r\n");
                    SerialAutoSendBuf= Encoding.Default.GetBytes(SerialSndTextBox.Text+"\r\n");
                    SerialRcvTextBox.AppendText("\r\n");
                    Stx += 2;
                }
            }

            SerialTxCnt.Text = Convert.ToString(Stx);
        }
        #endregion

        #region**网络发送**
        private void NetSndBtn_Click(object sender, EventArgs e)
        {

            if (NetSndHEX.Checked == true)	//“HEX发送” 按钮 
            {
                string sndStr = NetSndTextBox.Text.Replace(" ", "");
                sndStr = sndStr.Replace("\r\n", "");
                sndStr = sndStr.ToUpper();
                if (sndStr.Length % 2 != 0)
                {
                    MessageBox.Show("HEX发送模式下，字符数量\r\n应为偶数，请注意补零！", "输入错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int len = sndStr.Length / 2;
                byte[] tmp1 = new byte[len * 2];
                byte[] tmp2 = new byte[len];
                for (int i = 0; i < len * 2; i++)
                {
                    if (sndStr[i] >= '0' && sndStr[i] <= '9')
                        tmp1[i] = Convert.ToByte(sndStr[i] - '0');           //0~9
                    else
                        tmp1[i] = Convert.ToByte(sndStr[i] - 'A' + 10);      //10~15
                }
                for (int i = 0; i < len; i++)
                {
                    tmp2[i] = Convert.ToByte(tmp1[i * 2] * 16 + tmp1[i * 2 + 1]);
                }

                NetSend(ref tmp2);
                NetAutoSendBuf = tmp2;

                if (NetRcvShowSend.Checked)
                {
                    Netbuilder.Clear();
                    foreach (byte b in tmp2)
                    {
                        Netbuilder.Append(b.ToString("X2") + " ");
                    }

                    NetRcvTextBox.AppendText(Netbuilder.ToString());
                }

            }
            else
            {
                NetAutoSendBuf = Encoding.Default.GetBytes(NetSndTextBox.Text);

                NetSend(ref NetAutoSendBuf);

                //显示发送
                if (NetRcvShowSend.Checked)
                {
                    NetRcvTextBox.AppendText(NetSndTextBox.Text);
                }
                //如果发送新行
                if (NetSndNewLine.Checked)
                {
                    byte[] NewLine = Encoding.Default.GetBytes("\r\n");
                    NetSend(ref NewLine);
                    NetAutoSendBuf = Encoding.Default.GetBytes(NetSndTextBox.Text + "\r\n");
                    NetRcvTextBox.AppendText("\r\n");
                }
            }

            NetTxCnt.Text = Convert.ToString(Ntx);
        }

        private void NetSend(ref byte[] data)
        {
            int cnt = 0;
            #region**Server发送**
            if (NetModeBox.SelectedIndex == 1)
            {
                try
                {    //组发                
                    if (NetClientList.SelectedIndex == 0)
                    {
                        foreach (Socket client in NetClients)
                        {
                            cnt = client.Send(data);
                        }
                    }
                    else//单发
                    {
                        cnt = NetClients[NetClientList.SelectedIndex - 1].Send(data);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion

            #region**Client发送**
            else if (NetModeBox.SelectedIndex == 2)
            {
                try
                {
                    cnt = NetClient.Send(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion

            #region**UDP发送**
            else
            {
                try
                {
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(NetHideIPBox.Text), Convert.ToInt16(NetHidePortBox.Text));
                    cnt = NetLocalUdp.Send(data, data.Length, ep);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            #endregion

            Ntx += (UInt64)cnt;
        }
        #endregion


        #region **串口自动重发时间中断**
        //串口自动重发时间中断
        private void SerialTimer_Tick(object sender, EventArgs e)
        {
            if (Serialport.IsOpen && SerialAutoSendBuf != null) 
            {      
                Serialport.Write(SerialAutoSendBuf, 0, SerialAutoSendBuf.Length);
                Stx += Convert.ToUInt64(SerialAutoSendBuf.Length);
                SerialTxCnt.Text = Convert.ToString(Stx);
                if (SerialRcvShowSend.Checked)
                    SerialRcvTextBox.AppendText(Encoding.Default.GetString(SerialAutoSendBuf));
            }
        }
        #endregion

        #region**网络自动重发时间中断**
        private void NetTimer_Tick(object sender, EventArgs e)
        {
            if (NetConnectBtn.BackColor == Color.FromArgb(127, 0, 255, 0) && NetAutoSendBuf != null)
            {
                NetSend(ref NetAutoSendBuf);
                NetTxCnt.Text = Convert.ToString(Ntx);
                if (NetRcvShowSend.Checked)
                    NetRcvTextBox.AppendText(Encoding.Default.GetString(NetAutoSendBuf));
            }
        }
        #endregion



        #region **串口自动重发选中与取消**
        //串口自动重发选中与取消
        private void SerialSndAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if(SerialSndAutoSend.Checked)
            {
                SerialTimer.Interval = Convert.ToInt16(SerialSndTimerNum.Value);
                SerialTimer.Enabled = true;
            }
            else
            SerialTimer.Enabled = false;
        }
        #endregion

        #region**网络自动重发选中与取消**
        private void NetSndAutoSend_CheckedChanged(object sender, EventArgs e)
        {
            if (NetSndAutoSend.Checked)
            {
                NetTimer.Interval = Convert.ToInt16(NetSndTimerNum.Value);
                NetTimer.Enabled = true;
            }
            else
                NetTimer.Enabled = false;
        }
        #endregion


        #region **串口自动重发时间间隔变化**
        //串口自动重发时间间隔变化
        private void SerialSndTimerNum_ValueChanged(object sender, EventArgs e)
        {
            SerialTimer.Interval = Convert.ToInt16(SerialSndTimerNum.Value);
        }
        #endregion

        #region**网络自动重发时间间隔变化**
        private void NetSndTimerNum_ValueChanged(object sender, EventArgs e)
        {
            NetTimer.Interval = Convert.ToInt16(NetSndTimerNum.Value);
        }
        #endregion


        #region**串口参数变更**
        #region**串口端口变化**
        //串口端口变化
        private void SerialPortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SerialOpenBtn.Text == "关闭")
            {
                SerialOpenBtn.PerformClick();
                SerialInfo.Text = "端口变更请重新打开";
            }
            else SerialInfo.Text = "选择端口" + SerialPortBox.SelectedItem.ToString();
        }
        #endregion

        #region **串口波特率变化**
        //串口波特率变化
        private void SerialBaudBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Serialport.BaudRate = Convert.ToInt32(SerialBaudBox.SelectedItem.ToString());
            SerialInfo.Text = "波特率变更";
        }
        #endregion
        #endregion

        #region**网络参数变更**

        #region**网络协议变更**
        //网络协议变更
        private void NetModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //先关闭
            if (NetConnectBtn.BackColor == Color.FromArgb(127, 0, 255, 0))
            {
                NetConnectBtn.PerformClick();
            }
            NetCurrentMode = NetModeBox.SelectedIndex;

            if (NetModeBox.SelectedIndex == 0)
            {
                NetIPTextBox.Text = GetLocalIP();
                NetIPTextBox.Enabled = false;
                NetIPTextBox.BackColor = Color.White;

                label8.Hide();
                NetClientList.Hide();
                NetRcvTextBox.Height = 347;
                label6.Text = "本机IP地址";
                NetConnectBtn.Text = "连接";
            }
            else if (NetModeBox.SelectedIndex == 1)
            {
                NetIPTextBox.Text = GetLocalIP();
                NetIPTextBox.Enabled = false;
                NetIPTextBox.BackColor = Color.White;

                NetRcvTextBox.Height = 325;
                label8.Show();
                NetClientList.Show();
                label6.Text = "本机IP地址";
                NetConnectBtn.Text = "监听";
            }
            else
            {
                NetIPTextBox.Text = "192.168.0.1";
                NetIPTextBox.Enabled = true;

                label8.Hide();
                NetClientList.Hide();
                NetRcvTextBox.Height = 347;
                label6.Text = "服务器IP地址";
                NetConnectBtn.Text = "连接";
            }
            NetInfo.Text = "选择协议" + NetModeBox.SelectedItem.ToString();
        }
        #endregion

        #region**网络端口变更**
        //网络端口变更
        private void NetPortTextBox_TextChanged(object sender, EventArgs e)
        {
            NetInfo.Text = "端口变更";
        }

        private void NetPortTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //正则匹配 
            Regex r = new Regex("[0-9]|\b");
            Match m = r.Match(e.KeyChar.ToString());

            if (m.Success)
            {
                e.Handled = false;      //将事件传递到box中去，下同
            }
            else
            {
                e.Handled = true;       //将事件在这里截止
            }
        }
        #endregion

        #region**网络IP变更**
        //网络IP变更
        private void NetIPTextBox_TextChanged(object sender, EventArgs e)
        {
            NetInfo.Text = "IP变为" + NetIPTextBox.Text;
        }
        #endregion

        #region**网络IP变更按键过滤**
        //网络IP变更按键过滤
        private void NetIPTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //正则匹配 
            Regex r = new Regex("[0-9]|\\.|\b");//中间的.可以用[.]或\\.表示,其中第一个\是因为处于""下，第二个\是为了正则转义 
            Match m = r.Match(e.KeyChar.ToString());

            if (m.Success)
            {
                e.Handled = false;      //将事件传递到box中去，下同
            }
            else
            {
                e.Handled = true;       //将事件在这里截止
            }

        }
        #endregion
        #endregion
                

        #region**串口暂停接收**
        //串口暂停接收
        private void SerialRcvPause_CheckedChanged(object sender, EventArgs e)
        {
            if (SerialRcvPause.Checked)
                SerialInfo.Text = "暂停接收";
            else
                SerialInfo.Text = "恢复接收";
        }
        #endregion

        #region**网络暂停接收**
        private void NetRcvPause_CheckedChanged(object sender, EventArgs e)
        {
            if (NetRcvPause.Checked)
                NetInformLog("暂停接收");
            else
                NetInformLog("恢复接收");
        }
        #endregion


        #region**串口清空接收**
        //串口清空接收
        private void SerialClearBtn_Click(object sender, EventArgs e)
        {
            SerialRcvTextBox.Clear();
        }
        #endregion

        #region**网络清空接收**
        private void NetClearBtn_Click(object sender, EventArgs e)
        {
            NetRcvTextBox.Clear();
        }
        #endregion



        #region**串口接收数据处理**
        //串口数据处理
        private void SerialProcessData()
        {
            if (SerialRcvTextBox.Text.Length < SerialRcvTextBox.MaxLength)
            {
                #region**更新接收框与接收计数标签**
                Serialbuilder.Clear();//清除字符串构造器的内容
                                      //是否显示时间
                if (SerialRcvShowTime.Checked)
                {
                    Serialbuilder.Append("\r\n【" + DateTime.Now.ToString("yy-MM-dd--HH:mm:ss")
                      + "】\r\n");
                }
                //判断是否是显示HEX  
                if (SerialRcvHEX.Checked)
                {
                    //依次的拼接出16进制字符串  
                    foreach (byte b in SerialDataBuf)
                    {
                        Serialbuilder.Append(b.ToString("X2") + " ");
                    }
                }
                else
                {
                    //直接按ASCII规则转换成字符串  

                    Serialbuilder.Append(Encoding.Default.GetString(SerialDataBuf));

                }

                //显示接收数据
                if (!SerialRcvPause.Checked)
                    this.BeginInvoke((EventHandler)(delegate { SerialRcvTextBox.AppendText(Serialbuilder.ToString()); }));

                //修改接收计数  
                this.BeginInvoke((EventHandler)(delegate { SerialRxCnt.Text = Convert.ToString(Srx); }));
                #endregion
            }
            else
                SerialRcvTextBox.Clear();
        }


        #endregion

        #region**网络接收数据处理**
        private void NetProcessData()
        {
            if (NetRcvTextBox.Text.Length < NetRcvTextBox.MaxLength)
            {
                #region**更新接收框与接收计数标签**
                Netbuilder.Clear();//清除字符串构造器的内容
                                   //是否显示时间
                if (NetRcvShowTime.Checked)
                {
                    Netbuilder.Append("\r\n【" + DateTime.Now.ToString("yy-MM-dd--HH:mm:ss")
                      + "】\r\n");
                }
                //判断是否是显示HEX  
                if (NetRcvHEX.Checked)
                {
                    //依次的拼接出16进制字符串  
                    foreach (byte b in NetDataBuf)
                    {
                        Netbuilder.Append(b.ToString("X2") + " ");
                    }
                }
                else
                {
                    //直接按ASCII规则转换成字符串  

                    Netbuilder.Append(Encoding.Default.GetString(NetDataBuf));

                }

                //显示接收数据
                if (!NetRcvPause.Checked)
                    this.BeginInvoke((EventHandler)(delegate { NetRcvTextBox.AppendText(Netbuilder.ToString()); }));

                //修改接收计数  
                this.BeginInvoke((EventHandler)(delegate { NetRxCnt.Text = Convert.ToString(Nrx); }));
                #endregion
            }
            else
                NetRcvTextBox.Clear();
        }
        #endregion


        #region**串口数据到达中断**
        //串口数据到达中断
        private void SerialDataReceived(object sender, EventArgs e)
        {
            if (!Serialport.IsOpen) return;
            
            try
            {
                Seriallistening = true;//设置标记,防止处理数据时关闭串口
                int n = Serialport.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
                n = n < 1023 ? n : 1023;
                Srx += Convert.ToUInt64(n);//增加接收计数  
                SerialDataBuf[n] = 0;//防止此次数据显示后下次新数据覆盖后未被覆盖的部分仍然显示
                Serialport.Read(SerialDataBuf, 0, n);//读取缓冲数据  

                //到此为止是数据接收，剩下的应当invoke UI处理
                SerialProcessData();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "出错提示");
            }
            finally
            {
                Seriallistening = false;//可以关闭串口了。  
            }
            
        }
        #endregion

        #region**网络数据到达中断**

        #region**Server**
        void NetServerRcv(object obj)
        {
            Socket client = obj as Socket;

            //接收客户端发送过来的数据
            while (NetServerExit == false)
            {
                try
                {                    
                    int n = client.Receive(NetDataBuf, 1024, SocketFlags.None);
                    //从网络流中读出字符串,读不出则抛出断开连接异常                    
                    if (n == 0)
                    {
                        throw new Exception();
                    }
                    Nrx += (UInt64)n;

                    if (client.RemoteEndPoint != NetCurEP)
                    {
                        NetRcvTextBox.AppendText("\r\nReceived from" + client.RemoteEndPoint.ToString() + ":\r\n");
                    }
                    NetCurEP = client.RemoteEndPoint;
                    NetProcessData();
                }
                catch
                {
                    if (NetServerExit == false)
                    {
                        //通知断开连接
                        NetInformLog(string.Format("与[{0}]失去联系", client.RemoteEndPoint));

                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                        //用户组框删除
                        NetClientList.Items.RemoveAt(NetClientList.SelectedIndex);
                        NetClientList.SelectedIndex = 0;
                        //用户组删除
                        NetClients.Remove(client);
                    }
                    break;
                }
            }

        }
        #endregion

        #region**Client**
        private void NetClientRcv()
        {
            while (true)
            {
                try
                {
                    int n = NetClient.Receive(NetDataBuf, 1024, SocketFlags.None);
                    if (n == 0)
                    {
                        throw new Exception();
                    }
                    Nrx += (UInt64)n;
                    NetProcessData();
                }
                catch (Exception ex)
                {
                    if (NetConnectBtn.Text == "关闭")
                    {
                        NetInformLog(ex.Message);
                        NetConnectBtn.PerformClick();
                    }
                    break;
                }
            }
        }
        #endregion

        #region**UDP**
        private void NetUdpRcv()
        {
            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    //关闭udpClient时此句会产生异常
                    byte[] receiveBytes = NetLocalUdp.Receive(ref remote);
                    NetDataBuf = receiveBytes;
                    Nrx += (UInt64)receiveBytes.Length;
                    NetProcessData();
                }
                catch
                {
                    break;
                }
            }
        }
        #endregion

        #endregion



        #region**网络发送Hex发送框清空处理**
        private void NetSndHEX_CheckedChanged(object sender, EventArgs e)
        {
            if (NetSndHEX.Checked)
                NetSndTextBox.Clear();
        }
        #endregion

        #region**串口发送Hex发送框清空处理**
        private void SerialSndHEX_CheckedChanged(object sender, EventArgs e)
        {
            if (SerialSndHEX.Checked)
                SerialSndTextBox.Clear();
        }
        #endregion

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            //pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            ////pictureBox1
            pictureBox1.BackColor = Color.AliceBlue;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Grap.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pe = new Pen(Color.Gainsboro, 2f))
            {                
                //Grap.DrawLine(pe, 0, pictureBox1.Height / 2 - 15, pictureBox1.Width, pictureBox1.Height / 2);
                //Grap.DrawLine(pe, pictureBox1.Width, pictureBox1.Height / 2, 0, pictureBox1.Height / 2 + 15);
                PointF[] points= new PointF[5];
                points[0] = new PointF(pictureBox1.Width - 1, pictureBox1.Height / 2 - 15);
                points[1] = new PointF(1, pictureBox1.Height / 2);
                points[2] = new PointF(pictureBox1.Width - 1, pictureBox1.Height / 2 + 15);
                points[3] = new PointF( 5, pictureBox1.Height / 2);
                points[4] = new PointF(pictureBox1.Width - 1, pictureBox1.Height / 2 - 15);
                Grap.DrawPolygon(pe, points);

                pe.Color = Color.LightGray;
                pe.Width = 1;
                Grap.DrawLine(pe,0,0,pictureBox1.Width-1,0);
                Grap.DrawLine(pe,pictureBox1.Width-1,0,pictureBox1.Width-1,pictureBox1.Height-1);
                Grap.DrawLine(pe,pictureBox1.Width-1,pictureBox1.Height-1,0,pictureBox1.Height-1);
                Grap.DrawLine(pe, 0, pictureBox1.Height-1,0,0);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics Grap = e.Graphics;
            Grap.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pe = new Pen(Color.Gainsboro, 2f))
            {
                //Grap.DrawLine(pe, 0, pictureBox1.Height / 2 - 15, pictureBox1.Width, pictureBox1.Height / 2);
                //Grap.DrawLine(pe, pictureBox1.Width, pictureBox1.Height / 2, 0, pictureBox1.Height / 2 + 15);
                PointF[] points = new PointF[5];
                points[0] = new PointF(1, pictureBox2.Height / 2 - 15);
                points[1] = new PointF(pictureBox2.Width - 1, pictureBox2.Height / 2);
                points[2] = new PointF(1, pictureBox2.Height / 2 + 15);
                points[3] = new PointF(pictureBox2.Width - 5, pictureBox2.Height / 2);
                points[4] = new PointF(1, pictureBox2.Height / 2 - 15);
                Grap.DrawPolygon(pe, points);

                pe.Color = Color.LightGray;
                pe.Width = 1;
                Grap.DrawLine(pe, 0, 0, pictureBox2.Width - 1, 0);
                Grap.DrawLine(pe, pictureBox2.Width - 1, 0, pictureBox2.Width - 1, pictureBox2.Height - 1);
                Grap.DrawLine(pe, pictureBox2.Width - 1, pictureBox2.Height - 1, 0, pictureBox2.Height - 1);
                Grap.DrawLine(pe, 0, pictureBox2.Height - 1, 0, 0);
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.AliceBlue;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }


        #region**网络提示栏处理**
        private delegate void NetInformLogDelegate(string str);
        private void NetInformLog(string str)
        {
            if (NetInfo.InvokeRequired)
            {
                NetInformLogDelegate d = NetInformLog;
                NetInfo.Invoke(d, str);
            }
            else
            {
                NetInfo.Text = str;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            DealLeft();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            DealRight();
        }


        #endregion

        #region **按键按下**
        private void DealLeft()
        {
            if (UIMode == 1)
            {
                panel2.Hide();
                pictureBox1.Hide();
                pictureBox2.Location = new Point(0, 32);
                panel1.Location = new Point(2, 12);
                panel1.Width = 794;
                UIMode = 0;
            }
            else if (UIMode == 2)
            {
                panel2.Width = 397;
                pictureBox1.Location = new Point(391, 32);
                pictureBox2.Show();
                panel1.Show();
                UIMode = 1;
            }
        }

        private void DealRight()
        {
            if (UIMode == 1)
            {
                panel1.Hide();
                pictureBox2.Hide();
                pictureBox1.Location = new Point(789, 32);
                panel2.Width = 794;
                UIMode = 2;

            }
            else if (UIMode == 0)
            {
                pictureBox2.Location = new Point(401, 32);
                panel1.Location = new Point(403, 12);
                panel1.Width = 397;
                pictureBox1.Show();
                panel2.Show();
                UIMode = 1;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.Right))
            {
                DealRight();
                e.Handled = true;
            }
            else if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.Left))
            {
                DealLeft();
                e.Handled = true;
            }
            else if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.Enter))
            {
                //SerialRcvTextBox.AppendText("Ctrl+Enter\r\n");
                e.Handled = true;
            }
            else
                e.Handled = false;
        }
        #endregion
    }
}
