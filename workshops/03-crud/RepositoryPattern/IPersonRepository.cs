using System.Collections.Generic;

namespace TDD101.Workshops.CRUD.RepositoryPattern
{
    public interface IPersonRepository
    {
        int Create(Person person);
        IEnumerable<Person> FindAll();
        Person FindById(int id);
        void Update(Person person);
        void Delete(int id);
    }
}