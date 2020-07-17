using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementABC.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ClassName { get; set; }
        public ICollection<Student> students { get; set; }
    }
}
