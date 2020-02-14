using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public abstract class DatabaseConsumer : Validator, IDatabaseConsumer
    {
        private IDbConnection _connection;
        protected IDbConnection Connection => ValidateConnection();

        public void Connect(IDbConnection connection)
        {
            _connection = connection;
        }

        private IDbConnection ValidateConnection()
        {
            if (_connection is null)
            {
                throw new InvalidOperationException("No connection provided");
            }

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection;
        }
        
        protected async Task<IEnumerable<TItem>> SelectMany<TItem>(
            string sql,
            object parameters)
        {
            return await Connection.QueryAsync<TItem>(sql, parameters);
        }

        protected async Task<TItem> SelectFirst<TItem>(
            string sql,
            object parameters)
        {
            return await Connection.QueryFirstAsync<TItem>(sql, parameters);
        }

    }
}