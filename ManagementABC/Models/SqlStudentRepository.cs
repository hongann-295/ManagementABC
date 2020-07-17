using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementABC.Models
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;
        public SqlStudentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Student Create(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public bool Delete(int id)
        {
            var delStd = context.Students.Find(id);
            if (delStd != null)
            {
                context.Students.Remove(delStd);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public Student Edit(Student student)
        {
            var editStd = context.Students.Attach(student);
            editStd.State = EntityState.Modified;
            context.SaveChanges();
            return student;
        }

        public Student Get(int id)
        {
            return context.Students.Find(id);
        }

        public IEnumerable<Student> Gets()
        {
            return context.Students;
        }
    }
}
