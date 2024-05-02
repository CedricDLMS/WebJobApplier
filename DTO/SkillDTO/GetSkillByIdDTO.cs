using DTO.UserApplierDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SkillDTO
{
    /// <summary>
    /// Used In GetSkillById, return list of user having this skill
    /// </summary>
    public class GetSkillByIdDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? YearOfPractice { get; set; }
        public List<UserWithIdAndNameDTO?> User { get; set; }

    }
}
