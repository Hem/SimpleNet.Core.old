using ConsoleAppNew.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("In Here");
            Console.ReadKey();
            
            var repository = new PersonRepository();

            var recordsTask = repository.Find("Miller");

            recordsTask.Wait();


            foreach (var person in recordsTask.Result)
            {
                Console.WriteLine($" ({person.BusinessEntityId}) {person.FirstName}, {person.LastName}");
            }


            Console.WriteLine("PRINT COMPLETE:");



        }
    }
}
