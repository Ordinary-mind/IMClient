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
        ClientHelper clientHelper = null;
        byte[] bytes = new byte[1024];
        public Form1()
        {
            
        }
        public Form1(ClientHelper clientHelper)
        {
            InitializeComponent();
            this.clientHelper = clientHelper;
        }

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
                    this.appendTextInvoke("收←" + Encoding.UTF8.GetString(buffer) + "\n");
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
            if (clientHelper.tcpClient == null) return;
            if (clientHelper.tcpClient.Connected == false) return;

            byte[] data = Encoding.UTF8.GetBytes(msg);

            int len = data.Length;

            NetworkStream writeStream = clientHelper.tcpClient.GetStream();
            if (writeStream.CanWrite)
            {
               writeStream.Write(data, 0, len);
               this.tbChatContent.AppendText("发→" + msg + "\n");
            }
            else
            {
                MessageBox.Show("写流无法使用");
                clientHelper.tcpClient.Close();
            }

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                NetworkStream stream = clientHelper.tcpClient.GetStream();
                if (stream.CanRead)
                {
                    stream.BeginRead(bytes, 0, bytes.Length, receiveDataCallback, clientHelper);
                }
                if (stream.CanWrite)
                {
                    string msg = "@" + clientHelper.UserId + "," + clientHelper.NickName + "@";
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    stream.Write(data, 0, data.Length);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
