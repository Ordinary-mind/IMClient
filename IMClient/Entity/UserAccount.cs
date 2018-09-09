using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMClient.Entity
{
    class UserAccount
    {
        public UserAccount()
        {

        }
        public UserAccount(int UserId,string UserName,string NickName,string Password)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.NickName = NickName;
            this.Password = Password;
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
    }
}
