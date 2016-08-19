using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.VizsgaDataLayer
{
    public class StudentEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Course { get; set; }
    }
}
