using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthAPI.Database;
using SimpleAuthAPI.Interfaces;
using SimpleAuthAPI.Models.LargeModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test1Controller : ControllerBase
    {
        private readonly ITest1Repository _repository;
    public Test1Controller(ITest1Repository repository)
    {
            _repository = repository;
    }
        // GET: api/<Test1Controller>
        [HttpGet]
        public List<Test1> Get()
        {
            return _repository.GetTest1();
        }

        // GET api/<Test1Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }                     
    }
}
