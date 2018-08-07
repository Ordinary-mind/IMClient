namespace IMClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbServerIP = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbChatContent = new System.Windows.Forms.Label();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbChatContent = new System.Windows.Forms.TextBox();
            this.tbSendData = new System.Windows.Forms.TextBox();
            this.tbDisconnectServer = new System.Windows.Forms.Button();
            this.tbConnectServer = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.tbTip = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbConnectServer);
            this.groupBox1.Controls.Add(this.tbDisconnectServer);
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.tbServerIP);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Controls.Add(this.lbServerIP);
            this.groupBox1.Location = new System.Drawing.Point(23, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接区";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbTip);
            this.groupBox2.Controls.Add(this.btnSendData);
            this.groupBox2.Controls.Add(this.tbSendData);
            this.groupBox2.Controls.Add(this.tbChatContent);
            this.groupBox2.Controls.Add(this.lbChatContent);
            this.groupBox2.Location = new System.Drawing.Point(23, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 322);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "交互区";
            // 
            // lbServerIP
            // 
            this.lbServerIP.AutoSize = true;
            this.lbServerIP.Location = new System.Drawing.Point(6, 29);
            this.lbServerIP.Name = "lbServerIP";
            this.lbServerIP.Size = new System.Drawing.Size(53, 12);
            this.lbServerIP.TabIndex = 0;
            this.lbServerIP.Text = "服务器IP";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(166, 29);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(29, 12);
            this.lbPort.TabIndex = 1;
            this.lbPort.Text = "端口";
            // 
            // lbChatContent
            // 
            this.lbChatContent.AutoSize = true;
            this.lbChatContent.Location = new System.Drawing.Point(17, 29);
            this.lbChatContent.Name = "lbChatContent";
            this.lbChatContent.Size = new System.Drawing.Size(53, 12);
            this.lbChatContent.TabIndex = 1;
            this.lbChatContent.Text = "聊天记录";
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(65, 26);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(79, 21);
            this.tbServerIP.TabIndex = 2;
            this.tbServerIP.Text = "127.0.0.1";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(201, 26);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(55, 21);
            this.tbPort.TabIndex = 3;
            this.tbPort.Text = "9000";
            // 
            // tbChatContent
            // 
            this.tbChatContent.Location = new System.Drawing.Point(76, 29);
            this.tbChatContent.Multiline = true;
            this.tbChatContent.Name = "tbChatContent";
            this.tbChatContent.Size = new System.Drawing.Size(340, 204);
            this.tbChatContent.TabIndex = 3;
            // 
            // tbSendData
            // 
            this.tbSendData.Location = new System.Drawing.Point(76, 252);
            this.tbSendData.Name = "tbSendData";
            this.tbSendData.Size = new System.Drawing.Size(274, 21);
            this.tbSendData.TabIndex = 4;
            // 
            // tbDisconnectServer
            // 
            this.tbDisconnectServer.Location = new System.Drawing.Point(356, 24);
            this.tbDisconnectServer.Name = "tbDisconnectServer";
            this.tbDisconnectServer.Size = new System.Drawing.Size(60, 23);
            this.tbDisconnectServer.TabIndex = 4;
            this.tbDisconnectServer.Text = "断开";
            this.tbDisconnectServer.UseVisualStyleBackColor = true;
            this.tbDisconnectServer.Click += new System.EventHandler(this.tbDisconnectServer_Click);
            // 
            // tbConnectServer
            // 
            this.tbConnectServer.Location = new System.Drawing.Point(273, 24);
            this.tbConnectServer.Name = "tbConnectServer";
            this.tbConnectServer.Size = new System.Drawing.Size(77, 23);
            this.tbConnectServer.TabIndex = 5;
            this.tbConnectServer.Text = "连接服务器";
            this.tbConnectServer.UseVisualStyleBackColor = true;
            this.tbConnectServer.Click += new System.EventHandler(this.tbConnectServer_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(356, 250);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(60, 23);
            this.btnSendData.TabIndex = 5;
            this.btnSendData.Text = "发送";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // tbTip
            // 
            this.tbTip.Location = new System.Drawing.Point(76, 295);
            this.tbTip.Name = "tbTip";
            this.tbTip.Size = new System.Drawing.Size(340, 21);
            this.tbTip.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 472);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "IM客户端";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button tbConnectServer;
        private System.Windows.Forms.Button tbDisconnectServer;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbServerIP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.TextBox tbSendData;
        private System.Windows.Forms.TextBox tbChatContent;
        private System.Windows.Forms.Label lbChatContent;
        private System.Windows.Forms.TextBox tbTip;
    }
}

