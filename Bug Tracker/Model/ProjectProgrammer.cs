using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    class ProjectProgrammer
    {
        public int? ProjectProgrammerId { get; set; }
        public int? ProgrammerId { get; set; }
        public int? ProjectId { get; set; }
        public int? AdminId { get; set; }
    }
}
