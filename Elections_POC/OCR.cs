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
        string EnvironmentStr= ConfigurationManager.AppSettings["EnvironmentStr"];
        // string ResultPath = @"D:\Improvement\images\Result\";
        string ResultPath = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"];
        //string TemplatePath = @"D:\Improvement\images\Result\template.jpg";
        string TemplatePath = ConfigurationManager.AppSettings["ResultPath"];
        string TemplatePathOrgin = ConfigurationManager.AppSettings["TemplateOrginPath"];
        SupremaFingerPrint suprema ;
        string EncryptedIdentificationNumber;
        string ElectionPollingStationNumber ="";

        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private   Thread camera;
        private static Thread loaderThread;
        bool isCameraRunning = false;

        String ElectionPollingStation;
        String ElectionType;
        FingerPrint FingerPrint;
        public string result = "";
        long NID;
        string FinalPhotoName;

        string _IdIdentification;


        private void CaptureCamera()
        {

            //if (camera == null)
            //{
                camera = new Thread(new ThreadStart(CaptureCameraCallback));
                camera.Start();
           // }
            
           // camera.Join();
        }
        
        private void CaptureCameraCallback()
        {
            try
            {

                int CameraType = 1;
                if (EnvironmentStr == "laptop")
                {
                     CameraType = 0;
                }
                else if (EnvironmentStr == "tablet")
                {
                     CameraType = 1;
                }

                frame = new Mat();
                using (capture = new VideoCapture(CameraType)) { 
                    capture.AutoFocus = true;
                // capture.
                capture.FrameWidth = 1280;
                capture.FrameHeight = 720;

                if (capture.IsOpened() == false)
                {
                    capture.Open(CameraType);
                }
                    if (capture.IsOpened()) {

                        while (isCameraRunning)
                        {

                            capture.Read(frame);
                            ///capture.Release();
                            if (!frame.Empty())
                            {
                                //  int interval = (int)(1000 / capture.Fps);
                                image = BitmapConverter.ToBitmap(frame);
                                System.Threading.Thread.Sleep(30);

                                if (pictureBox1.Image != null)
                                {
                                    pictureBox1.Image.Dispose();
                                }
                                if (image != null)
                                {
                                    //313, 170313, 241 313, 224  376, 224
                                    Bitmap snapshot = new Bitmap(image);
                                    pictureBox1.Image = snapshot;

                                }
                            }
                        }
                    }
                    else { MessageBox.Show("can not open camera please check your camera"); }

                }

                // MessageBox.Show("CaptureCameraCallback done");
            }
            catch (Exception ex)
            {

                MessageBox.Show("CaptureCameraCallback" + ex.Message);
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

        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            try
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
                   
                  

                    btn_Start.Text = "تشغيل الكاميرا";

                    isCameraRunning = false;
                    btn_TakeSnapShot.Enabled = false;

                    try
                    {
                        Thread.Sleep(1000);
                       
                        // camera.Join();
                        if (camera.IsAlive == false)
                        {
                            capture.Release();
                        }

                      //  GC.Collect();
                    }
                       
                    
                    catch (Exception ) { }
                    
                    
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Btn_Start_Click" + ex.Message);
            }
        }
        int i = 0;

       
        private void Btn_TakeSnapShot_Click(object sender, EventArgs e)
        {


            try
            {
                if (isCameraRunning)
                    {
                        //   i = i + 1;
                        if (image == null) { return; }
                        Thread.Sleep(1000);

                        Btn_Start_Click(sender, e);
                    // MessageBox.Show("Btn_TakeSnapShot_Click  change btn text done and relase");

                    //Bitmap CopyImg = (Bitmap)image.Clone();
                    //image.Dispose();



                    // image.Save(ImgPath);
                    //  image.Dispose();
                    //  image.Save(ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg");

                    //image.Dispose();

                    // MessageBox.Show("Btn_TakeSnapShot_Click  saved done with new code ");


                  //  lblUserExist.Text = "تم التقاط الصـورة بنجاح";

                        MessageBox.Show("تم التقاط الصـورة بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // snapshot.Save(ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg");
                        btn_ShowNID.Enabled = true;
                    // btn_Start.Enabled = false;


                 //   StartLoader();

                    btn_TakeSnapShot.Enabled = false;
                        //for test
                        if (EnvironmentStr == "laptop")
                        {
                            string ImgPath = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo" + ".jpg";
                            Bitmap m = new Bitmap(ImgPath);
                            ShowNID(m);

                        }
                        else if (EnvironmentStr == "tablet")
                        {
                            ShowNID(image);

                        }
                    //   CloseLoader();

                    //ShowNID(m);
                    // Btn_ShowNID_Click(sender, e);
                    // MessageBox.Show("Btn_TakeSnapShot_Click  ShowNID done");
                   // backgroundWorkerLoader.RunWorkerCompleted();
                }

                else
                    {

                        MessageBox.Show("Cannot take picture if the camera isn't capturing image!");
                    }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Btn_TakeSnapShot_Click" + ex.Message);
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

                        _IdIdentification = page.GetText();//.GetString(page.GetText());


                      //  MessageBox.Show(_IdIdentification);


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

        public Bitmap AdjustBrightOrgin(Bitmap originalImage)
        {
            //   https://stackoverflow.com/questions/15408607/adjust-brightness-contrast-and-gamma-of-an-image
            // string ImageSource = TemplatePath @"E:\GetGroup\Improvment\Images\mohabbest.jpg";

            Bitmap adjustedImage = new Bitmap(TemplatePathOrgin);
            float brightness = 1.0f; // no change in brightness
            float contrast = 1.0f; // twice the contrast
            float gamma = 1.0f; // no change in gamma

            float adjustedBrightness = brightness;// - 1.0f;
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

            //Bitmap scrBitmap = AdjustBrightOrgin(img);


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

            if (scrBitmap != null)
            {
                Bitmap scrBitmapCopy = new Bitmap(scrBitmap);
                pictureBoxCropped.Image = scrBitmapCopy;
                pictureBoxCropped.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            //CropCard(scrBitmap,CropedImgPath);

            return scrBitmap;

        }

      private long   ValidateIdIdentification(string StrId) {
            if (StrId == "") { return 0; }
            try
            {
                string res = Regex.Replace(StrId.Trim(), @"[^\d]", "").Replace(" ", "");
                return long.Parse(res);
            }
            catch (Exception ) {
                return 0;
            }
        }
        private void Btn_ShowNID_Click(object sender, EventArgs e)
        {
         

        }
       void ShowNID(Bitmap ImgOrginalSrc) {

            try
            {
               
                    Reset("Id");
                // string pathDemo = @"D:\Improvement\images\new stand\RGC201911111331331.jpg";
                //  Bitmap ImgOrginalSrc = new Bitmap(pathDemo);
                // Bitmap ImgOrginalSrc = new Bitmap(ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg");

               
                    NID = ValidateIdIdentification(OCR_Fn(ImgOrginalSrc));
               
                if (NID != 0)
                    {
                        panel3.Visible = true;
                        lblUserExist.Visible = false;

                        //pictureBox1.Visible = true;

                        //var path = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg";

                        //FinalPhotoName = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + NID.ToString() + ".jpg";


                        //if (File.Exists(path))
                        //{
                        //    File.Copy(path, FinalPhotoName, true);
                        //}




                        // pictureBox1.ImageLocation = FinalPhotoName;
                        //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        txt_NationalID.Text = NID.ToString();
                    EncryptedIdentificationNumber = Cryptography.Encrypt(txt_NationalID.Text);




    var ElectorExists = GetDataFromPollingStationTable();
                        if (ElectorExists == false)
                        {
                            MessageBox.Show("رقم الهوية غير موجود في مركز الاقتراع", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    Txt_ElectorName.Visible = true; //rolan1
                            //  txt_NationalID.Enabled = true;

                            //  lbl_ElectorName.Visible = true;
                            //  btn_Search.Enabled = true;
                            DisableNationalID(true);
                        }
                        else
                        {
                            DisableNationalID(false);

                            CheckIfElectorSignedOrNot();
                            GetElectorName();
                        }
                    }
                    else
                    {
                        MessageBox.Show("لم يتمكن من قراءة الرقم القومي  " + NID.ToString());


                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Btn_ShowNID_Click" + ex.Message);
            }
        }
        public void Reset(string type="all") {
            if (type == "all")
            {
                if (pictureBoxCropped.Image != null)
                {

                    pictureBoxCropped.Image = null;
        
                  

                }
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image = null;

                    // pictureBox1.Image.Dispose();
                }

            }
            txt_NationalID.Text = "";
            Txt_ElectorName.Text = "";
            if (pbImageFrame.Image != null)
            {
               pbImageFrame.Image = null;

                //  pbImageFrame.Image.Dispose();
            }

        }
        public bool GetDataFromPollingStationTable()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {
                // var ElectorDataExists = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber.Trim() == NID.ToString() ).FirstOrDefault();
                EncryptedIdentificationNumber = Cryptography.Encrypt(txt_NationalID.Text.Trim());

                var ElectorDataExists = Elections.PollingStations.Where(s =>  s.ElectorIdentificationNumber.Trim() == EncryptedIdentificationNumber).FirstOrDefault();

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

        private void DisableNationalID(bool flag) {
            if (flag == true)
            {
                txt_NationalID.BackColor = Color.White; // (244, 249, 252);
            }
            else
            { 
                txt_NationalID.BackColor = Color.FromArgb(244, 249, 252);

            }
            txt_NationalID.Enabled = flag;
            
                    btn_Search.Enabled = flag;
        }
        public void CheckIfElectorSignedOrNot()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {
                try {
                    EncryptedIdentificationNumber = Cryptography.Encrypt(txt_NationalID.Text.Trim());

                    var Elector = Elections.Electors.Where(s => s.IdentificationNumber == EncryptedIdentificationNumber).FirstOrDefault();
                    if (Elector != null)
                    {
                        btn_TakeFingerPrint.Enabled = false;
                        MessageBox.Show("هذا الناخب قد انتخب من قبل");
                        // string absolutePath = @"D:\vs 19 projects\Elections_POC\Elections_POC\Electors IDs\";
                        // pictureBox1.ImageLocation = absolutePath + Elector.IdentificationImg;


                        // timer1.Start();                        
                        // lblUserExist.Visible = true;rolan1
                        //txt_NationalID.Text = NID.ToString();
                        //txt_NationalID.Enabled = false;rolan3

                        //btn_Search.Enabled = false;rolan3
                        //DisableNationalID(false);
                    }
                    else
                    {
                        btn_TakeFingerPrint.Enabled = true;


                        MessageBox.Show("من فضلك قم بأخذ  البصمة");
                        //suprema = new SupremaFingerPrint(); ;
                        //string Initializescanner = suprema.Initializescanner();
                        //if (Initializescanner == "")
                        //{
                        //    FingerPrint = suprema.Enroll(pbImageFrame);

                        //}
                        //else
                        //{
                        //    MessageBox.Show(Initializescanner);
                        //}

                    }

                    }
                    catch (Exception ) {
                }
                
                

                    //button2.Enabled = false;
                    // txt_NationalID.Text = NID.ToString();

                    //pictureBox1.ImageLocation = FinalPhotoName;
                    //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                
                // pictureBox1.ImageLocation = FinalPhotoName;
                // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public void GetElectorName()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {
                EncryptedIdentificationNumber = Cryptography.Encrypt(txt_NationalID.Text .Trim ());
                var ElectorData = Elections.PollingStations.Where(s =>  s.ElectorIdentificationNumber == EncryptedIdentificationNumber).FirstOrDefault();

                if (ElectorData == null)
                {

                }
                else
                {
                    // Txt_ElectorName.Visible = true;rolan1
                    //   lbl_ElectorName.Visible = true; rolan1
                    Txt_ElectorName.Text = Cryptography.Decrypt( ElectorData.ElectorName);
                //    Txt_ElectorName.Text = ElectorData.ElectorName;

                }

            }
        }

        public bool GetDataFromPollingStationAfterUpdateTxt_NationalId()
        {
            using (ElectionEntities Elections = new ElectionEntities())
            {

                // var UpdatedElectorData = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == txt_NationalID.Text && s.PollingStationsAr == ElectionPollingStation).FirstOrDefault();
                string EncryptednationalId = Cryptography.Encrypt(txt_NationalID.Text.Trim());
                var UpdatedElectorData = Elections.PollingStations.Where(s => s.ElectorIdentificationNumber == EncryptednationalId).FirstOrDefault();
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

                var ElectionFingerPrintData = Elections.FingerPrints.Where(s => s.UserID == NID.ToString()).FirstOrDefault();
                if (ElectionFingerPrintData != null)
                {
                    Elections.Electors.Add(new Elector
                    {
                        IdentificationNumber = txt_NationalID.ToString(),
                        //PollingStationsId = 1,
                        //   IdentificationImg = txt_NationalID.ToString() + ".jpeg",
                        // IdentificationTypeId = "",
                        FingerPrintId = ElectionFingerPrintData.Serial,
                        CreateDate = DateTime.Now
                    });

                    Elections.SaveChanges();
                }
                //else {
                //    ElectionFingerPrintData.IdentificationNumber=

                //    Elections.SaveChanges();
                //}
            }
        }
        public async Task AddElector(int serial)
        {

            using (ElectionEntities Elections = new ElectionEntities())
            {
                EncryptedIdentificationNumber = Cryptography.Encrypt(txt_NationalID.Text.Trim());

                var Elector = Elections.Electors.Where(s =>s.IdentificationNumber == EncryptedIdentificationNumber).FirstOrDefault();
                
                if (Elector == null)
                {



                    Elector elector = new Elector();
                    elector.IdentificationNumber =Cryptography .Encrypt ( txt_NationalID.Text);
                    elector.PollingStationsId = 1;
                    //elector.IdentificationImg = txt_NationalID.Text.ToString() + ".jpg";
                    elector.FingerPrintId = serial;
                    elector.CreateDate = DateTime.Now;
                    Elections.Electors.Add(elector);
                   await Elections.SaveChangesAsync();

                }
                //else {
                //    ElectionFingerPrintData.IdentificationNumber=

                //    Elections.SaveChanges();
                //}
            }
        }


        public async Task<int> AddFingerPrint(FingerPrint fingerPrint)
        {

            using (ElectionEntities Context = new ElectionEntities())
            {


                fingerPrint.UserID = txt_NationalID.Text;
                    
                    //ufd_res = m_Database.AddData(dlg.UserID, dlg.FingerIndex, m_Template1, m_Template1Size, null, 0, dlg.Memo);
                Context.FingerPrints.Add(fingerPrint);
               await  Context.SaveChangesAsync();

                 int serial = Context.FingerPrints.Where(f => f.UserID == txt_NationalID.Text).Select (s=>s.Serial).FirstOrDefault();
                return fingerPrint.Serial;
            }
         }
        
        private void OCR_Load(object sender, EventArgs e)
        {

            //-----------------------------------------
            btn_TakeSnapShot.Enabled = false;
            //btn_ShowNID.Enabled = false;
            // btn_TakeSnapShot.Hide();

            ElectionPollingStation = ConfigurationManager.AppSettings["ElectionPollingStation"];
            ElectionPollingStationNumber = ConfigurationManager.AppSettings["ElectionPollingStationNumber"];
            ElectionType = ConfigurationManager.AppSettings["ElectionType"];

            lbl_PollingStation.Text = ConfigurationManager.AppSettings["ElectionPollingStationAR"]; ;
            lblElectionType.Text = ElectionType;
            txt_NationalID.Enabled = false;
            //  Txt_ElectorName.Enabled = false; rolan3
            DisableNationalID(false);
            /////btn_ShowNID.Enabled = false;
        //    btn_TakeFingerPrint.Enabled = true;//rolan
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
                Txt_ElectorName.Text = "";
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

        private async void Btn_TakeFingerPrint_Click(object sender, EventArgs e)
        {
            try
            {

                //if(EnvironmentStr=="laptop")
                //{

                //    //  int serial = await AddFingerPrint(FingerPrint);
                //    await AddElector(1);
                //    MessageBox.Show("تم تسجيل بيانات المنتخب بنجاح");
                //    return;
                //}
                 SupremaFingerPrint suprema = new SupremaFingerPrint();
                // suprema.Initializescanner();
                // string ConnectionStr = ConfigurationManager.AppSettings["ElectionEntities"];
                //   string Initializescanner = suprema.Initializescanner();
                //if (Initializescanner == "")
                //{

                string Initializescanner = suprema.Initializescanner();
                if (Initializescanner == "")
                {
                    FingerPrint = suprema.Enroll(pbImageFrame);
                    suprema.Uninit();

                    if (pbImageFrame.Image != null)
                    {
                        int serial = await AddFingerPrint(FingerPrint);
                        await AddElector(serial);
                        MessageBox.Show("تم تسجيل بيانات المنتخب بنجاح");
                        
                        btn_TakeFingerPrint.Enabled = false;
                        Reset();
                    }
                }
                else
                {
                    MessageBox.Show(Initializescanner);
                    suprema.Uninit();
                   // GC.Collect();
                    // suprema.Enroll(pbImageFrame);
                }


               



                //string Uninit = suprema.Uninit();
                //if (Uninit != "")
                //{
                //    MessageBox.Show(Uninit);
                //}


                //Suprema suprema = new Suprema();
                //suprema.InitializeReader("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Election;Data Source=.");
                //MessageBox.Show("أخذ البصمه");

                //if (suprema.Enroll(NID.ToString(), "") == false)
                //{
                //    MessageBox.Show("هذه البصمة مسجلة باسم شخص آخر", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    UpdateElectorTable();
                //}

                //btn_TakeFingerPrint.Enabled = true;
            }
            catch (Exception ex) {
                MessageBox.Show("Btn_TakeFingerPrint_Click" + ex.Message );
              //  suprema.Uninit();
                GC.Collect();

            }
        }

        private void LblElectionType_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Lbl_NationalID_Click(object sender, EventArgs e)
        {

        }

        private void lbl_PollingStation_Click(object sender, EventArgs e)
        {

        }


        //FrmWaitForm f;
        //void StartLoader()
        //{
        //    f = new FrmWaitForm();
        //    f.Show();
        //    //loaderThread = new Thread(new ThreadStart(StartLoader)); // Setup thread
        //    //loaderThread.IsBackground = true; // Its background so, we need to set background flag
        //    //loaderThread.Start(); // Start the thread


        //}
        //private void LoaderCallback()
        //{


        //    f = new FrmWaitForm();
        //    f.Show();
        //}
        void CloseLoader()
        {

          //  f.Close();




        }

        private void backgroundWorkerLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // StartLoader();
        }

        private void backgroundWorkerLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CloseLoader();
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }
    }
    }

