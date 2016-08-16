using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using System.Threading.Tasks;
using SimpleNet.Core.Data.Mappers;

namespace SimpleNet.Core.Data.Repository
{
    public abstract class AbstractSimpleRepository
    {

        private readonly ISimpleDataAccessLayer _db;


        protected AbstractSimpleRepository(ISimpleDatabaseProvider provider)
                        :this(new SimpleDataAccessLayer(provider))
        {
        }
        protected AbstractSimpleRepository(ISimpleDataAccessLayer db)
        {
            _db = db;
        }


        protected DbParameter GetParameter(string name, object value)
        {
            return _db.DatabaseProvider.GetParameter(name, value);
        }
        protected DbParameter GetParameter(string name, object value, ParameterDirection direction)
        {
            return _db.DatabaseProvider.GetParameter(name, value, direction);
        }



        protected async Task<IList<T>> ReadAsync<T>(IRowMapper<T> mapper, string commandText, 
                                                CommandType commandType, DbParameter[] parameters)
        {
            return await _db.ReadAsync(mapper, commandText, commandType, parameters);
        }

        protected async Task<IList<T>> ReadAsync<T>(DbConnection connection, IRowMapper<T> mapper, string commandText, 
                                                CommandType commandType, DbParameter[] parameters, DbTransaction transaction = null)
        {
            return await _db.ReadAsync(connection, mapper, commandText, commandType, parameters, transaction);
        }

        protected async Task<int> ExecuteNonQueryAsync(string commandText, CommandType commandType, DbParameter[] parameters)
        {
            return await _db.ExecuteNonQueryAsync(commandText, commandType, parameters);
        }

        protected async Task<int> ExecuteNonQueryAsync(    DbConnection connection, string commandText, CommandType commandType, 
                                                        DbParameter[] parameters, DbTransaction transaction = null )
        {
            return await _db.ExecuteNonQueryAsync(connection, commandText, commandType, parameters, transaction);
        }

        protected async Task<object> ExecuteScalarAsync(string commandText, CommandType commandType, DbParameter[] parameters)
        {
            return await _db.ExecuteScalarAsync(commandText, commandType, parameters);
        }

        protected async Task<object> ExecuteScalarAsync(   DbConnection connection, string commandText, CommandType commandType, 
                                                        DbParameter[] parameters, DbTransaction transaction = null)
        {
            return await _db.ExecuteScalarAsync(connection, commandText, commandType, parameters, transaction);
        }
    }
}
