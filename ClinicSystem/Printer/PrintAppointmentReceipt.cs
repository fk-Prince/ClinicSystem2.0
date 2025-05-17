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
using TheArtOfDevHtmlRenderer.Adapters;
using ClinicSystem.Repository;
using System.Diagnostics.Eventing.Reader;

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

        private int y = 430;
        private int x = 50;

        private static int page = 1;
        private static int lastRead = 0;
        private string type;

        private Appointment selected;
        public PrintAppointmentReceipt(Patient patient, List<Appointment> app, string type)
        {
            InitializeComponent();
            this.app = app;
            this.type = type;
            this.patient = patient;

            if (type.Equals("Penalty"))
            {
                selected = app[0];
            }
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
            Brush brush = Brushes.Black;
            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            Font mainFont = new Font("Sans-serif", 11);
            SizeF size1;
            int maxRow = (page == 1) ? 3 : 5;
            int rows = 0;
            for (int i = lastRead; i < app.Count; i++)
            {
                Appointment a = app[i];
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(223, 249, 245)), 30, y - 10, this.Width - 30, 40);
                e.Graphics.DrawString($"Appointment No.  {a.AppointmentDetailNo}", mainFont, Brushes.Black, x, y);
                size1 = graphics.MeasureString($"Subtotal Amount.  {a.SubTotal.ToString("F2")}", mainFont);
                e.Graphics.DrawString($"Subtotal Amount:  {a.SubTotal.ToString("F2")}", mainFont, Brushes.Black, 800 - size1.Width, y);
                e.Graphics.DrawRectangle(Pens.Black, 30, y - 10, this.Width - 30, 40);
                e.Graphics.DrawRectangle(Pens.Black, 30, y - 10, this.Width - 30, 170);
                e.Graphics.DrawString($"Doctor Name:  {a.Doctor.DoctorLastName}, {a.Doctor.DoctorFirstName} {a.Doctor.DoctorMiddleName}", mainFont, Brushes.Black, x, y + 50);
                e.Graphics.DrawString($"Operation Name:  {a.Operation.OperationName}", mainFont, Brushes.Black, x, y + 80);
                e.Graphics.DrawString($"Room No:  {a.RoomNo}", mainFont, Brushes.Black, x, y + 110);

                size1 = graphics.MeasureString("Start Appointment", mainFont);
                e.Graphics.DrawString($"Start Appointment", mainFont, Brushes.Black, 600 - size1.Width, y + 50);

                size1 = graphics.MeasureString($"{a.StartTime.ToString("yyyy-MM-dd")}", mainFont);
                e.Graphics.DrawString($"{a.StartTime.ToString("yyyy-MM-dd")}", mainFont, Brushes.Black, 580 - size1.Width, y + 70);

                size1 = graphics.MeasureString($"{a.StartTime.ToString("hh:mm:ss tt")}", mainFont);
                e.Graphics.DrawString($"{a.StartTime.ToString("hh:mm:ss tt")}", mainFont, Brushes.Black, 585 - size1.Width, y + 90);

                size1 = graphics.MeasureString("End Appointment", mainFont);
                e.Graphics.DrawString($"End Appointment", mainFont, Brushes.Black, 800 - size1.Width, y + 50);

                size1 = graphics.MeasureString($"{a.StartTime.ToString("yyyy-MM-dd")}", mainFont);
                e.Graphics.DrawString($"{a.EndTime.ToString("yyyy-MM-dd")}", mainFont, Brushes.Black, 780 - size1.Width, y + 70);

                size1 = graphics.MeasureString($"{a.StartTime.ToString("hh:mm:ss tt")}", mainFont);
                e.Graphics.DrawString($"{a.EndTime.ToString("hh:mm:ss tt")}", mainFont, Brushes.Black, 785 - size1.Width, y + 90);

                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 600, y + 70);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 610, y + 70);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 620, y + 70);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 630, y + 70);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 640, y + 70);
                e.Graphics.DrawString("o", new Font("Sans-serif", 9), Brushes.Black, 650, y + 70);

                rows++;
                y += 150;
                if (i == app.Count - 1)
                {
                    drawTotal(e, y + 70);
                }

                if (rows == maxRow)
                {
                    if (i + 1 < app.Count)
                    {
                        e.Graphics.DrawString($"Page {page}", new Font("Sans-serif", 9), Brushes.Black, 10, 1070);
                        e.HasMorePages = true;
                        lastRead = i + 1;
                        page++;
                        y = 100;
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
            //drawTotal(e, y + 70);  
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

            }
            else if (type.Equals("Reappointment") || type.Equals("Penalty"))
            {
                e.Graphics.DrawString("Reschedule", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 660, 60);
                e.Graphics.DrawString("Appointment", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 650, 95);
                e.Graphics.DrawString("Details", new Font("Impact", 20, FontStyle.Bold), Brushes.Black, 720, 130);
            }
            e.Graphics.DrawString("Note* if you missed your appointment you have 1 week graceful period " +
                "to aquire a new appointment but a 15% penalty will be applied of your total amount.", new Font("Sans-serif", 08), Brushes.Black, 30, y - 30);

            e.Graphics.DrawString($"Date Issued: {dateAp}", new Font("Sans-serif", 12), Brushes.Black, 30, 310);
            e.Graphics.DrawString($"Time Issued: {timeAp}", new Font("Sans-serif", 12), Brushes.Black, 30, 340);

            e.Graphics.DrawString($"Patient Name: {fullname}", new Font("Sans-serif", 12, FontStyle.Bold), Brushes.Black, 30, 250);
            e.Graphics.DrawString($"Age: {patient.Age}", new Font("Sans-serif", 12), Brushes.Black, 30, 280);

        }

        private void drawTotal(PrintPageEventArgs e, float y)
        {
            DiscountRepository discountRepotisory = new DiscountRepository();
            string discountType = app.FirstOrDefault().Discounttype;
            Discount d = discountRepotisory.getDiscountsbyType(discountType);

            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            Font font = new Font("Sans-serif", 14, FontStyle.Regular);

           
            y += 30;
            if (type.Equals("Penalty"))
            {

                SizeF size2 = graphics.MeasureString($"₱  {selected.PenaltyAppointment.PenaltyAmount.ToString("F2")}", font);
                e.Graphics.DrawString("Penalty Fee:", font, Brushes.Black, 410, y);
                e.Graphics.DrawString($"₱  {selected.PenaltyAppointment.PenaltyAmount.ToString("F2")}", font, Brushes.Black, 820 - size2.Width, y);   
            } 
            else if (type.Equals("Add"))
            {
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
                y += 30;
                Font tfont = new Font("Sans-serif", 14, FontStyle.Bold);
                SizeF size3 = graphics.MeasureString($"₱ {total}", tfont);
                e.Graphics.DrawString("Total Ammount:", tfont, Brushes.Black, 410, y);
                e.Graphics.DrawString($"₱ {total}", tfont, Brushes.Black, 820 - size3.Width, y);

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
