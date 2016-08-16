using ConsoleApp.Dto;
using SimpleNet.Core.Data.Mappers;
using SimpleNet.Core.Data.SqlServer;
using System.Data;
using System.Data.Common;

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

            var parameters = new DbParameter[]
            {
                db.GetParameter("@LastName", "Miller")
            };

            var records = dal.ReadAsync<Person>(PERSON_MAPPER, SQL, CommandType.Text, parameters).Result;
            

        }



    }
}
