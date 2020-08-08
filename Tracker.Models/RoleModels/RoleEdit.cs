using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class RoleEdit
    {
        public int RoleId { get; set; }//this needs to go here or we cant access it in the role edit method of our role services
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
