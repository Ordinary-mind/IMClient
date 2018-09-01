﻿using MySql.Data.MySqlClient;
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
        MySqlConnection connection = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        String connnectStr = "server=127.0.0.1;port=3306;user=root;password=lqn.091023; database=network;SslMode = none;";
        string sql = null;
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
            this.toolStripStatusLabel1.Text = "已连接到服务器";
            try
            {
                NetworkStream stream = clientHelper.tcpClient.GetStream();
                if (stream.CanRead)
                {
                    stream.BeginRead(bytes, 0, bytes.Length, receiveDataCallback, clientHelper);
                }
                if (stream.CanWrite)
                {
                    string msg = "@1@" + clientHelper.UserId + "," + clientHelper.NickName;
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                sql = "select f.friend_id,u.user_id,u.nick_name from friend f left join useraccount u on f.friend_id=u.user_id where f.self_id=" + clientHelper.UserId;
                connection = new MySqlConnection(connnectStr);
                connection.Open();
                command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.cbFriendList.Items.Add(reader.GetString("nick_name"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
