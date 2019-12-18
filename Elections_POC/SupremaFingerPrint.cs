using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Suprema;
namespace Elections_POC
{
   public  class SupremaFingerPrint
    {
        
        // We use 384 bytes template size in this tutorial

        UFScannerManager m_ScannerManager;
        UFScanner m_Scanner;
        UFDatabase m_Database;
        UFMatcher m_Matcher;
        string m_strError;
        int m_Serial;
        string m_UserID;
        int m_FingerIndex;
        byte[] m_Template1;
        int m_Template1Size;
        byte[] m_Template2;
        int m_Template2Size;
        string m_Memo;
        //
        const int MAX_USERID_SIZE = 50;
        const int MAX_TEMPLATE_SIZE = 1024;
        const int MAX_MEMO_SIZE = 100;
        //
        const int DATABASE_COL_SERIAL = 0;
        const int DATABASE_COL_USERID = 1;
        const int DATABASE_COL_FINGERINDEX = 2;
        const int DATABASE_COL_TEMPLATE1 = 3;
        const int DATABASE_COL_TEMPLATE2 = 4;
        const int DATABASE_COL_MEMO = 5;
        string tbxMessage;
        public  SupremaFingerPrint()
        {
            m_ScannerManager = new UFScannerManager(new ScannerManager());
            // Set timeout for capturing images to 5 seconds

         


            m_Scanner = null;

            m_Database = null;
            m_Matcher = null;

            m_Template1 = new byte[MAX_TEMPLATE_SIZE];
            m_Template2 = new byte[MAX_TEMPLATE_SIZE];
        }
        public string   Initializescanner()
        {
            //=========================================================================//
            // Initilize scanners
            //=========================================================================//
            UFS_STATUS ufs_res;
            int nScannerNumber;
            string tbxMessage="";
            Cursor.Current = Cursors.WaitCursor;
            ufs_res = m_ScannerManager.Init();
            

            //  Cursor.Current = this.Cursor;
            if (ufs_res == UFS_STATUS.OK)
            {
                tbxMessage="UFScanner Init: OK\r\n";
            }
            else
            {
                UFScanner.GetErrorString(ufs_res, out m_strError);
                tbxMessage = "UFScanner Init: " + m_strError + "\r\n";
                return tbxMessage;
            }

            nScannerNumber = m_ScannerManager.Scanners.Count;
            tbxMessage="UFScanner GetScannerNumber: " + nScannerNumber + "\r\n";

            if (nScannerNumber == 0)
            {
                tbxMessage="There's no available scanner\r\n";
                return tbxMessage;
            }
            else
            {
                tbxMessage="First scanner will be used\r\n";
            }

            m_Scanner = m_ScannerManager.Scanners[0];
            m_Scanner.Timeout = 5000;
            //=========================================================================//
            // UpdateDatabaseList();
            //=========================================================================//

            //=========================================================================//
            // Create matcher
            //=========================================================================//
            m_Matcher = new UFMatcher();
            return "";
            //=========================================================================//
        }

        private bool ExtractTemplate(byte[] Template, out int TemplateSize)
        {
            UFS_STATUS ufs_res;
            int EnrollQuality;

            m_Scanner.ClearCaptureImageBuffer();

            //tbxMessage.AppendText("Place Finger\r\n");

            TemplateSize = 0;
            while (true)
            {
                ufs_res = m_Scanner.CaptureSingleImage();
                if (ufs_res != UFS_STATUS.OK)
                {
                    UFScanner.GetErrorString(ufs_res, out m_strError);
                    //tbxMessage.AppendText("UFScanner CaptureSingleImage: " + m_strError + "\r\n");
                    return false;
                }

                ufs_res = m_Scanner.Extract(Template, out TemplateSize, out EnrollQuality);
                if (ufs_res == UFS_STATUS.OK)
                {
                   //tbxMessage="UFScanner Extract: OK\r\n");
                    break;
                }
                else
                {
                    UFScanner.GetErrorString(ufs_res, out m_strError);
                  // tbxMessage="UFScanner Extract: " + m_strError + "\r\n");
                }

            }

            return true;
        }

        public FingerPrint Enroll(PictureBox pbImageFrame) {
            if (!ExtractTemplate(m_Template1, out m_Template1Size))
            {
                return null;
            }

            DrawCapturedImage(m_Scanner, pbImageFrame);

            //UserInfoForm dlg = new UserInfoForm(false);
            //  UFD_STATUS ufd_res;

            //tbxMessage.AppendText("Input user data\r\n");
            //if (dlg.ShowDialog(this) != DialogResult.OK)
            //{
            //   tbxMessage="User data input is cancelled by user\r\n");
            //    return;
            //}

            FingerPrint fingerPrint = new FingerPrint();

           
              //  fingerPrint.UserID = UserID;
                fingerPrint.FingerIndex = 5;
                fingerPrint.Template1 = m_Template1;
                fingerPrint.Template2 = m_Template2;
            
            return fingerPrint;
                //ufd_res = m.(dlg.UserID, dlg.FingerIndex, m_Template1, m_Template1Size, null, 0, dlg.Memo);

            //if (ufd_res != UFD_STATUS.OK)
            //{
            //    UFDatabase.GetErrorString(ufd_res, out m_strError);
            //    tbxMessage = "UFDatabase AddData: " + m_strError + "\r\n");
            //}
            //else
            //{
            //    cbScanTemplateType.Enabled = false;
            //}

            // UpdateDatabaseList();
        }

        private void DrawCapturedImage(UFScanner Scanner, PictureBox pbImageFrame)
        {
            Graphics g = pbImageFrame.CreateGraphics();
            Rectangle rect = new Rectangle(0, 0, pbImageFrame.Width, pbImageFrame.Height);
            try
            {
                //
                //Scanner.DrawCaptureImageBuffer(g, rect, cbDetectCore.Checked);
                //
                Bitmap bitmap;
                int Resolution;
                Scanner.GetCaptureImageBuffer(out bitmap, out Resolution);
                pbImageFrame.Image = bitmap;
            }
            finally
            {
                g.Dispose();
            }
        }
        //public bool IsInitializescanner()
        //{
        //    UFS_STATUS ufs_res;
        //    int nScannerNumber;
        //    string tbxMessage = "";
        //    Cursor.Current = Cursors.WaitCursor;
        //    //   ufs_res = m_ScannerManager.Init();

        //    if (ufs_res.in == UFS_STATUS.OK)
        //    {
        //        return true;
        //    }
        //}
        public  string  Uninit() {
            //=========================================================================//
            // Uninit scanner module
            //=========================================================================//
            UFS_STATUS ufs_res;

            Cursor.Current = Cursors.WaitCursor;
            ufs_res = m_ScannerManager.Uninit();
           // Cursor.Current = this.Cursor;
            if (ufs_res == UFS_STATUS.OK)
            {
                tbxMessage="UFScanner Uninit: OK\r\n";
            }
            else
            {
                UFScanner.GetErrorString(ufs_res, out m_strError);
               tbxMessage="UFScanner Uninit: " + m_strError + "\r\n";
            }
            //=========================================================================//

            //=========================================================================//
            // Close database
            //=========================================================================//
            //UFD_STATUS ufd_res;

            //if (m_Database != null)
            //{
            //    ufd_res = m_Database.Close();
            //    if (ufd_res == UFD_STATUS.OK)
            //    {
            //       tbxMessage="UFDatabase Close: OK\r\n";
            //    }
            //    else
            //    {
            //        UFDatabase.GetErrorString(ufd_res, out m_strError);
            //       tbxMessage="UFDatabase Close: " + m_strError + "\r\n";
            //    }
            //}

            //  lvDatabaseList.Items.Clear();

            return tbxMessage;
            //=========================================================================//

        }
    }
}
