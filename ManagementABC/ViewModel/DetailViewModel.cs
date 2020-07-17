using ManagementABC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ManagementABC.ViewModel
{
    public class DetailViewModel : Student
    {
        public string ClassName { get; set; }
    }
}
