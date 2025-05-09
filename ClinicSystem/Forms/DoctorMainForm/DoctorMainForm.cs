using System;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ClinicSystem.Main2;
using static System.Net.Mime.MediaTypeNames;

namespace ClinicSystem
{
    public partial class DoctorClinics : Form
    {

        private Button lastButtonClicked;
        private Doctor dr;
        private int x = 1;
        public DoctorClinics(Doctor dr)
        {
            this.dr = dr;
        
            InitializeComponent();
            Clock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            Date.Text = DateTime.Now.ToString("yyyy-MM-dd");
            doctorLastname.Text = dr.DoctorLastName.Substring(0,1).ToUpper() + dr.DoctorLastName.Substring(1).ToLower() + ", " + dr.DoctorFirstName + " " + dr.DoctorMiddleName;
            pictureBox2.Image = (dr.Image == null) ? Properties.Resources.doctoruser : dr.Image;


            DoctorHome home = new DoctorHome(dr);
            loadForm(home);
            SetButtonColor(HomeB);
            SetButtonColor(ViewPatientB);
            SetButtonColor(AppointmentsB);
            lastButtonClicked = HomeB;
            lastButtonClicked.BackColor = ColorTranslator.FromHtml("#B8EAE0");
            lastButtonClicked.ForeColor = ColorTranslator.FromHtml("#2E4E4E");

            HomeB.Paint += drawGradient;
            xTimer.Start();
        }

        private void drawGradient(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Rectangle rect = btn.ClientRectangle;
            Color color = ColorTranslator.FromHtml("#96D2CD");
            Color transparent = Color.FromArgb(170, color);

            Rectangle rectX = new Rectangle(rect.X, rect.Y, x, rect.Height);

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rectX,
                color,
                transparent,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, rectX);
            }
            Pen pen = new Pen(Color.FromArgb(255, 255, 255), 2);
            e.Graphics.DrawLine(pen, rect.Width - 1, 0, rect.Width - 1, rect.Height);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void DateTimer_Tick(object sender, EventArgs e)
        {
            Date.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void ViewPatientD_Click(object sender, EventArgs e)
        {
            DoctorViewPatient view = new DoctorViewPatient(dr);
            loadForm(view);
        }

        private void loadForm(Form f)
        {
            foreach (Control c in mainpanel.Controls)
            {
                if (c is Form && c.Name == f.Name)
                {
                    return;
                }
            }
            if (mainpanel.Controls.Count > 0)
            {
                mainpanel.Controls.Clear();
            }
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mainpanel.Controls.Add(f);
            mainpanel.Tag = f;
            f.Show();
        }

        private void mouseClicked(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != lastButtonClicked)
            {
                btn.BackColor = ColorTranslator.FromHtml("#B8EAE0"); 
                btn.ForeColor = ColorTranslator.FromHtml("#2E4E4E");
                lastButtonClicked.BackColor = ColorTranslator.FromHtml("#6FA8A6");  
                lastButtonClicked.ForeColor = Color.White;
                btn.Paint += drawGradient;
                x = 1;
                xTimer.Start();
                lastButtonClicked.Paint -= drawGradient;
                btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#96D2CD");    
                lastButtonClicked = btn;
            }
        }
        private void SetButtonColor(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = ColorTranslator.FromHtml("#6FA8A6");
            btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#96D2CD");
            btn.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void Home_Click(object sender, EventArgs e)
        {
            DoctorHome home = new DoctorHome(dr);
            loadForm(home);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LoginUserForm login = new LoginUserForm();
            login.Show();
            this.Hide();
        }

        private void SchedulesD_Click(object sender, EventArgs e)
        {
            DoctorAppointmentForm schedule = new DoctorAppointmentForm(dr);
            loadForm(schedule);
        }


        private void signOutB_Click(object sender, EventArgs e)
        {
            DialogResult option = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                Hide();
                LoginUserForm user = new LoginUserForm();
                user.Show();
            }
        }

        private void xTimer_Tick(object sender, EventArgs e)
        {
            x += 5;
            if (x >= 215)
            {
                xTimer.Stop();
                x = 215;
            }
            lastButtonClicked.Invalidate();
        }
    }
}
