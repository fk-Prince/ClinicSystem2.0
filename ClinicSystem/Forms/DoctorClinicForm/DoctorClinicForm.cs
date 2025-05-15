using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ClinicSystem.UserLoginForm;
using Guna.UI2.WinForms;

namespace ClinicSystem.Doctors
{
    public partial class DoctorMainForm : Form
    {
        private Guna2Button lastButtonClicked;
        private Staff staff;
        public DoctorMainForm(Staff staff)
        {
            this.staff = staff;
            InitializeComponent();
          
            ViewDoctor view = new ViewDoctor(staff);

            SetButtonColor(viewDentistB);
            SetButtonColor(addDentistB);
            //SetButtonColor(button2);
            LoadForm(view);
            lastButtonClicked = viewDentistB;
            lastButtonClicked.ForeColor = ColorTranslator.FromHtml("#2E4E4E");
            lastButtonClicked.FillColor = ColorTranslator.FromHtml("#6FA8A6");


        }

        public void LoadForm(Form f)
        {
            if (doctorpanel.Controls.Count > 0)
            {
                doctorpanel.Controls.Clear();
            }
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            doctorpanel.Controls.Add(f);
            doctorpanel.Tag = f;
            f.Show();
        }



        private void SetButtonColor(Guna2Button btn)
        {
            btn.FillColor = ColorTranslator.FromHtml("#CFF1EF");
            btn.BackColor = Color.Transparent;
            btn.ForeColor = ColorTranslator.FromHtml("#000000");
        }

        private void addDoctorB_Click(object sender, EventArgs e)
        {
            AddDoctor add = new AddDoctor(staff);
            LoadForm(add);
        }

        private void viewDoctorB_Click(object sender, EventArgs e)
        {
            ViewDoctor view = new ViewDoctor(staff);
            LoadForm(view);
        }

        private void doctorpanel_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                doctorpanel.ClientRectangle,
                ColorTranslator.FromHtml("#B7E6DE"),
                ColorTranslator.FromHtml("#E5F9F6"),
                90F))
            {
                e.Graphics.FillRectangle(brush, doctorpanel.ClientRectangle);
            }
        }

       

        private void mouseClicked(object sender, MouseEventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != lastButtonClicked)
            {
                btn.FillColor = ColorTranslator.FromHtml("#6FA8A6");
                btn.ForeColor = ColorTranslator.FromHtml("#2E4E4E");
                lastButtonClicked.FillColor = ColorTranslator.FromHtml("#CFF1EF");
                lastButtonClicked.ForeColor = ColorTranslator.FromHtml("#000000");

                lastButtonClicked = btn;
            }
        }

        
    }
}
