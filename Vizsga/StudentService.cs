using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsga.VizsgaDataLayer;

namespace Vizsga.Vizsga
{
    public class StudentService
    {
        protected readonly ISampleContext Context;
        public StudentService(ISampleContext context)
        {
            Context = context;
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

        public void SaveStudent(StudentEntity student)
        {
            StudentEntity studentEntity;
            if (student.Id > 0)
            {
                studentEntity = Context.Students.Where(e => e.Id == student.Id).FirstOrDefault();
            }
            else
            {
                studentEntity = new StudentEntity();
                Context.Students.Add(studentEntity);
            }
            studentEntity.Name = student.Name;
            studentEntity.Course = student.Course;
            Context.SaveChanges();
        }
    }
}
