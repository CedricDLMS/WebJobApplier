using Microsoft.VisualBasic;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserApplierDTOs
{
    public class UserApplierWithAll
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public List<Skills>? Skills { get; set; } // Might use DTOs
        public int SkillsCount { get; set; } // Might be revealant ? 

        public List<Models.MotivationLetter> Letters { get; set; }
        public List<Formation>? Formations { get; set; }
    }
}
