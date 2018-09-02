using MySql.Data.MySqlClient;
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
    public partial class IMClient : Form
    {
        public delegate void appendTextDelegate(String msg);
        ClientHelper clientHelper = new ClientHelper();
        string serverIP = "127.0.0.1";
        int port = 9000;
        byte[] bytes = new byte[1024];
        public IMClient()
        {
            
            
        }
        public IMClient(ClientHelper clientHelper)
        {
            this.clientHelper = clientHelper;
            InitializeComponent();
        }

        private void receiveDataCallback(IAsyncResult ar)
        {
            ClientHelper helper = (ClientHelper)ar.AsyncState;
            NetworkStream stream = helper.tcpClient.GetStream();
            int recvCount = 0;
            try
            {
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
            catch (Exception ex)
            {
                stream.Close();
                helper.tcpClient.Close();
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
            StringBuilder builder = new StringBuilder();
            builder.Append("@2@");
            string msg = this.tbSendData.Text;
            builder.Append(msg);
            if (clientHelper.tcpClient == null) return;
            if (clientHelper.tcpClient.Connected == false) return;

            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());

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
           
        }

        private void formCloseAction(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult r = MessageBox.Show("确定要退出程序?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r != DialogResult.OK)
                {
                    e.Cancel = true;//阻止关闭窗口
                }
                else Application.Exit();

            }
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            AddFriendForm addFriendForm = new AddFriendForm();
            addFriendForm.Show();
        }
    }
}
