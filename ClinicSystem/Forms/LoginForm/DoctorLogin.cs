using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClinicSystem;
using System.IO;
using ClinicSystem.Helpers;
using Guna.UI2.WinForms;
using ClinicSystem.Repository;
using DoctorClinic;
using ClinicSystem.MessagePromps;

namespace ClinicSystem.UserLoginForm
{
    public partial class DoctorLogin : Form
    {
        private static DoctorLogin instance;
        private DoctorRepository doctorRepository = new DoctorRepository();

        public DoctorLogin()
        {
            InitializeComponent();
        }



        public static DoctorLogin GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DoctorLogin();
            } else
            {
                instance.BringToFront();
            }
            //else
            //{
            //    instance.Hide();
            //    instance = null;
            //    GetInstance();
            //}
            return instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doctorid = doctorID.Text.Trim();
            string pin = doctorPin.Text.Trim();
            if (string.IsNullOrWhiteSpace(doctorid) || string.IsNullOrWhiteSpace(pin))
            {
                MessageBox.Show(
                    "Empty space, provide credentials",
                    "Incomplete Credentials",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            Doctor doctorFound = doctorRepository.doctorLogin(doctorid, pin);

            if (doctorFound == null)
            {
                MessageBox.Show(
                    "Wrong Doctor ID or PIN",
                    "Incorrect Credentials",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            else
            {
                MessagePromp.MainShowMessage(this, "Successfully Login", MessageBoxIcon.Information);
                LoginUserForm log = LoginUserForm.getInstance();
                log.Hide();
                this.Hide();
                DoctorClinics doc = new DoctorClinics(doctorFound);
                doc.WindowState = FormWindowState.Maximized;
                doc.FormBorderStyle = FormBorderStyle.None;
                doc.Show();
                doctorID.Text = "";
                doctorPin.Text = "";
            }
            
        }

       



        private void colorExit(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }
        private void colorEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            instance.Hide();
            instance = null;
        }


        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            doctorPin.UseSystemPasswordChar = !doctorPin.UseSystemPasswordChar;
            guna2ImageButton1.Image = doctorPin.UseSystemPasswordChar ? Properties.Resources.shows : Properties.Resources.hide;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            RFIDPromp p = RFIDPromp.getInstance();
            if (p != null)
            {
                p.showRFIDPromp(this, rfid =>
                {
                    if (!string.IsNullOrEmpty(rfid))
                    {
                        Doctor doctorFound = doctorRepository.doctorScanned(rfid);
                        if (doctorFound == null)
                        {
                            MessageBox.Show("Doctor not found, Please Scan the card carefully", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Successfully Login", "Successfully Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoginUserForm log = LoginUserForm.getInstance();
                            log.Hide();
                            p.close();
                            this.Hide();
                            DoctorClinics doc = new DoctorClinics(doctorFound);
                            doc.WindowState = FormWindowState.Maximized;
                            doc.FormBorderStyle = FormBorderStyle.None;
                            doc.Show();
                            doctorID.Text = "";
                            doctorPin.Text = "";
                        }
                    }
                });
            }
        }


    }
}
