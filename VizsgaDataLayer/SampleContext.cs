using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.VizsgaDataLayer
{
    public class SampleContext : DbContext, ISampleContext
    {
        public SampleContext():this("ExamDB")
        {

        }
        public SampleContext(string connectionString)
            : base(connectionString)
        {

        }
        public IDbSet<AppointmentEntity> Appointments
        {
            get
            {
                return Set<AppointmentEntity>();
            }
        }

        public IDbSet<StudentEntity> Students
        {
            get
            {
                return Set<StudentEntity>();
            }
        }
    }
}
