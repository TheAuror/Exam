using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsga.VizsgaDataLayer;

namespace Vizsga.Vizsga
{
    class StudentEntityClassMap : CsvClassMap<StudentEntity>
    {
        public StudentEntityClassMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.Course).Name("Course");
        }
    }
}
