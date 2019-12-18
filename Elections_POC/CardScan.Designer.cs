namespace Elections_POC
{
    partial class CardScan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardScan));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_TakeFingerPrint = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblUserExist = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_ElectorName = new System.Windows.Forms.Label();
            this.Txt_ElectorName = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.Lbl_NationalID = new System.Windows.Forms.Label();
            this.txt_NationalID = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_PollingStation = new System.Windows.Forms.Label();
            this.lbl_ElectionType = new System.Windows.Forms.Panel();
            this.lblElectionType = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.lbl_ElectionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(45, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 69);
            this.button1.TabIndex = 0;
            this.button1.Text = "قراءة البطاقة";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(78, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 215);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // btn_TakeFingerPrint
            // 
            this.btn_TakeFingerPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TakeFingerPrint.BackgroundImage")));
            this.btn_TakeFingerPrint.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TakeFingerPrint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_TakeFingerPrint.Location = new System.Drawing.Point(45, 334);
            this.btn_TakeFingerPrint.Name = "btn_TakeFingerPrint";
            this.btn_TakeFingerPrint.Size = new System.Drawing.Size(217, 69);
            this.btn_TakeFingerPrint.TabIndex = 5;
            this.btn_TakeFingerPrint.Text = "تسجيل البصمة";
            this.btn_TakeFingerPrint.UseVisualStyleBackColor = true;
            this.btn_TakeFingerPrint.Click += new System.EventHandler(this.Btn_TakeFingerPrint_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // lblUserExist
            // 
            this.lblUserExist.AutoSize = true;
            this.lblUserExist.BackColor = System.Drawing.Color.White;
            this.lblUserExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserExist.ForeColor = System.Drawing.Color.Red;
            this.lblUserExist.Location = new System.Drawing.Point(231, 468);
            this.lblUserExist.Name = "lblUserExist";
            this.lblUserExist.Size = new System.Drawing.Size(252, 29);
            this.lblUserExist.TabIndex = 6;
            this.lblUserExist.Text = "هذا الناخب قد انتخب من قبل";
            this.lblUserExist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserExist.Visible = false;
            this.lblUserExist.Click += new System.EventHandler(this.LblUserExist_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_TakeFingerPrint);
            this.panel1.Location = new System.Drawing.Point(703, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 518);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Linen;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(88, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(133, 122);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.lblUserExist);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(21, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 506);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_ElectorName);
            this.panel3.Controls.Add(this.Txt_ElectorName);
            this.panel3.Controls.Add(this.btn_Search);
            this.panel3.Controls.Add(this.Lbl_NationalID);
            this.panel3.Controls.Add(this.txt_NationalID);
            this.panel3.Location = new System.Drawing.Point(78, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(507, 150);
            this.panel3.TabIndex = 9;
            // 
            // lbl_ElectorName
            // 
            this.lbl_ElectorName.AutoSize = true;
            this.lbl_ElectorName.BackColor = System.Drawing.Color.White;
            this.lbl_ElectorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ElectorName.Location = new System.Drawing.Point(437, 66);
            this.lbl_ElectorName.Name = "lbl_ElectorName";
            this.lbl_ElectorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_ElectorName.Size = new System.Drawing.Size(49, 25);
            this.lbl_ElectorName.TabIndex = 11;
            this.lbl_ElectorName.Text = "الاسـم";
            this.lbl_ElectorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_ElectorName
            // 
            this.Txt_ElectorName.BackColor = System.Drawing.Color.White;
            this.Txt_ElectorName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_ElectorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ElectorName.Location = new System.Drawing.Point(27, 66);
            this.Txt_ElectorName.Name = "Txt_ElectorName";
            this.Txt_ElectorName.ReadOnly = true;
            this.Txt_ElectorName.Size = new System.Drawing.Size(352, 38);
            this.Txt_ElectorName.TabIndex = 10;
            this.Txt_ElectorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Search
            // 
            this.btn_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Search.BackgroundImage")));
            this.btn_Search.Font = new System.Drawing.Font("Arabic Typesetting", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Search.Location = new System.Drawing.Point(184, 110);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(95, 34);
            this.btn_Search.TabIndex = 9;
            this.btn_Search.Text = "بحث";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Visible = false;
            this.btn_Search.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Lbl_NationalID
            // 
            this.Lbl_NationalID.AutoSize = true;
            this.Lbl_NationalID.BackColor = System.Drawing.Color.White;
            this.Lbl_NationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NationalID.Location = new System.Drawing.Point(393, 15);
            this.Lbl_NationalID.Name = "Lbl_NationalID";
            this.Lbl_NationalID.Size = new System.Drawing.Size(93, 25);
            this.Lbl_NationalID.TabIndex = 7;
            this.Lbl_NationalID.Text = "الرقم القومي ";
            this.Lbl_NationalID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_NationalID
            // 
            this.txt_NationalID.BackColor = System.Drawing.Color.White;
            this.txt_NationalID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_NationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NationalID.Location = new System.Drawing.Point(27, 15);
            this.txt_NationalID.Name = "txt_NationalID";
            this.txt_NationalID.Size = new System.Drawing.Size(352, 38);
            this.txt_NationalID.TabIndex = 8;
            this.txt_NationalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_NationalID.TextChanged += new System.EventHandler(this.Txt_NationalID_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lbl_PollingStation);
            this.panel4.Location = new System.Drawing.Point(830, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(188, 78);
            this.panel4.TabIndex = 9;
            // 
            // lbl_PollingStation
            // 
            this.lbl_PollingStation.AutoSize = true;
            this.lbl_PollingStation.Font = new System.Drawing.Font("Arabic Typesetting", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PollingStation.Location = new System.Drawing.Point(25, 16);
            this.lbl_PollingStation.Name = "lbl_PollingStation";
            this.lbl_PollingStation.Size = new System.Drawing.Size(75, 44);
            this.lbl_PollingStation.TabIndex = 0;
            this.lbl_PollingStation.Text = "label";
            this.lbl_PollingStation.Click += new System.EventHandler(this.Lbl_PollingStation_Click);
            // 
            // lbl_ElectionType
            // 
            this.lbl_ElectionType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lbl_ElectionType.BackgroundImage")));
            this.lbl_ElectionType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lbl_ElectionType.Controls.Add(this.lblElectionType);
            this.lbl_ElectionType.Location = new System.Drawing.Point(67, 12);
            this.lbl_ElectionType.Name = "lbl_ElectionType";
            this.lbl_ElectionType.Size = new System.Drawing.Size(403, 78);
            this.lbl_ElectionType.TabIndex = 12;
            this.lbl_ElectionType.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_ElectionType_Paint);
            // 
            // lblElectionType
            // 
            this.lblElectionType.AutoSize = true;
            this.lblElectionType.Font = new System.Drawing.Font("Arabic Typesetting", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElectionType.Location = new System.Drawing.Point(27, 16);
            this.lblElectionType.Name = "lblElectionType";
            this.lblElectionType.Size = new System.Drawing.Size(75, 44);
            this.lblElectionType.TabIndex = 0;
            this.lblElectionType.Text = "label";
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.Transparent;
            this.btn_Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Back.BackgroundImage")));
            this.btn_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Back.Font = new System.Drawing.Font("Arabic Typesetting", 22.2F, System.Drawing.FontStyle.Bold);
            this.btn_Back.Location = new System.Drawing.Point(1, 12);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(69, 50);
            this.btn_Back.TabIndex = 10;
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.Btn_Back_Click);
            // 
            // CardScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1027, 588);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.lbl_ElectionType);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CardScan";
            this.Text = "Scanner Mode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CardScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.lbl_ElectionType.ResumeLayout(false);
            this.lbl_ElectionType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_TakeFingerPrint;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblUserExist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txt_NationalID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Lbl_NationalID;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_PollingStation;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label lbl_ElectorName;
        private System.Windows.Forms.TextBox Txt_ElectorName;
        private System.Windows.Forms.Panel lbl_ElectionType;
        private System.Windows.Forms.Label lblElectionType;
        private System.Windows.Forms.Button btn_Back;
    }
}