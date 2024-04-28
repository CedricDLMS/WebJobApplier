using Contsant;
using CsvHelper;
using CsvHelper.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ScrappingCSV
    {
        public readonly AppDbContext appDbContext;
        public ScrappingCSV(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        /// <summary>
        /// Look for a csv with job offers inside it, and reads its data and adds it in JobOffer Class , and to DbContext, and finally in the .db SQLite file
        /// </summary>
        /// <param name="appDbContext">Gives it a DbContextToWork, so i give it in parameters </param>
        /// <returns>Return a Task with a List<JobOffer> inside its .FromResult </returns>
        public static Task<List<JobOffer>> CsvHelper(AppDbContext appDbContext) // Method to read csv, and add it to class
        {
            List<JobOffer> records; // Create the list outside the scope, to use after the using (:
            using (var reader = new StreamReader(Constant.CsvPath)) // Using Constant.CsvPath , modify this if you want to change your csv file path 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<JobOfferMap>();
                records = csv.GetRecords<JobOffer>().ToList();
            }

            var list = records;
            foreach (var item in list) // Check if item exists based on sId
            {
                if (appDbContext.JobOffers.FirstOrDefault(c => c.sId == item.sId) == null)
                {
                    item.addDate = DateTime.Now;
                    appDbContext.JobOffers.Add(item);// Adds it to Db Context if doesn't exists
                }
            }
            appDbContext.SaveChanges();
            return Task.FromResult(list);
        }

    }
    /// <summary>
    /// used for mapping for CsvHelper
    /// </summary>
    public class JobOfferMap : ClassMap<JobOffer>
    {
        public JobOfferMap()
        {
            // Map each CSV column to the appropriate property in the JobOffer class
            Map(m => m.sId).Name("job_id");
            Map(m => m.Text).Name("job_name");
            Map(m => m.CompanyName).Name("company_name");
            Map(m => m.City).Name("job_location");
            Map(m => m.Url).Name("job_link");
            // Use 'query' for another purpose or ignore if not needed in JobOffer

            // Additional mapping for other fields like addDate if present in CSV
            // Example: Map(m => m.addDate).Name("add_date").TypeConverterOption.Format("yyyy-MM-dd"); // assuming a date format

            // Ignoring the mapping for Enterprise as it may not be directly present in the CSV
            // If EnterpriseID is supposed to be derived from 'query' or another column, map that accordingly
        }
    }
}
