using System.Data;
using System.Data.Common;
using SimpleNet.Core.Data.Contracts;
using System.Data.SqlClient;

namespace ConsoleApp.SqlServer
{
    public class SqlServerProvider : ISimpleDatabaseProvider
    {
        readonly string ConnectionString;

        public SqlServerProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public DbCommand GetCommand()
        {
            return new SqlCommand();
        }


        public DbParameter GetParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        public DbParameter GetParameter(string name, object value, ParameterDirection direction)
        {
            return new SqlParameter(name, value) { Direction = direction };
        }
    }
}
