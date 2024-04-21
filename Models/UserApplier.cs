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
        public string Name { get; set; }
        public int Age { get; set; }
        public string HomeLocation { get; set; }
        public string Description { get; set; }
        public string Resume {  get; set; }

        // Links for EF 

        public List<MotivationLetter> Letters { get; set; }

    }
}
