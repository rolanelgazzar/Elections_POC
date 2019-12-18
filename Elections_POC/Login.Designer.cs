namespace Elections_POC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btn_Login = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.pass_astr = new System.Windows.Forms.Label();
            this.usr_astr = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.user_pic = new System.Windows.Forms.PictureBox();
            this.pass_pic = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Login.BackgroundImage")));
            this.btn_Login.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_Login.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Login.Location = new System.Drawing.Point(649, 447);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(242, 56);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "تسجيل الدخول";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.txt_Password);
            this.panel1.Controls.Add(this.txt_UserName);
            this.panel1.Controls.Add(this.pass_astr);
            this.panel1.Controls.Add(this.btn_Login);
            this.panel1.Controls.Add(this.usr_astr);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.user_pic);
            this.panel1.Controls.Add(this.pass_pic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1272, 713);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // txt_Password
            // 
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(77)))));
            this.txt_Password.Location = new System.Drawing.Point(599, 373);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(330, 22);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.TextChanged += new System.EventHandler(this.Txt_Password_TextChanged);
            // 
            // txt_UserName
            // 
            this.txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txt_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(56)))), ((int)(((byte)(77)))));
            this.txt_UserName.Location = new System.Drawing.Point(599, 290);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(330, 22);
            this.txt_UserName.TabIndex = 0;
            // 
            // pass_astr
            // 
            this.pass_astr.AutoSize = true;
            this.pass_astr.BackColor = System.Drawing.Color.White;
            this.pass_astr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_astr.ForeColor = System.Drawing.Color.Red;
            this.pass_astr.Location = new System.Drawing.Point(948, 373);
            this.pass_astr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pass_astr.Name = "pass_astr";
            this.pass_astr.Size = new System.Drawing.Size(23, 29);
            this.pass_astr.TabIndex = 9;
            this.pass_astr.Text = "*";
            this.pass_astr.Visible = false;
            this.pass_astr.Click += new System.EventHandler(this.Pass_astr_Click);
            // 
            // usr_astr
            // 
            this.usr_astr.AutoSize = true;
            this.usr_astr.BackColor = System.Drawing.Color.White;
            this.usr_astr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usr_astr.ForeColor = System.Drawing.Color.Red;
            this.usr_astr.Location = new System.Drawing.Point(948, 286);
            this.usr_astr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usr_astr.Name = "usr_astr";
            this.usr_astr.Size = new System.Drawing.Size(23, 29);
            this.usr_astr.TabIndex = 7;
            this.usr_astr.Text = "*";
            this.usr_astr.Visible = false;
            this.usr_astr.Click += new System.EventHandler(this.Usr_astr_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(573, 111);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(375, 142);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // user_pic
            // 
            this.user_pic.BackColor = System.Drawing.Color.White;
            this.user_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.user_pic.Image = ((System.Drawing.Image)(resources.GetObject("user_pic.Image")));
            this.user_pic.Location = new System.Drawing.Point(554, 275);
            this.user_pic.Margin = new System.Windows.Forms.Padding(4);
            this.user_pic.Name = "user_pic";
            this.user_pic.Size = new System.Drawing.Size(427, 55);
            this.user_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.user_pic.TabIndex = 1;
            this.user_pic.TabStop = false;
            // 
            // pass_pic
            // 
            this.pass_pic.BackColor = System.Drawing.Color.White;
            this.pass_pic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pass_pic.BackgroundImage")));
            this.pass_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pass_pic.Location = new System.Drawing.Point(554, 360);
            this.pass_pic.Margin = new System.Windows.Forms.Padding(4);
            this.pass_pic.Name = "pass_pic";
            this.pass_pic.Size = new System.Drawing.Size(427, 55);
            this.pass_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pass_pic.TabIndex = 2;
            this.pass_pic.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1272, 713);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.user_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pass_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label pass_astr;
        private System.Windows.Forms.Label usr_astr;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox user_pic;
        private System.Windows.Forms.PictureBox pass_pic;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_UserName;
    }
}

