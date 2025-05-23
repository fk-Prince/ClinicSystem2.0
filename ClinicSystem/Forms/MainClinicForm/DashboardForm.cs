using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using ClinicSystem.Entity;
using ClinicSystem.UserLoginForm;
using Guna.UI2.WinForms;


namespace ClinicSystem.MainClinic
{
    public partial class DashboardForm : Form
    {
        private ClinicRepository clinicRepository = new ClinicRepository();

        private int patientTotal = 0;
        private int patientCount = 0;
        private int doctorCount = 0;
        private int doctorTotal = 0;
        private int totalEarnings;
        private int revenueX, settingX, rankingY, todayAppX;
        private Form f;
        private Guna2Panel slidePanel;
        private int x = 0;
        private int totalLeft = 0;
        private int totalRight = 0;
        private int maxIndex = -1;
        private int currentIndex = 0;
        private int missCounter;

        public DashboardForm(Staff staff, Form f)
        {
            this.f = f;
            InitializeComponent();
            displayAppointments();
            displayDoctorStats();
            patientTotal = clinicRepository.TotalPatient();
            doctorTotal = clinicRepository.TotalActiveDoctor();
            totalEarnings = clinicRepository.getEarnings();
            double revenueratio = clinicRepository.getPercentageIncrease();
            if (revenueratio < 0)
            {
                pictureRatio.Image = Properties.Resources.decreaseincome;
                increase.ForeColor = Color.Red;
            }
            else
            {
                pictureRatio.Image = Properties.Resources.increaseincome;
                increase.ForeColor = Color.Lime;
            }
            increase.Text = revenueratio.ToString() + "%";
            tbTotalEarniings.Text = "₱ " + totalEarnings.ToString("F2");
            panel4.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 50, 50));
            panel8.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, panel8.Width, panel8.Height, 50, 50));

            settingX = ClientSize.Width + 10;
            revenueX = ClientSize.Width + 10;
            todayAppX = ClientSize.Width + 10;
            settingP.Location = new Point(settingX, panel1.Bottom + 20);
            revenueP.Location = new Point(revenueX, settingP.Bottom + 20);
            todayAppP.Location = new Point(todayAppX, revenueP.Bottom + 50);

            //logo_img.BackColor = Color.Transparent;

            //QuantumCare_label.Font = new Font("Matura MT Script Capitals", 30, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            //QuantumCare_label.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            totalPatient.Text = "0";
            totalDentist.Text = "0";
            missCounter = clinicRepository.getAppointmentCountMissed();
            missCount.Text = missCounter.ToString();

            if (missCounter != 0)
            {
                missCount.ForeColor = Color.Red;
            } else
            {
                missCount.Text = "";
            }
            lastMonthTimer.Start();
            doctorT.Start();
            settingTimer.Start();
            rankingT.Start();



        }

        private void displayDoctorStats()
        {
            DoctorStats current = clinicRepository.getDoctorStats();
            if (current != null)
            {
                currentTP.Text = current.TotalPatient.ToString();
                currentTA.Text = current.TotalAppointments.ToString();
                //currentOS.Text = current.TotalOperations.ToString();
                currentRC.Text = "₱ " + current.TotalRevenue.ToString("F2");
                currentdName.Text = $"{current.Doctor.DoctorFirstName} {current.Doctor.DoctorMiddleName} {current.Doctor.DoctorLastName}";
                currentdID.Text = current.Doctor.DoctorID.ToString();
                currentdHired.Text = current.Doctor.DateHired.ToString("yyyy-MM-dd");
                currentdImage.Image = current.Doctor.Image == null ? Properties.Resources.doctoruser : current.Doctor.Image;
            }
            DoctorStats last = clinicRepository.getDoctorStatsLast();
            if (last != null)
            {
                lastTP.Text = last.TotalPatient.ToString();
                lastTA.Text = last.TotalAppointments.ToString();
                lastRC.Text = "₱ " + last.TotalRevenue.ToString("F2");
                lastName.Text = $"Dr. {last.Doctor.DoctorFirstName} {last.Doctor.DoctorMiddleName} {last.Doctor.DoctorLastName}";
                lastID.Text = last.Doctor.DoctorID.ToString();
                lastHired.Text = last.Doctor.DateHired.ToString("yyyy-MM-dd");
                lastImage.Image = last.Doctor.Image == null ? Properties.Resources.doctoruser : last.Doctor.Image;
            }
        }

        private void displayAppointments()
        {
            List<Appointment> appList = clinicRepository.getTodayAppointment();
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
                Guna2HtmlLabel label = myLabel(70, 115, $"We have no Appointment Today");
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

        private void prevB(object sender, EventArgs e)
        {
            prevSlide.Start();
        }

        private void nextB(object sender, EventArgs e)
        {

            nextSlide.Start();
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

        private int bv = 0;
        private void panel10_SizeChanged(object sender, EventArgs e)
        {
            int xc, x = 0;
            if (ClientSize.Width >= 1500)
            {
                bv = (panel1.Location.Y + panel1.Height) + 125;
                x = (ClientSize.Width - rankingPanel.Width) / 2;
                xc = 100;
                panel4.Location = new Point(xc, bv);
            }
            else
            {
                bv = (panel1.Location.Y + panel1.Height) + 10;

                xc = 10;
                panel4.Location = new Point(xc, bv);
                x = panel4.Right + xc;

            }

            settingX = ClientSize.Width + 10;
            revenueX = ClientSize.Width + 10;
            todayAppX = ClientSize.Width + 10;
            panel8.Location = new Point(xc, panel4.Bottom + 25);
            rankingPanel.Location = new Point(x, bv);
            todayAppP.Location = new Point(todayAppX, revenueP.Bottom + 30);
            settingP.Location = new Point(settingX, panel1.Bottom + 20);
            revenueP.Location = new Point(revenueX, settingP.Bottom + 20);

            panel4.Invalidate();
            panel8.Invalidate();
            revenueP.Invalidate();
            settingP.Invalidate();
            todayAppP.Invalidate();
            todayAppP.Invalidate();
            panel10.Invalidate();
        }

        private void revenueTimer_Tick(object sender, EventArgs e)
        {
            if (revenueX < (ClientSize.Width - revenueP.Width) && !todayAppT.Enabled)
            {
                todayAppT.Start();
            }
            revenueX -= 20;
            if (revenueX < (ClientSize.Width - revenueP.Width) - 20)
            {
                revenueX = (ClientSize.Width - revenueP.Width) - 20;
                revenueTimer.Stop();
            }
            revenueP.Location = new Point(revenueX, revenueP.Location.Y);
        }

        private void lastMonthTimer_Tick(object sender, EventArgs e)
        {
            if (patientTotal == 0)
            {
                totalPatient.Text = "0";
                lastMonthTimer.Stop();
            }
            if (patientCount > patientTotal)
            {
                lastMonthTimer.Stop();
                return;
            }
            totalPatient.Text = patientCount.ToString();
            patientCount++;
        }

        private void settingTimer_Tick(object sender, EventArgs e)
        {

            if (settingX < (ClientSize.Width - settingP.Width) && !revenueTimer.Enabled)
            {
                revenueTimer.Start();
            }
            settingX -= 20;
            if (settingX < (ClientSize.Width - settingP.Width) - 20)
            {
                settingX = (ClientSize.Width - settingP.Width) - 20;
                settingTimer.Stop();
            }
            settingP.Location = new Point(settingX, settingP.Location.Y);
        }

        private void rankingT_Tick(object sender, EventArgs e)
        {
            rankingY += 30;
            if (rankingY >= bv)
            {
                rankingY = bv;
                rankingT.Stop();
            }
            rankingPanel.Location = new Point(rankingPanel.Location.X, rankingY);
        }


        Guna2Panel p;

        private List<Guna2Panel> panels = new List<Guna2Panel>();
        private void setAppointmentStatus(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button == null) return;
            Appointment a = button.Tag as Appointment;
            if (a != null)
            {
                clinicRepository.updateAppointmentStatus(a);
                Guna2Panel panel = button.Parent as Guna2Panel;
                if (panel != null)
                {
                   
                    Timer t = new Timer();
                    t.Tag = panel;
                    t.Interval = 15;
                    t.Tick += slide;
                    t.Start();
                    missCounter--;
                    missCount.Text = missCounter.ToString();
                    if (missCount.Text.Equals("0"))
                    {
                        missCount.Text = "";
                    }
                    else
                    {
                        missCount.ForeColor = Color.Red;
                    }
                    missCount.BringToFront();
                }
            }
        }
        int panelX = 0;
        private void slide(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            p.AutoScroll = false;
            Guna2Panel panel = timer.Tag as Guna2Panel;
            panelX += 30;
            Guna2Panel parent = panel.Parent as Guna2Panel;
            if (panelX > parent.Width)
            {
                p.AutoScroll = true;
                panelX = 0;
                timer.Stop();
                p.Controls.Remove(panel);
                panels.Remove(panel);
                panelAdjust();
            }
            panel.Location = new Point(panelX, panel.Location.Y);
        }

        private void panelAdjust()
        {
            int y = 0;
            foreach (Guna2Panel panel in panels)
            {
                panel.Location = new Point(5, y + 5);
                y += panel.Height;
            }

            if (missCounter == 0)
            {
                missCount.Text = "";
                panel10.Controls.Remove(p);
                panel10.Invalidate();
                MessagePromp.MainShowMessageBig(this, "You have no notifications left.", MessageBoxIcon.Information);
            }
        }

        private void notificationClicked(object sender, EventArgs e)
        {
            List<Appointment> ap = clinicRepository.getUpcomingAppointment();
            if (ap.Count == 0)
            {
                missCount.ForeColor = Color.Black;
                MessagePromp.MainShowMessage(this, "You have no notifications", MessageBoxIcon.Information);
                return;
            }
            missCount.ForeColor = Color.Red;
            if (p != null)
            {
                panel10.Controls.Remove(p);
                p.Dispose();
                p = null;
                return;
            }

            p = new Guna2Panel();
            p.FillColor = Color.FromArgb(111, 168, 166); 
            p.Size = new Size(settingP.Width + 230, 206);
            p.Location = new Point(settingP.Location.X - 230, settingP.Location.Y + settingP.Height - 10);
            p.AutoScroll = true;
            panel10.Controls.Add(p);
            p.BringToFront();

            int y = 0;
            foreach (Appointment a in ap)
            {
                Guna2Panel s = new Guna2Panel();
                s.BorderColor = Color.LightGray;
                s.BackColor = Color.Transparent;
                s.Size = new Size(p.Width - 25, 75);
                s.BorderRadius = 10;
                s.Location = new Point(5, y + 5);
                s.FillColor = Color.FromArgb(233, 255, 252);

                Guna2Button b = new Guna2Button();
                b.Text = "SET AS ABSENT";
                b.Tag = a;
                b.Size = new Size(80, 50);
                b.BorderRadius = 5;
                b.Location = new Point((s.Width - b.Width) - 5, (s.Height - b.Height) / 2);
                b.FillColor = Color.FromArgb(34, 44, 54);
                b.BackColor = Color.Transparent;
                b.Click += setAppointmentStatus;
                s.Controls.Add(b);

                Guna2HtmlLabel label = myLabel(10, 10, $"Appointment No: {a.AppointmentDetailNo}");
                label.BackColor = s.FillColor;
                s.Controls.Add(label);
                label = myLabel(10, 25, $"Patient Name: {a.Patient.Firstname} {a.Patient.Middlename} {a.Patient.Lastname}");
                label.BackColor = s.FillColor;
                s.Controls.Add(label);
                label = myLabel(10, 40, $"Start Schedule: {a.StartTime.ToString("yyyy-MM-dd hh:mm:ss tt")}");
                label.BackColor = s.FillColor;
                s.Controls.Add(label);
                label = myLabel(10, 55, $"End Schedule:  {a.EndTime.ToString("yyyy-MM-dd hh:mm:ss tt")}");
                label.BackColor = s.FillColor;
                s.Controls.Add(label);

                p.Controls.Add(s);
                y += s.Height;
                panels.Add(s);
            }
        }

      

        private void todayAppT_Tick(object sender, EventArgs e)
        {
            todayAppX -= 20;
            if (todayAppX < (ClientSize.Width - todayAppP.Width) - 20)
            {
                todayAppX = (ClientSize.Width - todayAppP.Width) - 20;
                todayAppT.Stop();
            }
            todayAppP.Location = new Point(todayAppX, todayAppP.Location.Y);
        }

        private void doctorT_Tick(object sender, EventArgs e)
        {
            if (doctorTotal == 0)
            {
                totalDentist.Text = "0";
                doctorT.Stop();
            }
            if (doctorCount > doctorTotal)
            {
                doctorT.Stop();
                return;
            }
            totalDentist.Text = doctorCount.ToString();
            doctorCount++;
        }
        private Guna2HtmlLabel myLabel(int x, int y, string msg)
        {
            Guna2HtmlLabel label = new Guna2HtmlLabel();
            label.Text = msg;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            return label;
        }

    }
}

