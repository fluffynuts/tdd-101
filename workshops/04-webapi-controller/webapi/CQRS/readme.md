# Very Basic CQRS framework

CQRS stands for Command Query Responsibility Separation.

The idea is that queries only _ask for data_ and commands _mutate data_. This isn't enforced
in framework code (at least not in this simplistic implementation, and it's not trivial to enforce
for real -- one way would be to have a read-only user and a write-capable user at the database
and have two connection strings, selecting the correct one for the purpose) but can be "enforced"
via code review and coding standards.

## The parts

- `IQuery<T>`
    - the interface for a query 
        - does not have to be a database query!
            - could query an api
        - always returns something
    - queries should only _read_ data, not mutate it
- `ICommand<T>`
    - the interface for a command 
        - does not have to be database-connected!
            - could POST to an api, for example
        - normally returns something simple like a status or an id
            - could "return void" and just throw on error though
            - let's keep it simple here (:
    - commands are expected to mutate data
        - they may need to perform queries too
 - `CommandExecutor` and `QueryExecutor`
    - responsible for executing commands and queries
    - ensure validation is run
    - if read-only operations were to be enforced, it would happen in the QueryExecutor
    - often have the capability to fire events (eg start / complete / error of command / query)
        - useful for event-store systems
        - not implemented here (keeping it simple)
 - `DatabaseCommand` and `DatabaseQuery`
    - abstract classes to provide the plumbing for database-connected commands and queries
    
