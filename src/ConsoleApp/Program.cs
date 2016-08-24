using ConsoleApp.Repository;
using System;

namespace ConsoleApp
{
    /// <summary>
    /// Sample application to show how to execute SQL statements using SimpleNet.Core.Data library.
    /// We are using adventure works database as issue by Microsoft.
    /// </summary>
    public class Program
    {
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
