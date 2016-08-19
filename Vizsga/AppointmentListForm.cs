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
    public partial class AppointmentListForm : Form
    {
        private readonly AppointmentService _appointmentService;
        public AppointmentListForm(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            InitializeComponent();

        }

        AppointmentEntity Appointment { get; set; } = new AppointmentEntity();

        private void button1_Click(object sender, EventArgs e)
        {
            Appointment.Appointment = dateTimePicker1.Value;
            Appointment.StudentName = ((StudentEntity)comboBox1.SelectedItem).Name;
            Appointment.StudentId = ((StudentEntity)comboBox1.SelectedItem).Id;
            Appointment.Appointment.AddHours((int)numericUpDown1.Value);
            _appointmentService.SaveAppointment(Appointment);
        }

        private void AppointmentListForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = _appointmentService.GetStudents();
            comboBox1.DisplayMember = Name;
        }
    }
}
