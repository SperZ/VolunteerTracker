using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class ProgramCreate
    {
        [Required]
        public string ProgramName { get; set; }
       [Required]
        public string ProgramDescription { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
