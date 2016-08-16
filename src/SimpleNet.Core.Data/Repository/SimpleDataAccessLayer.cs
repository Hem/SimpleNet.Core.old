using SimpleNet.Core.Data.Contracts;
using SimpleNet.Core.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNet.Core.Data.Repository
{
    public class SimpleDataAccessLayer
    {
        internal readonly ISimpleDatabaseProvider Db;
        
        public SimpleDataAccessLayer(ISimpleDatabaseProvider db)
        {
            Db = db;
        }





        public async Task<IList<T>> ReadAsync<T>(       IRowMapper<T> mapper, 
                                                        string commandText, 
                                                        CommandType commandType,
                                                        DbParameter[] parameters  )
        {
            using (var connection = Db.GetConnection())
            {
                return await ReadAsync(connection, mapper, commandText, commandType, parameters);
            }
        }






        public async Task<IList<T>> ReadAsync<T>(   DbConnection connection, 
                                                    IRowMapper<T> mapper, 
                                                    string commandText, 
                                                    CommandType commandType,
                                                    DbParameter[] parameters, 
                                                    DbTransaction transaction = null  )
        {
            var records = new List<T>();

            using (var command = Db.GetCommand())
            {
                command.Connection = connection;
                command.CommandText = commandText;
                command.CommandType = commandType;
                
                if (transaction != null)
                    command.Transaction = transaction;
                
                // Add parameters
                if (parameters != null)
                    command.Parameters.AddRange(parameters.ToArray());

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        records.Add(mapper.MapRow(reader));
                    }
                }

                command.Parameters.Clear();
            }

            return records;
        }


    }
}
