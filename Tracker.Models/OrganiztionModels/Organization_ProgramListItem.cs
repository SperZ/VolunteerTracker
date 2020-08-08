using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models.OrganiztionModels
{
    public class Organization_ProgramListItem
    {
        public int OrganizationId { get; set; }
        [Display(Name = "Name")]
        public string OrganizationName { get; set; }
        public int OrganizationProgramId { get; set; }
        [Display(Name = "Name")]
        public string OrganizationProgramName { get; set; }
    }
}
