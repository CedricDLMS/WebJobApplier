using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Class for skills data, id , Label, totalYearOfPracticing
    /// </summary>
    public class Skills
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? YearOfPractice { get; set; }

        // EF NAVIGATIONS
        public List<UserApplier>? UserAppliers { get; set; }

    }
}
