namespace ClinicSystem.Doctors
{
    partial class DoctorOperation
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addSpecialized = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboOperation = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboDoctor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(410, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 37);
            this.label1.TabIndex = 10060;
            this.label1.Text = "Doctor Operation";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.addSpecialized);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-1, 103);
            this.panel1.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.panel1.MinimumSize = new System.Drawing.Size(1090, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 537);
            this.panel1.TabIndex = 10061;
            // 
            // addSpecialized
            // 
            this.addSpecialized.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addSpecialized.BorderColor = System.Drawing.Color.Silver;
            this.addSpecialized.BorderRadius = 18;
            this.addSpecialized.BorderThickness = 1;
            this.addSpecialized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addSpecialized.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addSpecialized.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addSpecialized.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addSpecialized.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addSpecialized.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(158)))), ((int)(((byte)(153)))));
            this.addSpecialized.Font = new System.Drawing.Font("Segoe UI Semibold", 13.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.addSpecialized.ForeColor = System.Drawing.Color.White;
            this.addSpecialized.HoverState.BorderColor = System.Drawing.Color.Silver;
            this.addSpecialized.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.addSpecialized.Location = new System.Drawing.Point(372, 361);
            this.addSpecialized.Name = "addSpecialized";
            this.addSpecialized.Size = new System.Drawing.Size(337, 42);
            this.addSpecialized.TabIndex = 10102;
            this.addSpecialized.Text = "Add Specialized";
            this.addSpecialized.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.addSpecialized.Click += new System.EventHandler(this.addPatientB_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.comboOperation);
            this.panel3.Location = new System.Drawing.Point(251, 186);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 57);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Operation Code / Name";
            // 
            // comboOperation
            // 
            this.comboOperation.BackColor = System.Drawing.Color.White;
            this.comboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOperation.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOperation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboOperation.FormattingEnabled = true;
            this.comboOperation.ItemHeight = 18;
            this.comboOperation.Location = new System.Drawing.Point(220, 15);
            this.comboOperation.Name = "comboOperation";
            this.comboOperation.Size = new System.Drawing.Size(327, 26);
            this.comboOperation.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.comboDoctor);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(251, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 57);
            this.panel2.TabIndex = 0;
            // 
            // comboDoctor
            // 
            this.comboDoctor.BackColor = System.Drawing.Color.White;
            this.comboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDoctor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDoctor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboDoctor.FormattingEnabled = true;
            this.comboDoctor.ItemHeight = 18;
            this.comboDoctor.Location = new System.Drawing.Point(220, 15);
            this.comboDoctor.Name = "comboDoctor";
            this.comboDoctor.Size = new System.Drawing.Size(327, 26);
            this.comboDoctor.TabIndex = 1;
            this.comboDoctor.SelectedIndexChanged += new System.EventHandler(this.comboDoctor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Doctor ID / FullName";
            // 
            // DoctorOperation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(230)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(1089, 639);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1089, 639);
            this.Name = "DoctorOperation";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboDoctor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button addSpecialized;
        private System.Windows.Forms.ComboBox comboOperation;
    }
}