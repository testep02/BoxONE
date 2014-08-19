using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxONE.Domain.Entities
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string SSN { get; set; }
        public int Active { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
