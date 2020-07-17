using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementABC.Models
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext context;
        public ClassRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Class Create(Class classss)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Class Edit(Class classs)
        {
            throw new NotImplementedException();
        }

        public Class Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> Gets()
        {
            return context.Classes;
        }
    }
}
