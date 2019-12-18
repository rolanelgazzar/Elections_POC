using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Tesseract;


namespace Elections_POC
{
    public partial class OCR : Form
    {

        // string ResultPath = @"D:\Improvement\images\Result\";
        string ResultPath = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"];
        //string TemplatePath = @"D:\Improvement\images\Result\template.jpg";
        string TemplatePath = ConfigurationManager.AppSettings["ResultPath"];


        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;

        String ElectionPollingStation;
        String ElectionType;

        public string result = "";
        string NID;
        string FinalPhotoName;

        string _IdIdentification;


        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            try
            {
                frame = new Mat();
                capture = new VideoCapture(1);               
                capture.Open(1);
                capture.Brightness = 10;
                capture.FrameWidth = 1280;
                capture.FrameHeight = 720;

                if (capture.IsOpened())
                {
                    while (isCameraRunning)
                    {

                        capture.Read(frame);
                        image = BitmapConverter.ToBitmap(frame);
                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                        }

                        Bitmap snapshot = new Bitmap(image,450,300);

                        pictureBox1.Image = snapshot;
                        image.Save(ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg");
                    }
                    //capture.Release();
                    //capture.Dispose();
                    //frame.Dispose();
                    //frame.Release();
                }
            }
            catch (Exception)
            {

               // MessageBox.Show(ex.Message);
            }

        }

        //private void CaptureCameraCallback()
        //{
        //    frame = new Mat();
        //    capture = new VideoCapture(0);
        //    capture.Open(0);

        //    if (capture.IsOpened())
        //    {
        //        while (isCameraRunning)
        //        {
        //            try
        //            {
        //                capture.Read(frame);

        //                image = BitmapConverter.ToBitmap(frame);
        //            }
        //            catch (Exception)
        //            {
        //                MessageBox.Show("f error");

        //            }

        //            if (pictureBox1.Image != null)
        //            {
        //                pictureBox1.Image.Dispose();
        //            }
        //            try
        //            {
        //                pictureBox1.Image = image;
        //            }
        //            catch (Exception)
        //            {
        //                MessageBox.Show("s error");

        //            }
        //        }
        //    }
        //}

        public OCR()
        {
            InitializeComponent();
            ElectionPollingStation = ConfigurationManager.AppSettings["ElectionPollingStation"];
            ElectionType = ConfigurationManager.AppSettings["ElectionType"];
            lbl_PollingStation.Text = ElectionPollingStation;
            lblElectionType.Text = ElectionType;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (btn_Start.Text.Equals("تشغيل الكاميرا"))
            {

                CaptureCamera();
                btn_Start.Text = "ايقاف الكاميرا";
                isCameraRunning = true;
                btn_TakeSnapShot.Enabled = true;

            }
            else
            {
                capture.Release();
                btn_Start.Text = "تشغيل الكاميرا";
                
                isCameraRunning = false;
                btn_TakeSnapShot.Enabled = false;
            }
        }

        private void Btn_TakeSnapShot_Click_1(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {

                try
                {

                 // Bitmap snapshot = new Bitmap(pictureBox1.Image, 30, 30);

                    MessageBox.Show("تم التقاط الصـورة بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // snapshot.Save(ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg");
                    btn_ShowNID.Enabled = true;
                    // btn_Start.Enabled = false;
                    Btn_Start_Click(sender, e);
                    btn_TakeSnapShot.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                MessageBox.Show("Cannot take picture if the camera isn't capturing image!");
            }
        }


        // Rolan

        public string OCR_Fn(Bitmap ImgOrginalSrc)
        {
            Bitmap OCRImageSrc = ImageProcessing(ImgOrginalSrc);
            //--------------------Test M
            //Bitmap OCRImageSrc = ImgOrginalSrc;

            //-----------------------------------------
            //string _IdIdentification;


            //  var pathTessdata = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            // pathTessdata = Path.Combine(pathTessdata, "tessdata");
            // pathTessdata = pathTessdata.Replace("file:\\", "");



            using (var engine = new TesseractEngine(ConfigurationManager.AppSettings["TessDataPath"], "num+ara_number", EngineMode.Default))
            {
                var img = new Bitmap(OCRImageSrc);
                using (img)
                {

                    //  img.Save(@"D:\Improvement\images\New folder\new.jpg");
                    using (var page = engine.Process(img))
                    {

                        _IdIdentification = page.GetText().Replace(" ","").Trim();//.GetString(page.GetText());


                        MessageBox.Show(_IdIdentification);


                        return _IdIdentification;
                    }


                }

            }
        }
        public static Bitmap RotateImage(Bitmap img, float rotationAngle)
        {

            Bitmap bmp = img;// new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new System.Drawing.Point(0, 0));
            gfx.Dispose();
            return bmp;
        }
        public Bitmap CropCard(Bitmap bitmap)
        {
            //new stand 
            //int CoordX = int.Parse("278");
            //int CoordY = int.Parse("293");
            //int ImageWidth = int.Parse("963"); //int.Parse(ConfigurationManager.AppSettings["CropWidthSSN"]);
            //int ImageHeight = int.Parse("144");


            int CoordX = int.Parse(ConfigurationManager.AppSettings["T_CropXSSN"]);
            int CoordY = int.Parse(ConfigurationManager.AppSettings["T_CropYSSN"]);
            int ImageWidth = int.Parse(ConfigurationManager.AppSettings["T_CropWidthSSN"]);
            int ImageHeight = int.Parse(ConfigurationManager.AppSettings["T_CropHeightSSN"]);




            //low resolution
            //int CoordX = int.Parse("123");
            //int CoordY = int.Parse("427");
            //int ImageWidth = int.Parse("963"); //int.Parse(ConfigurationManager.AppSettings["CropWidthSSN"]);
            //int ImageHeight = int.Parse("144");
            //int CoordX = int.Parse("123");
            //int CoordY = int.Parse("427");
            //int ImageWidth = int.Parse("963"); //int.Parse(ConfigurationManager.AppSettings["CropWidthSSN"]);
            //int ImageHeight = int.Parse("144");



            //old stand
            //int CoordX = int.Parse("374");
            //int CoordY = int.Parse("576");
            //int ImageWidth = int.Parse("757"); //int.Parse(ConfigurationManager.AppSettings["CropWidthSSN"]);
            //int ImageHeight = int.Parse("142");


            var img = CroppedImage(bitmap, new Rectangle(CoordX, CoordY, ImageWidth, ImageHeight));// new Bitmap();
                                                                                                   //   img.Save(CropedImgPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            return img;

        }
        public Bitmap CroppedImage(Bitmap BmpImage, Rectangle CropArea)
        {
            try
            {
                Bitmap result = BmpImage.Clone(CropArea, BmpImage.PixelFormat);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Bitmap ChangeColor(Bitmap scrBitmap, float limit)
        {


            //https://stackoverflow.com/questions/33096826/c-sharp-how-to-remove-all-color-except-black-from-an-image
            // const float limit = 0.3f; //0.3f
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    Color c = scrBitmap.GetPixel(i, j);
                    if (c.GetBrightness() > limit)
                    {
                        scrBitmap.SetPixel(i, j, Color.White);
                    }
                }
            }




            return scrBitmap;

        }
        public Bitmap AdjustBright(Bitmap originalImage)
        {
            //   https://stackoverflow.com/questions/15408607/adjust-brightness-contrast-and-gamma-of-an-image
            // string ImageSource = TemplatePath @"E:\GetGroup\Improvment\Images\mohabbest.jpg";

            Bitmap adjustedImage = new Bitmap(TemplatePath);
            float brightness = 1.0f; // no change in brightness
            float contrast = 2.0f; // twice the contrast
            float gamma = 1.0f; // no change in gamma

            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
        new float[] {contrast, 0, 0, 0, 0}, // scale red
        new float[] {0, contrast, 0, 0, 0}, // scale green
        new float[] {0, 0, contrast, 0, 0}, // scale blue
        new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
        new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(adjustedImage);
            g.DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                , 0, 0, originalImage.Width, originalImage.Height,
                GraphicsUnit.Pixel, imageAttributes);
            // adjustedImage.Save(@"E:\GetGroup\Improvment\Images\brighness.jpg");
            return adjustedImage;
        }
        public Bitmap ImageProcessing(Bitmap scrBitmap)
        {

            //rotat ==>http://www.aforgenet.com/framework/docs/html/18d8bd4d-b15e-8507-a480-b2fe6eaeab44.htm

            if (scrBitmap.Width < scrBitmap.Height)
            {
                scrBitmap = RotateImage(scrBitmap, 90);
            }

            scrBitmap = CropCard(scrBitmap);
            scrBitmap.Save(ResultPath + "cropImage.jpg");
            scrBitmap.Save(ResultPath + "result.jpg");




            //change color

            scrBitmap = ChangeColor(scrBitmap, 0.3f);
            scrBitmap.Save(ResultPath + "res1_BlackWhite.jpg");


            scrBitmap = AdjustBright(scrBitmap);
            scrBitmap.Save(ResultPath + "res2_Bright.jpg");

            // scrBitmap = ChangeColor(scrBitmap, NewPath, CropedImgPath,0.5f);
            scrBitmap.Save(ResultPath + "result.jpg");


            pictureBox1.Image = scrBitmap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //CropCard(scrBitmap,CropedImgPath);

            return scrBitmap;

        }


        private void Btn_ShowNID_Click(object sender, EventArgs e)
        {


            Bitmap ImgOrginalSrc = new Bitmap(ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg");



            NID = OCR_Fn(ImgOrginalSrc);

            if (NID != null)
            {
                panel3.Visible = true;
                lblUserExist.Visible = false;
                // pictureBox1.Visible = false;
                pictureBox1.Visible = true;

                var path = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg";

                FinalPhotoName = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + NID.ToString() + ".jpg";


                if (File.Exists(path))
                {
                    File.Copy(path, FinalPhotoName, true);
                }




                // pictureBox1.ImageLocation = FinalPhotoName;
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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

        public bool GetDataFromPollingStationTable()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {

                var ElectorDataExists = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == txt_NationalID.Text && s.PollingStationsAr == ElectionPollingStation).FirstOrDefault();
                if (ElectorDataExists == null)
                {
                    return false;
                    //var UpdatedElectorData = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == txt_NationalID.ToString() && s.PollingStationsAr == ElectionPollingStation).FirstOrDefault();
                    //if (UpdatedElectorData == null)
                    //{
                    //    return false;
                    //}
                    //else
                    //{
                    //    return true;
                    //}

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
                var Elector = Elections.Electors.Where(s => s.IdentificationNumber == txt_NationalID.Text).FirstOrDefault();
                if (Elector != null)
                {

                    // string absolutePath = @"D:\vs 19 projects\Elections_POC\Elections_POC\Electors IDs\";
                    // pictureBox1.ImageLocation = absolutePath + Elector.IdentificationImg;


                    // timer1.Start();                        
                    lblUserExist.Visible = true;
                    //txt_NationalID.Text = NID.ToString();
                    txt_NationalID.Enabled = false;
                    btn_Search.Enabled = false;
                }
                else
                {
                    btn_TakeFingerPrint.Enabled = true;
                    //button2.Enabled = false;
                    // txt_NationalID.Text = NID.ToString();

                    //pictureBox1.ImageLocation = FinalPhotoName;
                    //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                // pictureBox1.ImageLocation = FinalPhotoName;
                // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void GetElectorName()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {

                var ElectorData = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == txt_NationalID.Text && s.PollingStationsAr == ElectionPollingStation).FirstOrDefault();

                if (ElectorData == null)
                {

                }
                else
                {
                    Txt_ElectorName.Visible = true;
                    lbl_ElectorName.Visible = true;
                    Txt_ElectorName.Text = ElectorData.ElectorName;
                }

            }
        }

        public bool GetDataFromPollingStationAfterUpdateTxt_NationalId()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {

                var UpdatedElectorData = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == txt_NationalID.Text && s.PollingStationsAr == ElectionPollingStation).FirstOrDefault();

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

        public void UpdateElectorTable()
        {

            using (ElectionEntities Elections = new ElectionEntities())
            {

                var ElectionFingerPrintData = Elections.FingerPrints.Where(s => s.UserID == txt_NationalID.Text).FirstOrDefault();
                if (ElectionFingerPrintData != null)
                {
                    Elections.Electors.Add(new Elector
                    {
                        IdentificationNumber = txt_NationalID.Text,
                        //PollingStationsId = 1,
                        IdentificationImg = txt_NationalID.Text + ".jpg",
                        // IdentificationTypeId = "",
                       // FingerPrintId = ElectionFingerPrintData.Serial,
                        // CreateDate = DateTime.Now
                    });

                    Elections.SaveChanges();

                }
            }
        }
        private void OCR_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            btn_TakeFingerPrint.Enabled = false;


            //btn_TakeSnapShot.Enabled = false;
            ////btn_ShowNID.Enabled = false;
            //// btn_TakeSnapShot.Hide();

            //ElectionPollingStation = ConfigurationManager.AppSettings["ElectionPollingStation"];
            //lbl_PollingStation.Text = ElectionPollingStation.ToString(); ElectionPollingStation = ConfigurationManager.AppSettings["ElectionPollingStation"];
            //ElectionType = ConfigurationManager.AppSettings["ElectionType"];

            //lbl_PollingStation.Text = ElectionPollingStation;
            //lblElectionType.Text = ElectionType;
            //txt_NationalID.Enabled = false;
            //Txt_ElectorName.Enabled = false;
            //btn_Search.Enabled = false;
            //lblUserExist.Visible = false;
            ///////btn_ShowNID.Enabled = false;


           

        }



        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Search_Click(object sender, EventArgs e)
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

        private void Lbl_ElectionType_Paint(object sender, PaintEventArgs e)
        {

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
            }

            btn_TakeFingerPrint.Enabled = false;
           
            //button2.Enabled = true;
            // MessageBox.Show(suprema.GetCardID());
            // MessageBox.Show( suprema.GetCardID());
        }

        private void LblElectionType_Click(object sender, EventArgs e)
        {

        }
    }
}

