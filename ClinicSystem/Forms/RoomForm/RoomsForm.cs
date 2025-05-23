using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using ClinicSystem.UserLoginForm;
using Guna.UI2.WinForms;

namespace ClinicSystem.Rooms
{
    public partial class RoomsForm : Form
    {
        private List<Room> roomList;
        private List<Room> roomType;
        private RoomRepository db = new RoomRepository();

        private int x = -375;
        public RoomsForm()
        {
            InitializeComponent();
            roomList = db.getRooms();
            roomType = db.getRoomType();
            string type = "No Rooms";
            displayRooms(roomList, "No Rooms");
            roomType.ForEach(room => comboBox1.Items.Add(room.Roomtype));
            if (roomType.Count == 0)
            {
                comboBox1.Items.Add("No registered room type.          ");
                comboBox1.SelectedIndex = 0;
            }

            //RESIZE 
            int y = (ClientSize.Height - addRoomPanel.Height) / 2;
            if (ClientSize.Height < 1080)
            {
                y += 30;

            }
            addRoomPanel.Location = new Point(-addRoomPanel.Width, y);
        }

        private void displayRooms(List<Room> roomList, string type)
        {

            flowLayout.Controls.Clear();
            if (roomList.Count == 0 && type.Equals("No Rooms"))
            { 
                Label label = new Label();
                label.Text = $"Currently We Have {type}.";
                label.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                label.ForeColor = Color.Black;
                label.AutoSize = false;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;

                Panel panel = new Panel();
                panel.Size = new Size(flowLayout.Width, 500);
                panel.Controls.Add(label);
                flowLayout.Controls.Add(panel);
                return;
            }
            if (roomList.Count > 0)
            {
                foreach (Room r in roomList)
                {
                    Guna2Panel panel = new Guna2Panel();
                    panel.Size = new Size(300, 200);
                    panel.Location = new Point(50, 100);
                    panel.Margin = new Padding(20, 10, 10, 10);
                    panel.BackColor = Color.Transparent;
                    panel.FillColor = Color.FromArgb(111, 168, 166);
                    panel.BorderRadius = 30;
                    //panel.Region = Region.FromHrgn(dll.CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 50, 50));

                    Label label = createLabel("Room No ", r.RoomNo.ToString(), 10, 20);
                    panel.Controls.Add(label);

                    Label label1 = createLabel("Room Type ", r.Roomtype, 10, 40);
                    panel.Controls.Add(label1);

                    Guna2TextBox tb = new Guna2TextBox();
                    tb.Multiline = true;
                    tb.Text = r.RoomDescription;
                    tb.Location = new Point(15,80);
                    tb.Size = new Size(270, 100);
                    tb.ReadOnly = true;
                    tb.ForeColor = Color.Black;
                    tb.BorderRadius = 5;
                    tb.BackColor = Color.Transparent;
                    panel.Controls.Add(tb);

                    flowLayout.Controls.Add(panel);
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

        private void button3_Click(object sender, EventArgs e)
        {
            timerout.Start();
        }


        private void timerin_Tick(object sender, EventArgs e)
        {
            x += 50;
            addRoomB.Enabled = false;
            if (x >= (ClientSize.Width - addRoomPanel.Width) / 2)
            {
                x = (ClientSize.Width - addRoomPanel.Width) / 2;
                timerin.Stop();
            }
            addRoomPanel.Location = new Point(x, addRoomPanel.Location.Y);
        }

        private void timerout_Tick(object sender, EventArgs e)
        {
            x -= 50;
            if (x <= -addRoomPanel.Width)
            {
                x = -addRoomPanel.Width;
                timerout.Stop();
                addRoomB.Enabled = true;
                addRoomPanel.Visible = false;
                flowLayout.Visible = true;
                SearchBar1.Enabled = true;
            }
            addRoomPanel.Location = new Point(x, addRoomPanel.Location.Y);
        }


        private void addPatientB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(roomno.Text.Trim()) || comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(roomDescription.Text.Trim()))
            {
                MessagePromp.ShowCenter(this, "Empty Field", MessageBoxIcon.Error);
                return;
            }
            if(roomDescription.Text.Trim().Equals("No registered room type.          "))
            {
                MessagePromp.ShowCenter(this, "No registered room type.", MessageBoxIcon.Error);
                return;
            }

            string roomtype = comboBox1.SelectedItem.ToString();
            int roomNumber;
            if (!int.TryParse(roomno.Text, out roomNumber))
            {
                MessagePromp.ShowCenter(this, "Room No can only be number", MessageBoxIcon.Error);
                return;
            }

            foreach (Room roomss in roomList)
            {
                if (roomss.RoomNo == roomNumber)
                {
                    MessagePromp.ShowCenter(this, "Try different RoomNo. this room already exist", MessageBoxIcon.Error);
                    return;
                }
            }

            Room room = new Room(roomNumber, roomtype);
            db.insertRoom(room);
            MessagePromp.ShowCenter(this, "Successfully Added", MessageBoxIcon.Information);
            roomno.Text = "";
            comboBox1.SelectedIndex = -1;
            roomList.Add(room);
            roomDescription.Text = "";
            timerout.Start();
            displayRooms(roomList, "No Rooms");
        }
        private void addRoomB_Click(object sender, EventArgs e)
        {
            timerin.Start();
            SearchBar1.Enabled = false;
            addRoomB.Enabled = true;
            addRoomPanel.Visible = true;
            flowLayout.Visible = false;
            roomno.Text = "";
            comboBox1.SelectedIndex = -1;
            roomDescription.Text = "";
        }

        private void comboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;
            foreach (Room r in roomType)
            {
                if (r.Roomtype.Equals(comboBox1.SelectedItem.ToString()))
                {
                    roomDescription.Text = r.RoomDescription;
                    break;
                }
            }
        }

        private void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void SearchBar1_TextChanged(object sender, EventArgs e)
        {
            load.Stop();
            load.Start();         
        }

        private void flowLayout_SizeChanged(object sender, EventArgs e)
        {
            int y = (ClientSize.Height - addRoomPanel.Height) / 2;
            if (ClientSize.Height < 1080)
            {
                y += 30;

            }
            addRoomPanel.Location = new Point(-addRoomPanel.Width, y);
            addRoomPanel.Invalidate();
        }

        private void RoomsForm_Shown(object sender, EventArgs e)
        {
            string type = "";
            if (roomList.Count == 0)
            {
                type = "No Rooms";
            }
            displayRooms(roomList, type);
        }

        private void load_Tick(object sender, EventArgs e)
        {
            load.Stop();
            List<Room> filteredRoom = new List<Room>();

            if (string.IsNullOrWhiteSpace(SearchBar1.Text))
            {
                filteredRoom = roomList;
            }
            else
            {

                filteredRoom = roomList.Where(
                   room => room.RoomNo.ToString().StartsWith(SearchBar1.Text, StringComparison.OrdinalIgnoreCase) ||
                           room.Roomtype.StartsWith(SearchBar1.Text, StringComparison.OrdinalIgnoreCase)
               ).ToList();

            }
            displayRooms(filteredRoom, "");
        }
    }
}
