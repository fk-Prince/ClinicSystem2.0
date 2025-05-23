using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClinicSystem.Appointments;
using Guna.UI2.WinForms;


namespace ClinicSystem.Main2
{
    public partial class DoctorAppointmentForm : Form
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();

        private List<Appointment> patientAppointments;
        private Doctor dr;
        private DataTable table = new DataTable();

        public DoctorAppointmentForm(Doctor dr)
        {
            this.dr = dr;
            InitializeComponent();
            patientAppointments = appointmentRepository.getAppointmentsbyDoctor(dr);

            table.Columns.Add("Appointment No", typeof(int));
            table.Columns.Add("Operation", typeof(string));
            table.Columns.Add("Start Appointment", typeof(string));
            table.Columns.Add("End Appointment", typeof(string));
            table.Columns.Add("Patient ID", typeof(string));
            table.Columns.Add("Patient Fullname", typeof(string));
            dataGrid.DataSource = table;

            date1.Value = DateTime.Now;
            date2.Value = DateTime.Now;

            if (patientAppointments.Count == 0)
            {
                loadAppointment(DateTime.Today, "YOU HAS NO REGISTERED APPOINTMENT.");
            }
            else
            {
                loadAppointment(DateTime.Today, "YOU HAS NO APPOINTMENT TODAY.");
            }
        }
        private void loadAppointment(DateTime date, string type)
        {
            List<Appointment> filteredAppointments = patientAppointments
                .Where(pa => pa.StartTime.Date == date.Date)
                .ToList();

            displaySchedules(filteredAppointments, type);
        }
        Panel panel5;
        private void displaySchedules(List<Appointment> filteredAppointments, string type)
        {
            table.Rows.Clear();

            if (panel5 != null)
            {
                guna2Panel1.Controls.Remove(panel5);
                panel5 = null;
            }


            if (filteredAppointments.Count == 0)
            {
                dataGrid.Visible = false;


                Panel panel = new Panel();
                panel.Size = new Size(guna2Panel1.ClientSize.Width - 10, 500);
                panel.Dock = DockStyle.Fill;

                Label label = new Label();
                label.Text = type;
                label.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                label.ForeColor = Color.Black;
                label.AutoSize = false;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;

                panel.Controls.Add(label);
                guna2Panel1.Controls.Add(panel);
                panel5 = panel;
            }
            else
            {
                dataGrid.Visible = true;

                foreach (Appointment a in filteredAppointments)
                {
                    table.Rows.Add(
                        a.AppointmentDetailNo,
                        a.Operation.OperationName,
                        a.StartTime.ToString("yyyy-MM-dd") + Environment.NewLine + a.StartTime.ToString("hh:mm:ss tt"),
                        a.EndTime.ToString("yyyy-MM-dd") + Environment.NewLine + a.EndTime.ToString("hh:mm:ss tt"),
                        a.Patient.Patientid.ToString(),
                        $"{a.Patient.Firstname} {a.Patient.Middlename} {a.Patient.Lastname}"
                    );
                }
            }


            guna2Panel1.Invalidate();
        }





        private void radioToday_CheckedChanged(object sender, EventArgs e)
        {
            if (radioToday.Checked)
                loadAppointment(DateTime.Today, "YOU HAVE NO APPOINTMENT TODAY.");
        }

        private void weekRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (weekRadio.Checked)
            {
                DateTime startOfWeek = DateTime.Today;
                DateTime endOfWeek = startOfWeek.AddDays(7);
                List<Appointment> filteredAppointments = patientAppointments
                    .Where(pa => pa.StartTime >= startOfWeek && pa.StartTime < endOfWeek)
                    .ToList();

                displaySchedules(filteredAppointments, "YOU HAVE NO APPOINTMENT THIS WEEK.");
            }
        }


        private void monthRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (monthRadio.Checked)
            {
                DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                List<Appointment> filteredAppointments = patientAppointments
                    .Where(pa => pa.StartTime >= startOfMonth && pa.StartTime <= endOfMonth)
                    .ToList();

                displaySchedules(filteredAppointments, "YOU HAVE NO APPOINTMENT THIS MONTH.");
            }
        }

        private void allSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (allSchedule.Checked)
                displaySchedules(patientAppointments, "YOU HAVE NO REGISTERED APPOINTMENT.");
        }

        private void selection_CheckedChanged(object sender, EventArgs e)
        {
            date1.Visible = selection.Checked;
            date2.Visible = selection.Checked;
            arrow.Visible = selection.Checked;
            label1.Visible = selection.Checked;
            label2.Visible = selection.Checked;
            if (selection.Checked) pickDate();
        }

        private void datePickDate_ValueChanged_1(object sender, EventArgs e)
        {
            if (date1.Value.Date <= date2.Value.Date)
                pickDate();
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            if (date1.Value.Date <= date2.Value.Date)
                pickDate();
        }

        private void pickDate()
        {
            DateTime date11 = date1.Value.Date;
            DateTime date22 = date2.Value.Date;
            List<Appointment> filteredAppointments = patientAppointments
                .Where(pa => pa.StartTime.Date >= date11 && pa.StartTime.Date <= date22)
                .ToList();

            displaySchedules(filteredAppointments, "YOU HAVE NO APPOINTMENT THIS DATE.");
        }

        private void SearchBar1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            radioToday.Checked = false;
            weekRadio.Checked = false;
            monthRadio.Checked = false;
            allSchedule.Checked = false;
            selection.Checked = false;
            date1.Visible = false;
            date2.Visible = false;
            arrow.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            string searchText = SearchBar1.Text;
            if (string.IsNullOrWhiteSpace(searchText))
            {
                radioToday.Checked = true;
                loadAppointment(DateTime.Today, "");
            }
            else
            {
                var filteredAppointments = patientAppointments
                    .Where(pa => pa.Operation.OperationName.StartsWith(searchText, StringComparison.OrdinalIgnoreCase) ||
                                 pa.Operation.OperationCode.StartsWith(searchText, StringComparison.OrdinalIgnoreCase) ||
                                 pa.Patient.Lastname.StartsWith(searchText, StringComparison.OrdinalIgnoreCase) ||
                                 pa.Patient.Firstname.StartsWith(searchText, StringComparison.OrdinalIgnoreCase) ||
                                 pa.Patient.Patientid.ToString().EndsWith(searchText, StringComparison.OrdinalIgnoreCase) ||
                                 pa.AppointmentDetailNo.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                displaySchedules(filteredAppointments, "");
            }
        }
        private void AllAppointments_Load(object sender, EventArgs e)
        {
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dataGrid.RowTemplate.Height = 70;
            dataGrid.Columns[0].Width = 100;
        }

        private void DoctorAppointmentForm_SizeChanged(object sender, EventArgs e)
        {
            guna2Panel1.Invalidate();
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            if (date1.Value.Date <= date2.Value.Date)
                pickDate();
        }

        private void date2_ValueChanged_1(object sender, EventArgs e)
        {
            if (date1.Value.Date <= date2.Value.Date)
                pickDate();
        }
    }
}
