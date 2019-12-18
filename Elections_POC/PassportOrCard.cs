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
    public partial class PassportOrCard : Form
    {
        int TabletOrScanner;
        public PassportOrCard(int _TabletOrScanner)
        {
            TabletOrScanner = _TabletOrScanner;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TabletOrScanner == 2)
            {
                CardScan CardScan = new CardScan();
                this.Hide();
                CardScan.ShowDialog();
                this.Show();
            }
            else
            {
                OCR OCR = new OCR();
                this.Hide();
                OCR.ShowDialog();
                this.Show();
            }

        }

        private void PassportOrCard_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
        }
    }
}
