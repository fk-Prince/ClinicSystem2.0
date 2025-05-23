using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicSystem.Appointments;
using ClinicSystem.Forms.AppointmentsForm;
using ClinicSystem.UserLoginForm;
using Guna.UI2.WinForms;

namespace ClinicSystem
{
    public partial class AppointmentForm : Form
    {
        private Guna2Button lastButtonClicked;
        private int staffid;
        public AppointmentForm(int staffid)
        {
            this.staffid = staffid;
            InitializeComponent();

            SetButtonColor(allAppointmentB);
            SetButtonColor(addAppointmentB);
            SetButtonColor(rescheduleB);
            SetButtonColor(missedAppointment);

            AllAppointments allAppointments = new AllAppointments();
            LoadForm(allAppointments);

            lastButtonClicked = allAppointmentB;     
            lastButtonClicked.ForeColor = ColorTranslator.FromHtml("#2E4E4E");
            lastButtonClicked.FillColor = ColorTranslator.FromHtml("#6FA8A6");
        }

        private void SetButtonColor(Guna2Button btn)
        {
            btn.FillColor = ColorTranslator.FromHtml("#CFF1EF");
            btn.BackColor = Color.Transparent;
            btn.ForeColor = ColorTranslator.FromHtml("#000000");
        }

        public void LoadForm(Form f)
        {
            foreach (Control c in appointmentPanel.Controls)
            {
                if (c is Form && c.Name == f.Name)
                {
                    return;
                }
            }
            if (appointmentPanel.Controls.Count > 0)
            {
                appointmentPanel.Controls.Clear();
            }
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            appointmentPanel.Controls.Add(f);
            appointmentPanel.Tag = f;
            f.Show();
        }

       

        private void allAppointmentB_Click(object sender, EventArgs e)
        {
            AllAppointments allAppointments = new AllAppointments();
            LoadForm(allAppointments);
        }

        private void addAppointmentB_Click(object sender, EventArgs e)
        {
            AddAppointmentForm add = new AddAppointmentForm(staffid);
            LoadForm(add);
        }

        private void rescheduleB_Click(object sender, EventArgs e)
        {
            RescheduleForm add = new RescheduleForm();
            LoadForm(add);
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

        private void missedAppointment_Click(object sender, EventArgs e)
        {
            MissedAppointmentForm missed = new MissedAppointmentForm();
            LoadForm(missed);
        }
    }
}
