using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ClinicSystem.ClinicHistory;
using ClinicSystem.Doctors;
using ClinicSystem.MainClinic;
using ClinicSystem.Rooms;
using ClinicSystem.UserLoginForm;

namespace ClinicSystem
{
    public partial class ClinicSystem : Form
    {
        private Button lastButtonClicked;
        private Staff staff;

       
        public ClinicSystem(Staff staff)
        {
            this.staff = staff;
            InitializeComponent();
            StaffIdentity.Text = staff.Username;
            Clock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            Date.Text = DateTime.Now.ToString("yyyy-MM-dd");

            DashboardForm dashboard = new DashboardForm(staff, this);
            LoadForm(dashboard);
            SetButtonColor(dashboardB);
            SetButtonColor(patientsB);
            SetButtonColor(operationsB);
            SetButtonColor(dentistsB);
            SetButtonColor(roomsB);
            SetButtonColor(appointmentsB);
            SetButtonColor(patientHistoryB);

            lastButtonClicked = dashboardB;
            dashboardB.Paint += drawGradient;
            xTimer.Start();
        }

        private void SetButtonColor(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = ColorTranslator.FromHtml("#6FA8A6");
            btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#96D2CD");
            btn.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }
        
        public void LoadForm(Form f)
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
        private void AddPatientS_Click_1(object sender, EventArgs e)
        {
            FormPatient patientForm = new FormPatient(staff);
            LoadForm(patientForm);
        }


        private void appointmentButton_Click(object sender, EventArgs e)
        {
            AppointmentForm appointmentForm = new AppointmentForm(staff.StaffId);
            LoadForm(appointmentForm);
        }

        private void OperationClicked(object sender, EventArgs e)
        {
            OperationForm of = new OperationForm();
            LoadForm(of);
        }

        private void roomClicked(object sender, EventArgs e)
        {
            RoomsForm room = new RoomsForm();
            LoadForm(room);
        }


        private void dashboardClicked(object sender, EventArgs e)
        {
            DashboardForm dashboard = new DashboardForm(staff, this);
            LoadForm(dashboard);
        }

        private void dateTimer_Tick(object sender, EventArgs e)
        {
            Date.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }

        private void hoursTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            Clock.Text = currentTime.ToString("hh:mm:ss tt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DoctorMainForm doc = new DoctorMainForm(staff);
            LoadForm(doc);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClinicForm clinic = new ClinicForm(staff);
            LoadForm(clinic);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult option = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                Hide();
                LoginUserForm user = new LoginUserForm();
                user.Show();
            }
        }



        private void mouseClicked(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != lastButtonClicked)
            {
                
                btn.BackColor = ColorTranslator.FromHtml("#B8EAE0");
                btn.ForeColor = ColorTranslator.FromHtml("#2E4E4E");
                btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#B8EAE0");
                btn.Paint += drawGradient;
                x = 1;
                xTimer.Start();
                lastButtonClicked.Paint -= drawGradient;
                lastButtonClicked.BackColor = ColorTranslator.FromHtml("#6FA8A6");
                btn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#96D2CD");
                lastButtonClicked.ForeColor = Color.White;
                lastButtonClicked = btn;
            }
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
            Pen pen = new Pen(Color.FromArgb(255, 255, 255), 3);  
            e.Graphics.DrawLine(pen, rect.Width - 2, 0, rect.Width - 2, rect.Height);

        }

        private int x = 1;

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