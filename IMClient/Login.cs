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
    public partial class Login : Form
    {
        MySqlConnection connection = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        String connnectStr = "server=127.0.0.1;port=3306;user=root;password=12345678; database=network;SslMode = none;";
        String sql = null;
        ClientHelper clientInfo = null;
        String serverIP = null;
        int port;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String userName = this.tbUserName.Text;
            String password = this.tbPassword.Text;
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("请填写有效的用户名和密码！");
            }
            else
            {
                try
                {
                    sql = "select * from useraccount where user_name='" + userName + "' and password='" + password + "'";
                    connection = new MySqlConnection(connnectStr);
                    connection.Open();
                    command = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        clientInfo = new ClientHelper();
                        clientInfo.UserId = reader.GetInt32("user_id");
                        clientInfo.NickName = reader.GetString("nick_name");
                        connection.Close();
                        String serverIP = null;
                        int port;
                        try
                        {
                            serverIP = "127.0.0.1";
                            port = 9000;
                            if (clientInfo.tcpClient != null)
                            {
                                MessageBox.Show("client已被初始化");
                            }
                            else
                            {
                                clientInfo.tcpClient = new TcpClient();
                                Console.WriteLine("begin connect to server");
                                clientInfo.tcpClient.BeginConnect(serverIP, port, connectServerCallback, clientInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        connection.Close();
                        MessageBox.Show("用户名或密码错误！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void connectServerCallback(IAsyncResult ar)
        {
            ClientHelper helper = (ClientHelper)ar.AsyncState;
            try
            {
                helper.tcpClient.EndConnect(ar);
                Console.WriteLine("end connect");
                if (helper.tcpClient != null)
                {
                    string msg = "@" + helper.UserId + "," + helper.NickName + "@";
                    if (helper.tcpClient.Connected == false) return;
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    int len = data.Length;
                    NetworkStream stream = helper.tcpClient.GetStream();
                    if (stream.CanWrite)
                    {
                        stream.Write(data, 0, len);
                    }
                    else
                    {
                        MessageBox.Show("写流无法使用");
                        helper.tcpClient.Close();
                    }

                }
                
                //Form1 form1 = new Form1(helper, this);
                //form1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Invoke((EventHandler)delegate
            {
                this.Hide();
                Form1 form1 = new Form1(clientInfo, this);
                form1.Show();
            });
            
          
        }
    }
    }
