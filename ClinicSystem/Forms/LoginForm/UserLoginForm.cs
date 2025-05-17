using System;
using System.Drawing;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ClinicSystem.UserLoginForm;
using System.Collections.Generic;
using ClinicSystem;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics.Metrics;
using Guna.UI2.WinForms;
using System.IO.Ports;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using System.IO;
using System.Data.Common;
using ClinicSystem.Repository;
using ClinicSystem.MessagePromps;


namespace ClinicSystem
{
    public partial class LoginUserForm : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
  

        private static LoginUserForm instance;
        private List<Control> tab = new List<Control>();

  
        public LoginUserForm()
        {
            
            InitializeComponent();

            Load += LoginUserForm_Load;

            tab.Add(Username);
            tab.Add(Password);
            tab.Add(guna2Button1);

            instance = this;
        }



        private void LoginUserForm_Load(object sender, EventArgs e)
        {
        
            panel4.BackColor = ColorTranslator.FromHtml("#A6E5DC");
            //dentalClinic_label.Font = new Font("Lucida Bright", 20, FontStyle.Italic);
            //QuantumCare_Label.Font = new Font("Matura MT Script Capitals", 30, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            panel3.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 30, 30));
            //staffPortal_label.Font = new Font("Lucida Bright", 26, FontStyle.Bold);
            staffPortal_label.ForeColor = ColorTranslator.FromHtml("#6FA8A6");
           
         

            panel2.BackColor = ColorTranslator.FromHtml("#E9FFFC");
            panel2.Paint += (s, ev) =>
            {
                using (Pen pen = new Pen(ColorTranslator.FromHtml("#B8EAE0"), 1))
                {
                    ev.Graphics.DrawLine(pen, 0, 0, panel2.Width, 0);
                }
            };
            panel5.Paint += panel5_Paint;
        }



    

        public static LoginUserForm getInstance()
        {
            return instance;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();

            try
            {
                if (string.IsNullOrWhiteSpace(Username.Text) || string.IsNullOrWhiteSpace(Password.Text))
                {
                    MessagePromp.LoginShowMessage(this, "Wrong username or Password", MessageBoxIcon.Error);
                    return;
                }
                string driver = DatabaseConnection.getConnection();
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                string query = "SELECT Username, Password, StaffId FROM staff_tbl WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@USERNAME", username);
                command.Parameters.AddWithValue("@PASSWORD", password);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == false)
                {
                    MessagePromp.LoginShowMessage(this, "Wrong Username or Password", MessageBoxIcon.Error);

                    return;
                }
                while (reader.Read())
                {
                    guna2Button1.Enabled = false;
                    
                    Staff staff = new Staff(int.Parse(reader["StaffID"].ToString()), reader["Username"].ToString(), reader["Password"].ToString());
                    MessagePromp.LoginShowMessage(this, "Successfully Login", MessageBoxIcon.Information);
                    Timer timer = new Timer();
                    timer.Interval = 1000;
                    timer.Tick += (s, y) =>
                    {
                        timer.Stop();
                        this.Hide();
                        ClinicSystem clinicSystem = new ClinicSystem(staff);
                        clinicSystem.WindowState = FormWindowState.Maximized;
                        clinicSystem.FormBorderStyle = FormBorderStyle.None;
                        clinicSystem.Show();
                    };
                    timer.Start();
                    DoctorLogin dl = DoctorLogin.GetInstance();
                    dl.Close();
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void doctorB_Click(object sender, EventArgs e)
        {
            DoctorLogin docl = DoctorLogin.GetInstance();
            docl.Show();
        }


        private bool initialFocuse = true;

        private void s(object sender, PaintEventArgs e)
        {
            if (initialFocuse)
            {
                logo_img.Focus();
                initialFocuse = false;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();

            }  
         }

        private void button1_Click(object sender, EventArgs e)
        {
 
            Password.UseSystemPasswordChar = !Password.UseSystemPasswordChar;
            passwordToggle.Image = Password.UseSystemPasswordChar ? Properties.Resources.shows : Properties.Resources.hide;
            //SetPlaceholder(Username, "Username...");
            //SetPlaceholder(Password, "Password...");
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel3.ClientRectangle,
                ColorTranslator.FromHtml("#B7E6DE"),
                ColorTranslator.FromHtml("#E5F9F6"),
                90F))
            {
                e.Graphics.FillRectangle(brush, panel3.ClientRectangle);
            }
        }  

        private Image FadeImageBottom(Image originalImage, int fadeHeight)
        {
            int width = panel5.Width;
            int height = panel5.Height;

            Bitmap resized = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, width, height);
            }

            using (Graphics g = Graphics.FromImage(resized))
            {
                Rectangle fadeRect = new Rectangle(0, height - fadeHeight, width, fadeHeight);
                Color topGradientColor = ColorTranslator.FromHtml("#B7E6DE"); 

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    fadeRect,
                    Color.FromArgb(0, topGradientColor),
                    topGradientColor,
                    90f))
                {
                    g.FillRectangle(brush, fadeRect);
                }
            }

            return resized;
        }



        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            if (bgClinic_img.Image == null) return;

            Image faded = FadeImageBottom(bgClinic_img.Image, 100);

            e.Graphics.DrawImage(faded, new Rectangle(0, 0, panel5.Width, panel5.Height));
        }

    }
}
        
    
