using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MotivationLetterDTOs
{
    /// <summary>
    /// DTO for motivation LETTER
    /// </summary>
    public class MotivationLetterCreateDTO
    {
        public string Name {  get; set; }
        public string Content { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
