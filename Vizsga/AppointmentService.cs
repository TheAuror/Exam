using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsga.VizsgaDataLayer;

namespace Vizsga.Vizsga
{
    public class AppointmentService
    {
        protected readonly ISampleContext Context;
        public AppointmentService(ISampleContext context)
        {
            Context = context;
        }

        public List<AppointmentEntity> GetAppointments()
        {
            List<AppointmentEntity> list = new List<AppointmentEntity>();
            foreach (var i in Context.Appointments)
            {
                list.Add(new AppointmentEntity()
                {
                    Id = i.Id,
                    StudentId = i.StudentId,
                    Appointment = i.Appointment,
                    StudentCourse = i.StudentCourse,
                    StudentName = i.StudentName
                });
            }
            return list;
        }

        public List<StudentEntity> GetStudents()
        {
            List<StudentEntity> list = new List<StudentEntity>();
            foreach (var i in Context.Students)
            {
                list.Add(new StudentEntity()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Course = i.Course
                });
            }
            return list;
        }

        public void SaveAppointment(AppointmentEntity appointment)
        {
            AppointmentEntity appointmentEntity;
            if (appointment.Id > 0)
            {
                appointmentEntity = Context.Appointments.Where(e => e.Id == appointment.Id).FirstOrDefault();
            }
            else
            {
                appointmentEntity = new AppointmentEntity();
                Context.Appointments.Add(appointmentEntity);
            }
            appointmentEntity.StudentName = appointment.StudentName;
            appointmentEntity.StudentCourse = appointment.StudentCourse;
            appointmentEntity.Appointment = appointment.Appointment;
            appointmentEntity.StudentId = appointment.StudentId;
            Context.SaveChanges();
        }
    }
}
