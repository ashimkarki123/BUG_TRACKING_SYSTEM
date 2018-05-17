using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model to save bug history
    /// </summary>
    class BugHistoryViewModel
    {
        public int BugHistoryId { get; set; }
        public int VersionControlId { get; set; }
        public string Description { get; set; }
        
    }
}
