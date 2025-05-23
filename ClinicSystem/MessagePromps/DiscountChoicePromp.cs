    
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ClinicSystem.Appointments;
using ClinicSystem.MainClinic;
using ClinicSystem.PatientForm;
using ClinicSystem.Repository;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace ClinicSystem.UserLoginForm
{
    public class DiscountChoicePromp : Panel
    {
        private static DiscountChoicePromp instance;
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private DiscountRepository discountRepository = new DiscountRepository();
        private ClinicRepository clinicRepository = new ClinicRepository();
        private List<Appointment> appList;
        private List<Discount> discount;
        private Discount selectedDiscount = null;

        private TextBox totalAfterDiscount;
        private TextBox tbRate;
        private Action<bool, List<Appointment>> co;
        private Patient patient;
        private Form form;

        private int previousindex = 0;
        private int staffid;
        private string type;
        private DiscountChoicePromp(Form form, string type, Patient patient,  List<Appointment> appList, int staffid)
        {
            this.form = form;
            this.appList = appList;
            this.type = type;
            this.staffid = staffid;
            this.patient = patient;
            discount = discountRepository.getDiscounts();
            Size = new Size(400,400);
            BackColor = Color.FromArgb(111, 168, 166);
            BorderStyle = BorderStyle.FixedSingle;

            loadComponents(form);
        }
        private void selected(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo.SelectedIndex == -1) return;

            if (combo.SelectedItem.ToString().Equals("Senior Citizen", StringComparison.OrdinalIgnoreCase) && patient.Age < 65)
            {
                MessagePromp.ShowCenter(form, "This Patient is not eligible for this \ntype of discount age must be above 65", MessageBoxIcon.Error);
                combo.SelectedIndex = previousindex;
                return;
            }

            selectedDiscount = discount.FirstOrDefault(d => d.Discounttype == combo.SelectedItem.ToString());
            previousindex = combo.SelectedIndex;
            if (selectedDiscount == null) return;
            tbRate.Text = (selectedDiscount.DiscountRate * 100).ToString() + " %";
            totalAfterDiscount.Text = appList.Sum(app => app.SubTotal - (app.SubTotal * selectedDiscount.DiscountRate)).ToString("F2");

        }
       
        private void confirm(object sender, EventArgs e)
        {
           

            List<Appointment> newApp = new List<Appointment>() ;
           
                foreach (Appointment app in appList)
                {
                    double total = app.SubTotal - (app.SubTotal * selectedDiscount.DiscountRate);
                    newApp.Add(new Appointment(
                         app.Patient, app.Doctor, app.Operation,
                         app.StartTime, app.EndTime,
                         app.SubTotal, app.RoomNo, app.AppointmentDetailNo,
                         total, selectedDiscount.Discounttype,
                         "", DateTime.Now, "Upcoming",app.Prescription));
                }  
                appointmentRepository.insertAppointment(staffid,patient,newApp,type);
                co?.Invoke(true, newApp);
            


            newApp.Clear();
            instance.Dispose();
            instance = null;
        }

     
        private void mouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.Black;
        }

        private void mouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.Red;
        }

        private void clicked(object sender, EventArgs e)
        {
            instance.Dispose();
            instance = null;
        }

        public static void showChoices(Form f,string type, Patient patient, int staffid, List<Appointment> appList, Action<bool, List<Appointment>> confirmation)
        {
           
            if (instance != null && f.Controls.Contains(instance))
            {
                f.Controls.Remove(instance);
                instance.Dispose();
            }


            instance = new DiscountChoicePromp(f, type, patient, appList, staffid);
            instance.co = confirmation;
            
            instance.Location = new Point((f.Width - 400) /2, (f.Height - 400) / 2);
            f.Controls.Add(instance);
            instance.BringToFront();
        }

        public static void closePanel()
        {
            if (instance != null)
            {
                instance.Dispose();
                instance = null;
            }
        }
        ComboBox discountType;
        public void loadComponents(Form f)
        {
            Label label = new Label();
            label.Text = "X";
            label.Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold);
            label.ForeColor = Color.Black;
            label.Cursor = Cursors.Hand;
            label.AutoSize = true;
            label.Location = new Point(380, -3);
            label.Click += clicked;
            label.MouseEnter += mouseEnter;
            label.MouseLeave += mouseLeave;
            Controls.Add(label);


            Label title = new Label();
            title.Text = $"Discount Eligible";
            title.AutoSize = true;
            title.Font = new Font("Arial", 20, FontStyle.Bold);
            title.ForeColor = Color.White;
            title.Location = new Point(85, 20);
            Controls.Add(title);

            Label discountTypeLabel = new Label();
            discountTypeLabel.Text = $"Discount Type";
            discountTypeLabel.AutoSize = true;
            discountTypeLabel.Font = new Font("Arial", 10);
            discountTypeLabel.ForeColor = Color.White;
            discountTypeLabel.Location = new Point(45, 90);
            Controls.Add(discountTypeLabel);

            tbRate = new TextBox();
            tbRate.Text = "0 %";
            tbRate.ReadOnly = true;
            tbRate.Size = new Size(40, 40);
            tbRate.Location = new Point(310, 110);
            Controls.Add(tbRate); 

            discountType = new ComboBox();
            discountType.DropDownStyle = ComboBoxStyle.DropDownList;
   
            if (discount.Count == 0)
            {
                DialogResult res = MessageBox.Show("Do you want to register a No Discount to continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    appointmentRepository.setDiscount();
                    selectedDiscount = discount.FirstOrDefault(d => d.Discounttype == discountType.SelectedItem.ToString());
                    discountType.SelectedItem = "No Discount"; 
                }
                else
                {
                    return;
                }
            }
            

            discount = discountRepository.getDiscounts();
            foreach (Discount disc in discount)
            {
                discountType.Items.Add(disc.Discounttype);
            }
            discountType.SelectedItem = "No Discount";
            selectedDiscount = discount.FirstOrDefault(d => d.Discounttype == discountType.SelectedItem.ToString());
            previousindex = discountType.SelectedIndex;
          
            discountType.SelectedIndexChanged += selected;
            discountType.Size = new Size(250, 40);
            discountType.Location = new Point(50, 110);
            Controls.Add(discountType);

        

            Label subTotalLabel = new Label();
            subTotalLabel.Text = $"Subtotal";
            subTotalLabel.AutoSize = true;
            subTotalLabel.Font = new Font("Arial", 10);
            subTotalLabel.ForeColor = Color.White;
            subTotalLabel.Location = new Point(45, 160);
            Controls.Add(subTotalLabel);

            TextBox subTotalValue = new TextBox();
            subTotalValue.Text = appList.Sum(app => app.SubTotal).ToString("F2");
            subTotalValue.ReadOnly = true;
            subTotalValue.Size = new Size(300, 40);
            subTotalValue.Location = new Point(50, 180);
            Controls.Add(subTotalValue);

            Label discountLabel = new Label();
            discountLabel.Text = $"Total incl Discount";
            discountLabel.AutoSize = true;
            discountLabel.Font = new Font("Arial", 10);
            discountLabel.ForeColor = Color.White;
            discountLabel.Location = new Point(45, 220);
            Controls.Add(discountLabel);

            totalAfterDiscount = new TextBox();
            totalAfterDiscount.ReadOnly = true;
            totalAfterDiscount.Text = appList.Sum(app => app.SubTotal).ToString("F2");
            totalAfterDiscount.Size = new Size(300, 40);
            totalAfterDiscount.Location = new Point(50, 240);
            Controls.Add(totalAfterDiscount);

            Button button = new Button();
            button.Text = "CONFIRM";
            button.Size = new Size(200, 50);
            button.BackColor = Color.FromArgb(233, 255, 252);
            button.ForeColor = Color.Black;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(100, 320);
            button.Click += confirm;
            Controls.Add(button);

            f.Controls.Add(this);
        }
    }

}
