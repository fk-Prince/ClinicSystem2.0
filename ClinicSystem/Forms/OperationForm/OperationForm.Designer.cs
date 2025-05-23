namespace ClinicSystem
{
    partial class OperationForm
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
            this.operationFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.comboRoomType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picturePrice = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureDuration = new System.Windows.Forms.PictureBox();
            this.pictureName = new System.Windows.Forms.PictureBox();
            this.pictureCode = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.opDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.Description = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.opDuration = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.opPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.opName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.opCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timerin = new System.Windows.Forms.Timer(this.components);
            this.timerout = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.addOperationPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.addOperationB = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.SearchBar1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.load = new System.Windows.Forms.Timer(this.components);
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCode)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.addOperationPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationFlowPanel
            // 
            this.operationFlowPanel.AutoScroll = true;
            this.operationFlowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.operationFlowPanel.Location = new System.Drawing.Point(13, 75);
            this.operationFlowPanel.Name = "operationFlowPanel";
            this.operationFlowPanel.Size = new System.Drawing.Size(0, 0);
            this.operationFlowPanel.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel9.Controls.Add(this.comboRoomType);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel9.ForeColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(32, 296);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(396, 32);
            this.panel9.TabIndex = 10061;
            // 
            // comboRoomType
            // 
            this.comboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRoomType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRoomType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboRoomType.FormattingEnabled = true;
            this.comboRoomType.IntegralHeight = false;
            this.comboRoomType.Location = new System.Drawing.Point(188, 2);
            this.comboRoomType.Name = "comboRoomType";
            this.comboRoomType.Size = new System.Drawing.Size(205, 29);
            this.comboRoomType.TabIndex = 2;
            this.comboRoomType.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.taab);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operation Room";
            // 
            // picturePrice
            // 
            this.picturePrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.picturePrice.Location = new System.Drawing.Point(428, 252);
            this.picturePrice.Name = "picturePrice";
            this.picturePrice.Size = new System.Drawing.Size(16, 16);
            this.picturePrice.TabIndex = 12;
            this.picturePrice.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::ClinicSystem.Properties.Resources.back;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(28, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureDuration
            // 
            this.pictureDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.pictureDuration.Location = new System.Drawing.Point(428, 201);
            this.pictureDuration.Name = "pictureDuration";
            this.pictureDuration.Size = new System.Drawing.Size(16, 16);
            this.pictureDuration.TabIndex = 11;
            this.pictureDuration.TabStop = false;
            // 
            // pictureName
            // 
            this.pictureName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.pictureName.Location = new System.Drawing.Point(429, 149);
            this.pictureName.Name = "pictureName";
            this.pictureName.Size = new System.Drawing.Size(16, 16);
            this.pictureName.TabIndex = 10;
            this.pictureName.TabStop = false;
            // 
            // pictureCode
            // 
            this.pictureCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.pictureCode.Location = new System.Drawing.Point(429, 97);
            this.pictureCode.Name = "pictureCode";
            this.pictureCode.Size = new System.Drawing.Size(16, 16);
            this.pictureCode.TabIndex = 9;
            this.pictureCode.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(141, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Operation Details";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel8.Controls.Add(this.opDescription);
            this.panel8.Controls.Add(this.Description);
            this.panel8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.ForeColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(32, 353);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(396, 106);
            this.panel8.TabIndex = 6;
            // 
            // opDescription
            // 
            this.opDescription.BorderRadius = 5;
            this.opDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.opDescription.DefaultText = "";
            this.opDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.opDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.opDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.opDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opDescription.Location = new System.Drawing.Point(185, 6);
            this.opDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opDescription.MaxLength = 200;
            this.opDescription.Multiline = true;
            this.opDescription.Name = "opDescription";
            this.opDescription.PlaceholderText = "";
            this.opDescription.SelectedText = "";
            this.opDescription.Size = new System.Drawing.Size(206, 95);
            this.opDescription.TabIndex = 12;
            this.opDescription.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.taab);
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Description.Location = new System.Drawing.Point(3, 8);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(74, 17);
            this.Description.TabIndex = 1;
            this.Description.Text = "Description";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel7.Controls.Add(this.opDuration);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.ForeColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(32, 192);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(396, 32);
            this.panel7.TabIndex = 5;
            // 
            // opDuration
            // 
            this.opDuration.BorderRadius = 5;
            this.opDuration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.opDuration.DefaultText = "";
            this.opDuration.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.opDuration.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.opDuration.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opDuration.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opDuration.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opDuration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opDuration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.opDuration.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opDuration.Location = new System.Drawing.Point(185, 2);
            this.opDuration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opDuration.Name = "opDuration";
            this.opDuration.PlaceholderText = "";
            this.opDuration.SelectedText = "";
            this.opDuration.Size = new System.Drawing.Size(206, 27);
            this.opDuration.TabIndex = 12;
            this.opDuration.TextChanged += new System.EventHandler(this.opDuration_TextChanged);
            this.opDuration.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.taab);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Duration (HH:MM:SS)";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel5.Controls.Add(this.opPrice);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(32, 244);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(396, 32);
            this.panel5.TabIndex = 3;
            // 
            // opPrice
            // 
            this.opPrice.BorderRadius = 5;
            this.opPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.opPrice.DefaultText = "";
            this.opPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.opPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.opPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.opPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opPrice.Location = new System.Drawing.Point(186, 2);
            this.opPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opPrice.MaxLength = 10;
            this.opPrice.Name = "opPrice";
            this.opPrice.PlaceholderText = "";
            this.opPrice.SelectedText = "";
            this.opPrice.Size = new System.Drawing.Size(206, 27);
            this.opPrice.TabIndex = 12;
            this.opPrice.TextChanged += new System.EventHandler(this.opPrice_TextChanged);
            this.opPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly);
            this.opPrice.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.taab);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Price";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel4.Controls.Add(this.opName);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(32, 141);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(396, 32);
            this.panel4.TabIndex = 2;
            // 
            // opName
            // 
            this.opName.BorderRadius = 5;
            this.opName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.opName.DefaultText = "";
            this.opName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.opName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.opName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.opName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opName.Location = new System.Drawing.Point(185, 3);
            this.opName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opName.MaxLength = 20;
            this.opName.Name = "opName";
            this.opName.PlaceholderText = "";
            this.opName.SelectedText = "";
            this.opName.Size = new System.Drawing.Size(206, 27);
            this.opName.TabIndex = 12;
            this.opName.TextChanged += new System.EventHandler(this.opName_TextChanged);
            this.opName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextOnly);
            this.opName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.taab);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Operation Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.panel3.Controls.Add(this.opCode);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(32, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 32);
            this.panel3.TabIndex = 0;
            // 
            // opCode
            // 
            this.opCode.BorderRadius = 5;
            this.opCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.opCode.DefaultText = "";
            this.opCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.opCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.opCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.opCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.opCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.opCode.Location = new System.Drawing.Point(185, 3);
            this.opCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.opCode.MaxLength = 10;
            this.opCode.Name = "opCode";
            this.opCode.PlaceholderText = "";
            this.opCode.SelectedText = "";
            this.opCode.Size = new System.Drawing.Size(206, 27);
            this.opCode.TabIndex = 11;
            this.opCode.TextChanged += new System.EventHandler(this.opCode_TextChanged);
            this.opCode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.taab);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Operation Code";
            // 
            // timerin
            // 
            this.timerin.Interval = 2;
            this.timerin.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerout
            // 
            this.timerout.Interval = 2;
            this.timerout.Tick += new System.EventHandler(this.timerout_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(229)))), ((int)(((byte)(220)))));
            this.panel2.Controls.Add(this.addOperationPanel);
            this.panel2.Controls.Add(this.addOperationB);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel2.MinimumSize = new System.Drawing.Size(1084, 719);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 724);
            this.panel2.TabIndex = 11;
            // 
            // addOperationPanel
            // 
            this.addOperationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.addOperationPanel.BorderColor = System.Drawing.Color.Gray;
            this.addOperationPanel.BorderRadius = 20;
            this.addOperationPanel.BorderThickness = 1;
            this.addOperationPanel.Controls.Add(this.guna2Button2);
            this.addOperationPanel.Controls.Add(this.panel9);
            this.addOperationPanel.Controls.Add(this.panel3);
            this.addOperationPanel.Controls.Add(this.panel4);
            this.addOperationPanel.Controls.Add(this.picturePrice);
            this.addOperationPanel.Controls.Add(this.panel5);
            this.addOperationPanel.Controls.Add(this.button3);
            this.addOperationPanel.Controls.Add(this.panel7);
            this.addOperationPanel.Controls.Add(this.pictureDuration);
            this.addOperationPanel.Controls.Add(this.panel8);
            this.addOperationPanel.Controls.Add(this.pictureName);
            this.addOperationPanel.Controls.Add(this.label8);
            this.addOperationPanel.Controls.Add(this.pictureCode);
            this.addOperationPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.addOperationPanel.Location = new System.Drawing.Point(-458, 139);
            this.addOperationPanel.Name = "addOperationPanel";
            this.addOperationPanel.Size = new System.Drawing.Size(460, 560);
            this.addOperationPanel.TabIndex = 10;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.Gray;
            this.guna2Button2.BorderRadius = 18;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(229)))), ((int)(((byte)(220)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.Location = new System.Drawing.Point(133, 496);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(203, 43);
            this.guna2Button2.TabIndex = 10063;
            this.guna2Button2.Text = "Add Operation";
            this.guna2Button2.Click += new System.EventHandler(this.button2_Click);
            this.guna2Button2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.taab);
            // 
            // addOperationB
            // 
            this.addOperationB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addOperationB.AutoRoundedCorners = true;
            this.addOperationB.BackColor = System.Drawing.Color.Transparent;
            this.addOperationB.BorderColor = System.Drawing.Color.Transparent;
            this.addOperationB.BorderRadius = 16;
            this.addOperationB.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addOperationB.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addOperationB.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addOperationB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addOperationB.FillColor = System.Drawing.Color.Transparent;
            this.addOperationB.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.addOperationB.ForeColor = System.Drawing.Color.Black;
            this.addOperationB.Image = global::ClinicSystem.Properties.Resources.add;
            this.addOperationB.ImageSize = new System.Drawing.Size(35, 35);
            this.addOperationB.Location = new System.Drawing.Point(1034, 90);
            this.addOperationB.Name = "addOperationB";
            this.addOperationB.Size = new System.Drawing.Size(38, 35);
            this.addOperationB.TabIndex = 9;
            this.addOperationB.Click += new System.EventHandler(this.addOperationB_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.flowLayout);
            this.panel1.Location = new System.Drawing.Point(1, 131);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel1.MinimumSize = new System.Drawing.Size(1088, 588);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 593);
            this.panel1.TabIndex = 8;
            // 
            // flowLayout
            // 
            this.flowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayout.AutoScroll = true;
            this.flowLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(255)))), ((int)(((byte)(252)))));
            this.flowLayout.Location = new System.Drawing.Point(0, 0);
            this.flowLayout.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flowLayout.MinimumSize = new System.Drawing.Size(1084, 588);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(1084, 593);
            this.flowLayout.TabIndex = 0;
            this.flowLayout.SizeChanged += new System.EventHandler(this.flowLayout_SizeChanged);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.SearchBar1);
            this.panel11.Controls.Add(this.label11);
            this.panel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel11.Location = new System.Drawing.Point(13, 12);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(289, 69);
            this.panel11.TabIndex = 6;
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
            this.SearchBar1.Location = new System.Drawing.Point(10, 28);
            this.SearchBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchBar1.Name = "SearchBar1";
            this.SearchBar1.PlaceholderText = "";
            this.SearchBar1.SelectedText = "";
            this.SearchBar1.Size = new System.Drawing.Size(276, 37);
            this.SearchBar1.TabIndex = 11;
            this.SearchBar1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Search Operation Code | Name";
            // 
            // load
            // 
            this.load.Interval = 500;
            this.load.Tick += new System.EventHandler(this.load_Tick);
            // 
            // OperationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(168)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(1084, 724);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.operationFlowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1084, 724);
            this.Name = "OperationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OperationForm";
            this.Shown += new System.EventHandler(this.OperationForm_Shown);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCode)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.addOperationPanel.ResumeLayout(false);
            this.addOperationPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel operationFlowPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureName;
        private System.Windows.Forms.PictureBox pictureCode;
        private System.Windows.Forms.PictureBox pictureDuration;
        private System.Windows.Forms.PictureBox picturePrice;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timerin;
        private System.Windows.Forms.Timer timerout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button addOperationB;
        private Guna.UI2.WinForms.Guna2Panel addOperationPanel;
        private Guna.UI2.WinForms.Guna2TextBox opCode;
        private Guna.UI2.WinForms.Guna2TextBox opDescription;
        private Guna.UI2.WinForms.Guna2TextBox opDuration;
        private Guna.UI2.WinForms.Guna2TextBox opPrice;
        private Guna.UI2.WinForms.Guna2TextBox opName;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox SearchBar1;
        private System.Windows.Forms.Timer load;
        private System.Windows.Forms.ComboBox comboRoomType;
    }
}