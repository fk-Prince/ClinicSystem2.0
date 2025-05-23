using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using ClinicSystem.UserLoginForm;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace ClinicSystem
{
    public partial class OperationForm : Form
    { 
        private OperationRepository operationRepository = new OperationRepository();

        private List<Operation> operationlist;
        private bool isAddOperationShowing = false;
        private List<Control> tab = new List<Control>();
        private List<string> roomtype;
        public OperationForm()
        {
            InitializeComponent();
            operationlist = operationRepository.getOperationOnDoctors();
            roomtype = operationRepository.getAvailableRoomType();
            //foreach (string item in roomtype)
            //{
            //    comboRoomType.Items.Add(item);
            //}
 
            displayOperations(operationlist,"No Operation");
            int y = (ClientSize.Height - addOperationPanel.Height) / 2;
            if (ClientSize.Height < 1080)
            {
                y += 55;

            }
            addOperationPanel.Location = new Point(-addOperationPanel.Width, y);
            tab.Add(opCode);
            tab.Add(opName);
            tab.Add(opDuration);
            tab.Add(opPrice);
            tab.Add(comboRoomType);
            tab.Add(opDescription);
            tab.Add(guna2Button2);

            foreach (Control control in tab)
            {
                control.PreviewKeyDown += taab;
            }
        }




        private void displayOperations(List<Operation> operationlist, string type)
        {
            flowLayout.Controls.Clear();
            if (operationlist.Count > 0)
            {

                foreach (Operation operation in operationlist)
                {
                    Guna2Panel panel = new Guna2Panel();
                    panel.Size = new Size(300, 290);
                    panel.Location = new Point(50, 100);
                    panel.Margin = new Padding(20, 10, 10, 10);
                    panel.BackColor = Color.Transparent;
                    panel.FillColor = Color.FromArgb(111, 168, 166);
                    panel.BorderRadius = 20;


                    Label label = createLabel("Operation Code", operation.OperationCode, 10, 5);
                    panel.Controls.Add(label);

                    label = createLabel("Operation Name", operation.OperationName, 10, 25);
                    panel.Controls.Add(label);

                    label = createLabel(
                        "Date-Added",
                        operation.DateAdded.ToString("yyyy-MM-dd"),
                        10,
                        45
                    );
                    panel.Controls.Add(label);

                    label = createLabel("Price", operation.Price.ToString(), 10, 65);
                    panel.Controls.Add(label);

                    label = createLabel("Duration", operation.Duration.ToString(), 10, 85);
                    panel.Controls.Add(label);

                    label = createLabel("Room Type", operation.OperationRoomType, 10, 105);
                    panel.Controls.Add(label);

                    label = new Label();
                    label.Text = "Description";
                    label.MaximumSize = new Size(200, 0);
                    label.AutoSize = true;
                    label.Location = new Point(15, 125);
                    panel.Controls.Add(label);


                    Guna2TextBox tb = new Guna2TextBox();
                    tb.Multiline = true;
                    tb.Text = operation.Description;
                    tb.Location = new Point(15, 150);
                    tb.Size = new Size(270, 60);
                    tb.ReadOnly = true;
                    tb.ForeColor = Color.Black;
                    tb.BorderRadius = 5;
                    tb.BackColor = Color.Transparent;
                    tb.ScrollBars = ScrollBars.Vertical;
                    panel.Controls.Add(tb);

                    Panel panelLine = new Panel();
                    panelLine.Size = new Size(260, 1);
                    panelLine.BackColor = Color.Gray;
                    panelLine.Location = new Point(20, 215);
                    panel.Controls.Add(panelLine);

                    label = new Label();
                    label.Text = "Doctor Assigned";
                    label.MaximumSize = new Size(200, 0);
                    label.AutoSize = true;
                    label.Location = new Point(15, 225);
                    panel.Controls.Add(label);

                    Guna2Button b = new Guna2Button();
                    b.Image = Properties.Resources.add;
                    b.Tag = operation;
                    b.ImageSize = new Size(20, 20);
                    b.Location = new Point(260, 220);
                    b.Cursor = Cursors.Hand;
                    b.HoverState.FillColor = Color.Transparent;
                    b.Size = new Size(27, 27);
                    b.FillColor = Color.Transparent;
                    b.Click += OperationClicked;
                    b.BackColor = Color.Transparent;
                    panel.Controls.Add(b);

                    System.Windows.Forms.ComboBox combo = new System.Windows.Forms.ComboBox();
                    foreach (Doctor doctor in operation.Doctor)
                    {
                        string fullname = doctor.DoctorLastName + ", " + doctor.DoctorFirstName + " " + doctor.DoctorMiddleName;
                        combo.Items.Add(doctor.DoctorID + " | " + fullname);
                    }
                    if (operation.Doctor.Count == 0)
                    {
                        combo.Items.Add("No Doctor Assigned");
                    }
                    combo.ItemHeight = 20;
                    combo.Location = new Point(15, 250);
                    combo.DropDownStyle = ComboBoxStyle.DropDownList;
                    combo.Size = new Size(270, 38);
                    combo.MaxDropDownItems = 5;
                    combo.IntegralHeight = false;
                    panel.Controls.Add(combo);




                    flowLayout.Controls.Add(panel);
                }
            } else
            {
                Label label = new Label();
                label.Text = $"{type}.";
                label.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                label.ForeColor = Color.Black;
                label.AutoSize = false;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;

                Panel panel = new Panel();
                panel.Size = new Size(flowLayout.Width, 500);
                panel.Controls.Add(label);
                flowLayout.Controls.Add(panel);
            }

        }

        private void OperationClicked(object sender, EventArgs e)
        {
            Guna2Button b = sender as Guna2Button;
            Panel pa = b.Parent as Panel;
            Operation operation = b.Tag as Operation;
            operationCode = operation.OperationCode;
            List<Doctor> docList = operationRepository.getDoctorHaveNoOperation(operation);
            Guna2Panel p = new Guna2Panel();
            p.Size = new Size(280, 100);
            p.Location = new Point((pa.Width - p.Width) / 2, pa.Height - p.Height - 20);
            p.FillColor = Color.FromArgb(150, 210, 205);
            p.BackColor = Color.Transparent;
            p.BorderRadius = 10;
            p.BorderColor = Color.Black;
            p.BorderThickness = 2;
            pa.Controls.Add(p);
            p.BringToFront();

            Label label1 = new Label();
            label1.Text = "X";
            label1.Font = new Font("Segui UI", 12,FontStyle.Bold);
            label1.Cursor = Cursors.Hand;
            label1.Click += closePopup;
            label1.Location = new Point(255,3);
            p.Controls.Add(label1);

            Label label = new Label();
            label.Text = "Select Doctor";
            label.AutoSize = true;
            label.Location = new Point(10, 10);
            p.Controls.Add(label);

            ComboBox c = new ComboBox();
            docList.ForEach(dd => c.Items.Add($"{dd.DoctorID} | {dd.DoctorLastName},  {dd.DoctorFirstName} {dd.DoctorMiddleName}"));
            c.ItemHeight = 20;
            c.SelectedIndexChanged += selectedDoctor;
            c.Location = new Point(10, 30);
            c.DropDownStyle = ComboBoxStyle.DropDownList;
            c.Size = new Size(260, 38);
            c.MaxDropDownItems = 5;
            c.IntegralHeight = false;
            p.Controls.Add(c);

            but = new Guna2Button();
            but.BorderRadius = 10;
            but.Click += addDoctorOperation;
            but.FillColor = Color.FromArgb(233, 255, 252);
            but.BackColor = Color.Transparent;
            but.Size = new Size(260, 30);
            but.ForeColor = Color.Black;
            but.Text = "Assign";
            but.Location = new Point(10,65);
            p.Controls.Add(but);

            if (docList.Count == 0)
            {
                c.Items.Add("All Dr. has assigned to this operation!");
                c.SelectedIndex = 0;
                but.Enabled = false;
            }
        }

        private void closePopup(object sender, EventArgs e)
        {
            Label l = sender as Label;
            Guna2Panel p = l.Parent as Guna2Panel;
            p.Dispose();
        }

        private void selectedDoctor(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;
            if (c.SelectedIndex == -1) return;

            if (!c.SelectedItem.ToString().Equals("All Dr. has assigned to this operation!"))
            {
                string doctorid = c.SelectedItem.ToString().Split('|')[0].Trim();
                but.Tag = doctorid;
            } 
        }

        Guna2Button but;
        string operationCode;

        private void addDoctorOperation(object sender, EventArgs e)
        {

            if (but.Tag == null)
            {
                MessagePromp.ShowCenter(this, "No Selected Doctor", MessageBoxIcon.Error);
                return;
            }
            string docid = but.Tag as string;
            if (!string.IsNullOrWhiteSpace(docid))
            {
                operationRepository.setDoctorOperation(docid, operationCode);
                Guna2Panel p = but.Parent as Guna2Panel ;
                p.Dispose();
                operationlist = operationRepository.getOperationOnDoctors();
                displayOperations(operationlist, "No Operation");
                MessagePromp.ShowCenter(this, "Successfully assigned doctor to this operation", MessageBoxIcon.Information);
            } 
        }

        public Label createLabel(string title, string value, int x, int y)
        {
            Label label = new Label();
            label.Text = $"{title}:   {value}";
            label.MaximumSize = new Size(280, 30);
            label.AutoSize = true;
            label.Location = new Point(x, y);
            label.Font = new Font("Segui UI", 10, FontStyle.Regular);
            return label;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            load.Stop();
            load.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isAddOperationShowing)
            {
                return;
            }
            isAddOperationShowing = !isAddOperationShowing;
            timerin.Start();
            addOperationPanel.Visible = true;
            flowLayout.Visible = false;
            SearchBar1.Enabled = false;
            SearchBar1.Text = "";
        }

        private void opCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(opCode.Text))
            {
                string opCode = this.opCode.Text;
                bool op = operationlist.Any(operation => operation.OperationCode.Equals(opCode, StringComparison.OrdinalIgnoreCase));
                pictureCode.Image = op ? Properties.Resources.error : Properties.Resources.check;
            }
            else
            {
                pictureCode.Image = null;
            }
        }

        private void opName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(opName.Text))
            {
                string opName = this.opName.Text;
                bool op = operationlist.Any(operation => operation.OperationName.Equals(opName, StringComparison.OrdinalIgnoreCase));
                pictureName.Image = op ? Properties.Resources.error : Properties.Resources.check;
            }
            else
            {
                pictureName.Image = null;
            }
        }

        private void opDuration_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(opDuration.Text))
            {
                TimeSpan duration;
                bool op = TimeSpan.TryParseExact(opDuration.Text, @"hh\:mm\:ss", null, out duration);
                if (op)
                {
                    op = duration != TimeSpan.Zero;
                }
                pictureDuration.Image = op ? Properties.Resources.check : Properties.Resources.error;
            }
            else
            {
                pictureDuration.Image = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string opCode = this.opCode.Text.Trim();
            string opName = this.opName.Text.Trim();
            string opDescription = this.opDescription.Text.Trim();
            if (string.IsNullOrWhiteSpace(opCode)
                || string.IsNullOrWhiteSpace(opName)
                || string.IsNullOrWhiteSpace(opDescription)
                || string.IsNullOrWhiteSpace(opPrice.Text)
                || string.IsNullOrWhiteSpace(opDuration.Text))
            {
                MessagePromp.ShowCenter(this, "Please fill up all fields", MessageBoxIcon.Error);
                return;
            }

            bool duplicateCode = operationlist.Any(operation => operation.OperationCode.Equals(opCode, StringComparison.OrdinalIgnoreCase));
            if (duplicateCode)
            {
                MessagePromp.ShowCenter(this, "Duplicate Operation Code", MessageBoxIcon.Error);
                return;
            }

            bool operationName = operationlist.Any(operation => operation.OperationName.Equals(opName, StringComparison.OrdinalIgnoreCase));
            if (operationName)
            {
                MessagePromp.ShowCenter(this, "Try Different Operation Name", MessageBoxIcon.Error);
                return;
            }
            double price;
            if (!double.TryParse(opPrice.Text, out price))
            {
                MessagePromp.ShowCenter(this, "Invalid Price", MessageBoxIcon.Error);
                return;
            }
            price = double.Parse(price.ToString("F2"));

            if (price >= 1000000000)
            {
                MessagePromp.ShowCenter(this, "Price is too big.", MessageBoxIcon.Error);
                return;
            }

            TimeSpan duration;
            if (!TimeSpan.TryParseExact(opDuration.Text, @"hh\:mm\:ss", null, out duration))
            {
                MessagePromp.ShowCenter(this, "Invalid Duration", MessageBoxIcon.Error);
                return;
            }
            if (duration == TimeSpan.Zero)
            {
                MessagePromp.ShowCenter(this, "Invalid Duration", MessageBoxIcon.Error);
                return;
            }

            if (comboRoomType.SelectedIndex == -1 || comboRoomType.SelectedItem.ToString().Equals("No registered room type.       "))
            {
                MessagePromp.ShowCenter(this, "Select room type for this operation.", MessageBoxIcon.Error);
                return;
            }

            bool success = operationRepository.insertOperation(new Operation(opCode.ToUpper(), Capitalize(opName), DateTime.Now, opDescription, price, duration, comboRoomType.SelectedItem.ToString()));
            if (success)
            {
                MessagePromp.ShowCenter(this, "Operation Added Successfully", MessageBoxIcon.Information);
                reset();
            }
            else
            {
                MessagePromp.ShowCenter(this, "Operation Failed to Add", MessageBoxIcon.Error);

            }
        }
        public string Capitalize(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            isAddOperationShowing = !isAddOperationShowing;
            reset();
            timerout.Start();
        }

        public void reset()
        {
            opCode.Text = "";
            opName.Text = "";
            opDescription.Text = "";
            opPrice.Text = "";
            opDuration.Text = "";
            comboRoomType.SelectedIndex = -1;
            timerout.Start();
            operationlist = operationRepository.getOperationOnDoctors();
            displayOperations(operationlist, "");
            SearchBar1.Text = "";
            SearchBar1.Enabled = true;
        }

        private void opPrice_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(opPrice.Text))
            {
                bool op = double.TryParse(opPrice.Text, out double price);
                if (op)
                {
                    op = double.Parse(opPrice.Text) <= 1000000000;
                }
                picturePrice.Image = op ? Properties.Resources.check : Properties.Resources.error;
            }
            else
            {
                picturePrice.Image = null;
            }
        }

        private void TextOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private int x = -457;
        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 50;

            if (x >= (ClientSize.Width - addOperationPanel.Width) / 2)
            {
                x = (ClientSize.Width - addOperationPanel.Width) / 2;
                addOperationB.Enabled = false;
                timerin.Stop();
            }
            addOperationPanel.Location = new Point(x, addOperationPanel.Location.Y);
        }


        private void timerout_Tick(object sender, EventArgs e)
        {
            x -= 50;
            if (x <= -addOperationPanel.Width)
            {
                x = -addOperationPanel.Width;
                timerout.Stop();
                addOperationPanel.Visible = false;
                flowLayout.Visible = true;
                addOperationB.Enabled = true;
                SearchBar1.Enabled  = true;
            }
            addOperationPanel.Location = new Point(x, addOperationPanel.Location.Y);
        }

        private void addOperationB_Click(object sender, EventArgs e)
        {
            
            timerin.Start();
            SearchBar1.Enabled = false;
            addOperationB.Enabled = false;
            flowLayout.Visible = false;
            addOperationPanel.Visible = true;
        }

        private void flowLayout_SizeChanged(object sender, EventArgs e)
        {
            int y = (ClientSize.Height - addOperationPanel.Height) / 2;
            if (ClientSize.Height < 1080)
            {
                y += 55;

            }
            addOperationPanel.Location = new Point(-addOperationPanel.Width, y);
            addOperationPanel.Invalidate();
        }

        private void taab(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                Control currentControl = sender as Control;
                int currentIndex = tab.IndexOf(currentControl);

                if (currentIndex >= 0)
                {
                    int nextIndex = (currentIndex + 1) % tab.Count;
                    tab[nextIndex].Focus();
                    e.IsInputKey = true;
                }
            }
        }

        private void OperationForm_Shown(object sender, EventArgs e)
        {
            foreach (string item in roomtype)
            {
                comboRoomType.Items.Add(item);
            }
            if (roomtype.Count == 0) {
                comboRoomType.Items.Add("No registered room type.       ");
                comboRoomType.SelectedIndex = 0;
            }

            displayOperations(operationlist,"No Operation");
        }

        private void load_Tick(object sender, EventArgs e)
        {
            load.Stop();
            string type;
            List<Operation> filteredOperationList = new List<Operation>();
            if (string.IsNullOrWhiteSpace(SearchBar1.Text))
            {
                filteredOperationList = operationlist;
                type = "No Operation";
            }
            else
            {

                filteredOperationList = operationlist.Where(
                   operation =>
                   operation.OperationName.StartsWith(SearchBar1.Text, StringComparison.OrdinalIgnoreCase) ||
                   operation.OperationCode.StartsWith(SearchBar1.Text, StringComparison.OrdinalIgnoreCase)
               ).ToList();
                type = "Operation doenst exists";
            }
            displayOperations(filteredOperationList, type);
        }

    }
}
