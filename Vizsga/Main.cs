using Autofac;
using CsvHelper;
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
using Vizsga.VizsgaDataLayer;

namespace Vizsga.Vizsga
{
    public partial class Main : Form
    {
        private readonly StudentService _studentService;
        private readonly AppointmentService _appointmentService;
        public Main(StudentService studentService, AppointmentService appointmentService)
        {
            _studentService = studentService;
            _appointmentService = appointmentService;
            InitializeComponent();
        }

        public List<StudentEntity> Students { get; set; } = new List<StudentEntity>();
        public FileInfo CurrentFile { get; set; }

        private void Main_Load(object sender, EventArgs e)
        {
            using (var lifestimeScope = Program.Container.BeginLifetimeScope())
            {
                var form = lifestimeScope.Resolve<LoginForm>();
                form.ShowDialog();
                if (form.DialogResult != DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (StreamReader reader = (new StreamReader((string)e.Argument, Encoding.GetEncoding("iso-8859-2"))))
            {
                int rowCount = File.ReadLines((string)e.Argument).Count();
                var csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<StudentEntityClassMap>();
                var input = new List<StudentEntity>(csv.GetRecords<StudentEntity>().ToList());
                Invoke(new Action(() =>
                {
                    Students = input;
                    SaveStudents();
                }));
                MessageBox.Show("Betöltés vége");
            }
        }

        private void SaveStudents()
        {
            foreach (var student in Students)
            {

            }
        }

        private void hallgatókBeolvasásaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy) return;
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.CheckFileExists = true;
                open.Multiselect = false;
                open.Filter = "Csv fájlok (.csv)|*.csv|Minden fájl|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Students.Clear();
                    backgroundWorker.RunWorkerAsync(open.FileName);
                }
                else
                {
                    return;
                }
                CurrentFile = new FileInfo(open.FileName);
            }
        }

        private void hallgatókListájaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var lifetimeScope = Program.Container.BeginLifetimeScope())
            {
                Form form = new StudentListForm(_studentService);
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
        }

        private void időpontFoglalásokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AppointmentListForm(_appointmentService);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
