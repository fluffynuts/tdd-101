using System;
using System.Data;

namespace TDD101.Workshops.CRUD
{
    public class MySqlSimpleMigrator: IDisposable
    {
        private IDbConnection _connection;

        public MySqlSimpleMigrator(IDbConnection connection)
        {
            _connection = connection;
            MigrateUp();
        }

        private void MigrateUp()
        {
            using var cmd = _connection.CreateCommand();
            cmd.CommandText = @"
            create table people (
                id int primary key auto_increment not null, 
                first_name varchar(128), 
                last_name varchar(128), 
                email varchar(128)
            );
            ";
            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _connection = null;
        }
    }
}