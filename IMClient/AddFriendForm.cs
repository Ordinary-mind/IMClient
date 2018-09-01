using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMClient
{
    public partial class AddFriendForm : Form
    {
        public AddFriendForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string content = this.tbSearch.Text;
            if (!string.IsNullOrEmpty(content))
            {
                string sql = "select * from useraccount where nick_name=@nick_name";
                DataTable data = DBHelper.QueryData(sql, new MySqlParameter[] { new MySqlParameter("nick_name", content) });
                if (data != null)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        string userId = data.Rows[i]["user_id"].ToString();
                        string nickName = data.Rows[i]["nick_name"].ToString();
                        MessageBox.Show("匹配到：用户ID：" + userId + ",昵称：" + nickName);
                    }
                }
                else
                {
                    MessageBox.Show("未匹配到该用户！");
                }
            }
        }
    }
}
