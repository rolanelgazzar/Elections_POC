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
            this.pbImageFrame = new System.Windows.Forms.PictureBox();
            this.pictureBoxCropped = new System.Windows.Forms.PictureBox();
            this.btn_TakeFingerPrint = new System.Windows.Forms.Button();
            this.lblUserExist = new System.Windows.Forms.Label();
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
            this.backgroundWorkerLoader = new System.ComponentModel.BackgroundWorker();
            this.btn_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCropped)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.lbl_ElectionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ShowNID
            // 
            this.btn_ShowNID.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_ShowNID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ShowNID.Image = ((System.Drawing.Image)(resources.GetObject("btn_ShowNID.Image")));
            this.btn_ShowNID.Location = new System.Drawing.Point(949, 424);
            this.btn_ShowNID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ShowNID.Name = "btn_ShowNID";
            this.btn_ShowNID.Size = new System.Drawing.Size(163, 56);
            this.btn_ShowNID.TabIndex = 3;
            this.btn_ShowNID.Text = "قراءة البطاقة";
            this.btn_ShowNID.UseVisualStyleBackColor = true;
            this.btn_ShowNID.Visible = false;
            this.btn_ShowNID.Click += new System.EventHandler(this.Btn_ShowNID_Click);
            // 
            // btn_TakeSnapShot
            // 
            this.btn_TakeSnapShot.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_TakeSnapShot.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_TakeSnapShot.Image = ((System.Drawing.Image)(resources.GetObject("btn_TakeSnapShot.Image")));
            this.btn_TakeSnapShot.Location = new System.Drawing.Point(927, 170);
            this.btn_TakeSnapShot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_TakeSnapShot.Name = "btn_TakeSnapShot";
            this.btn_TakeSnapShot.Size = new System.Drawing.Size(164, 56);
            this.btn_TakeSnapShot.TabIndex = 2;
            this.btn_TakeSnapShot.Text = "التقاط صورة";
            this.btn_TakeSnapShot.UseVisualStyleBackColor = true;
            this.btn_TakeSnapShot.Click += new System.EventHandler(this.Btn_TakeSnapShot_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_Start.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Start.Image = ((System.Drawing.Image)(resources.GetObject("btn_Start.Image")));
            this.btn_Start.Location = new System.Drawing.Point(927, 100);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(164, 56);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "تشغيل الكاميرا";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(592, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 249);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pbImageFrame);
            this.panel1.Controls.Add(this.pictureBoxCropped);
            this.panel1.Controls.Add(this.btn_TakeFingerPrint);
            this.panel1.Controls.Add(this.lblUserExist);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btn_ShowNID);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_TakeSnapShot);
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.Location = new System.Drawing.Point(-87, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1354, 502);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pbImageFrame
            // 
            this.pbImageFrame.BackColor = System.Drawing.SystemColors.Control;
            this.pbImageFrame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbImageFrame.BackgroundImage")));
            this.pbImageFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImageFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImageFrame.Location = new System.Drawing.Point(592, 318);
            this.pbImageFrame.Name = "pbImageFrame";
            this.pbImageFrame.Size = new System.Drawing.Size(331, 119);
            this.pbImageFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageFrame.TabIndex = 13;
            this.pbImageFrame.TabStop = false;
            // 
            // pictureBoxCropped
            // 
            this.pictureBoxCropped.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCropped.BackgroundImage")));
            this.pictureBoxCropped.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCropped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCropped.Location = new System.Drawing.Point(126, 55);
            this.pictureBoxCropped.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxCropped.Name = "pictureBoxCropped";
            this.pictureBoxCropped.Size = new System.Drawing.Size(451, 52);
            this.pictureBoxCropped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCropped.TabIndex = 12;
            this.pictureBoxCropped.TabStop = false;
            // 
            // btn_TakeFingerPrint
            // 
            this.btn_TakeFingerPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TakeFingerPrint.BackgroundImage")));
            this.btn_TakeFingerPrint.Enabled = false;
            this.btn_TakeFingerPrint.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Bold);
            this.btn_TakeFingerPrint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_TakeFingerPrint.Location = new System.Drawing.Point(927, 355);
            this.btn_TakeFingerPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_TakeFingerPrint.Name = "btn_TakeFingerPrint";
            this.btn_TakeFingerPrint.Size = new System.Drawing.Size(164, 56);
            this.btn_TakeFingerPrint.TabIndex = 6;
            this.btn_TakeFingerPrint.Text = "تسجيل البصمة";
            this.btn_TakeFingerPrint.UseVisualStyleBackColor = true;
            this.btn_TakeFingerPrint.Click += new System.EventHandler(this.Btn_TakeFingerPrint_Click);
            // 
            // lblUserExist
            // 
            this.lblUserExist.AutoSize = true;
            this.lblUserExist.BackColor = System.Drawing.Color.White;
            this.lblUserExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserExist.ForeColor = System.Drawing.Color.Red;
            this.lblUserExist.Location = new System.Drawing.Point(370, 306);
            this.lblUserExist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserExist.Name = "lblUserExist";
            this.lblUserExist.Size = new System.Drawing.Size(207, 24);
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
            this.panel3.Location = new System.Drawing.Point(129, 124);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(448, 180);
            this.panel3.TabIndex = 10;
            // 
            // lbl_ElectorName
            // 
            this.lbl_ElectorName.AutoSize = true;
            this.lbl_ElectorName.BackColor = System.Drawing.Color.White;
            this.lbl_ElectorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ElectorName.Location = new System.Drawing.Point(347, 63);
            this.lbl_ElectorName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ElectorName.Name = "lbl_ElectorName";
            this.lbl_ElectorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_ElectorName.Size = new System.Drawing.Size(84, 39);
            this.lbl_ElectorName.TabIndex = 11;
            this.lbl_ElectorName.Text = "الاسـم";
            this.lbl_ElectorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_ElectorName
            // 
            this.Txt_ElectorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Txt_ElectorName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_ElectorName.Enabled = false;
            this.Txt_ElectorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ElectorName.Location = new System.Drawing.Point(6, 63);
            this.Txt_ElectorName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_ElectorName.Name = "Txt_ElectorName";
            this.Txt_ElectorName.ReadOnly = true;
            this.Txt_ElectorName.Size = new System.Drawing.Size(263, 38);
            this.Txt_ElectorName.TabIndex = 10;
            this.Txt_ElectorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Search
            // 
            this.btn_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Search.BackgroundImage")));
            this.btn_Search.Font = new System.Drawing.Font("Arabic Typesetting", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Search.Location = new System.Drawing.Point(157, 125);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(99, 39);
            this.btn_Search.TabIndex = 9;
            this.btn_Search.Text = "بحث";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Lbl_NationalID
            // 
            this.Lbl_NationalID.AutoSize = true;
            this.Lbl_NationalID.BackColor = System.Drawing.Color.White;
            this.Lbl_NationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_NationalID.Location = new System.Drawing.Point(273, 15);
            this.Lbl_NationalID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_NationalID.Name = "Lbl_NationalID";
            this.Lbl_NationalID.Size = new System.Drawing.Size(160, 39);
            this.Lbl_NationalID.TabIndex = 7;
            this.Lbl_NationalID.Text = "الرقم القومي ";
            this.Lbl_NationalID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Lbl_NationalID.Click += new System.EventHandler(this.Lbl_NationalID_Click);
            // 
            // txt_NationalID
            // 
            this.txt_NationalID.BackColor = System.Drawing.Color.White;
            this.txt_NationalID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_NationalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NationalID.Location = new System.Drawing.Point(6, 14);
            this.txt_NationalID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_NationalID.Name = "txt_NationalID";
            this.txt_NationalID.Size = new System.Drawing.Size(263, 38);
            this.txt_NationalID.TabIndex = 8;
            this.txt_NationalID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.lbl_PollingStation);
            this.panel4.Location = new System.Drawing.Point(862, 11);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(214, 62);
            this.panel4.TabIndex = 10;
            // 
            // lbl_PollingStation
            // 
            this.lbl_PollingStation.AutoSize = true;
            this.lbl_PollingStation.Font = new System.Drawing.Font("Arabic Typesetting", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PollingStation.Location = new System.Drawing.Point(72, 13);
            this.lbl_PollingStation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_PollingStation.Name = "lbl_PollingStation";
            this.lbl_PollingStation.Size = new System.Drawing.Size(59, 35);
            this.lbl_PollingStation.TabIndex = 0;
            this.lbl_PollingStation.Text = "label";
            this.lbl_PollingStation.Click += new System.EventHandler(this.lbl_PollingStation_Click);
            // 
            // lbl_ElectionType
            // 
            this.lbl_ElectionType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lbl_ElectionType.BackgroundImage")));
            this.lbl_ElectionType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lbl_ElectionType.Controls.Add(this.lblElectionType);
            this.lbl_ElectionType.Location = new System.Drawing.Point(42, 10);
            this.lbl_ElectionType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbl_ElectionType.Name = "lbl_ElectionType";
            this.lbl_ElectionType.Size = new System.Drawing.Size(356, 63);
            this.lbl_ElectionType.TabIndex = 11;
            this.lbl_ElectionType.Paint += new System.Windows.Forms.PaintEventHandler(this.Lbl_ElectionType_Paint);
            // 
            // lblElectionType
            // 
            this.lblElectionType.AutoSize = true;
            this.lblElectionType.Font = new System.Drawing.Font("Arabic Typesetting", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElectionType.Location = new System.Drawing.Point(41, 13);
            this.lblElectionType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblElectionType.Name = "lblElectionType";
            this.lblElectionType.Size = new System.Drawing.Size(59, 35);
            this.lblElectionType.TabIndex = 0;
            this.lblElectionType.Text = "label";
            this.lblElectionType.Click += new System.EventHandler(this.LblElectionType_Click);
            // 
            // backgroundWorkerLoader
            // 
            this.backgroundWorkerLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerLoader_ProgressChanged);
            this.backgroundWorkerLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoader_RunWorkerCompleted);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.Color.Transparent;
            this.btn_Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Back.BackgroundImage")));
            this.btn_Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Back.Font = new System.Drawing.Font("Arabic Typesetting", 22.2F, System.Drawing.FontStyle.Bold);
            this.btn_Back.Location = new System.Drawing.Point(2, 10);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(52, 41);
            this.btn_Back.TabIndex = 12;
            this.btn_Back.UseVisualStyleBackColor = false;
            this.btn_Back.Click += new System.EventHandler(this.Btn_Back_Click);
            // 
            // OCR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1028, 528);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.lbl_ElectionType);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OCR";
            this.Text = "Tablet Mode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OCR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCropped)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.PictureBox pictureBoxCropped;
        private System.Windows.Forms.PictureBox pbImageFrame;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoader;
        private System.Windows.Forms.Button btn_Back;
    }
}