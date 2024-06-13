namespace Application_desktop
{
    partial class Login
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
            labLogin = new Label();
            labPassword = new Label();
            butConnection = new Button();
            butDelete = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // labLogin
            // 
            labLogin.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            labLogin.Location = new Point(600, 300);
            labLogin.Name = "lablogin";
            labLogin.Size = new Size(500, 100);
            labLogin.TabIndex = 4;
            labLogin.Text = "Login";
            // 
            // labPassword
            // 
            labPassword.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            labPassword.Location = new Point(450, 500);
            labPassword.Name = "labpassword";
            labPassword.Size = new Size(500, 100);
            labPassword.TabIndex = 4;
            labPassword.Text = "Mot de passe";
            // 
            // butConnection
            // 
            butConnection.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            butConnection.Location = new Point(825, 600);
            butConnection.Name = "butconnection";
            butConnection.Size = new Size(200, 50);
            butConnection.TabIndex = 3;
            butConnection.Text = "Connection";
            butConnection.UseVisualStyleBackColor = true;
            butConnection.Click += butConnection_Click;
            // 
            // butDelete
            // 
            butDelete.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            butDelete.Location = new Point(1075, 600);
            butDelete.Name = "butdelete";
            butDelete.Size = new Size(200, 50);
            butDelete.TabIndex = 4;
            butDelete.Text = "Effacer";
            butDelete.UseVisualStyleBackColor = true;
            butDelete.Click += butDelete_Click;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(800, 300);
            txtUsername.Name = "txtusername";
            txtUsername.Size = new Size(500, 61);
            txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(800, 500);
            txtPassword.Name = "txtpassword";
            txtPassword.Size = new Size(500, 61);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 732);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(butDelete);
            Controls.Add(butConnection);
            Controls.Add(labPassword);
            Controls.Add(labLogin);
            Name = "Login";
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labLogin;
        private Label labPassword;
        private Button butConnection;
        private Button butDelete;
        private TextBox txtUsername;
        private TextBox txtPassword;
    }
}