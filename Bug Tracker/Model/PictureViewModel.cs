using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.Model
{
    /// <summary>
    /// Model for saving image about bug
    /// </summary>
    class PictureViewModel
    {
        public int? ImageId { get; set; }
        public int BugId { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        
    }
}
