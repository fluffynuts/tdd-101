using System.Collections.Generic;
using TDD101.Workshops.WebApi.CQRS;
using TDD101.Workshops.WebApi.Models;

namespace TDD101.Workshops.WebApi.DataAccess
{
    public class FindPersonById: DatabaseQuery<Person>
    {
        public int Id { get; }

        public FindPersonById(int id)
        {
            Id = id;
            throw new System.NotImplementedException();
        }

        public override Person Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public class FindAllPeople : DatabaseQuery<IEnumerable<Person>>
    {
        public override IEnumerable<Person> Execute()
        {
            throw new System.NotImplementedException();
        }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}