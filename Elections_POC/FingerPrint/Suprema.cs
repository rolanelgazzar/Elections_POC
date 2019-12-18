using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Suprema;
namespace Elections_POC
{
    public class Suprema
    {
        private UFDatabase m_Database = new UFDatabase();
        private UFScanner m_Scanner = new UFScanner();
        private UFScannerManager m_ScannerManager;
        private UFMatcher m_Matcher;
        private UFD_STATUS m_ufd_res = UFD_STATUS.ERROR;
        UFM_STATUS m_ufm_res;
        private byte[] m_bTemplate1;
        private int m_nTemplateSize1;
        const int nMAX_TEMPLATE_SIZE = 1024;
        private string m_szConnectionString;
        private string strLastError = "";

        public string LastError
        {
            get
            {
                return strLastError;
            }
        }

        public void SetDatabasePath(string path)
        {
        }

        public void InitializeReader(string connectionString)
        {
            m_ScannerManager = new UFScannerManager(new ScannerManager());

            m_Scanner = null;
            m_Database = null;
            m_Matcher = null;
            m_bTemplate1 = new byte[nMAX_TEMPLATE_SIZE];
            m_szConnectionString = connectionString;
        }

        public void ReleaseReader()
        {
            //ToDo put the code of the deinialization here
        }

        public string GetCardID()
        {
            try
            {
                Log("Start Get Card ID");
                byte[][] DBTemplate = null;
                int[] DBTemplateSize = null;
                int[] DBSerial = null;
                int DBTemplateNum;
                int nMatchIndex;
                // Initialize scanners
                UFS_STATUS ufs_res = new UFS_STATUS();
                int nScannerNumber;

                ufs_res = m_ScannerManager.Init();

                nScannerNumber = m_ScannerManager.Scanners.Count;

                if (nScannerNumber <= 0)
                {
                    strLastError = "There are no suprema scanner";
                    Log(strLastError);
                    return "";
                }

                m_Scanner = m_ScannerManager.Scanners[0];

                // Database           
                m_Database = new UFDatabase();

                if (m_szConnectionString != null)
                {
                    m_ufd_res = m_Database.Open(m_szConnectionString, "", "");
                }

                // Create matcher
                m_Matcher = new UFMatcher();
                if (!ExtractTemplate(m_bTemplate1, out m_nTemplateSize1))
                {
                    m_ScannerManager.Uninit();
                    m_Database.Close();
                    return "";
                }

                m_ScannerManager.Uninit();
                //Identify      loyee fingerprint :GetTemplateListWithSerial
                m_ufd_res = m_Database.GetTemplateListWithSerial(out DBTemplate, out DBTemplateSize, out DBTemplateNum, out DBSerial);
                //Identify employee fingerprint :Identify
                m_ufm_res = m_Matcher.Identify(m_bTemplate1, m_nTemplateSize1, DBTemplate, DBTemplateSize, DBTemplateNum, 5000, out nMatchIndex);
                string m_strUserID = "";
                int m_nFingerIndex = 0;
                string memo = "";
                int x = 0;
                if (nMatchIndex >= 0 && DBSerial != null)
                {
                    m_ufd_res = m_Database.GetDataBySerial(DBSerial[nMatchIndex], out m_strUserID, out m_nFingerIndex, m_bTemplate1, out m_nTemplateSize1, null, out x, out memo);
                }
                else
                    m_strUserID = "";

                if (m_ufm_res != UFM_STATUS.OK)
                {
                    return "";
                }

                Log(m_strUserID.Replace('\0', ' ').Trim());
                return m_strUserID.Replace('\0', ' ').Trim();
            }
            catch (Exception ex)
            {
                strLastError = "Unkown Error Happened:\n" + ex.Message;
                Log(strLastError);
                return "";
            }
        }
        public bool Enroll(string nUserID, string strUserName, int FingerIndex = 1)
        {
            bool bRet = false;
            try
            {
                //ErrorMessage = "";
                UFS_STATUS ufs_status;
                int nScannerNumber;

                ufs_status = m_ScannerManager.Init();

                nScannerNumber = m_ScannerManager.Scanners.Count;

                if (nScannerNumber <= 0)
                {
                    strLastError = "There are no suprema scanner";
                    Log(strLastError);
                    return false;
                }

                m_Scanner = m_ScannerManager.Scanners[0];
                // Open database          
                m_Database = new UFDatabase();
                //string szDataSource;
                if (m_szConnectionString != string.Empty)
                    m_ufd_res = m_Database.Open(m_szConnectionString, "", "");
                else
                    return false;
                if (m_ufd_res != UFD_STATUS.OK)
                    return false;
                // Create matcher          
                m_Matcher = new UFMatcher();
                if (!ExtractTemplate(m_bTemplate1, out m_nTemplateSize1))
                    return false;
                m_ScannerManager.Uninit();

                #region Check if the finger is used before for other user

                byte[][] DBTemplate = null;
                int[] DBTemplateSize = null;
                int[] DBSerial = null;
                int DBTemplateNum;
                int nMatchIndex;
                string m_strUserID = "";
                int m_nFingerIndex = 0;
                string memo = "";
                int x = 0;

                m_ufd_res = m_Database.GetTemplateListWithSerial(out DBTemplate, out DBTemplateSize, out DBTemplateNum, out DBSerial);
                m_ufm_res = m_Matcher.Identify(m_bTemplate1, m_nTemplateSize1, DBTemplate, DBTemplateSize, DBTemplateNum, 5000, out nMatchIndex);

                if (nMatchIndex >= 0 && DBSerial != null)
                {
                    m_ufd_res = m_Database.GetDataBySerial(DBSerial[nMatchIndex], out m_strUserID, out m_nFingerIndex, m_bTemplate1, out m_nTemplateSize1, null, out x, out memo);
                    if (m_strUserID.Replace('\0', ' ').Trim() != nUserID && m_nFingerIndex == FingerIndex)
                    {
                        strLastError = "This fingerprint is used for another person";
                        Log(strLastError);
                        return false;
                    }
                }

                #endregion

                m_ufd_res = m_Database.AddData(nUserID.ToString(), FingerIndex, m_bTemplate1, m_nTemplateSize1, null, 0, "");
                if (m_ufd_res == UFD_STATUS.OK)
                {
                    bRet = true;
                }
                else if (m_ufd_res == UFD_STATUS.ERR_SAME_FINGER_EXIST)
                {
                    m_ufd_res = m_Database.UpdateDataByUserInfo(nUserID, FingerIndex, m_bTemplate1, m_nTemplateSize1, null, 0, null);
                    if (m_ufd_res == UFD_STATUS.OK)
                        bRet = true;
                }
            }
            catch (Exception ex)
            {
                
                strLastError = "Unkown Error Happened:\n" + ex.Message;
                Log(strLastError);
            }

            return bRet;
        }

        public bool Verify(string nUserID, string strUserName, int fingerIndex = 1)
        {
            try
            {
                byte[][] DBTemplate = null;
                int[] DBTemplateSize = null;
                int[] DBSerial = null;
                int DBTemplateNum;
                int nMatchIndex;
                // Initialize scanners
                UFS_STATUS ufs_res = new UFS_STATUS();
                int nScannerNumber;

                ufs_res = m_ScannerManager.Init();

                nScannerNumber = m_ScannerManager.Scanners.Count;

                if (nScannerNumber <= 0)
                {
                    strLastError = "There are no suprema scanner";
                    Log(strLastError);
                    return false;
                }

                m_Scanner = m_ScannerManager.Scanners[0];

                // Database           
                m_Database = new UFDatabase();

                if (m_szConnectionString != null)
                {
                    m_ufd_res = m_Database.Open(m_szConnectionString, "", "");
                }

                // Create matcher
                m_Matcher = new UFMatcher();
                if (!ExtractTemplate(m_bTemplate1, out m_nTemplateSize1))
                    return false;

                m_ScannerManager.Uninit();
                //Identify      loyee fingerprint :GetTemplateListWithSerial
                m_ufd_res = m_Database.GetTemplateListWithSerial(out DBTemplate, out DBTemplateSize, out DBTemplateNum, out DBSerial);
                //Identify employee fingerprint :Identify
                m_ufm_res = m_Matcher.Identify(m_bTemplate1, m_nTemplateSize1, DBTemplate, DBTemplateSize, DBTemplateNum, 5000, out nMatchIndex);
                string m_strUserID = "";
                int m_nFingerIndex = 0;
                string memo = "";
                int x = 0;
                if (nMatchIndex >= 0 && DBSerial != null)
                {
                    m_ufd_res = m_Database.GetDataBySerial(DBSerial[nMatchIndex], out m_strUserID, out m_nFingerIndex, m_bTemplate1, out m_nTemplateSize1, null, out x, out memo);
                }
                else
                    m_strUserID = "";

                if (m_ufm_res != UFM_STATUS.OK)
                {
                    return false;
                }

                if (m_strUserID.Replace('\0', ' ').Trim() == nUserID.ToString() && m_nFingerIndex == fingerIndex)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                strLastError = "Unkown Error Happened:\n" + ex.Message;
                Log(strLastError);
                return false;
            }
        }

        private bool ExtractTemplate(byte[] Template, out int TemplateSize)
        {
            UFS_STATUS ufs_res;
            int EnrollQuality;
            if (m_Scanner != null)
                m_Scanner.ClearCaptureImageBuffer();
            TemplateSize = 0;
            while (true)
            {
                ufs_res = m_Scanner.CaptureSingleImage();
                if (ufs_res != UFS_STATUS.OK)
                    return false;
                ufs_res = m_Scanner.Extract(Template, out TemplateSize, out EnrollQuality);
                if (ufs_res == UFS_STATUS.OK)
                    break;
            }
            return true;
        }

        public static bool Log(string LogString)
        {
            try
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Log.txt", DateTime.Now.ToString() + "--" + LogString + '\n' + "-------------------------");
                return true;
            }
            catch (Exception )
            {
                return false;
                throw;
            }
        }
    }
}
