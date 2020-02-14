using TDD101.Workshops.CRUD.CQRS.Framework;

namespace TDD101.Workshops.CRUD.CQRS
{
    public class CreatePerson : DatabaseCommand<int>
    {
        public Person Person { get; }

        public CreatePerson(
            Person person)
        {
            Person = person;
        }

        public override int Execute()
        {
            return Exec<int>(
                "insert into people (first_name, last_name, email) values (@FirstName, @LastName, @Email); select LAST_INSERT_ID();",
                new
                {
                    Person.FirstName,
                    Person.LastName,
                    Person.Email
                });
        }

        public override void Validate()
        {
            // some basic validations
            AssertIsSet(Person, nameof(Person));
            AssertIsSet(Person.Email, nameof(Person.Email));
            AssertIsSet(Person.FirstName, nameof(Person.FirstName));
            AssertIsSet(Person.LastName, nameof(Person.LastName));
        }
    }
}