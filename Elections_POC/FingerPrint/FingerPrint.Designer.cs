namespace Elections_POC
{
    partial class FingerPrint
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
            this.btn_TakeFingerPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_TakeFingerPrint
            // 
            this.btn_TakeFingerPrint.Location = new System.Drawing.Point(491, 171);
            this.btn_TakeFingerPrint.Name = "btn_TakeFingerPrint";
            this.btn_TakeFingerPrint.Size = new System.Drawing.Size(237, 98);
            this.btn_TakeFingerPrint.TabIndex = 0;
            this.btn_TakeFingerPrint.Text = "Take Your Finger Print";
            this.btn_TakeFingerPrint.UseVisualStyleBackColor = true;
            this.btn_TakeFingerPrint.Click += new System.EventHandler(this.Btn_TakeFingerPrint_Click);
            // 
            // FingerPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_TakeFingerPrint);
            this.Name = "FingerPrint";
            this.Text = "FingerPrint";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_TakeFingerPrint;
    }
}