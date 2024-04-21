using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Class for applications 
    /// </summary>
    public class Apply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ApplyDate { get; set; }

        // Links for EF
        public int JobOfferID { get; set; }
        public JobOffer JobOffer { get; set;}

        public int MotivationLetterID {  get; set; }
        public MotivationLetter MotivationLetter { get; set; }
    }
}
