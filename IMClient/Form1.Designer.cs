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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.tbSendData = new System.Windows.Forms.TextBox();
            this.tbChatContent = new System.Windows.Forms.TextBox();
            this.lbChatContent = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSendData);
            this.groupBox2.Controls.Add(this.tbSendData);
            this.groupBox2.Controls.Add(this.tbChatContent);
            this.groupBox2.Controls.Add(this.lbChatContent);
            this.groupBox2.Location = new System.Drawing.Point(23, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 440);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "交互区";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
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
            // tbSendData
            // 
            this.tbSendData.Location = new System.Drawing.Point(76, 252);
            this.tbSendData.Name = "tbSendData";
            this.tbSendData.Size = new System.Drawing.Size(274, 21);
            this.tbSendData.TabIndex = 4;
            // 
            // tbChatContent
            // 
            this.tbChatContent.Location = new System.Drawing.Point(76, 29);
            this.tbChatContent.Multiline = true;
            this.tbChatContent.Name = "tbChatContent";
            this.tbChatContent.Size = new System.Drawing.Size(340, 204);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 472);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "IM客户端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.TextBox tbSendData;
        private System.Windows.Forms.TextBox tbChatContent;
        private System.Windows.Forms.Label lbChatContent;
    }
}

