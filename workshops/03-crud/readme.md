# TDD for CRUD operations

The repository pattern is _one_ common mechanism for performing data operations. Another
is CQRS. Pick one of the below (or do both if you like).

## Common spec:

Given the following descriptor for a Person within a system:

- unique identifier
- first name
- last name
- email address

- Your data layer must be backed by a real data store.
- The choice of engine is irrelevant -- pick any storage mechanism you like, as long
    as your tests cover actually putting data into the storage, and getting data back out again
- For testing, you may find it really useful to use one of the PeanutButter.TempDb implementations.

## Repository workshop

Build whatever is necessary to implement a basic Repository pattern:

- Create(person) (should return the id)
- FindAll()
- FindById(id)
- Update(person)
- Delete(id)


## CQRS workshop

Build the necessary commands and queries to satisfy:

- CreatePerson
- FindAllPeople
- FindPersonById
- UpdatePersonDetails
- DeletePerson
