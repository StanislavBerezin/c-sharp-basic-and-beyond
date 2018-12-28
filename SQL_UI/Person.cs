using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_UI
{
    public class Person
    {
        public int id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

     

        public string FullInfo
        {
            //will get resultslike Stas Berezin (mail.com)
            get { return $"{FirstName} {LastName}"; }
           
        }
    }
}
