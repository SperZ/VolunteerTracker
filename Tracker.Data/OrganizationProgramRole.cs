using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class OrganizationProgramRole
    {
        [Key]
        public int OrganizationProgramRoleId { get; set; }
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        public int OrganizationProgramId { get; set; }
        [ForeignKey(nameof(OrganizationProgramId))]
        public virtual OrganizationProgram OrganizationProgram{get; set;}

    }
}
