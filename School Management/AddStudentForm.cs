using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'projectDataSet10.Student'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            //this.studentTableAdapter.Fill(this.projectDataSet10.Student);

        }

        private void studentGridTest_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //var heigth = 40;
            //foreach(DataGridViewRow dr in studentGridTest.Rows)
            //{
            //    heigth += dr.Height;
            //}
            //studentGridTest.Height = heigth;
        }
    }
}
