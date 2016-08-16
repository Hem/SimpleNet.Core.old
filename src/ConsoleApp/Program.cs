using ConsoleApp.Dto;
using ConsoleApp.SqlServer;
using SimpleNet.Core.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        public const string CONNECTION_STRING = @"Server=.\SQLEXPRESS;Database=AdventureWorks2012;Trusted_Connection=True;";


        static IRowMapper<Person> PERSON_MAPPER = MapBuilder<Person>.BuildAllProperties();

        public static void Main(string[] args)
        {
            const string SQL = @"SELECT * FROM Person.Person WHERE LastName = @LastName ";

            var db = new SqlServerProvider(CONNECTION_STRING);

            var dal = new SimpleNet.Core.Data.Repository.SimpleDataAccessLayer(db);

            var parameters = new[]
            {
                db.GetParameter("@LastName", "Miller")
            };

            var records = dal.ReadAsync<Person>(PERSON_MAPPER, SQL, CommandType.Text, parameters).Result;



        }
    }
}
