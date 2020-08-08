using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class OrganizationProgram
    {
        public OrganizationProgram()
        {
            this.Volunteers = new HashSet<Volunteer>();
            this.Roles = new HashSet<Role>();
        }
        [Key]
        public int ProgramId { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [MaxLength(350)]
        public string ProgramDescription { get; set; }
        [Required]
        public string Address { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public int OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }
    }
}
