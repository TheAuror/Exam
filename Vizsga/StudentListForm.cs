using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vizsga.VizsgaDataLayer;

namespace Vizsga.Vizsga
{
    public partial class StudentListForm : Form
    {
        private readonly StudentService _studentService;
        public StudentListForm(StudentService studentService)
        {
            InitializeComponent();
            _studentService = studentService;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource =_studentService.GetStudents();
        }
    }
}
