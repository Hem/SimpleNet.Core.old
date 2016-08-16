using ConsoleApp.Repository;
using System;

namespace ConsoleApp
{
    public class Program
    {
        public const string CONNECTION_STRING = @"Server=.\SQLEXPRESS;Database=AdventureWorks2012;Trusted_Connection=True;";
        

        public static void Main(string[] args)
        {


            var repository = new PersonRepository();

            var recordsTask = repository.Find("Miller");

            recordsTask.Wait();


            foreach(var person in recordsTask.Result)
            {
                Console.WriteLine($" ({person.BusinessEntityId}) {person.FirstName}, {person.LastName}");
            }


            Console.WriteLine("PRINT COMPLETE:");
            Console.ReadLine();

            

        }



    }
}
