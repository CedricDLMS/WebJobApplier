using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SkillDTO
{
    /// <summary>
    /// Used to get SkillDTO , without List of userApplier
    /// </summary>
    public class GetSkillDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? YearOfPractice { get; set; }
    }
}
