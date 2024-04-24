using System.Reflection.Metadata;

namespace Contsant
{
    public class Constant
    {
        // Static backing field for CurrentDirectory
        private static string _currentDirectory;

        // Static property for CurrentDirectory
        public static string CurrentDirectory
        {
            get
            {
                // Initialize _currentDirectory if it hasn't been set yet
                if (string.IsNullOrEmpty(_currentDirectory))
                {
                    _currentDirectory = System.IO.Directory.GetCurrentDirectory();
                }
                return _currentDirectory;
            }
            set { _currentDirectory = value; }  // Optionally allow setting from outside
        }
        public static string parentFolder { get; } = Directory.GetParent(CurrentDirectory)?.FullName;

        // Static property for CsvPath
        public static string CsvPath { get; } = @$"{parentFolder}/Python/JIM-jobs-scraper-FR/job_db/scraped_indeed_jobs.csv";
    }
}
