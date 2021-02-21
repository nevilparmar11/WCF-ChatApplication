
namespace WindowsClient
{
    partial class SignupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pswhideview = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(329, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Signup Form";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblName.Location = new System.Drawing.Point(92, 61);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 26);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblEmail.Location = new System.Drawing.Point(92, 121);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(68, 26);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblUsername.Location = new System.Drawing.Point(92, 181);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(113, 26);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblPassword.Location = new System.Drawing.Point(92, 244);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(108, 26);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbName.Location = new System.Drawing.Point(251, 64);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(215, 30);
            this.tbName.TabIndex = 6;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbEmail.Location = new System.Drawing.Point(251, 117);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(215, 30);
            this.tbEmail.TabIndex = 7;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbUsername.Location = new System.Drawing.Point(251, 177);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(215, 30);
            this.tbUsername.TabIndex = 8;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPassword.Location = new System.Drawing.Point(251, 240);
            this.tbPassword.MaxLength = 15;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(215, 30);
            this.tbPassword.TabIndex = 9;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSubmit.Location = new System.Drawing.Point(97, 325);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(179, 43);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnBack.Location = new System.Drawing.Point(287, 325);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(179, 43);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back to Login";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pswhideview
            // 
            this.pswhideview.AutoSize = true;
            this.pswhideview.Checked = true;
            this.pswhideview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pswhideview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pswhideview.Location = new System.Drawing.Point(484, 244);
            this.pswhideview.Name = "pswhideview";
            this.pswhideview.Size = new System.Drawing.Size(60, 22);
            this.pswhideview.TabIndex = 12;
            this.pswhideview.Text = "Hide";
            this.pswhideview.UseVisualStyleBackColor = true;
            this.pswhideview.CheckedChanged += new System.EventHandler(this.pswhideview_CheckedChanged);
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Controls.Add(this.pswhideview);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Name = "SignupForm";
            this.Text = "SignupForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignupForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.CheckBox pswhideview;
    }
}