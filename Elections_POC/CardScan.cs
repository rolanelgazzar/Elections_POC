using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using WIA;


namespace Elections_POC
{
    public partial class CardScan : Form
    {
        string ScanColorFlag = ConfigurationManager.AppSettings["ScanColorFlag"];
        string  pathScanColor = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "PhotoColor.png";
        //Bitmap bitmap1;
        //OpenFileDialog openFileDialog;
        public static long result;
        string NID;
        String ElectionPollingStation;
        String ElectionPollingStationAr;
        String ElectionType;

        string FinalPhotoName;

        CardOCR CardOcr = new CardOCR();
        public CardScan()
        {
            
            
                InitializeComponent();
                ElectionPollingStation = ConfigurationManager.AppSettings["ElectionPollingStation"];
            ElectionPollingStationAr = ConfigurationManager.AppSettings["ElectionPollingStationAr"];

            ElectionType = ConfigurationManager.AppSettings["ElectionType"];

                lbl_PollingStation.Text = ElectionPollingStationAr;
                lblElectionType.Text = ElectionType;
            
        }

        public void UpdateElectorTable()
        {

            using (ElectionEntities Elections = new ElectionEntities())
            {

                var ElectionFingerPrintData = Elections.FingerPrints.Where(s => s.UserID == txt_NationalID.Text).FirstOrDefault();
                if (ElectionFingerPrintData != null)
                {
                    Elections.Electors.Add(new Elector
                    {
                        IdentificationNumber = Cryptography.Encrypt(txt_NationalID.Text),
                        PollingStationsId =int.Parse(ConfigurationManager.AppSettings["ElectionPollingStation"]),
                        //IdentificationImg = txt_NationalID.Text + ".jpg",
                        // IdentificationTypeId = "",
                        FingerPrintId = ElectionFingerPrintData.Serial,
                        CreateDate = DateTime.Now
                    });

                    Elections.SaveChanges();

                }
            }
        }

        public bool GetDataFromPollingStationTable()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {
                string EncryptedNationalId = Cryptography.Encrypt(txt_NationalID.Text);
                var ElectorDataExists = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == EncryptedNationalId && s.PollingStationsAr == ElectionPollingStation).FirstOrDefault();
                if (ElectorDataExists == null)
                {
                     return false;
                 

                }
                else
                {
                    return true;
                }

            }
        }
        public void GetElectorName()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {
                string EncryptedNationalId = Cryptography.Encrypt(txt_NationalID.Text);
                var ElectorData = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == EncryptedNationalId && s.PollingStationsAr == ElectionPollingStation).FirstOrDefault();

                if (ElectorData == null)
                {
                    
                }
                else
                {
                    Txt_ElectorName.Visible = true;
                    lbl_ElectorName.Visible = true;
                    Txt_ElectorName.Text= Cryptography.Decrypt(ElectorData.ElectorName);
                    btn_Search.Enabled = false;
                }

            }
        }

        public bool GetDataFromPollingStationAfterUpdateTxt_NationalId()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {
                string EncryptedNationalId = Cryptography.Encrypt(txt_NationalID.Text);
                var UpdatedElectorData = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == EncryptedNationalId && s.PollingStationsAr == ElectionPollingStation).FirstOrDefault();

                if (UpdatedElectorData == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

       public void CheckIfElectorSignedOrNot()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {
                string EncryptedNationalId = Cryptography.Encrypt(txt_NationalID.Text);

                var Elector = Elections.Electors.Where(s => s.IdentificationNumber == EncryptedNationalId).FirstOrDefault();
                if (Elector != null)
                {
                                       
                    lblUserExist.Visible = true;
                    //txt_NationalID.Text = NID.ToString();
                    txt_NationalID.Enabled = false;
                    btn_Search.Enabled = false;
                }
                else
                {
                    btn_TakeFingerPrint.Enabled = true;
                  
                }
              
            }
        }


        private void CardScan_Load(object sender, EventArgs e)
        {
            btn_TakeFingerPrint.Enabled = false;
            panel3.Visible = false;
        }

        private void Btn_TakeFingerPrint_Click(object sender, EventArgs e)
        {
            Suprema suprema = new Suprema();

            suprema.InitializeReader("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Election;Data Source=.");

            //suprema.InitializeReader("DSN=FP;Uid=;Pwd=;");
            //suprema.Enroll((Guid.NewGuid()).ToString(), "");


            if (suprema.Enroll(txt_NationalID.Text, "") == false)
            {
                MessageBox.Show("هذه البصمة مسجلة باسم شخص آخر", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UpdateElectorTable();
                MessageBox.Show("تم تسجيل بياناتك بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            btn_TakeFingerPrint.Enabled = false;
            txt_NationalID.Text = "";
            Txt_ElectorName.Text = "";
            //button2.Enabled = true;

            // MessageBox.Show(suprema.GetCardID());
            // MessageBox.Show( suprema.GetCardID());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           

            txt_NationalID.Text = "";
            Txt_ElectorName.Text = "";
            lblUserExist.Visible = false;
            pictureBox1.Image = null;
            NID = "";
           Bitmap m= CardOcr.StartScan();


            NID = CardOcr.Get_Id(m);

            if (NID != null)
            {
                panel3.Visible = true;
                lblUserExist.Visible = false;
               // pictureBox1.Visible = false;
                pictureBox1.Visible = true;

               var path = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.png";

                FinalPhotoName = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + NID.ToString() + ".png";

               
                if (File.Exists(path))
                {
                   File.Copy(path, FinalPhotoName, true);
                    //System.IO.File.Move(path,FinalPhotoName);

                }



                if (File.Exists(pathScanColor) && ScanColorFlag=="true") { FinalPhotoName = pathScanColor; }
               //FinalPhotoName;
               // pictureBox1.ImageLocation = @"D:\vs 19 projects\Elections_POC\Elections_POC\bin\Debug\Photo.jpeg";
                pictureBox1.ImageLocation = FinalPhotoName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                  txt_NationalID.Text = NID.ToString();
                  
                


                var ElectorExists = GetDataFromPollingStationTable();
                if (ElectorExists == false)
                {

                    MessageBox.Show("رقم الهوية غير موجود في مركز الاقتراع", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    Txt_ElectorName.Visible = false;
                    lbl_ElectorName.Visible = false;
                    btn_Search.Visible = true;
                }
                else
                {
                    CheckIfElectorSignedOrNot();
                    GetElectorName();
                }
            }
            else
            {
                
            }


        }

        private void LblUserExist_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_PollingStation_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var UpdatedElectorExists = GetDataFromPollingStationAfterUpdateTxt_NationalId();
            if (UpdatedElectorExists == false)
            {

                MessageBox.Show("رقم الهوية المعدل غير موجود في مركز الاقتراع", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CheckIfElectorSignedOrNot();
                GetElectorName();
            }

        }

        private void Txt_NationalID_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Lbl_ElectionType_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {
            //this.DialogResult = DialogResult.OK;

        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }
    }

}
