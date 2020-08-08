using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class ProgramEdit
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }

        public string ProgramDescription { get; set; }

        public string Address { get; set; }
    }
}
