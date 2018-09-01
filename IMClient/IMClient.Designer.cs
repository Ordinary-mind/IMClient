using System;
using System.Windows.Forms;

namespace IMClient
{
    partial class IMClient
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.tbSendData = new System.Windows.Forms.TextBox();
            this.tbChatContent = new System.Windows.Forms.TextBox();
            this.lbChatContent = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.lbFriendList = new System.Windows.Forms.Label();
            this.cbFriendList = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSendData);
            this.groupBox2.Controls.Add(this.tbSendData);
            this.groupBox2.Controls.Add(this.tbChatContent);
            this.groupBox2.Controls.Add(this.lbChatContent);
            this.groupBox2.Location = new System.Drawing.Point(22, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 343);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "交互区";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(465, 292);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(60, 23);
            this.btnSendData.TabIndex = 5;
            this.btnSendData.Text = "发送";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // tbSendData
            // 
            this.tbSendData.Location = new System.Drawing.Point(76, 294);
            this.tbSendData.Name = "tbSendData";
            this.tbSendData.Size = new System.Drawing.Size(383, 21);
            this.tbSendData.TabIndex = 4;
            // 
            // tbChatContent
            // 
            this.tbChatContent.Location = new System.Drawing.Point(76, 29);
            this.tbChatContent.Multiline = true;
            this.tbChatContent.Name = "tbChatContent";
            this.tbChatContent.Size = new System.Drawing.Size(449, 245);
            this.tbChatContent.TabIndex = 3;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddFriend);
            this.groupBox1.Controls.Add(this.lbFriendList);
            this.groupBox1.Controls.Add(this.cbFriendList);
            this.groupBox1.Location = new System.Drawing.Point(22, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息区";
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Location = new System.Drawing.Point(434, 25);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(75, 23);
            this.btnAddFriend.TabIndex = 2;
            this.btnAddFriend.Text = "添加好友";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // lbFriendList
            // 
            this.lbFriendList.AutoSize = true;
            this.lbFriendList.Location = new System.Drawing.Point(17, 31);
            this.lbFriendList.Name = "lbFriendList";
            this.lbFriendList.Size = new System.Drawing.Size(53, 12);
            this.lbFriendList.TabIndex = 1;
            this.lbFriendList.Text = "好友列表";
            // 
            // cbFriendList
            // 
            this.cbFriendList.FormattingEnabled = true;
            this.cbFriendList.Location = new System.Drawing.Point(76, 28);
            this.cbFriendList.Name = "cbFriendList";
            this.cbFriendList.Size = new System.Drawing.Size(196, 20);
            this.cbFriendList.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 485);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(597, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "状态栏";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "状态信息";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 507);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IM客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formCloseAction);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.TextBox tbSendData;
        private System.Windows.Forms.TextBox tbChatContent;
        private System.Windows.Forms.Label lbChatContent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbFriendList;
        private System.Windows.Forms.ComboBox cbFriendList;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnAddFriend;
    }
}

