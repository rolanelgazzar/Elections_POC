namespace Elections_POC
{
    partial class OCR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCR));
            this.btn_ShowNID = new System.Windows.Forms.Button();
            this.btn_TakeSnapShot = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserExist = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_ElectorName = new System.Windows.Forms.Label();
            this.Txt_ElectorName = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.Lbl_NationalID = new System.Windows.Forms.Label();
            this.txt_NationalID = new System.Windows.Forms.TextBox();
            this.btn_TakeFingerPrint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_PollingStation = new System.Windows.Forms.Label();
            this.lbl_ElectionType = new System.Windows.Forms.Panel();
            this.lblElectionType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel4.SuspendLayout();
            this.lbl_ElectionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ShowNID
            // 
            this.btn_ShowNID.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_ShowNID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ShowNID.Image = ((System.Drawing.Image)(resources.GetObject("btn_ShowNID.Image")));
            this.btn_ShowNID.Location = new System.Drawing.Point(72, 262);
            this.btn_ShowNID.Name = "btn_ShowNID";
            this.btn_ShowNID.Size = new System.Drawing.Size(217, 69);
            this.btn_ShowNID.TabIndex = 3;
            this.btn_ShowNID.Text = "قراءة البطاقة";
            this.btn_ShowNID.UseVisualStyleBackColor = true;
            this.btn_ShowNID.Click += new System.EventHandler(this.Btn_ShowNID_Click);
            // 
            // btn_TakeSnapShot
            // 
            this.btn_TakeSnapShot.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_TakeSnapShot.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_TakeSnapShot.Image = ((System.Drawing.Image)(resources.GetObject("btn_TakeSnapShot.Image")));
            this.btn_TakeSnapShot.Location = new System.Drawing.Point(542, 489);
            this.btn_TakeSnapShot.Name = "btn_TakeSnapShot";
            this.btn_TakeSnapShot.Size = new System.Drawing.Size(143, 69);
            this.btn_TakeSnapShot.TabIndex = 2;
            this.btn_TakeSnapShot.Text = "التقاط صورة";
            this.btn_TakeSnapShot.UseVisualStyleBackColor = true;
            this.btn_TakeSnapShot.Click += new System.EventHandler(this.Btn_TakeSnapShot_Click_1);
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_Start.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Start.Image = ((System.Drawing.Image)(resources.GetObject("btn_Start.Image")));
            this.btn_Start.Location = new System.Drawing.Point(542, 409);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(143, 69);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "تشغيل الكاميرا";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(83, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(602, 347);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblUserExist);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_TakeSnapShot);
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 618);
            this.panel1.TabIndex = 7;
            // 
            // lblUserExist
            // 
            this.lblUserExist.AutoSize = true;
            this.lblUserExist.BackColor = System.Drawing.Color.White;
            this.lblUserExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserExist.ForeColor = System.Drawing.Color.Red;
            this.lblUserExist.Location = new System.Drawing.Point(197, 529);
            this.lblUserExist.Name = "lblUserExist";
            this.lblUserExist.Size = new System.Drawing.Size(252, 29);
            this.lblUserExist.TabIndex = 11;
            this.lblUserExist.Text = "هذا الناخب قد انتخب من قبل";
            this.lblUserExist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserExist.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_ElectorName);
            this.panel3.Controls.Add(this.Txt_ElectorName);
            this.panel3.Controls.Add(this.btn_Search);
            this.panel3.Controls.Add(this.Lbl_NationalID);
            this.panel3.Controls.Add(this.txt_NationalID);
            this.panel3.Location = new System.Drawing.Point(83, 409);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 112);
            this.panel3.TabIndex = 10;
            // 
            // lbl_ElectorName
            // 
            this.lbl_ElectorName.AutoSize = true;
            this.lbl_ElectorName.BackColor = System.Drawing.Color.White;
            this.lbl_ElectorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ElectorName.Location = new System.Drawing.Point(394, 44);
            this.lbl_ElectorName.Name = "lbl_ElectorName";
            this.lbl_ElectorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_ElectorName.Size = new System.Drawing.Size(49, 25);
            this.lbl_ElectorName.TabIndex = 11;
            this.lbl_ElectorName.Text = "الاسـم";
            this.lbl_ElectorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_ElectorName
            // 
            this.Txt_ElectorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Txt_ElectorName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_ElectorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ElectorName.Location = new System.Drawing.Point(13, 44);
            this.Txt_ElectorName.Name = "Txt_ElectorName";
            this.Txt_ElectorName.ReadOnly = true;
            this.Txt_ElectorName.Size = new System.Drawing.Size(317, 21);
            this.Txt_ElectorName.TabIndex = 10;
            this.Txt_ElectorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Search
            // 
            this.btn_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Search.BackgroundImage")));
            this.btn_Search.Font = new System.Drawing.Font("Arabic Typesetting", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Search.Location = new System.Drawing.Point(172, 71);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(95, 34);
            this.btn_Search.TabIndex = 9;
            this.btn_Search.Text = "بحث";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Visible = false;
            this.btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Lbl_NationalID
            // 
            this.Lbl_NationalID.AutoSize = true;
            this.Lbl_NationalID.BackColor = System.Drawing.Color.White;
            this.Lbl_NationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NationalID.Location = new System.Drawing.Point(350, 15);
            this.Lbl_NationalID.Name = "Lbl_NationalID";
            this.Lbl_NationalID.Size = new System.Drawing.Size(93, 25);
            this.Lbl_NationalID.TabIndex = 7;
            this.Lbl_NationalID.Text = "الرقم القومي ";
            this.Lbl_NationalID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_NationalID
            // 
            this.txt_NationalID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.txt_NationalID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_NationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NationalID.Location = new System.Drawing.Point(13, 15);
            this.txt_NationalID.Name = "txt_NationalID";
            this.txt_NationalID.Size = new System.Drawing.Size(317, 21);
            this.txt_NationalID.TabIndex = 8;
            this.txt_NationalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_TakeFingerPrint
            // 
            this.btn_TakeFingerPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TakeFingerPrint.BackgroundImage")));
            this.btn_TakeFingerPrint.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_TakeFingerPrint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_TakeFingerPrint.Location = new System.Drawing.Point(72, 361);
            this.btn_TakeFingerPrint.Name = "btn_TakeFingerPrint";
            this.btn_TakeFingerPrint.Size = new System.Drawing.Size(217, 69);
            this.btn_TakeFingerPrint.TabIndex = 6;
            this.btn_TakeFingerPrint.Text = "تسجيل البصمة";
            this.btn_TakeFingerPrint.UseVisualStyleBackColor = true;
            this.btn_TakeFingerPrint.Click += new System.EventHandler(this.Btn_TakeFingerPrint_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btn_TakeFingerPrint);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btn_ShowNID);
            this.panel2.Location = new System.Drawing.Point(732, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 562);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Linen;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(84, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(163, 133);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lbl_PollingStation);
            this.panel4.Location = new System.Drawing.Point(881, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 78);
            this.panel4.TabIndex = 10;
            // 
            // lbl_PollingStation
            // 
            this.lbl_PollingStation.AutoSize = true;
            this.lbl_PollingStation.Font = new System.Drawing.Font("Arabic Typesetting", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PollingStation.Location = new System.Drawing.Point(96, 16);
            this.lbl_PollingStation.Name = "lbl_PollingStation";
            this.lbl_PollingStation.Size = new System.Drawing.Size(75, 44);
            this.lbl_PollingStation.TabIndex = 0;
            this.lbl_PollingStation.Text = "label";
            // 
            // lbl_ElectionType
            // 
            this.lbl_ElectionType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lbl_ElectionType.BackgroundImage")));
            this.lbl_ElectionType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lbl_ElectionType.Controls.Add(this.lblElectionType);
            this.lbl_ElectionType.Location = new System.Drawing.Point(56, 12);
            this.lbl_ElectionType.Name = "lbl_ElectionType";
            this.lbl_ElectionType.Size = new System.Drawing.Size(369, 78);
            this.lbl_ElectionType.TabIndex = 11;
            this.lbl_ElectionType.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_ElectionType_Paint);
            // 
            // lblElectionType
            // 
            this.lblElectionType.AutoSize = true;
            this.lblElectionType.Font = new System.Drawing.Font("Arabic Typesetting", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElectionType.Location = new System.Drawing.Point(55, 16);
            this.lblElectionType.Name = "lblElectionType";
            this.lblElectionType.Size = new System.Drawing.Size(75, 44);
            this.lblElectionType.TabIndex = 0;
            this.lblElectionType.Text = "label";
            this.lblElectionType.Click += new System.EventHandler(this.LblElectionType_Click);
            // 
            // OCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1119, 650);
            this.Controls.Add(this.lbl_ElectionType);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OCR";
            this.Text = "Tablet Mode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OCR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.lbl_ElectionType.ResumeLayout(false);
            this.lbl_ElectionType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_ShowNID;
        private System.Windows.Forms.Button btn_TakeSnapShot;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_TakeFingerPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_PollingStation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_ElectorName;
        private System.Windows.Forms.TextBox Txt_ElectorName;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label Lbl_NationalID;
        private System.Windows.Forms.TextBox txt_NationalID;
        private System.Windows.Forms.Label lblUserExist;
        private System.Windows.Forms.Panel lbl_ElectionType;
        private System.Windows.Forms.Label lblElectionType;
    }
}