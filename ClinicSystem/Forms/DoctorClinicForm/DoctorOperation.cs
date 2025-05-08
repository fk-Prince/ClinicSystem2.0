using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicSystem.UserLoginForm;

namespace ClinicSystem.Doctors
{
    public partial class DoctorOperation : Form
    {
        private OperationRepository db = new OperationRepository();
        private Dictionary<Doctor, Operation> docOp = new Dictionary<Doctor, Operation>();
        private List<Operation> operationList;
        private List<Doctor> doctorList;

        public DoctorOperation()
        {
            InitializeComponent();
            //docOp = db.getDoctorOperation();
            //doctorList = db.getDoctors();
            //operationList = db.getOperation();
            if (doctorList.Count == 0)
            {
                comboDoctor.Items.Add("There is no Doctor");
                comboDoctor.SelectedIndex = 0;
                addSpecialized.Enabled = false;
                return;
            }
          
            foreach (Doctor doc in doctorList)
            {
                comboDoctor.Items.Add($"{doc.DoctorID}  |  Dr.{Capitalize(doc.DoctorLastName)},  {Capitalize(doc.DoctorFirstName)}  {Capitalize(doc.DoctorMiddleName)} ");
            }
        }



        public string Capitalize(string text)
        {
            return text.Substring(0,1).ToUpper() + text.Substring(1).ToLower();
        }

        private void comboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDoctor.SelectedIndex == -1) return;
            comboOperation.Items.Clear();
            foreach (Operation op in operationList)
            {
                comboOperation.Items.Add($"{op.OperationCode}  |  {op.OperationName}");
            }
        }

        private void addPatientB_Click(object sender, EventArgs e)
        {
            if (comboDoctor.SelectedIndex == -1)
            {
                MessagePromp.MainShowMessage(this, "No selected Doctor", MessageBoxIcon.Error);
                return;
            }

            if (comboOperation.SelectedIndex == -1)
            {
                MessagePromp.MainShowMessage(this, "No selected Operation", MessageBoxIcon.Error);
                return;
            }
            string doctorId = comboDoctor.SelectedItem.ToString().Split(' ')[0].Trim();
            string operationCode = comboOperation.SelectedItem.ToString().Split(' ')[0].Trim();
            foreach (var d in docOp){
                if (d.Key.DoctorID.Equals(doctorId) && operationCode.Equals(d.Value.OperationCode))
                {
                    MessagePromp.MainShowMessageBig(this, "This Doctor already have this Operation.", MessageBoxIcon.Error);
                    return;
                }
            }

            Doctor doc = doctorList.FirstOrDefault(d => d.DoctorID == doctorId);
            Operation op = operationList.FirstOrDefault(o => operationCode.Equals(o.OperationCode));
           

            bool success = db.insertSpecialized(doc, op);
            if (success)
            {
                docOp[doc] = op;
                MessagePromp.MainShowMessage(this, "Successfully Added Specialized", MessageBoxIcon.Information);
                comboDoctor.SelectedIndex = -1;
                comboOperation.SelectedIndex = -1;
            }
        }
    }
}
