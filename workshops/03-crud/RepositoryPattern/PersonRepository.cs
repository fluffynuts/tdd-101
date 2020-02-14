using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Dapper;

namespace TDD101.Workshops.CRUD.RepositoryPattern
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Func<IDbConnection> _connectionFactory;

        public PersonRepository(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int Create(Person person)
        {
            using var connection = _connectionFactory();
            return connection.QueryFirst<int>(
                "insert into people (first_name, last_name, email) values (@FirstName, @LastName, @Email); select LAST_INSERT_ID();",
                new
                {
                    person.FirstName,
                    person.LastName,
                    person.Email
                }
            );
        }

        public IEnumerable<Person> FindAll()
        {
            throw new NotImplementedException();
        }

        public Person FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}