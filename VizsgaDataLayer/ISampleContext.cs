using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.VizsgaDataLayer
{
    public interface ISampleContext
    {
        IDbSet<StudentEntity> Students { get; }
        IDbSet<AppointmentEntity> Appointments { get; }

        int SaveChanges();
    }
}
