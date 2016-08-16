using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp.Dto
{
    public class Person
    {
        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Guid RowGuid { get; set; }
    }
}
