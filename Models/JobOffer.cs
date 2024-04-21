using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Class for job offers
    /// </summary>
    public class JobOffer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public DateTime addDate { get; set; }
        public string City { get; set; }

        // Virtual link to Entreprise ID
        public int EntrepriseID { get; set; }
        public Entreprise Entreprise { get; set; }

        public List<Apply> Applies { get; set; }
    }
}
