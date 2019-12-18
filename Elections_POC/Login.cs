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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text != "" && txt_Password.Text != "")  //validating the fields whether the fields or empty or not  
            {
                var User = Program.Elections.Users.Where(s => s.UserName == txt_UserName.Text & s.Password == txt_Password.Text).FirstOrDefault();
                if (User != null)
                {
                    //PassportOrCard PassOrCard = new PassportOrCard();
                    //this.Hide();
                    //PassOrCard.ShowDialog();
                    //this.Show();

                    Tablet_or_Scanner TabletOrScanner = new Tablet_or_Scanner();
                    this.Hide();
                    TabletOrScanner.ShowDialog();
                    this.Show();


                }
                else
                {
                    MessageBox.Show("خطأ فى اسم المستخدم او رقم السر", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("برجاء ملئ الخانات الفارغة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Usr_astr_Click(object sender, EventArgs e)
        {

        }

        private void Pass_astr_Click(object sender, EventArgs e)
        {

        }

        private void Txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            //if (txt_UserName.Text != "" && txt_Password.Text != "")  //validating the fields whether the fields or empty or not  
            //{
                
            //        string UserName = txt_UserName.Text;
            //        string Password = Cryptography.Encrypt(txt_Password.Text.ToString());   // Passing the Password to Encrypt method and the method will return encrypted string and stored in Password variable.  

            //    using (ElectionEntities Elections = new ElectionEntities())
            //    {

                    
            //            Elections.Users.Add(new User
            //            {
            //                UserName = UserName.ToString(),
            //                Password = Password.ToString()                          
            //            });

            //            Elections.SaveChanges();

                    
            //    }


            //    MessageBox.Show("Record inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
            //}
            //else
            //{
            //    MessageBox.Show("Please fill all the fields!..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);  //showing the error message if any fields is empty  
            //}
        }
    }
}

