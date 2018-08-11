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
        ClientHelper clientInfo = null;
        Login login = null;
        public Form1()
        {

        }
        public Form1(ClientHelper clientInfo, Login login)
        {
            this.clientInfo = clientInfo;
            this.login = login;
            InitializeComponent();
        }

        byte[] bytes = new byte[1024];

        private void receiveDataCallback(IAsyncResult ar)
        {
            ClientHelper helper = (ClientHelper)ar.AsyncState;
            NetworkStream stream = helper.tcpClient.GetStream();
            int recvCount = 0;
            if (stream.CanRead)
            {
                recvCount = stream.EndRead(ar);
                if (recvCount != 0)
                {

                    byte[] buffer = new byte[recvCount];
                    Array.Copy(bytes, 0, buffer, 0, recvCount);
                    appendTextInvoke("收←" + Encoding.UTF8.GetString(buffer) + "\n");
                    stream.BeginRead(bytes, 0, bytes.Length, receiveDataCallback, helper);
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
            if (clientInfo.tcpClient == null) return;
            if (clientInfo.tcpClient.Connected == false) return;

            byte[] data = Encoding.UTF8.GetBytes(msg);

            int len = data.Length;

            NetworkStream writeStream = clientInfo.tcpClient.GetStream();
            if (writeStream.CanWrite)
            {
               writeStream.Write(data, 0, len);
                appendTextInvoke("发→" + msg + "\n");
            }
            else
            {
                MessageBox.Show("写流无法使用");
                clientInfo.tcpClient.Close();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = clientInfo.tcpClient;
                NetworkStream stream = client.GetStream();
                if (stream.CanRead)
                {
                    stream.BeginRead(bytes, 0, bytes.Length, receiveDataCallback, clientInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
