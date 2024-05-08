using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MotivationLetter
{
    /// <summary>
    /// DTO for motivation LETTER
    /// </summary>
    public class MotivationLetterGetDTO
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Content { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
