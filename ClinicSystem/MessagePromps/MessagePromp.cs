using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicSystem.UserLoginForm
{
    public partial class MessagePromp : Panel
    {
        private static MessagePromp instance;
        private Timer timer;
        public MessagePromp(string message,
                        
                           MessageBoxIcon icon)
        {
          
            //Size = new Size(300, 50);
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;

            PictureBox picturebox = new PictureBox();
            picturebox.Margin = new Padding(0, 0, 20, 0);
            picturebox.Size = new Size(32, 32);
            picturebox.Location = new Point(10, 10);
            picturebox.SizeMode = PictureBoxSizeMode.CenterImage;

            Label label = new Label();
            label.Text = message;
            label.AutoSize = true;
            label.Location = new Point(50, 15);
            label.Font = new Font("Arial", 10, FontStyle.Bold);



            switch (icon)
            {
                case MessageBoxIcon.Error:
                    picturebox.Image = Properties.Resources.error;
                    BackColor = Color.FromArgb(220, 53, 69);
                    label.ForeColor = Color.White;
                    break;
                case MessageBoxIcon.Information:
                    picturebox.Image = Properties.Resources.checked2;
                    BackColor = Color.FromArgb(40, 167, 69); 
                    label.ForeColor = Color.White;
                    break;
                default:
                    picturebox.Image = null;
                    break;
            }

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += Tick;
            timer.Start();

            this.Controls.Add(picturebox);
            this.Controls.Add(label);



        }

        private void Tick(object sender, EventArgs e)
        {
            Parent?.Controls.Remove(this);
            timer?.Stop();
        }

        public static void MainShowMessage(Form f, string message, MessageBoxIcon icon)
        {
            if (instance != null && f.Controls.Contains(instance))
            {
                f.Controls.Remove(instance);
                instance.Dispose();
            }

            instance = new MessagePromp(message, icon);
            instance.Size = new Size(300, 50);
            int stopped = f.Width - 300;
            int start = f.Width + 350;
            instance.Location = new Point(start, 50);
            f.Controls.Add(instance);
            instance.BringToFront();

            instance.mainAnim(f,stopped, start);
        }

        public static void MainShowMessageBig(Form f, string message, MessageBoxIcon icon)
        {

            
            if (instance != null && f.Controls.Contains(instance))
            {
                f.Controls.Remove(instance);
                instance.Dispose();
            }

            instance = new MessagePromp(message, icon);
            instance.Size = new Size(400, 50);
            int stopped = f.Width - 400;
            int start = f.Width + 400;
            instance.Location = new Point(start, 50);
            f.Controls.Add(instance);
            instance.BringToFront();

            instance.mainAnim(f,stopped, start);
        }
        

        public static void LoginShowMessage(Form f, string message, MessageBoxIcon icon)
        {
            if (instance != null && f.Controls.Contains(instance))
            {
                f.Controls.Remove(instance);
                instance.Dispose();
            }
            instance = new MessagePromp(message, icon);
            instance.Size = new Size(300, 50);
            instance.Location = new Point((f.Width - instance.Width) / 2, -50);
            f.Controls.Add(instance);
            instance.BringToFront();

            instance.loginAnim();
        }

        public static void ShowCenter(Form f, string message, MessageBoxIcon icon)
        {
            if (instance != null && f.Controls.Contains(instance))
            {
                f.Controls.Remove(instance);
                instance.Dispose();
            }
            instance = new MessagePromp(message, icon);
            instance.Size = new Size(400, 50);
            instance.Location = new Point((f.Width - instance.Width) / 2, (f.Height - instance.Height) / 2);
            f.Controls.Add(instance);
            instance.BringToFront();
        }

        private void mainAnim(Form f, int stop, int start)
        {
            timer = new Timer();
            timer.Interval = 15;
            int x = start;

            timer.Tick += (s, e) =>
            {
                x -= 15;
                if (x <= stop)
                {
                    x = stop;
                    timer.Stop();
                }
                this.Location = new Point(x, 50);
            };

            timer.Start();
        }

        private void loginAnim()
        {
            timer = new Timer();
            timer.Interval = 15;
            int y = -50;

            timer.Tick += (s, e) =>
            {
                y += 5; 
                if (y >= 20)
                {
                    y = 20;
                    timer.Stop();
                   
                }
                this.Location = new Point(110, y);
            };

            timer.Start();
        }

    }
}
