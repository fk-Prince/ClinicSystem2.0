using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.WebControls;
using System.Data;
using Guna.UI2.WinForms;
using DoctorClinic;

namespace ClinicSystem
{
    public partial class DoctorHome : Form
    {
        private DoctorRepository doctorRepository = new DoctorRepository();
        private OperationRepository operationRepositroy = new OperationRepository();

        private DataTable dt;   
        private Doctor dr;
        private List<Operation> operations = new List<Operation>();

        //UTILITY
        private Guna2Panel slidePanel;
        private int maxIndex = -1;
        private int currentIndex = 0;
        private int x = 0;
        private int totalLeft = 0;
        private int totalRight = 0;
        public DoctorHome(Doctor dr)
        {
            this.dr = dr;
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Operation Code", typeof(string));
            dt.Columns.Add("Operation Name", typeof(string));
            dataGrid.DataSource = dt;

            displayTodayAppointment();
            
            drImage.Image = (dr.Image == null) ? Properties.Resources.doctoruser : dr.Image;
            DoctorID.Text = dr.DoctorID.ToString();
            DoctorFullName.Text += dr.DoctorFirstName + "  " + dr.DoctorMiddleName + "  " + dr.DoctorLastName;
            Age.Text = dr.DoctorAge.ToString();
            Address.Text = dr.DoctorAddress;
            Gender.Text = dr.Gender;
            dateHired.Text = dr.DateHired.ToString("yyyy-MM-dd");
            operations = operationRepositroy.getOperationByDoctor(dr.DoctorID);

            if (dr.DoctorActive)
            {
                inactiveB.FillColor = Color.FromArgb(183, 230, 222);
                inactiveB.ForeColor = Color.FromArgb(34, 44, 54);
                inactiveB.BorderThickness = 0;
                activeB.FillColor = Color.FromArgb(111, 168, 166);
                activeB.ForeColor = Color.White;
            } else
            {
                activeB.FillColor = Color.FromArgb(183, 230, 222);
                activeB.ForeColor = Color.FromArgb(34, 44, 54);
                activeB.BorderThickness = 0;
                inactiveB.FillColor = Color.FromArgb(111, 168, 166);
                inactiveB.ForeColor = Color.White;

            }

            foreach (Operation op in operations)
            { 
                dt.Rows.Add(op.OperationCode, op.OperationName);
            }
        }

        private void displayTodayAppointment()
        {
            List<Appointment> appList = new DoctorRepository().getTodayAppointmentByDoctor(dr.DoctorID);
            slidePanel = new Guna2Panel();
            int width = 360;
            int subpanelx = 0;
            if (appList.Count == 1)
            {
                next.Visible = false;
            }
            if (appList.Count > 0)
            {
                for (int i = 0; i < appList.Count; i++)
                {
                    Appointment a = appList[i];
                    Guna2Panel panel = new Guna2Panel();
                    panel.BackColor = Color.Transparent;
                    panel.BorderRadius = 10;
                    panel.BorderColor = Color.FromArgb(34, 44, 54);
                    panel.BorderThickness = 1;
                    panel.Size = new Size(360, 243);
                    panel.FillColor = Color.White;
                    panel.Location = new Point(subpanelx, 0);

                    Guna2HtmlLabel label = new Guna2HtmlLabel();
                    label.Text = $"Appointment Timeline";
                    label.AutoSize = true;
                    label.Location = new Point(20, 10);
                    label.Font = new Font("Segoe UI", 15, FontStyle.Regular);
                    panel.Controls.Add(label);

                    label = myLabel(panel.Width - 75, 20, $"No. {a.AppointmentDetailNo}");
                    panel.Controls.Add(label);

                    Guna2Panel p1 = new Guna2Panel();
                    p1.Size = new Size(320, 2);
                    p1.BackColor = Color.LightGray;
                    p1.Location = new Point(20, 50);
                    panel.Controls.Add(p1);

                    PictureBox picture = new PictureBox();
                    picture.Size = new Size(40, 40);
                    picture.Image = (a.Doctor.Image == null) ? Properties.Resources.doctoruser : a.Doctor.Image;
                    picture.Location = new Point(20, 60);
                    picture.SizeMode = PictureBoxSizeMode.Zoom;
                    panel.Controls.Add(picture);


                    label = myLabel(70, 65, $"Dr. {a.Doctor.DoctorFirstName} {a.Doctor.DoctorMiddleName} {a.Doctor.DoctorLastName}");
                    label.Font = new Font("Segui UI", 15);
                    panel.Controls.Add(label);

                    label = myLabel(50, 100, $"{a.StartTime.ToString("hh:mm:ss tt")}  ");
                    label.Font = new Font("Segui UI", 13);
                    panel.Controls.Add(label);

                    label = myLabel(85, 125, "o");
                    panel.Controls.Add(label);

                    label = myLabel(85, 135, "o");
                    panel.Controls.Add(label);

                    label = myLabel(85, 145, "o");
                    panel.Controls.Add(label);

                    label = myLabel(150, 140, $"Patient Name: {a.Patient.Firstname} {a.Patient.Middlename} {a.Patient.Lastname}");
                    panel.Controls.Add(label);

                    label = myLabel(150, 160, $"Operation Name: {a.Operation.OperationName}");
                    panel.Controls.Add(label);

                    label = myLabel(85, 155, "o");
                    panel.Controls.Add(label);

                    label = myLabel(85, 165, "o");
                    panel.Controls.Add(label);

                    label = myLabel(85, 175, "o");
                    panel.Controls.Add(label);

                    label = myLabel(50, 200, $"{a.EndTime.ToString("hh:mm:ss tt")}");
                    label.Font = new Font("Segui UI", 13);
                    panel.Controls.Add(label);

                    slidePanel.Size = new Size(width += 360, 243);
                    slidePanel.Controls.Add(panel);
                    subpanelx += panel.Width;
                    maxIndex++;
                }
            }
            else
            {
                Guna2Panel panel = new Guna2Panel();
                panel.BackColor = Color.Transparent;
                panel.BorderRadius = 10;
                panel.BorderColor = Color.FromArgb(34, 44, 54);
                panel.BorderThickness = 1;
                panel.Size = new Size(360, 243);
                panel.FillColor = Color.White;
                panel.Location = new Point(subpanelx, 0);
                Guna2HtmlLabel label = myLabel(70, 115, $"You have no appointment today.");
                label.Font = new Font("Segoe UI", 12);
                panel.Controls.Add(label);
                slidePanel.Size = new Size(360, 243);
                slidePanel.Controls.Add(panel);

                back.Visible = false;
                next.Visible = false;
            }
            apPanel.Controls.Add(slidePanel);
            back.Visible = false;
        }

        private Guna2HtmlLabel myLabel(int x, int y, string msg)
        {
            Guna2HtmlLabel label = new Guna2HtmlLabel();
            label.Text = msg;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            return label;
        }


        private void activeB_Click(object sender, EventArgs e)
        {
            inactiveB.FillColor = Color.FromArgb(183, 230, 222);
            inactiveB.ForeColor = Color.FromArgb(34,44,54);

            activeB.FillColor = Color.FromArgb(111, 168, 166);
            activeB.ForeColor = Color.White;

            string active = "Yes";
            doctorRepository.updateDoctorStatus(dr.DoctorID, active);
        }

        private void inactiveB_Click(object sender, EventArgs e)
        {
            activeB.FillColor = Color.FromArgb(183, 230, 222);
            activeB.ForeColor = Color.FromArgb(34, 44, 54);

            inactiveB.FillColor = Color.FromArgb(111, 168, 166);
            inactiveB.ForeColor = Color.White;

            string active = "No";   
            doctorRepository.updateDoctorStatus(dr.DoctorID, active);
        }

        private void DoctorHome_Load(object sender, EventArgs e)
        {
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void infoDoctorPanel_SizeChanged(object sender, EventArgs e)
        {
            if (ClientSize.Width > 1500)
            {
                todayAppP.Location = new Point(dataGrid.Left + 20, dataGrid.Location.Y + 100);
                todayAppP.Visible = true;
            } else
            {
                //todayAppP.Location = new Point(dataGrid.Bottom + 20, (dataGrid.Location.Y + dataGrid.Height) + 20);
                todayAppP.Visible = false;
            }
            dataGrid.Invalidate();
            todayAppP.Invalidate();
        }

        private void back_Click(object sender, EventArgs e)
        {
            prevSlide.Start();
        }

        private void next_Click(object sender, EventArgs e)
        {
            nextSlide.Start();
        }

        private void prevSlide_Tick(object sender, EventArgs e)
        {
            back.Enabled = false;
            next.Enabled = false;
            x += 20;
            totalRight += 20;
            if (totalRight >= 360)
            {
                back.Enabled = true;
                next.Enabled = true;
                currentIndex--;
                totalRight = 0;
                prevSlide.Stop();
                next.Visible = true;
                if (currentIndex == 0)
                {
                    back.Visible = false;
                }
            }
            slidePanel.Location = new Point(x, slidePanel.Location.Y);
        }

        private void nextSlide_Tick(object sender, EventArgs e)
        {
            back.Enabled = false;
            next.Enabled = false;

            x -= 20;
            totalLeft += 20;
            if (totalLeft >= 360)
            {
                back.Enabled = true;
                next.Enabled = true;

                back.Visible = true;
                currentIndex++;
                totalLeft = 0;
                nextSlide.Stop();
                if (currentIndex == maxIndex)
                {
                    next.Visible = false;
                }
            }
            slidePanel.Location = new Point(x, slidePanel.Location.Y);
        }
    }
}
