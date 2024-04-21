using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Class for Letters of Motivations
    /// </summary>
    public class MotivationLetter
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        // EF Links
        public int UserApplierID {  get; set; }
        public UserApplier Applier { get; set; }
            
        public List<Apply> Applies { get; set; }

    }
}
