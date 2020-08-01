using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;

namespace Tracker.Models
{
    public class OrganizationDetail
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizatinonDescription { get; set; }
        public string Address { get; set; }
        public string WebUrl { get; set; }
        public virtual ICollection<OrganizationProgram> OrganizationPrograms { get; set; }
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }

}
