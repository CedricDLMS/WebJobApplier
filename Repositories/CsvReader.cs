using Models;

namespace Repositories
{
    public class CsvReader
    {
        public readonly AppDbContext context;
        public CsvReader(AppDbContext context)
        {
            this.context = context;
        }


    }
}
