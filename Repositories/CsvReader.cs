using Models;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Contsant;

namespace Repositories
{
    public class CsvReader
    {
        public readonly AppDbContext context;
        public readonly Contant contstant;
        public CsvReader(AppDbContext context,Contant contant)
        {
            this.context = context;
            this.contstant = contant;
        }

        public List<JobOffer> ReadJobOffersFromCsv(AppDbContext _context)
        {
            using (var reader = new StreamReader(contstant.CurrentDirectory))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                
                var records = csv.GetRecords<JobOffer>();
                return new List<JobOffer>(records);
            }
        }
    }
    public class JobOfferMap : ClassMap<JobOffer>
    {
        public JobOfferMap()
        {
            Map(m => m.Text).Name("job_name");
            Map(m => m.CompanyName).Name("company_name");
            Map(m => m.Url).Name("job_link_query");
            Map(m => m.City).Name("job_location");
        }
    }
}
