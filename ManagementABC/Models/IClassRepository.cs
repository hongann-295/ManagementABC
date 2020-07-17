using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementABC.Models
{
    public interface IClassRepository
    {
        IEnumerable<Class> Gets();
        Class Get(int id);
        Class Create(Class classss);
        Class Edit(Class classs);
        bool Delete(int id);
    }
}
