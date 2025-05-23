using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DoctorClinic;
using Guna.UI2.WinForms;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace ClinicSystem.Doctors
{
    public partial class ViewDoctor : Form
    {
        private List<Doctor> doctorList;
        private DoctorRepository doctorRepository = new DoctorRepository();
        public ViewDoctor(UserLoginForm.Staff staff)
        {
            InitializeComponent();

            doctorList = doctorRepository.getDoctors();
            string type = "";
            if (doctorList.Count == 0)
            {
                type = "Currently We Have No Doctors";
           
                SearchBar.Enabled = false;
                all.Enabled = false;
                active.Enabled = false;
                inactive.Enabled = false;
            }
            displayDoctors(doctorList, type);
          

        }
        public string Capitalize(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        private void displayDoctors(List<Doctor> doctorList, string type)
        {
            flowPanel.Controls.Clear();
            if (!string.IsNullOrWhiteSpace(type))
            {
                Label label = new Label();
                label.Text = $"{type}.";
                label.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                label.ForeColor = Color.Black;
                label.AutoSize = false;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;

                Panel panel = new Panel();
                panel.Size = new Size(flowPanel.Width, 500);
                panel.Controls.Add(label);
                flowPanel.Controls.Add(panel);
                return;
            }
            if (doctorList.Count > 0)
            {
                foreach (Doctor doctor in doctorList)
                {

                        Guna2Panel panel = new Guna2Panel();
                        panel.Size = new Size(300, 230);
                        panel.Location = new Point(50, 100);
                        panel.Margin = new Padding(20, 10, 10, 10);
                        panel.FillColor = Color.FromArgb(111, 168, 166);
                        panel.BackColor = Color.Transparent;
                        panel.BorderRadius = 30;
                        //panel.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 50, 50));

                        PictureBox picture = new PictureBox();
                        picture.Image = (doctor.Image == null) ? Properties.Resources.doctoruser : doctor.Image;
                        picture.Location = new Point(15, 10);
                        picture.Size = new Size(64, 64);
                        picture.SizeMode = PictureBoxSizeMode.Zoom;
                        picture.BackColor = Color.FromArgb(111, 168, 166);
                        panel.Controls.Add(picture);


                        Label label = createLabel("Doctor ID", doctor.DoctorID.ToString(), 10, 80);
                        panel.Controls.Add(label);

                        string fullname = Capitalize(doctor.DoctorFirstName) + "  " + Capitalize(doctor.DoctorMiddleName) + "  " + Capitalize(doctor.DoctorLastName);
                        label = createLabel("Doctor Name", fullname, 10, 100);
                        panel.Controls.Add(label);

                        label = createLabel(
                            "Age",
                            doctor.DoctorAge.ToString(),
                            10,
                            120
                        );
                        panel.Controls.Add(label);

                        label = createLabel("Gender", doctor.Gender, 10, 140);
                        panel.Controls.Add(label);

                        label = createLabel("Date-Hired", doctor.DateHired.ToString("yyyy-MM-dd"), 10, 160);
                        panel.Controls.Add(label);

                        label = createLabel("Address", doctor.DoctorAddress, 10, 180);
                        panel.Controls.Add(label);

                        label = createLabel("In Service", doctor.DoctorActive ? "Active" : "Inactive", 10, 200);
                        panel.Controls.Add(label);

                    flowPanel.Controls.Add(panel);
                    
                }
            }

        }
        public Label createLabel(string title, string value, int x, int y)
        {
            Label label = new Label();
            label.Text = $"{title}:   {value}";
            label.MaximumSize = new Size(280, 30);
            label.AutoSize = true;
            label.Location = new Point(x, y);
            label.BackColor = Color.FromArgb(111, 168, 166);
            label.Font = new Font("Segui UI", 10, FontStyle.Regular);
            return label;
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            searchDOctor();
        }

        private void searchDOctor()
        {
            timer1.Stop();
            timer1.Start();
        }

   
        private void all_CheckedChanged(object sender, EventArgs e)
        {
            searchDOctor();
        }

        private void active_CheckedChanged(object sender, EventArgs e)
        {
            searchDOctor();
        }

        private void inactive_CheckedChanged(object sender, EventArgs e)
        {
            searchDOctor();
        }

        private void ViewDoctor_Shown(object sender, EventArgs e)
        {
            string type = "";
            if (doctorList.Count == 0)
            {
                type = "Currently We Have No Doctors";

                SearchBar.Enabled = false;
                all.Enabled = false;
                active.Enabled = false;
                inactive.Enabled = false;
            }
            displayDoctors(doctorList, type);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dataGrid.Visible)
            {
                displayDoctorOperation(SearchBar.Text);
                return;
            }
           

            List<Doctor> filteredDoctor = new List<Doctor>(); 
            timer1.Stop();
            if (string.IsNullOrWhiteSpace(SearchBar.Text))
            {
                filteredDoctor = doctorList;
            }
            else
            {
                filteredDoctor = doctorList.Where(
                    doctor =>
                        doctor.DoctorFirstName.StartsWith(SearchBar.Text, StringComparison.OrdinalIgnoreCase) ||
                        doctor.DoctorLastName.StartsWith(SearchBar.Text, StringComparison.OrdinalIgnoreCase) ||
                        doctor.DoctorID.ToString().StartsWith(SearchBar.Text, StringComparison.OrdinalIgnoreCase) ||
                        doctor.DoctorID.ToString().EndsWith(SearchBar.Text, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            if (active.Checked)
            {
                filteredDoctor = filteredDoctor.Where(d => d.DoctorActive).ToList();
            }
            else if (inactive.Checked)
            {
                filteredDoctor = filteredDoctor.Where(d => !d.DoctorActive).ToList();
            }
            string type = filteredDoctor.Count < 1 ? "Doctor Not Found" : "";
            displayDoctors(filteredDoctor, type);
        }

        private DataTable table = new DataTable();
        private Dictionary<Doctor, Operation> docOp;
        private int y;
        private bool isViewOperation = false;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            docOp = doctorRepository.getDoctorOperations();
            if (string.IsNullOrWhiteSpace(SearchBar.Text.Trim()))
            {
                displayGrid(docOp);
            }
            else
            {
                displayDoctorOperation(SearchBar.Text.Trim());
            }
            a.Visible = true;
            dropdown.Start();
        }

        private void displayGrid(Dictionary<Doctor, Operation> filter)
        {
            table.Rows.Clear();
            foreach (var pair in filter)
            {
                Doctor doctor = pair.Key;
                Operation operation = pair.Value;
                table.Rows.Add(doctor.DoctorID,  "Dr. " + doctor.DoctorFirstName + " " + doctor.DoctorMiddleName + " " + doctor.DoctorLastName, operation.OperationCode, operation.OperationName);
            }
        }

        private void displayDoctorOperation(string doctorid)
        {
            timer1.Stop();
            Dictionary<Doctor, Operation> filter = new Dictionary<Doctor, Operation>();
            if (string.IsNullOrWhiteSpace(doctorid))
            {
                filter = docOp;
            }
            else
            {
                filter = docOp.Where(x =>
                          x.Key.DoctorFirstName.StartsWith(doctorid.Trim(), StringComparison.OrdinalIgnoreCase) ||
                          x.Key.DoctorLastName.StartsWith(doctorid.Trim(), StringComparison.OrdinalIgnoreCase) ||
                          x.Key.DoctorID.ToString().StartsWith(doctorid.Trim(), StringComparison.OrdinalIgnoreCase) ||
                          x.Key.DoctorID.ToString().EndsWith(doctorid.Trim(), StringComparison.OrdinalIgnoreCase)
                      ).ToDictionary(x => x.Key, x=> x.Value);

            }
  
            if (active.Checked)
            {
                filter = filter.Where(d => d.Key.DoctorActive).ToDictionary(x => x.Key, x => x.Value);
            }
            else if (inactive.Checked)
            {
                filter = filter.Where(d => !d.Key.DoctorActive).ToDictionary(x => x.Key, x => x.Value);
            }
            displayGrid(filter);
           
        }

        private void ViewDoctor_Load(object sender, EventArgs e)
        {
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#5CA8A3");
            dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            table.Columns.Add("Doctor ID", typeof(string));
            table.Columns.Add("Doctor Full Name", typeof(string));
            table.Columns.Add("Operation Code", typeof(string));
            table.Columns.Add("Operation Name", typeof(string));
            dataGrid.DataSource = table;

 
        }

        private void dropdown_Tick(object sender, EventArgs e)
        {
            if (!isViewOperation)
            {
                y += 50;
                if (y >= 0)
                {
                    dropdown.Stop();
                    a.Visible = true;
                    isViewOperation = !isViewOperation;
                    y = 0;
                }
                a.Location = new Point((ClientSize.Width - a.Size.Width) / 2, y);
            }
            else
            {
                y -= 50;
                if (y <= -a.Height)
                {
                    dropdown.Stop();
                    a.Visible = false;
                    isViewOperation = !isViewOperation;
                    y = -a.Height;
                }
                a.Location = new Point((ClientSize.Width - a.Size.Width) / 2, y);
            }
            a.BringToFront();
        }

        private void ViewDoctor_SizeChanged(object sender, EventArgs e)
        {
            a.Location = new Point((ClientSize.Width - a.Size.Width) / 2, -a.Size.Height);
            y = -a.Size.Height;
            a.BringToFront();
        }
    }
}
