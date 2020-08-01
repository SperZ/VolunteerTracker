using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class Role
    {
        public Role()
        {
            this.Volunteers = new HashSet<Volunteer>();
            this.OrganizaitonPrograms = new HashSet<OrganizationProgram>();
        }
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        
        public virtual ICollection<Volunteer> Volunteers { get; set; }
        public virtual ICollection<OrganizationProgram> OrganizaitonPrograms { get; set; }
    }
}
