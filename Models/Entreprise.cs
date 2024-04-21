namespace Models
{
    /// <summary>
    /// Class for Entreprises
    /// </summary>
    public class Entreprise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Infos { get; set; }

        // Link for job offers EF 
        public List<JobOffer>  JobOffers { get; set; }
    }
}
