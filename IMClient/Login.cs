using MySql.Data.MySqlClient;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace IMClient
{
    public partial class Login : Form
    {
        MySqlConnection connection = null;
        MySqlCommand command = null;
        MySqlDataReader reader = null;
        String connnectStr = "server=127.0.0.1;port=3306;user=root;password=lqn.091023; database=network;SslMode = none;";
        String sql = null;
        ClientHelper helper = null;
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
                    sql = "select * from useraccount where user_name='" + userName + "' and password='" + password + "'";
                    Console.WriteLine(sql);
                    connection = new MySqlConnection(connnectStr);
                    connection.Open();
                    command = new MySqlCommand(sql, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        helper = new ClientHelper();
                        helper.UserId = reader.GetInt32("user_id");
                        helper.NickName = reader.GetString("nick_name");
                        connection.Close();
                        try
                        {
                            {
                                helper.tcpClient = new TcpClient();
                                helper.tcpClient.BeginConnect(serverIP, port, connectServerCallback, helper);
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
            ClientHelper clientHelper = (ClientHelper)ar.AsyncState;
            if (clientHelper.tcpClient != null)
            {
                try
                {
                    clientHelper.tcpClient.EndConnect(ar);
                    this.Invoke((EventHandler)delegate{
                        this.Hide();
                        Form1 form1 = new Form1(clientHelper);
                        form1.Show();
                                 });
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register(this);
            this.Hide();
            register.Show();
        }
    }
    }
