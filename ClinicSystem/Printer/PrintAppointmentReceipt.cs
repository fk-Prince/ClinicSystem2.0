using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using System.Drawing.Printing;
using System.Security.Policy;
using ClinicSystem.PatientForm;
using ClinicSystem.Appointments;
using ClinicSystem.UserLoginForm;

namespace ClinicSystem
{
    public partial class PrintAppointmentReceipt : Form
    {
        private Image image = Properties.Resources.Logo;
        private List<Appointment> app;
        private Patient patient;

        private string fullname;
        private string dateAp = DateTime.Now.ToString("yyyy-MM-dd");
        private string timeAp = DateTime.Now.ToString("hh:mm:ss tt");


        private float x = 25;
        private float y = 430;
        private float rowHeight = 30f;
        private float col0 = 80f;
        private float col1 = 80f;
        private float col2 = 120f;
        private float col3 = 130f;
        private float col45 = 130f;
        private float col6 = 130f;
        private float defaultCol = 150f;

        private static int page = 1;
        private static int lastRead = 0;
        private string type;
        public PrintAppointmentReceipt(Patient patient, List<Appointment> app, string type)
        {
            InitializeComponent();
            this.app = app;
            this.type = type;
            this.patient = patient;


        }

        internal void print()
        {
            printPreviewDialog1.Document = printDocument;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();

            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}
        }

    

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (page == 1)
            {
                drawHeader(e);
            }
           
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font rowFont = new Font("Arial", 10);
            Brush brush = Brushes.Black;
  
            string[] headers = { "Appt.", "Room", "Operation", "Doctor", "   Start", "    End", "Amount" };
            string[] headers1 = { " No.", "  No.", "   Name", " Name", "   Time", "   Time", "" };
            if (page != 1)
            {
                x = 20;
                y = 100;
                rowHeight = 30f;
            }
            for (int i = 0; i < headers.Length; i++)
            {
                float colWidth;
                if (i == 0) colWidth = col0;
                else if (i == 1) colWidth = col1;
                else if (i == 2) colWidth = col2;
                else if (i == 3) colWidth = col3;
                else if (i == 4 || i == 5) colWidth = col45;
                else if (i == 6) colWidth = col6;
                else colWidth = defaultCol;

                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(183, 230, 222)), x, y, colWidth, rowHeight + 30);
                e.Graphics.DrawLine(Pens.Black, x, y, x + colWidth, y);
                e.Graphics.DrawLine(Pens.Black, x, y + (rowHeight + 30), x + colWidth, y + (rowHeight + 30));
               
                e.Graphics.DrawString(headers[i], headerFont, brush, x + 5, y + 5);
                e.Graphics.DrawString(headers1[i], headerFont, brush, x + 5, y + 35);
               
                x += colWidth;
            }
            y += rowHeight + 30; 

            int rows = 0;
            int maxRow = (page == 1) ? 9 : 13;

            if (app.Count > 8)  e.Graphics.DrawString($"Page {page}", new Font("Sans-serif", 9), Brushes.Black, 10, 1070);

            rowHeight += 30;
            for (int i = lastRead; i < app.Count(); i++)
            {
                Appointment a = app[i];
                x = 25;

                for (int col = 0; col < headers.Length; col++)
                {
                    float colWidth = columnWidth(col);
                    string data = columnData(col, a);


                    if (rows % 2 == 0) e.Graphics.FillRectangle(Brushes.White, x, y, colWidth, rowHeight);
                    else e.Graphics.FillRectangle(Brushes.LightGray, x, y, colWidth, rowHeight);

                    e.Graphics.DrawLine(Pens.Black, x, y, x + colWidth, y);
                    e.Graphics.DrawLine(Pens.Black, x, y + rowHeight, x + colWidth, y + rowHeight);

                    if (col == 4 || col == 5)
                    {
                        e.Graphics.DrawString(DateTime.Parse(data).ToString("yyyy-MM-dd"), rowFont, brush, x + 5, y + 10);
                        e.Graphics.DrawString(DateTime.Parse(data).ToString("hh:mm:ss tt"), rowFont, brush, x + 5, y + 30);
                    }
                    else
                    {
                        e.Graphics.DrawString(data, rowFont, brush, x + 5, y + 10);
                    }
                    x += colWidth;
                }

                rows++;
                y += rowHeight;

                if (rows == maxRow)
                {
                    e.HasMorePages = true;
                    lastRead = i + 1;
                    page++;
                    y = 100;
                    x = 20;
                    return;
                }
            }


            y += 100;
            drawTotal(e, y);
        }
       

        private void drawHeader(PrintPageEventArgs e)
        {
            fullname = Capitalized(patient.Firstname) + "  " + Capitalized(patient.Middlename) + "  " + Capitalized(patient.Lastname);
            e.Graphics.DrawImage(image, 20, 20, 140, 140);
            e.Graphics.DrawString("Quantum Care", new Font("Impact", 36, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline), Brushes.Black, 140, 25);
            e.Graphics.DrawString("506 J.P. Laurel Ave,", new Font("Sans-serif", 12, FontStyle.Regular), Brushes.Black, 145, 85);
            e.Graphics.DrawString("Poblacion District, Davao City", new Font("Sans-serif", 12, FontStyle.Regular), Brushes.Black, 145, 105);

            if (type.Equals("Add"))
            {
                e.Graphics.DrawString("Appointment", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 650, 60);
                e.Graphics.DrawString("Details", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 720, 95);
                e.Graphics.DrawString($"Date of Scheduling: {dateAp}", new Font("Sans-serif", 12), Brushes.Black, 30, 310);
                e.Graphics.DrawString($"Time of Scheduling: {timeAp}", new Font("Sans-serif", 12), Brushes.Black, 30, 340);
            } else if (type.Equals("Reappointment"))
            {
                e.Graphics.DrawString("Reschedule", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 660, 60);
                e.Graphics.DrawString("Appointment", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 650, 95);
                e.Graphics.DrawString("Details", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 720, 130);
                e.Graphics.DrawString($"Date of ReScheduling: {dateAp}", new Font("Sans-serif", 12), Brushes.Black, 30, 310);
                e.Graphics.DrawString($"Time of ReScheduling: {timeAp}", new Font("Sans-serif", 12), Brushes.Black, 30, 340);
            }


            e.Graphics.DrawString($"Patient Name: {fullname}", new Font("Sans-serif", 12, FontStyle.Bold), Brushes.Black, 30, 250);
            e.Graphics.DrawString($"Age: {patient.Age}", new Font("Sans-serif", 12), Brushes.Black, 30, 280);
      
        }

        private void drawTotal(PrintPageEventArgs e, float y)
        {
            if (type.Equals("Add", StringComparison.OrdinalIgnoreCase))
            {
                AppointmentRepository db = new AppointmentRepository();
                string type = app.FirstOrDefault()?.Discounttype ?? "";
                Discount d = db.getDiscountsbyType(type);

                Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
                Font font = new Font("Sans-serif", 14, FontStyle.Regular);
                string stotal = app.Sum(a => a.SubTotal).ToString("F2");
                SizeF size1 = graphics.MeasureString($"₱  {stotal}", font);
                e.Graphics.DrawString("Subtotal:", font, Brushes.Black, 410, y);
                e.Graphics.DrawString($"₱  {stotal}", font, Brushes.Black, 820 - size1.Width, y);

                y += 30;
                string discount = app.Sum(a => a.SubTotal * d.DiscountRate).ToString("F2");
                SizeF size2 = graphics.MeasureString($"₱  {discount}", font);
                e.Graphics.DrawString("Discounted:", font, Brushes.Black, 410, y);
                e.Graphics.DrawString($"₱  {discount}", font, Brushes.Black, 820 - size2.Width, y);

                y += 30;
                string total = app.Sum(a => a.SubTotal - (a.SubTotal * d.DiscountRate)).ToString("F2");
                Font tfont = new Font("Sans-serif", 14, FontStyle.Bold);
                SizeF size3 = graphics.MeasureString($"₱ {total}", tfont);
                e.Graphics.DrawString("Total Ammount:", tfont, Brushes.Black, 410, y);
                e.Graphics.DrawString($"₱ {total}", tfont, Brushes.Black, 820 - size3.Width, y);
            }
        }

        private float columnWidth(int col)
        {

            switch (col)
            {
                case 0: return col0;
                case 1: return col1;
                case 2: return col2;
                case 3: return col3;
                case 4: return col45;
                case 5: return col45;
                case 6: return col6;
                default: return defaultCol;
            }
        }

        private string columnData(int col, Appointment a)
        {

            switch (col)
            {
                case 0: return  "  " + a.AppointmentDetailNo.ToString();
                case 1: return " " + a.RoomNo.ToString();
                case 2: return a.Operation.OperationName;
                case 3: return a.Doctor.DoctorFirstName + " " + a.Doctor.DoctorLastName;
                case 4: return a.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt");
                case 5: return a.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt");
                case 6:
                    if (type.Equals("Add", StringComparison.OrdinalIgnoreCase)) return a.SubTotal.ToString("F2");
                    else  return a.Total.ToString("F2");
                    

                default: return "";
            }
        }

        private string Capitalized(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1);
        }

        private void previewClosed(object sender, FormClosingEventArgs e)
        {
            lastRead = 0;
            type = "";
        }

    }
}
