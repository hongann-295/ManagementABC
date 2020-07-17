using ManagementABC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementABC.ViewModel
{
    public class HomeCreateViewModel
    {

        [Required]
        [StringLength(30, ErrorMessage = "Can not  exceed 30 characters")]
        public string Fullname { get; set; }
        public DateTime DoB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
