
namespace WindowsClient
{
    partial class OneToOneChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneToOneChatForm));
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMyMessage = new System.Windows.Forms.TextBox();
            this.lblMyMessage = new System.Windows.Forms.Label();
            this.lstChatMessages = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOnlineUsers = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSendMessage.BackgroundImage")));
            this.btnSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendMessage.Location = new System.Drawing.Point(687, 357);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(71, 63);
            this.btnSendMessage.TabIndex = 20;
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMyMessage
            // 
            this.txtMyMessage.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMyMessage.Location = new System.Drawing.Point(54, 357);
            this.txtMyMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMyMessage.Multiline = true;
            this.txtMyMessage.Name = "txtMyMessage";
            this.txtMyMessage.Size = new System.Drawing.Size(603, 71);
            this.txtMyMessage.TabIndex = 19;
            // 
            // lblMyMessage
            // 
            this.lblMyMessage.AutoSize = true;
            this.lblMyMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyMessage.Location = new System.Drawing.Point(48, 316);
            this.lblMyMessage.Name = "lblMyMessage";
            this.lblMyMessage.Size = new System.Drawing.Size(167, 31);
            this.lblMyMessage.TabIndex = 18;
            this.lblMyMessage.Text = "My Message";
            // 
            // lstChatMessages
            // 
            this.lstChatMessages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstChatMessages.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChatMessages.FormattingEnabled = true;
            this.lstChatMessages.ItemHeight = 20;
            this.lstChatMessages.Location = new System.Drawing.Point(50, 72);
            this.lstChatMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstChatMessages.Name = "lstChatMessages";
            this.lstChatMessages.Size = new System.Drawing.Size(657, 228);
            this.lstChatMessages.TabIndex = 17;
            this.lstChatMessages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstChatMessages_DrawItem);
            this.lstChatMessages.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstChatMessages_MeasureItem);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblTitle.Location = new System.Drawing.Point(45, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 26);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "OneToOne Message Window";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Please select any username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(816, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Online Users";
            // 
            // lbOnlineUsers
            // 
            this.lbOnlineUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbOnlineUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbOnlineUsers.FormattingEnabled = true;
            this.lbOnlineUsers.ItemHeight = 22;
            this.lbOnlineUsers.Location = new System.Drawing.Point(821, 72);
            this.lbOnlineUsers.Name = "lbOnlineUsers";
            this.lbOnlineUsers.Size = new System.Drawing.Size(120, 356);
            this.lbOnlineUsers.TabIndex = 24;
            this.lbOnlineUsers.SelectedIndexChanged += new System.EventHandler(this.lbOnlineUsers_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(445, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(193, 41);
            this.btnBack.TabIndex = 25;
            this.btnBack.Text = "Go back to Dashboard";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // OneToOneChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 446);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbOnlineUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMyMessage);
            this.Controls.Add(this.lblMyMessage);
            this.Controls.Add(this.lstChatMessages);
            this.Controls.Add(this.lblTitle);
            this.Name = "OneToOneChatForm";
            this.Text = "OneToOneChatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtMyMessage;
        private System.Windows.Forms.Label lblMyMessage;
        private System.Windows.Forms.ListBox lstChatMessages;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbOnlineUsers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnBack;
    }
}