using System;

namespace ConsoleAppNew.Dto
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
