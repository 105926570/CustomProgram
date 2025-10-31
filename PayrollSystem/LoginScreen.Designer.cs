namespace PayrollSystem
{
    partial class LoginScreen
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
            this.loginButton = new System.Windows.Forms.Button();
            this.userameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameInputBox = new System.Windows.Forms.TextBox();
            this.passwordInputBox = new System.Windows.Forms.TextBox();
            this.hidePasswordCheck = new System.Windows.Forms.CheckBox();
            this.capsLockWarningLabel = new System.Windows.Forms.Label();
            this.hideUserCheck = new System.Windows.Forms.CheckBox();
            this.loginPageTitleLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.btnLoginAsAdmn = new System.Windows.Forms.Button();
            this.btnLoginAsMngr = new System.Windows.Forms.Button();
            this.btnLoginAsEmp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(157, 270);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(187, 94);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // userameLabel
            // 
            this.userameLabel.AutoSize = true;
            this.userameLabel.Location = new System.Drawing.Point(152, 143);
            this.userameLabel.Name = "userameLabel";
            this.userameLabel.Size = new System.Drawing.Size(116, 25);
            this.userameLabel.TabIndex = 1;
            this.userameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(152, 205);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(112, 25);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameInputBox
            // 
            this.usernameInputBox.Location = new System.Drawing.Point(157, 171);
            this.usernameInputBox.Name = "usernameInputBox";
            this.usernameInputBox.Size = new System.Drawing.Size(300, 31);
            this.usernameInputBox.TabIndex = 3;
            // 
            // passwordInputBox
            // 
            this.passwordInputBox.Location = new System.Drawing.Point(157, 233);
            this.passwordInputBox.Name = "passwordInputBox";
            this.passwordInputBox.PasswordChar = '*';
            this.passwordInputBox.Size = new System.Drawing.Size(300, 31);
            this.passwordInputBox.TabIndex = 4;
            // 
            // hidePasswordCheck
            // 
            this.hidePasswordCheck.AutoSize = true;
            this.hidePasswordCheck.Checked = true;
            this.hidePasswordCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hidePasswordCheck.Location = new System.Drawing.Point(463, 235);
            this.hidePasswordCheck.Name = "hidePasswordCheck";
            this.hidePasswordCheck.Size = new System.Drawing.Size(188, 29);
            this.hidePasswordCheck.TabIndex = 5;
            this.hidePasswordCheck.Text = "Hide Password";
            this.hidePasswordCheck.UseVisualStyleBackColor = true;
            this.hidePasswordCheck.CheckedChanged += new System.EventHandler(this.hidePasswordCheck_CheckedChanged);
            // 
            // capsLockWarningLabel
            // 
            this.capsLockWarningLabel.AutoSize = true;
            this.capsLockWarningLabel.BackColor = System.Drawing.SystemColors.Control;
            this.capsLockWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capsLockWarningLabel.ForeColor = System.Drawing.Color.Maroon;
            this.capsLockWarningLabel.Location = new System.Drawing.Point(261, 205);
            this.capsLockWarningLabel.Name = "capsLockWarningLabel";
            this.capsLockWarningLabel.Size = new System.Drawing.Size(270, 25);
            this.capsLockWarningLabel.TabIndex = 6;
            this.capsLockWarningLabel.Text = "!NOTE! CAPS LOCK IS ON";
            // 
            // hideUserCheck
            // 
            this.hideUserCheck.AutoSize = true;
            this.hideUserCheck.Location = new System.Drawing.Point(463, 171);
            this.hideUserCheck.Name = "hideUserCheck";
            this.hideUserCheck.Size = new System.Drawing.Size(192, 29);
            this.hideUserCheck.TabIndex = 7;
            this.hideUserCheck.Text = "Hide Username";
            this.hideUserCheck.UseVisualStyleBackColor = true;
            this.hideUserCheck.CheckedChanged += new System.EventHandler(this.hideUserCheck_CheckedChanged);
            // 
            // loginPageTitleLabel
            // 
            this.loginPageTitleLabel.AutoSize = true;
            this.loginPageTitleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.loginPageTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginPageTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginPageTitleLabel.ForeColor = System.Drawing.Color.Black;
            this.loginPageTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.loginPageTitleLabel.Name = "loginPageTitleLabel";
            this.loginPageTitleLabel.Size = new System.Drawing.Size(247, 42);
            this.loginPageTitleLabel.TabIndex = 8;
            this.loginPageTitleLabel.Text = "LOGIN PAGE";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(175, 66);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(391, 50);
            this.welcomeLabel.TabIndex = 9;
            this.welcomeLabel.Text = "Welcome\r\nPlease log-in with your company details";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoginAsAdmn
            // 
            this.btnLoginAsAdmn.Location = new System.Drawing.Point(364, 280);
            this.btnLoginAsAdmn.Name = "btnLoginAsAdmn";
            this.btnLoginAsAdmn.Size = new System.Drawing.Size(187, 94);
            this.btnLoginAsAdmn.TabIndex = 10;
            this.btnLoginAsAdmn.Tag = "debug";
            this.btnLoginAsAdmn.Text = "Login As Admin";
            this.btnLoginAsAdmn.UseVisualStyleBackColor = true;
            this.btnLoginAsAdmn.Click += new System.EventHandler(this.btnLoginAsAdmn_Click);
            // 
            // btnLoginAsMngr
            // 
            this.btnLoginAsMngr.Location = new System.Drawing.Point(548, 280);
            this.btnLoginAsMngr.Name = "btnLoginAsMngr";
            this.btnLoginAsMngr.Size = new System.Drawing.Size(187, 94);
            this.btnLoginAsMngr.TabIndex = 11;
            this.btnLoginAsMngr.Tag = "debug";
            this.btnLoginAsMngr.Text = "Login As Manager";
            this.btnLoginAsMngr.UseVisualStyleBackColor = true;
            // 
            // btnLoginAsEmp
            // 
            this.btnLoginAsEmp.Location = new System.Drawing.Point(482, 366);
            this.btnLoginAsEmp.Name = "btnLoginAsEmp";
            this.btnLoginAsEmp.Size = new System.Drawing.Size(187, 94);
            this.btnLoginAsEmp.TabIndex = 12;
            this.btnLoginAsEmp.Tag = "debug";
            this.btnLoginAsEmp.Text = "Login As Employee";
            this.btnLoginAsEmp.UseVisualStyleBackColor = true;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoginAsEmp);
            this.Controls.Add(this.btnLoginAsMngr);
            this.Controls.Add(this.btnLoginAsAdmn);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.loginPageTitleLabel);
            this.Controls.Add(this.hideUserCheck);
            this.Controls.Add(this.capsLockWarningLabel);
            this.Controls.Add(this.hidePasswordCheck);
            this.Controls.Add(this.passwordInputBox);
            this.Controls.Add(this.usernameInputBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userameLabel);
            this.Controls.Add(this.loginButton);
            this.KeyPreview = true;
            this.Name = "LoginScreen";
            this.Text = "Login Screen";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CapsLock_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label userameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameInputBox;
        private System.Windows.Forms.TextBox passwordInputBox;
        private System.Windows.Forms.CheckBox hidePasswordCheck;
        private System.Windows.Forms.Label capsLockWarningLabel;
        private System.Windows.Forms.CheckBox hideUserCheck;
        private System.Windows.Forms.Label loginPageTitleLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button btnLoginAsAdmn;
        private System.Windows.Forms.Button btnLoginAsMngr;
        private System.Windows.Forms.Button btnLoginAsEmp;
    }
}

