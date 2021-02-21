
namespace WindowsClient
{
    partial class LoginForm
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignup = new System.Windows.Forms.Button();
            this.pswhideview = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.welcomeLabel.Location = new System.Drawing.Point(115, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(541, 39);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to WCF Chat Application";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(122, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(125, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbUsername.Location = new System.Drawing.Point(247, 116);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(225, 30);
            this.tbUsername.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbPassword.Location = new System.Drawing.Point(247, 179);
            this.tbPassword.MaxLength = 15;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(225, 30);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnLogin.Location = new System.Drawing.Point(247, 258);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(225, 40);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignup
            // 
            this.btnSignup.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnSignup.Location = new System.Drawing.Point(247, 351);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(225, 40);
            this.btnSignup.TabIndex = 6;
            this.btnSignup.Text = "Create new Account";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // pswhideview
            // 
            this.pswhideview.AutoSize = true;
            this.pswhideview.Checked = true;
            this.pswhideview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pswhideview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.pswhideview.Location = new System.Drawing.Point(499, 187);
            this.pswhideview.Name = "pswhideview";
            this.pswhideview.Size = new System.Drawing.Size(60, 22);
            this.pswhideview.TabIndex = 7;
            this.pswhideview.Text = "Hide";
            this.pswhideview.UseVisualStyleBackColor = true;
            this.pswhideview.CheckedChanged += new System.EventHandler(this.pswhideview_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pswhideview);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.CheckBox pswhideview;
    }
}