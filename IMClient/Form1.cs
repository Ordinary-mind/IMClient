using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMClient
{
    public partial class Form1 : Form
    {
        public delegate void appendTextDelegate(String msg);
        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void tbConnectServer_Click(object sender, EventArgs e)
        {
            String serverIP = null;
            int port;
            try
            {
                serverIP = this.tbServerIP.Text.Trim();
                port = Convert.ToInt32(this.tbPort.Text);
                if (client != null)
                {
                    MessageBox.Show("不能重复登录");
                }
                else
                {
                    client = new TcpClient();
                    client.BeginConnect(serverIP, port, connectServerCallback, client);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        byte[] bytes = new byte[1024];
        private void connectServerCallback(IAsyncResult ar)
        {
            client = (TcpClient)ar.AsyncState;
            if (client != null)
            {
                try
                {
                    client.EndConnect(ar);
                    tbTip.AppendText("已连接到服务器");
                    NetworkStream stream = client.GetStream();

                    if (stream.CanRead)
                    {
                        stream.BeginRead(bytes, 0, bytes.Length, new AsyncCallback(receiveDataCallback), stream);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void receiveDataCallback(IAsyncResult ar)
        {
            NetworkStream stream = (NetworkStream)ar.AsyncState;
            int recvCount = 0;
            if (stream.CanRead)
            {
                recvCount = stream.EndRead(ar);
                if (recvCount != 0)
                {

                    byte[] buffer = new byte[recvCount];
                    Array.Copy(bytes, 0, buffer, 0, recvCount);
                    this.appendTextInvoke("收←" + Encoding.UTF8.GetString(buffer) + "\n");
                    stream.BeginRead(bytes, 0, bytes.Length, receiveDataCallback, stream);
                }
            }

        }

        private void appendTextInvoke(String msg)
        {
            if (this.tbChatContent.InvokeRequired)
            {
                appendTextDelegate dele = new appendTextDelegate(appendTextInvoke);
                this.tbChatContent.Invoke(dele, msg);
            }
            else
            {
                this.tbChatContent.AppendText(msg);
            }
        }


        private void btnSendData_Click(object sender, EventArgs e)
        {
            string msg = this.tbSendData.Text;
            if (client == null) return;
            if (client.Connected == false) return;

            byte[] data = Encoding.UTF8.GetBytes(msg);

            int len = data.Length;

            NetworkStream writeStream = client.GetStream();
            if (writeStream.CanWrite)
            {
               writeStream.Write(data, 0, len);
                this.tbChatContent.AppendText("发→" + msg + "\n");
            }
            else
            {
                MessageBox.Show("写流无法使用");
                client.Close();
            }

        }

        private void tbDisconnectServer_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client = null;
            }
            else
            {
                MessageBox.Show("您未与服务器建立连接");
            }
        }
    }
}
