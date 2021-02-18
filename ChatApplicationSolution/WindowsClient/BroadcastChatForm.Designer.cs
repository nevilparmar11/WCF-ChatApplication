
namespace WindowsClient
{
    partial class BroadcastChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BroadcastChatForm));
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMyMessage = new System.Windows.Forms.TextBox();
            this.lblMyMessage = new System.Windows.Forms.Label();
            this.lstChatMessages = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSendMessage.BackgroundImage")));
            this.btnSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendMessage.Location = new System.Drawing.Point(701, 356);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(71, 63);
            this.btnSendMessage.TabIndex = 15;
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMyMessage
            // 
            this.txtMyMessage.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMyMessage.Location = new System.Drawing.Point(68, 356);
            this.txtMyMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMyMessage.Multiline = true;
            this.txtMyMessage.Name = "txtMyMessage";
            this.txtMyMessage.Size = new System.Drawing.Size(603, 71);
            this.txtMyMessage.TabIndex = 14;
            // 
            // lblMyMessage
            // 
            this.lblMyMessage.AutoSize = true;
            this.lblMyMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyMessage.Location = new System.Drawing.Point(62, 315);
            this.lblMyMessage.Name = "lblMyMessage";
            this.lblMyMessage.Size = new System.Drawing.Size(167, 31);
            this.lblMyMessage.TabIndex = 13;
            this.lblMyMessage.Text = "My Message";
            // 
            // lstChatMessages
            // 
            this.lstChatMessages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstChatMessages.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChatMessages.FormattingEnabled = true;
            this.lstChatMessages.ItemHeight = 20;
            this.lstChatMessages.Location = new System.Drawing.Point(64, 71);
            this.lstChatMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstChatMessages.Name = "lstChatMessages";
            this.lstChatMessages.Size = new System.Drawing.Size(657, 228);
            this.lstChatMessages.TabIndex = 12;
            this.lstChatMessages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstChatMessages_DrawItem);
            this.lstChatMessages.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstChatMessages_MeasureItem);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(57, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(448, 39);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Broadcast Message Window";
            // 
            // BroadcastChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMyMessage);
            this.Controls.Add(this.lblMyMessage);
            this.Controls.Add(this.lstChatMessages);
            this.Controls.Add(this.lblTitle);
            this.Name = "BroadcastChatForm";
            this.Text = "BroadcastChatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtMyMessage;
        private System.Windows.Forms.Label lblMyMessage;
        private System.Windows.Forms.ListBox lstChatMessages;
        private System.Windows.Forms.Label lblTitle;
    }
}