using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// class for formation, id, school name , description, beginDate, endDate, Diploma(string)
    /// </summary>
    public class Formation
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Description { get; set; }
        public string Diploma {  get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        // EF navigation

        public List<UserApplier>? Appliers { get; set; }


    }
}
