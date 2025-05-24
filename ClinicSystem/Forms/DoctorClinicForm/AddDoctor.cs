using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.MessagePromps;
using ClinicSystem.UserLoginForm;
using DoctorClinic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ClinicSystem.Doctors
{
    public partial class AddDoctor : Form
    {
        private DoctorRepository doctorRepository = new DoctorRepository();
        private List<Control> tab = new List<Control>();
        private Image image;
        public AddDoctor(Staff staff)
        {
            InitializeComponent();
            
            doctorID.Text = doctorRepository.getDoctorLastID();
            dateHired.Value = DateTime.Now;
            tab.Add(firstName);
            tab.Add(middleName);
            tab.Add(lastName);
            tab.Add(Address);
            tab.Add(dateHired);
            tab.Add(Age);
            tab.Add(contactNumber);
            tab.Add(enterPIN);
            tab.Add(confirmedPIN);

            foreach (Control control in tab)
            {
                control.PreviewKeyDown += taab;
            }
        }
        private void TextOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void Number_Only(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

     

        private void taab(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                Control currentControl = sender as Control;
                int currentIndex = tab.IndexOf(currentControl);

                if (currentIndex >= 0)
                {
                    int nextIndex = (currentIndex + 1) % tab.Count;
                    tab[nextIndex].Focus();
                    e.IsInputKey = true;
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                string imagePath = ofd.FileName;
                pictureBox1.ImageLocation = imagePath;
                image = Image.FromFile(imagePath);
                drPicture.Text = "";
                drPicture.FlatAppearance.BorderSize = 0;
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox1.BringToFront();
                
            }
            else
            {
                drPicture.FlatAppearance.BorderSize = 1;
                drPicture.Text = "Browse";
                pictureBox1.ImageLocation = null;
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                image = null;
                drPicture.BringToFront();
            }
        }

        private void addDentistB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstName.Text) ||
                string.IsNullOrWhiteSpace(middleName.Text) ||
                string.IsNullOrWhiteSpace(lastName.Text) ||
                string.IsNullOrWhiteSpace(Address.Text) ||
                string.IsNullOrWhiteSpace(Age.Text) ||
                string.IsNullOrWhiteSpace(contactNumber.Text) ||
                string.IsNullOrWhiteSpace(enterPIN.Text) ||
                string.IsNullOrWhiteSpace(confirmedPIN.Text)) {
                MessagePromp.ShowCenter(this,"Please fill all the empty fields.",MessageBoxIcon.Error);
                return;
            }

            int ageInt = 0;
            if (!int.TryParse(Age.Text, out ageInt))
            {
                MessagePromp.ShowCenter(this, "Invalid Age", MessageBoxIcon.Error);
                return;
            }
            if (ageInt > 120 || ageInt <= 0)
            {
                MessagePromp.ShowCenter(this, "Invalid Age", MessageBoxIcon.Error);
                return;
            }

            if (ageInt <= 18)
            {
                MessagePromp.ShowCenter(this, "Doctor must be above 18 years old.", MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(contactNumber.Text.Trim()) && (!long.TryParse(contactNumber.Text, out _) || !Regex.IsMatch(contactNumber.Text.Trim(), @"^9\d{9}$")))
            {
                MessagePromp.ShowCenter(this, "Invalid Contact Number", MessageBoxIcon.Error);
                return;
            }

            if (!rMale.Checked && !rFemale.Checked)
            {
                MessagePromp.ShowCenter(this, "Choose gender", MessageBoxIcon.Error);
                return;
            }
            string gender = rMale.Checked ? "Male" : "Female";


            if (!enterPIN.Text.Equals(confirmedPIN.Text,StringComparison.OrdinalIgnoreCase)){
                MessagePromp.ShowCenter(this, "PIN NOT MATCH, Try again.", MessageBoxIcon.Error);
                return;
            }

       
            
            string contact = contactNumber.Text.Trim();
            if (contact.Length != 0)
            {
                contact = "0" + contact;
            }



            Doctor doctor = new Doctor(
                doctorID.Text.Trim(),
                firstName.Text.Trim(),
                middleName.Text.Trim(),
                lastName.Text.Trim(),
                ageInt,
                enterPIN.Text.Trim(),
                dateHired.Value,
                gender,
                Address.Text.Trim(),
                contact,
                image,
                doctorRFID
            );
    
            bool succ = doctorRepository.AddDoctor(doctor);
            if (succ)
            {
                MessagePromp.ShowCenter(this, "Doctor Successfully Added.", MessageBoxIcon.Information);
                doctorID.Text = doctorRepository.getDoctorLastID();
                lrfid.Visible = false;
                firstName.Text = "";
                middleName.Text = "";
                lastName.Text = "";
                enterPIN.Text = "";
                Age.Text = "";
                doctorRFID = "";
                rFemale.Checked = false;
                rMale.Checked = false;
                Address.Text = "";
                contactNumber.Text = "";
                confirmedPIN.Text = "";
                pictureBox1.Image = null;
                drPicture.FlatAppearance.BorderSize = 1;
                drPicture.BringToFront();
            }
        }

        private void confirmedPIN_TextChanged(object sender, EventArgs e)
        {
            checkPin();
        }

        private void checkPin()
        {
            if (string.IsNullOrWhiteSpace(enterPIN.Text) ||
                string.IsNullOrWhiteSpace(confirmedPIN.Text))
            {
                p1.Image = null;
                p2.Image = null;
                return;
            }
            if (!enterPIN.Text.Equals(confirmedPIN.Text, StringComparison.OrdinalIgnoreCase))
            {
                p1.Image = Properties.Resources.error;
                p2.Image = Properties.Resources.error;
            } else
            {
                p1.Image = Properties.Resources.checked2;
                p2.Image = Properties.Resources.checked2;
            }
        }

        private string doctorRFID = "";
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RFIDPromp p = RFIDPromp.getInstance();
            if (p != null)
            {
                p.showRFIDPromp(this, rfid =>
                {
                    if (!string.IsNullOrEmpty(rfid))
                    {
                        p.Hide();
                        p.close();
                        Doctor doc = doctorRepository.doctorScanned(rfid);
                        if (doc != null)
                        {
                            MessagePromp.ShowCenter(this, "RFID already scanned, Please Try another one.", MessageBoxIcon.Error);
                        } else
                        {
                            doctorRFID = rfid;  
                            MessagePromp.ShowCenter(this, "RFID recorded", MessageBoxIcon.Information);
                            string rf = "";
                            for (int i = 0; i < doctorRFID.Length; i++)
                            {
                                if (i == 0 || i == 1 || i == doctorRFID.Length - 1 || i == doctorRFID.Length - 2)
                                {
                                    rf += doctorRFID[i];
                                } else
                                {
                                    rf += "*";
                                }
                            }
                            doctorID.Text = rf;
                            lrfid.Visible = true;
                            doctorID.Visible = true;
                        }
                    }
                });
            }
        }


    }
}
