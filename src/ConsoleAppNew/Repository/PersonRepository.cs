using ConsoleAppNew.Dto;
using SimpleNet.Core.Data.Mappers;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace ConsoleAppNew.Repository
{
    public class PersonRepository : BaseRepository
    {
        static IRowMapper<Person> PERSON_MAPPER = MapBuilder<Person>.BuildAllProperties();


        public async Task<IList<Person>> Find(string lastName)
        {
            const string SQL = @" SELECT * FROM Person.Person WHERE LastName like @LastName ";

            return await ReadAsync<Person>(PERSON_MAPPER, SQL, CommandType.Text, new DbParameter[]
            {
                GetParameter("@LastName", $"{lastName}%")
            });
        }


    }
    
}
