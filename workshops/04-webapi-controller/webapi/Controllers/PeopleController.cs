using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TDD101.Workshops.WebApi.CQRS;
using TDD101.Workshops.WebApi.Models;

namespace TDD101.Workshops.WebApi.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public PeopleController(
            IQueryExecutor queryExecutor,
            ICommandExecutor commandExecutor
        )
        {
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        [Route("{id}")]
        [HttpGet]
        public Person Find(int id)
        {
            throw new NotImplementedException();
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Person> FindAll()
        {
            throw new NotImplementedException();
        }

        [Route("")]
        [HttpPut]
        public int Add(Person person)
        {
            throw new NotImplementedException();
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}