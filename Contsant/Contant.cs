using System.Reflection.Metadata;

namespace Contsant
{
    public class Contant
    {
        public string CurrentDirectory
        {
            get { return _currentDirectory; }
            set
            {
                _currentDirectory = System.IO.Directory.GetCurrentDirectory();
            }
        }
        static public string _currentDirectory { get; set; }
        //static string path = System.IO.Directory.
        static string CsvPath = @$"{_currentDirectory}/Models/scraped_indeed_jobs.csv";
    }
}
