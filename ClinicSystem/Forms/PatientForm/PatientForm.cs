using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ClinicSystem.UserLoginForm;
using Guna.UI2.WinForms;

namespace ClinicSystem
{

    public partial class FormPatient : Form
    {
        private Guna2Button lastClickedButton;
        private Staff staff;
        public FormPatient(Staff staff)
        {
            this.staff = staff;
            InitializeComponent();

           
            SetButtonColor(addPatientB);
            SetButtonColor(viewPatientB);
            lastClickedButton = addPatientB;
            lastClickedButton.ForeColor = ColorTranslator.FromHtml("#2E4E4E");
            lastClickedButton.FillColor = ColorTranslator.FromHtml("#6FA8A6");
            AddPatients addPatientForm = new AddPatients(staff);
            loadForm(addPatientForm);

            //addPatientB1.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, addPatientB1.Width, addPatientB1.Height, 30, 30));
            //viewPatientB2.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, viewPatientB2.Width, viewPatientB2.Height, 30, 30));

        }

        private void SetButtonColor(Guna2Button btn)
        {
            btn.FillColor = ColorTranslator.FromHtml("#CFF1EF");
            btn.BackColor = Color.Transparent;
            btn.ForeColor = ColorTranslator.FromHtml("#000000"); 
        }

        private void loadForm(Form f)
        {
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls.Clear();
            }
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panel2.Controls.Add(f);
            panel2.Tag = f;
            f.Show();
        }

        private void mouseClicked(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;

            if (btn != lastClickedButton)
            {
                btn.FillColor = ColorTranslator.FromHtml("#6FA8A6");
                btn.ForeColor = ColorTranslator.FromHtml("#2E4E4E"); 
                lastClickedButton.FillColor = ColorTranslator.FromHtml("#CFF1EF");
                lastClickedButton.ForeColor = ColorTranslator.FromHtml("#000000");

                lastClickedButton = btn;
            }
        }

        private void addPatientClicked(object sender, MouseEventArgs e)
        {
            AddPatients addPatientForm = new AddPatients(staff);
            loadForm(addPatientForm);
        }

        private void viewPatientClicked(object sender, MouseEventArgs e)
        {
            ViewPatientForm addPatientForm = new ViewPatientForm(staff);
            loadForm(addPatientForm);
        }

    }
}
