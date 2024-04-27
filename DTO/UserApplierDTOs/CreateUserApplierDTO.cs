using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CreateUserApplierDTO
    {
        public string Firstname {get; set;}
        public string Lastname {get; set;}
        public int Age {get; set;}
        public string HomeLocation {get; set;}
        public string Description {get; set;}
    }
}
