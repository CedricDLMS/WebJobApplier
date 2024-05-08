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
        public string UserName {  get; set; }
        public string Password1 { get; set;}
        public string Password2 { get; set;}
        public string Email {  get; set;}
        public int Age {get; set;}
        public string City {get; set;}
        public string? Description {get; set;}
    }
}
