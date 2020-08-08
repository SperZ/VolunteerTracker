using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class OrganizationCreate
    {
        [Required]
        public string OrganizationName { get; set; }
        [MaxLength(500)]
        public string OrganizatinonDescription { get; set; }
        public string Address { get; set; }
        [Required]
        public string WebUrl { get; set; }
    }
}
