using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Image = System.Drawing.Image;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.PatientForm;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Google.Protobuf.WellKnownTypes;
using TheArtOfDevHtmlRenderer.Adapters;
using static Guna.UI2.Native.WinApi;

namespace ClinicSystem.DoctorClinic
{
    public partial class PrintDoctorReceipt : Form
    {
        private Image image = Properties.Resources.Logo;
        private List<Appointment> app;
        private Patient patient;

        private string patientFullName;
        private string doctorFullName;
        private Patient selectedPatient;
        private Doctor selectedDoctor;

        private int page = 1;
        private static int lastRead = 0;
        private int y = 370;
        private int x = 50;

        private int newLine = 100;
        private string type;
        private string fullname;
        public PrintDoctorReceipt(Doctor dr, List<Appointment> app, string type)
        {
            InitializeComponent();
            this.type = type;
            foreach (Appointment a in app)
            {
                selectedPatient = a.Patient;
                selectedDoctor = dr;
                patientFullName = Capitalized(a.Patient.Firstname) + "  " + Capitalized(a.Patient.Middlename) + "  " + Capitalized(a.Patient.Lastname);
                fullname = Capitalized(selectedDoctor.DoctorFirstName) + "  " + Capitalized(selectedDoctor.DoctorMiddleName) + "  " + Capitalized(selectedDoctor.DoctorLastName);
                doctorFullName = fullname;
                break;
            }
            this.app = app;

        }

        private string Capitalized(string name)
        {
            return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        }

        internal void print()
        {
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (page == 1)
            {
                drawHeader(e);
            }
            Brush brush = Brushes.Black;
            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            Font mainFont = new Font("Sans-serif", 11);
            SizeF size1;
            int maxRow = (page == 1) ? 2 : 3;
            int rows = 0;
            StringBuilder sb;
            for (int i = lastRead; i < app.Count; i++)
            {
                Appointment a = app[i];
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(223, 249, 245)), 30, y - 10, this.Width - 30, 40);
                e.Graphics.DrawString("Status: " + a.Status, mainFont, Brushes.Black, 620, y);
                e.Graphics.DrawString($"Appointment No.  {a.AppointmentDetailNo}", mainFont, Brushes.Black, x, y);
                e.Graphics.DrawRectangle(Pens.Black, 30, y - 10, this.Width - 30, 40);
                e.Graphics.DrawRectangle(Pens.Black, 30, y - 10, this.Width - 30, 350);
                e.Graphics.DrawString($"Operation Name:  {a.Operation.OperationName}", mainFont, Brushes.Black, x, y + 50);
                e.Graphics.DrawString($"Doctor Name:  {fullname}", mainFont, Brushes.Black, x, y + 80);


                sb = checkDiagnosisLength(a.Diagnosis);
                e.Graphics.DrawLine(Pens.Black, 60, y + 120, this.Width - 60, y + 120);
                e.Graphics.DrawString($"Doctor Diagnosis:", mainFont, Brushes.Black, x, y + 130);
                e.Graphics.DrawString(sb.ToString(), new Font("Arial", 11), brush, x + 10, y + 155);

                e.Graphics.DrawLine(Pens.Black, 60, y + 220, this.Width - 60, y + 220);
                sb = checkDiagnosisLength(a.Prescription);
                e.Graphics.DrawString($"Doctor Prescription:", mainFont, Brushes.Black, x, y + 230);
                e.Graphics.DrawString(sb.ToString(), new Font("Arial", 11), brush, x + 10, y + 255);
                e.Graphics.DrawLine(Pens.Black, 60, y + 330, this.Width - 60, y + 330);

                size1 = graphics.MeasureString("Start Appointment:", mainFont);
                e.Graphics.DrawString($"Start Appointment", mainFont, Brushes.Black, 600 - size1.Width, y + 40);

                size1 = graphics.MeasureString($"{a.StartTime.ToString("yyyy-MM-dd")}", mainFont);
                e.Graphics.DrawString($"{a.StartTime.ToString("yyyy-MM-dd")}", mainFont, Brushes.Black, 580 - size1.Width, y + 60);

                size1 = graphics.MeasureString($"{a.StartTime.ToString("hh:mm:ss tt")}", mainFont);
                e.Graphics.DrawString($"{a.StartTime.ToString("hh:mm:ss tt")}", mainFont, Brushes.Black, 585 - size1.Width, y + 80);

                size1 = graphics.MeasureString("End Appointment", mainFont);
                e.Graphics.DrawString($"End Appointment", mainFont, Brushes.Black, 800 - size1.Width, y + 40);

                size1 = graphics.MeasureString($"{a.StartTime.ToString("yyyy-MM-dd")}", mainFont);
                e.Graphics.DrawString($"{a.EndTime.ToString("yyyy-MM-dd")}", mainFont, Brushes.Black, 780 - size1.Width, y + 60);

                size1 = graphics.MeasureString($"{a.StartTime.ToString("hh:mm:ss tt")}", mainFont);
                e.Graphics.DrawString($"{a.EndTime.ToString("hh:mm:ss tt")}", mainFont, Brushes.Black, 785 - size1.Width, y + 80);

                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 600, y + 60);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 610, y + 60);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 620, y + 60);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 630, y + 60);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 640, y + 60);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 650, y + 60);

                rows++;
                y += 350;

                if (rows == maxRow)
                {
                    if (i + 1 < app.Count)
                    {
                        e.Graphics.DrawString($"Page {page}", new Font("Sans-serif", 9), Brushes.Black, 10, 1070);
                        e.HasMorePages = true;
                        lastRead = i + 1;
                        page++;
                        y = 20;
                        x = 40;
                    }
                    else
                    {
                        if (page != 1)
                        {
                            e.Graphics.DrawString($"Page {page}", new Font("Sans-serif", 9), Brushes.Black, 10, 1070);
                        }
                        e.HasMorePages = false;
                    }

                    return;

                }



            }
        }


        private StringBuilder checkDiagnosisLength(string diagnosis)
        {
            StringBuilder sb = new StringBuilder();
            int textIndex = 0;
            for (int i = 0; i < diagnosis.Length; i++)
            {

                sb.Append(diagnosis[i]);
                textIndex++;

                if (textIndex == newLine)
                {
                    sb.Append(Environment.NewLine);
                    textIndex = 0;
                }
            }
            return sb;
        }

        private void drawHeader(PrintPageEventArgs e)
        {

            e.Graphics.DrawImage(image, 20, 20, 140, 140);
            e.Graphics.DrawString("Quantum Care", new Font("Impact", 36, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline), Brushes.Black, 140, 25);
            e.Graphics.DrawString("506 J.P. Laurel Ave,", new Font("Sans-serif", 12, FontStyle.Regular), Brushes.Black, 145, 85);
            e.Graphics.DrawString("Poblacion District, Davao City", new Font("Sans-serif", 12, FontStyle.Regular), Brushes.Black, 145, 105);

            if (type.Equals("Discharged", StringComparison.OrdinalIgnoreCase))
            {
                e.Graphics.DrawString("Discharged", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 685, 60);
                e.Graphics.DrawString("Slip", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 720, 95);
            }
            else
            {
                e.Graphics.DrawString("Diagnosis", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 685, 60);
                e.Graphics.DrawString("Details", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 720, 95);
            }

            e.Graphics.DrawString($"Patient Name  : {patientFullName}", new Font("Sans-serif", 12, FontStyle.Bold), Brushes.Black, 30, 210);
            e.Graphics.DrawString($"Age  : {selectedPatient.Age}", new Font("Sans-serif", 12), Brushes.Black, 30, 230);
            e.Graphics.DrawString($"Gender  : {selectedPatient.Gender}", new Font("Sans-serif", 12), Brushes.Black, 30, 250);
            e.Graphics.DrawString($"Contact No.  : {selectedPatient.ContactNumber}", new Font("Sans-serif", 12), Brushes.Black, 30, 270);

            e.Graphics.DrawString($"Attending Doctor  : {doctorFullName}", new Font("Sans-serif", 12, FontStyle.Bold), Brushes.Black, 30, 300);
            e.Graphics.DrawString($"Dr. Contact No.  : {selectedDoctor.DoctorContactNumber}", new Font("Sans-serif", 12), Brushes.Black, 30, 320);
        }

        private void printPreviewClosed(object sender, FormClosedEventArgs e)
        {
            lastRead = 0;
        }
    }
}
