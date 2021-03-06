﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IMClient
{
    public class ClientHelper
    {
        public TcpClient tcpClient { get; set; }
        public byte[] buffer { get; set; }
        private int userId;
        private String nickName;
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public String NickName
        {
            get
            {
                return nickName;
            }
            set
            {
                nickName = value;
            }
        }
    }
}
