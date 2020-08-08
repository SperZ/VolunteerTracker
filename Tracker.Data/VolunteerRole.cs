using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class VolunteerRole
    {
        [Key]
        public int VolunteerRoleId { get; set; }
        public int VolunteerId { get; set; }
        [ForeignKey(nameof(VolunteerId))]
        public virtual Volunteer Volunteer { get; set; }

        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual 

    }
}
