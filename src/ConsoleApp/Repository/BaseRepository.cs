using SimpleNet.Core.Data.Repository;
using SimpleNet.Core.Data.SqlServer;

namespace ConsoleApp.Repository
{
    public class BaseRepository : AbstractSimpleRepository
    {
        static string CONNECTION_STRING = string.Empty;

        static BaseRepository()
        {
            CONNECTION_STRING = @"Server=.\SQLEXPRESS;Database=AdventureWorks2012;Trusted_Connection=True;";
        }


        // Yes! I know the connection string should be injected...
        protected BaseRepository() : base(new SqlServerProvider(CONNECTION_STRING))
        {

        }
    }
}
