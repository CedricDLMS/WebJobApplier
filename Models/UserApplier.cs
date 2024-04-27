using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Class for the user of the application
    /// </summary>
    public class UserApplier
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string HomeLocation { get; set; }
        public string Description { get; set; }

        // Links for EF 

        public List<Skills>? Skills { get; set; } // all nullable cause user can have them null 
        public List<MotivationLetter>? Letters { get; set; }
        public List<Formation>? Formations { get; set; }
    }
}
