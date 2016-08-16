using ConsoleApp.Dto;
using SimpleNet.Core.Data.Mappers;
using SimpleNet.Core.Data.Repository;
using SimpleNet.Core.Data.SqlServer;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace ConsoleApp.Repository
{
    public class PersonRepository : BaseRepository
    {
        static IRowMapper<Person> PERSON_MAPPER = MapBuilder<Person>.BuildAllProperties();


        public async Task<IList<Person>> Find(string lastName)
        {
            const string SQL = @" SELECT * FROM Person.Person WHERE LastName = @LastName ";

            return await ReadAsync<Person>(PERSON_MAPPER, SQL, CommandType.Text, new DbParameter[]
            {
                GetParameter("@LastName", "Miller")
            });
        }


    }


    public class BaseRepository : AbstractSimpleRepository
    {
        const string CONNECTION_STRING = @"Server=.\SQLEXPRESS;Database=AdventureWorks2012;Trusted_Connection=True;";
        // Yes! I know the connection string should be injected...
        protected BaseRepository():base(new SqlServerProvider(CONNECTION_STRING))
        {

        }
    }
}
