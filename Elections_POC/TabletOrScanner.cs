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
    public partial class Tablet_or_Scanner : Form
    {
        public Tablet_or_Scanner()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //    OCR OCR = new OCR();
            //    this.Hide();
            //    OCR.ShowDialog();
            //    this.Show();

            PassportOrCard PassportOrCard = new PassportOrCard(1);
            this.Hide();
            PassportOrCard.ShowDialog();
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PassportOrCard PassportOrCard = new PassportOrCard(2);
            this.Hide();
            PassportOrCard.ShowDialog();
            this.Show();

            //CardScan CardScan = new CardScan(2);
            //this.Hide();
            //CardScan.ShowDialog();
            //this.Show();
        }

        private void Tablet_or_Scanner_Load(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
