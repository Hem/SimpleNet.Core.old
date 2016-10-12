using SimpleNet.Core.Data;
using SimpleNet.Core.Data.Repository;
using SimpleNet.Core.Data.SqlServer;

namespace ConsoleApp.Repository
{
    public class BaseRepository : AbstractSimpleRepository
    {
        public override ISimpleDataAccessLayer Database { get; set; }
        
        public BaseRepository()
        {
            const string CONNECTION_STRING = @"Server=.\SQLEXPRESS;Database=AdventureWorks2012;Trusted_Connection=True;";

            Database = new SimpleDataAccessLayer(new SqlServerProvider(CONNECTION_STRING));
        }
    }
}
