namespace ClinicSystem.Rooms
{
    partial class RoomsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchBar1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addRoomB = new Guna.UI2.WinForms.Guna2Button();
            this.addRoomPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.addPatientB = new Guna.UI2.WinForms.Guna2Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.roomDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.roomno = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timerin = new System.Windows.Forms.Timer(this.components);
            this.timerout = new System.Windows.Forms.Timer(this.components);
            this.load = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.addRoomPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayout
            // 
            this.flowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayout.AutoScroll = true;
            this.flowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.flowLayout.Location = new System.Drawing.Point(-1, 0);
            this.flowLayout.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flowLayout.MinimumSize = new System.Drawing.Size(1084, 599);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(1084, 604);
            this.flowLayout.TabIndex = 0;
            this.flowLayout.SizeChanged += new System.EventHandler(this.flowLayout_SizeChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.SearchBar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 61);
            this.panel1.TabIndex = 6;
            // 
            // SearchBar1
            // 
            this.SearchBar1.BorderRadius = 5;
            this.SearchBar1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBar1.DefaultText = "";
            this.SearchBar1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SearchBar1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SearchBar1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBar1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBar1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBar1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBar1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SearchBar1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBar1.IconRight = global::ClinicSystem.Properties.Resources.search24;
            this.SearchBar1.Location = new System.Drawing.Point(10, 22);
            this.SearchBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchBar1.Name = "SearchBar1";
            this.SearchBar1.PlaceholderText = "";
            this.SearchBar1.SelectedText = "";
            this.SearchBar1.Size = new System.Drawing.Size(274, 34);
            this.SearchBar1.TabIndex = 12;
            this.SearchBar1.TextChanged += new System.EventHandler(this.SearchBar1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Room No. | Room Types";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.panel2.Controls.Add(this.addRoomB);
            this.panel2.Controls.Add(this.addRoomPanel);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel2.MinimumSize = new System.Drawing.Size(1084, 724);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 724);
            this.panel2.TabIndex = 10;
            // 
            // addRoomB
            // 
            this.addRoomB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addRoomB.AutoRoundedCorners = true;
            this.addRoomB.BackColor = System.Drawing.Color.Transparent;
            this.addRoomB.BorderColor = System.Drawing.Color.Transparent;
            this.addRoomB.BorderRadius = 16;
            this.addRoomB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addRoomB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addRoomB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addRoomB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addRoomB.FillColor = System.Drawing.Color.Transparent;
            this.addRoomB.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.addRoomB.ForeColor = System.Drawing.Color.Black;
            this.addRoomB.Image = global::ClinicSystem.Properties.Resources.add;
            this.addRoomB.ImageSize = new System.Drawing.Size(35, 35);
            this.addRoomB.Location = new System.Drawing.Point(1025, 79);
            this.addRoomB.Name = "addRoomB";
            this.addRoomB.Size = new System.Drawing.Size(38, 35);
            this.addRoomB.TabIndex = 12;
            this.addRoomB.Click += new System.EventHandler(this.addRoomB_Click);
            // 
            // addRoomPanel
            // 
            this.addRoomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.addRoomPanel.BorderColor = System.Drawing.Color.Gray;
            this.addRoomPanel.BorderRadius = 30;
            this.addRoomPanel.BorderThickness = 1;
            this.addRoomPanel.Controls.Add(this.addPatientB);
            this.addRoomPanel.Controls.Add(this.panel4);
            this.addRoomPanel.Controls.Add(this.button3);
            this.addRoomPanel.Controls.Add(this.label10);
            this.addRoomPanel.Controls.Add(this.panel10);
            this.addRoomPanel.Controls.Add(this.panel9);
            this.addRoomPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.addRoomPanel.Location = new System.Drawing.Point(-372, 147);
            this.addRoomPanel.Name = "addRoomPanel";
            this.addRoomPanel.Size = new System.Drawing.Size(371, 517);
            this.addRoomPanel.TabIndex = 11;
            // 
            // addPatientB
            // 
            this.addPatientB.BackColor = System.Drawing.Color.Transparent;
            this.addPatientB.BorderColor = System.Drawing.Color.Gray;
            this.addPatientB.BorderRadius = 18;
            this.addPatientB.BorderThickness = 1;
            this.addPatientB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addPatientB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addPatientB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addPatientB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addPatientB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(229)))), ((int)(((byte)(220)))));
            this.addPatientB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPatientB.ForeColor = System.Drawing.Color.Black;
            this.addPatientB.Location = new System.Drawing.Point(90, 417);
            this.addPatientB.Name = "addPatientB";
            this.addPatientB.Size = new System.Drawing.Size(203, 43);
            this.addPatientB.TabIndex = 10064;
            this.addPatientB.Text = "Add Room";
            this.addPatientB.Click += new System.EventHandler(this.addPatientB_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.roomDescription);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(26, 257);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(333, 131);
            this.panel4.TabIndex = 10060;
            // 
            // roomDescription
            // 
            this.roomDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.roomDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.roomDescription.Location = new System.Drawing.Point(98, 1);
            this.roomDescription.Multiline = true;
            this.roomDescription.Name = "roomDescription";
            this.roomDescription.ReadOnly = true;
            this.roomDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.roomDescription.Size = new System.Drawing.Size(231, 127);
            this.roomDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Room";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::ClinicSystem.Properties.Resources.back;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(26, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.label10.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(108, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(165, 37);
            this.label10.TabIndex = 0;
            this.label10.Text = "Add Rooms";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.label9);
            this.panel10.Controls.Add(this.roomno);
            this.panel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel10.Location = new System.Drawing.Point(26, 130);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(333, 40);
            this.panel10.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(3, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Room No.";
            // 
            // roomno
            // 
            this.roomno.BorderRadius = 5;
            this.roomno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.roomno.DefaultText = "";
            this.roomno.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.roomno.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.roomno.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.roomno.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.roomno.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.roomno.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.roomno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.roomno.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.roomno.Location = new System.Drawing.Point(98, 4);
            this.roomno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.roomno.MaxLength = 6;
            this.roomno.Name = "roomno";
            this.roomno.PlaceholderText = "";
            this.roomno.SelectedText = "";
            this.roomno.Size = new System.Drawing.Size(231, 32);
            this.roomno.TabIndex = 0;
            this.roomno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.comboBox1);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel9.Location = new System.Drawing.Point(26, 198);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(333, 40);
            this.panel9.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(98, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 29);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboRoomType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Room Type";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.panel3.Controls.Add(this.flowLayout);
            this.panel3.Location = new System.Drawing.Point(3, 120);
            this.panel3.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel3.MinimumSize = new System.Drawing.Size(1088, 599);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1088, 604);
            this.panel3.TabIndex = 9;
            // 
            // timerin
            // 
            this.timerin.Interval = 2;
            this.timerin.Tick += new System.EventHandler(this.timerin_Tick);
            // 
            // timerout
            // 
            this.timerout.Interval = 2;
            this.timerout.Tick += new System.EventHandler(this.timerout_Tick);
            // 
            // load
            // 
            this.load.Interval = 500;
            this.load.Tick += new System.EventHandler(this.load_Tick);
            // 
            // RoomsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1084, 724);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1084, 724);
            this.Name = "RoomsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomsForm";
            this.Shown += new System.EventHandler(this.RoomsForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.addRoomPanel.ResumeLayout(false);
            this.addRoomPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timerin;
        private System.Windows.Forms.Timer timerout;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox SearchBar1;
        private Guna.UI2.WinForms.Guna2Panel addRoomPanel;
        private Guna.UI2.WinForms.Guna2TextBox roomno;
        private Guna.UI2.WinForms.Guna2Button addPatientB;
        private Guna.UI2.WinForms.Guna2Button addRoomB;
        private System.Windows.Forms.Timer load;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox roomDescription;
    }
}