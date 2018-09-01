using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace IMClient
{
    public partial class Login : Form
    {
        ClientHelper helper = new ClientHelper();
        string serverIP = "127.0.0.1";
        int port = 9000;
        byte[] bytes = new byte[1024];
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
                    StringBuilder builder = new StringBuilder();
                    builder.Append("@1@").Append(userName).Append(password);
                    byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
                    int len = data.Length;
                    NetworkStream writeStream = helper.tcpClient.GetStream();
                    if (writeStream.CanWrite)
                    {
                        writeStream.Write(data, 0, len);
                    }
                    else
                    {
                        MessageBox.Show("写流无法使用");
                        helper.tcpClient.Close();
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register(this);
            register.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            helper.tcpClient = new TcpClient();
            helper.tcpClient.BeginConnect(serverIP, port, connectCallback, helper);
        }

        private void connectCallback(IAsyncResult ar)
        {
            ClientHelper clientHelper = (ClientHelper)ar.AsyncState;
            if (clientHelper.tcpClient != null)
            {
                try
                {
                    clientHelper.tcpClient.EndConnect(ar);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("与服务器连接发生错误！");
                }
            }
        }
    }
    }
