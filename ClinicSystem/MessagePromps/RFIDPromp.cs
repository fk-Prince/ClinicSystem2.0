using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ClinicSystem.MessagePromps
{
    public class RFIDPromp : Guna2Panel
    {
        private static RFIDPromp instance;
        private static SerialPort sp;
        public RFIDPromp()
        {
        }

        public static RFIDPromp getInstance()
        {
            if (instance == null)
            {
                string[] ports = SerialPort.GetPortNames();
                if (ports.Length <= 0)
                {
                    MessageBox.Show("No RFID Ports Found", "RFID NOT AVAILABLE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
                else
                {
                    if (sp != null && sp.IsOpen)
                    {
                        sp.Close();
                    }
                    foreach (string port in ports)
                    {
                        sp = new SerialPort(port, 9600);
                        sp.Open();
                        sp.DataReceived += data;
                        break;
                    }
                }
                instance = new RFIDPromp();
            }
            return instance;
        }

        private static string RFIDdata;

        private static void data(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp != null && sp.IsOpen)
            {
                try
                {
                    string receivedData = sp.ReadExisting();
                    string[] parts = receivedData.Split(':');
                    if (parts[0].Equals("UID"))
                    {
                        RFIDdata = parts[1];
                        if (instance.InvokeRequired)
                        {
                            instance.Invoke(new Action(() =>
                            {
                                instance.rfidtext?.Invoke(RFIDdata);                          
                            }));
                        }
                        else
                        {
                            instance.rfidtext?.Invoke(RFIDdata);
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error SERIAL PORT", "RFID NOT AVAILABLE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error main", "RFID NOT AVAILABLE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("SERIAL PORT IS NOT OPEN","RFID NOT AVAILABLE",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private Action<string> rfidtext;
        public void showRFIDPromp(Form f, Action<string> rfid)
        {
            Size = new Size(300, 300);
            Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            Location = new Point((f.Width - 300) / 2, (f.Height - 300) / 2);
            FillColor = Color.FromArgb(34, 44, 54);
            BorderThickness = 0;
            BorderRadius = 20;
            instance.rfidtext = rfid;

            PictureBox p = new PictureBox();
            p.Size = new Size(100, 100);
            p.BackColor = Color.Transparent;
            p.Location = new Point((Width - 100) / 2, 50);
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Image = Properties.Resources.rfid2;


            Label label = new Label();
            label.Text = "RFID is ready";
            label.Size = new Size(300,50);
            label.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(33, 42, 58);
            label.Location = new Point(0, 180);
            label.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label);
            Label label2 = new Label();
            label2.Text = "Please connect your ID";
            label2.Size = new Size(300, 30);
            label2.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(33, 42, 58);
            label2.Location = new Point(0, 240);
            label2.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(label2);
            Controls.Add(p);

            Label label3 = new Label();
            label3.Text = "X";
            label3.Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Cursor = Cursors.Hand;
            label3.Location = new Point(260, 15);
            label3.Click += clicked;
            label3.MouseEnter += mouseEnter;
            label3.BackColor = Color.Transparent;
            label3.MouseLeave += mouseLeave;
            Controls.Add(label3);
            f.Controls.Add(this);
            BringToFront();
            Focus();
            Show();
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.ForeColor = Color.White;
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

        public void close()
        {
            sp.DataReceived -= data;
            //sp.Close();
            instance.Dispose();
            instance = null;
        }
    }
}
