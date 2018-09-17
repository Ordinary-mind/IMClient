﻿using IMClient.Entity;
using IMClient.Utils;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections;
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
        ClientHelper clientHelper = Login.helper;
        List<ComboxItem> items = new List<ComboxItem>();
        AddFriendForm addFriendForm = null;
        //private string toAddFriendFormString;
        //public string ToAddFriendFormString
        //{
        //    get
        //    {
        //        return toAddFriendFormString;
        //    }
        //    set
        //    {
        //        if (value != toAddFriendFormString)
        //        {
        //            toAddFriendFormString = value;
        //            ValueChanged();
        //        }
        //    }
        //}

        //private void ValueChanged()
        //{
        //    if (ValueChangeEvent != null)
        //    {
                
        //    }
        //}

        byte[] bytes = new byte[10240];
        
        public IMClient()
        {
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
                    if (recvCount>0)
                    {

                        byte[] buffer = new byte[recvCount];
                        Array.Copy(bytes, 0, buffer, 0, recvCount);
                        string recvString = Encoding.UTF8.GetString(buffer);
                        string instrction = recvString.Substring(0, 4);
                        string content = recvString.Substring(4);
                        switch (instrction)
                        {
                            case "@02@":
                                List<UserAccount> accounts = JsonConvert.DeserializeObject<List<UserAccount>>(content);
                                foreach (UserAccount account in accounts)
                                {
                                    ComboxItem item = new ComboxItem(account.NickName,account.UserId);
                                    this.Invoke((EventHandler)delegate
                                    {
                                        items.Add(item);
                                        cbFriendList.Items.Add(item);
                                    });
                                }
                                break;
                            case "@03@":
                                if (addFriendForm != null) addFriendForm.ContentFromServer = content;
                                else
                                {
                                    addFriendForm = new AddFriendForm();
                                    addFriendForm.ContentFromServer = content;
                                }
                                break;
                            case "@04@":
                                ChatRecords record = JsonConvert.DeserializeObject<ChatRecords>(content);
                                if (record != null)
                                {
                                    var user = items.Where(item => Int32.Parse(item.Value.ToString()) == record.FromId).ToList();
                                    if (user.Count > 0)
                                    {
                                        this.Invoke((EventHandler)delegate {
                                            tbChatContent.AppendText("收←" + user[0].Key + ":" + record.Content + "\n");
                                        });
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                stream.BeginRead(bytes, 0, bytes.Length,receiveDataCallback,helper);
            }
            catch (Exception ex)
            {
                MessageBox.Show("flag=="+ex.Message);
                stream.Close();
                helper.tcpClient.Close();
            }

        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                string sendTo = cbFriendList.Text;
                if (String.IsNullOrEmpty(sendTo))
                {
                    MessageBox.Show("请先选择聊天对象！");
                }
                else
                {
                    string userId = ((ComboxItem)cbFriendList.SelectedItem).Value.ToString();
                    string nickName = ((ComboxItem)cbFriendList.SelectedItem).Key;

                    ChatRecords record = new ChatRecords();
                    record.RecordId = Guid.NewGuid().ToString().Replace("-", "");
                    record.FromId = clientHelper.UserId;
                    record.ToId = int.Parse(userId);
                    record.SendTime = DateTime.Now;
                    record.Content = tbSendData.Text == null ? "" : tbSendData.Text;
                    string content = JsonConvert.SerializeObject(record);
                    builder.Append("@04@");
                    builder.Append(content);
                    if (clientHelper.tcpClient == null) return;
                    if (clientHelper.tcpClient.Connected == false) return;

                    byte[] data = Encoding.UTF8.GetBytes(builder.ToString());

                    int len = data.Length;

                    NetworkStream writeStream = clientHelper.tcpClient.GetStream();
                    if (writeStream.CanWrite)
                    {
                        writeStream.Write(data, 0, len);
                        this.tbChatContent.AppendText("发→"+ nickName+":" + record.Content + "\n");
                    }
                    else
                    {
                        MessageBox.Show("写流无法使用");
                        clientHelper.tcpClient.Close();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("IMServer.btnSendData_Click" + ex.Message);
            }

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.clientHelper.tcpClient.GetStream().BeginRead(bytes, 0, bytes.Length, receiveDataCallback, this.clientHelper);
                StringBuilder builder = new StringBuilder();
                builder.Append("@02@");
                if (clientHelper.tcpClient == null) return;
                if (clientHelper.tcpClient.Connected == false) return;

                byte[] data = Encoding.UTF8.GetBytes(builder.ToString());

                int len = data.Length;

                NetworkStream writeStream = clientHelper.tcpClient.GetStream();
                if (writeStream.CanWrite)
                {
                    writeStream.Write(data, 0, len);
                }
                else
                {
                    MessageBox.Show("写流无法使用");
                    clientHelper.tcpClient.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("load" + ex.Message);
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
            addFriendForm = new AddFriendForm();
            addFriendForm.Show();
        }
    }
}
