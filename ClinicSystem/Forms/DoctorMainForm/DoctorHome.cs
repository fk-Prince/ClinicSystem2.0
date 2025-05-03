using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.WebControls;
using System.Data;

namespace ClinicSystem
{
    public partial class DoctorHome : Form
    {
        private Doctor dr;
        private List<Operation> operations = new List<Operation>();
        private OperationRepository db = new OperationRepository();
        private DataTable dt;
        public DoctorHome(Doctor dr)
        {
            this.dr = dr;
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Operation Code", typeof(string));
            dt.Columns.Add("Operation Name", typeof(string));
            dataGrid.DataSource = dt;

            //logo_img.Parent = panel1;
            //logo_img.BackColor = Color.Transparent;
            //logo_img.SizeMode = PictureBoxSizeMode.StretchImage;

            //lblDentC.Parent = panel1;
            //lblQC.Parent = panel1;
            //lblDentC.BackColor = Color.Transparent;
            //lblQC.BackColor = Color.Transparent;
            //lblDentC.BringToFront();
            //lblQC.BringToFront();


            drImage.Image = (dr.Image == null) ? Properties.Resources.doctoruser : dr.Image;
            DoctorID.Text = dr.DoctorID.ToString();
            DoctorFullName.Text += dr.DoctorFirstName + "  " + dr.DoctorMiddleName + "  " + dr.DoctorLastName;
            Age.Text = dr.DoctorAge.ToString();
            Address.Text = dr.DoctorAddress;
            Gender.Text = dr.Gender;
            dateHired.Text = dr.DateHired.ToString("yyyy-MM-dd");
            operations = db.getOperationByDoctor(dr.DoctorID);

            if (dr.DoctorActive)
            {
                inactiveB.FillColor = Color.FromArgb(183, 230, 222);
                inactiveB.ForeColor = Color.FromArgb(34, 44, 54);

                activeB.FillColor = Color.FromArgb(111, 168, 166);
                activeB.ForeColor = Color.White;
            } else
            {
                activeB.FillColor = Color.FromArgb(183, 230, 222);
                activeB.ForeColor = Color.FromArgb(34, 44, 54);

                inactiveB.FillColor = Color.FromArgb(111, 168, 166);
                inactiveB.ForeColor = Color.White;

            }

            //drImage.BackColor = Color.Transparent;
            //drImage.SizeMode = PictureBoxSizeMode.StretchImage;

            foreach (Operation op in operations)
            {
                //specialized.Text += "Operation Code:  " + op.OperationCode + Environment.NewLine + "Operation Name:  " + op.OperationName + Environment.NewLine;
                //specialized.Text += "------------------------------------------------------------------" + Environment.NewLine;
                dt.Rows.Add(op.OperationCode, op.OperationName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult option = MessageBox.Show("Do you want to logout ?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                DoctorClinics doc = DoctorClinics.getInstance();
                doc.Hide();
                LoginUserForm form = new LoginUserForm();
                form.Show();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void infoDoctorPanel_Paint(object sender, PaintEventArgs e)
        {
            //using (LinearGradientBrush brush = new LinearGradientBrush(
            //    infoDoctorPanel.ClientRectangle,
            //    ColorTranslator.FromHtml("#B7E6DE"), 
            //    ColorTranslator.FromHtml("#E5F9F6"),
            //    90F))
            //{
            //    e.Graphics.FillRectangle(brush, infoDoctorPanel.ClientRectangle);
            //}
        }

        private void activeB_Click(object sender, EventArgs e)
        {
            inactiveB.FillColor = Color.FromArgb(183, 230, 222);
            inactiveB.ForeColor = Color.FromArgb(34,44,54);

            activeB.FillColor = Color.FromArgb(111, 168, 166);
            activeB.ForeColor = Color.White;

            string active = "Yes";
            db.updateDoctorStatus(dr.DoctorID, active);
        }

        private void inactiveB_Click(object sender, EventArgs e)
        {
            activeB.FillColor = Color.FromArgb(183, 230, 222);
            activeB.ForeColor = Color.FromArgb(34, 44, 54);

            inactiveB.FillColor = Color.FromArgb(111, 168, 166);
            inactiveB.ForeColor = Color.White;

            string active = "No";   
            db.updateDoctorStatus(dr.DoctorID, active);
        }        
    }
}
