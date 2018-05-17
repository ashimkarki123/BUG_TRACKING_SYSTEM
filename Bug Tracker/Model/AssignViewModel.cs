using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model to assign task for programmer
    /// </summary>
    class AssignViewModel
    {
        public int AssignId { get; set; }
        public int BugId { get; set; }
        public int AssignBy { get; set; }
        public int AssignTo { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DeadLine { get; set; } 
        public string Description { get; set; }
    }
}
