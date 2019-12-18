using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elections_POC
{
    public partial class FingerPrint : Form
    {
        public FingerPrint()
        {   
            InitializeComponent();
            //textBox1.Text = OCR.result;
        }

        private void Btn_TakeFingerPrint_Click(object sender, EventArgs e)
        {
            Suprema suprema = new Suprema();
            //suprema.InitializeReader("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=FingerPrint;Data Source=.");

            suprema.InitializeReader("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Election;Data Source=.");


            //suprema.InitializeReader("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Election;Data Source=.");

            suprema.InitializeReader("DSN=FP;Uid=;Pwd=;");
            //suprema.Enroll((Guid.NewGuid()).ToString(), "");
            if (suprema.Enroll((Guid.NewGuid()).ToString(), "") == false)
            {
                MessageBox.Show("This fingerprint is used for another person");
            }
            // MessageBox.Show(suprema.GetCardID());
            //  MessageBox.Show( suprema.GetCardID());
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
