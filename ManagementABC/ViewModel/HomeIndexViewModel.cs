using ManagementABC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementABC.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Student> students { get; set; }
        public string TitleName { get; set; }
    }
}
