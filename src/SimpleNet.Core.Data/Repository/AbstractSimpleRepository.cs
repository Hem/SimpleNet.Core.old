using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using System.Threading.Tasks;
using SimpleNet.Core.Data.Mappers;

namespace SimpleNet.Core.Data.Repository
{
    public abstract class AbstractSimpleRepository
    {
        public abstract ISimpleDataAccessLayer Database { get; set; }

        

        protected DbParameter GetParameter(string name, object value)
        {
            return Database.DatabaseProvider.GetParameter(name, value);
        }
        protected DbParameter GetParameter(string name, object value, ParameterDirection direction)
        {
            return Database.DatabaseProvider.GetParameter(name, value, direction);
        }



        protected async Task<IList<T>> ReadAsync<T>(IRowMapper<T> mapper, string commandText, 
                                                CommandType commandType, DbParameter[] parameters)
        {
            return await Database.ReadAsync(mapper, commandText, commandType, parameters);
        }

        protected async Task<IList<T>> ReadAsync<T>(DbConnection connection, IRowMapper<T> mapper, string commandText, 
                                                CommandType commandType, DbParameter[] parameters, DbTransaction transaction = null)
        {
            return await Database.ReadAsync(connection, mapper, commandText, commandType, parameters, transaction);
        }

        protected async Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, DbParameter[] parameters)
        {
            return await Database.ExecuteNonQueryAsync(commandText, commandType, parameters);
        }

        protected async Task<int> ExecuteNonQueryAsync(    DbConnection connection, string commandText, CommandType commandType, 
                                                        DbParameter[] parameters, DbTransaction transaction = null )
        {
            return await Database.ExecuteNonQueryAsync(connection, commandText, commandType, parameters, transaction);
        }

        protected async Task<object> ExecuteScalarAsync(string commandText, CommandType commandType, DbParameter[] parameters)
        {
            return await Database.ExecuteScalarAsync(commandText, commandType, parameters);
        }

        protected async Task<object> ExecuteScalarAsync(   DbConnection connection, string commandText, CommandType commandType, 
                                                        DbParameter[] parameters, DbTransaction transaction = null)
        {
            return await Database.ExecuteScalarAsync(connection, commandText, commandType, parameters, transaction);
        }
    }
}
