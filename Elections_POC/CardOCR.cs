using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using WIA;

namespace Elections_POC
{
    public class CardOCR
    {
        Bitmap bitmap1;
        //OpenFileDialog openFileDialog;
        public  string result;
        //  long NID;

         string ScanColorFlag = ConfigurationManager.AppSettings["ScanColorFlag"];
            string pathScanColor = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "PhotoColor.png";

        public string Get_Id(Bitmap imageFile)
        {

   


            string path = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"];// + "Photo.png";
            //  string path = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.jpg";
            // bitmap1 = new Bitmap(path);
            bitmap1 = new Bitmap(imageFile);
            int CoordX = int.Parse(ConfigurationManager.AppSettings["CropXSSN"]);
            int CoordY = int.Parse(ConfigurationManager.AppSettings["CropYSSN"]);
            int ImageWidth = int.Parse(ConfigurationManager.AppSettings["CropWidthSSN"]);
            int ImageHeight = int.Parse(ConfigurationManager.AppSettings["CropHeightSSN"]);
            bitmap1 = CroppedImage(bitmap1, new System.Drawing.Rectangle(CoordX, CoordY, ImageWidth, ImageHeight));
            bitmap1.Save(path + "r1CroppedImage.png");

            using (Bitmap newBitmap = new Bitmap(bitmap1))
            {
                //newBitmap.SetResolution(400, 400);
                //newBitmap.Save(path + "r2SetResolution.png");


                // AForge.Imaging.Filters.BrightnessCorrection brightnessCorrection = new BrightnessCorrection();

                //bitmap1 = AForge.Imaging.Filters.Grayscale.CommonAlgorithms.RMY.Apply(newBitmap);
                // brightnessCorrection.AdjustValue = 50;
                bitmap1 = ChangeColor(bitmap1, 0.60f);
                bitmap1 = blackAndWhite(bitmap1);
              
                // bitmap1 = brightnessCorrection.Apply(bitmap1);
                bitmap1.Save(path +  "r3brightnessCorrection.png");
              // bitmap1 = ModifyImageThreshold(bitmap1);
                //bitmap1.Save(new FileInfo(openFileDialog.FileName).Name);

                //bitmap1.Save(path + "r4ModifyImageThreshold.png");



               // bitmap1.Save(new FileInfo(path).Name);
                //TesseractEngine engine = new TesseractEngine(ConfigurationManager.AppSettings["TessDataPath"], "num+ara_number", EngineMode.Default);
                TesseractEngine engine = new TesseractEngine(@"./tessdata", "num+ara_number", EngineMode.Default);
                // TesseractEngine engine = new TesseractEngine(@"./OCR/tessdata", "num", EngineMode.Default);
                //var img = Pix.LoadFromFile(path);
                //Page page = engine.Process(img, PageSegMode.Auto);
                Page page = engine.Process(bitmap1, PageSegMode.Auto);
                

                ////result =Regex.Replace(page.GetText(), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline).Replace("/","").Replace(@"\","").Replace(" ", "").Trim();
                result = page.GetText().Replace("/", " ").Replace(@"\", " ").Replace(" ", "").Trim();
               // MessageBox.Show(result);

                // result = page.GetText();
                //return result.Replace(" ", "").Trim();
                return result;

                //MessageBox.Show(result.Replace(" ", "").Trim());

                // MessageBox.Show(result);

            }
            //  ProcessImagesthread();
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
        public static Bitmap blackAndWhite(Bitmap originalbmp)
        {
            // var originalbmp = new Bitmap(Bitmap.FromFile(OFD.FileName)); // Load the  image

            using (Graphics gr = Graphics.FromImage(originalbmp)) // SourceImage is a Bitmap object
            {
                var gray_matrix = new float[][] {
                new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                new float[] { 0,      0,      0,      1, 0 },
                new float[] { 0,      0,      0,      0, 1 }
            };

                var ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                ia.SetThreshold(0.8f); // Change this threshold as needed
                var rc = new Rectangle(0, 0, originalbmp.Width, originalbmp.Height);
                gr.DrawImage(originalbmp, rc, 0, 0, originalbmp.Width, originalbmp.Height, GraphicsUnit.Pixel, ia);
            }

            return originalbmp;
        }
        public static Bitmap CroppedImage(Bitmap BmpImage, Rectangle CropArea)
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

        public static Bitmap ModifyImageThreshold(Bitmap img)
        {
              float ThresholdValue = 0.35F;
           // float ThresholdValue = 0.55F;
            //float ThresholdValue = 0.35F;


            Bitmap bm = new Bitmap(img.Width, img.Height);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetThreshold(ThresholdValue);

            System.Drawing.Point[] points =
                {
                    new System.Drawing.Point(0, 0),
                    new System.Drawing.Point(img.Width, 0),
                    new System.Drawing.Point(0, img.Height),
                };
            Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(img, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }
            bm.SetResolution(400, 400);
            return bm;
        }

        public Bitmap StartScan()
        {
            try
            {

                //var path = @"C:\Users\oayman\Desktop\scan02222100.jpeg";


                // Create a DeviceManager instance
                var deviceManager = new DeviceManager();
                // Create an empty variable to store the scanner instance
                DeviceInfo firstScannerAvailable = null;

                // Loop through the list of devices to choose the first available
                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    // Skip the device if it's not a scanner
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }

                    firstScannerAvailable = deviceManager.DeviceInfos[i];

                    break;
                }

                // Connect to the first available scanner
                var device = firstScannerAvailable.Connect();

                // Select the scanner
                var scannerItem = device.Items[1];

                /**
                * Set the scanner settings
                */
                int resolution = 400;
                int width_pixel = 1280;
                int height_pixel = 750;
                int color_mode = 2;
                //int resolution = 300;
                //int width_pixel = 1015;
                //int height_pixel = 688;
                //int color_mode = 1;
                AdjustScannerSettings(scannerItem, resolution, 0, 0, width_pixel, height_pixel, 10, 5, color_mode);
                //   AdjustScannerSettings(scannerItem, 150, 0, 0, 1250, 1700, 0, 0, 1);

                // Retrieve a image in JPEG format and store it into a variable
                var imageFile = (ImageFile)scannerItem.Transfer(FormatID.wiaFormatPNG);

               

                var path = ConfigurationManager.AppSettings["ElectorsIDsFolderPath"] + "Photo.png";

                //var path = @"C:\Users\oayman\Desktop\scan02222100.jpeg";

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                // Save image !
                imageFile.SaveFile(path);


                var imageBytes = (byte[])imageFile.FileData.get_BinaryData();
                var ms = new MemoryStream(imageBytes);
                var img = Image.FromStream(ms);

                GC.Collect();


                //scan again
                if (ScanColorFlag == "true")
                {
                     deviceManager = new DeviceManager();
                    // Create an empty variable to store the scanner instance
                     firstScannerAvailable = null;

                    // Loop through the list of devices to choose the first available
                    for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                    {
                        // Skip the device if it's not a scanner
                        if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                        {
                            continue;
                        }

                        firstScannerAvailable = deviceManager.DeviceInfos[i];

                        break;
                    }

                    // Connect to the first available scanner
                     device = firstScannerAvailable.Connect();

                    // Select the scanner
                     scannerItem = device.Items[1];

                    /**
                    * Set the scanner settings
                    */
                  
                     color_mode = 0;
                    //int resolution = 300;
                    AdjustScannerSettings(scannerItem, resolution, 0, 0, width_pixel, height_pixel, 10, 5, color_mode);
                    var imageFile2 = (ImageFile)scannerItem.Transfer(FormatID.wiaFormatPNG);


                    if (File.Exists(pathScanColor))
                    {
                        File.Delete(pathScanColor);
                    }

                    // Save image !
                    imageFile2.SaveFile(pathScanColor);
                }
                // Save the image in some path with filename


                return (Bitmap)img;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
               // MessageBox.Show("Check the Scanner cable to be connected.");
            }


        }



        /// <summary>
        /// Adjusts the settings of the scanner with the providen parameters.
        /// </summary>
        /// <param name="scannnerItem">Scanner Item</param>
        /// <param name="scanResolutionDPI">Provide the DPI resolution that should be used e.g 150</param>
        /// <param name="scanStartLeftPixel"></param>
        /// <param name="scanStartTopPixel"></param>
        /// <param name="scanWidthPixels"></param>
        /// <param name="scanHeightPixels"></param>
        /// <param name="brightnessPercents"></param>
        /// <param name="contrastPercents">Modify the contrast percent</param>
        /// <param name="colorMode">Set the color mode</param>
        private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel, int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode)
        {
            const string WIA_SCAN_COLOR_MODE = "6146";
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
        }

        /// <summary>
        /// Modify a WIA property
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

    }
}
