using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SimpleNet.Core.Data.SqlServer
{
    public class SqlServerProvider : ISimpleDatabaseProvider
    {
        readonly string _connectionString;

        public SqlServerProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            var conn = new SqlConnection(_connectionString);
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
