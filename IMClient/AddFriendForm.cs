﻿using IMClient.Entity;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMClient
{
    public partial class AddFriendForm : Form
    {
        public ClientHelper clientHelper = null;
        byte[] bytes = new byte[10240];
        public AddFriendForm()
        {
            
        }
        public AddFriendForm(ClientHelper clientHelper)
        {
            InitializeComponent();
            this.clientHelper = clientHelper;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string content = this.tbSearch.Text;
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("搜索内容不能为空！");
            }
            try
            {
                if (clientHelper.tcpClient != null)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes("@03@"+content);
                    NetworkStream stream = clientHelper.tcpClient.GetStream();
                    stream.Write(bytes, 0, bytes.Length);

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddFriendForm_Load(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = clientHelper.tcpClient;
                NetworkStream stream = client.GetStream();
                if (stream.CanRead)
                {
                    stream.BeginRead(bytes, 0, bytes.Length, readCallback, clientHelper);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AddFriendForm-AddFriendForm_Load:" + ex.Message);
            }

        }

        private void readCallback(IAsyncResult ar)
        {
            try
            {
                ClientHelper helper = (ClientHelper)ar.AsyncState;
                NetworkStream stream = helper.tcpClient.GetStream();
                int length = stream.EndRead(ar);
                byte[] buff = new byte[length];
                Array.Copy(bytes, buff,length);
                string result = Encoding.UTF8.GetString(buff);
                string instruction = result.Substring(0, 4);
                string content = result.Substring(4);
                List<UserAccount> userAccounts = JsonConvert.DeserializeObject<List<UserAccount>>(content);
                if (userAccounts.Count>0)
                {
                    this.Invoke((EventHandler)delegate {
                        dataGridView2.Rows.Clear();
                    });
                    foreach(UserAccount account in userAccounts)
                    {
                        this.Invoke((EventHandler)delegate
                        {
                            int index = dataGridView2.Rows.Add();
                            dataGridView2.Rows[index].Cells[0].Value = account.UserId;
                            dataGridView2.Rows[index].Cells[1].Value = account.NickName;
                        });
                    }
                }
                else
                {
                    MessageBox.Show("未搜索到相关用户！");
                }
                stream.BeginRead(bytes, 0, bytes.Length, readCallback, clientHelper);
            }
            catch(Exception ex)
            {
                MessageBox.Show("AddFriendForm-readCallback:" + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}