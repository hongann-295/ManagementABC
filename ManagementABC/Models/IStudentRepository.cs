using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementABC.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Gets();
        Student Get(int id);
        Student Create(Student student);
        Student Edit(Student student);
        bool Delete(int id);
    }
}
