using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Company.Fleet.Infra.Singleton;

namespace Company.Fleet.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SingletonController : ControllerBase
    {
        private readonly SingletonContainer singletonContainer;

        public SingletonController(SingletonContainer singletonContainer)
        {
            this.singletonContainer = singletonContainer;
        }
        
        [HttpGet("GetWithSingletonContainer/")]
        public IActionResult GetWithSingletonContainer()
        {
            var singleton = singletonContainer;
            return Ok(singletonContainer);
        }

        [HttpGet("GetWithoutSingleton/")]
        public IActionResult GetWithoutSingleton()
        {
            var singleton = new WithoutSingleton();
            return Ok(singleton);
        }

        [HttpGet("GetWithSingleton/")]
        public IActionResult GetWithSingleton()
        {
            var singleton = WithSingleton.Instance;
            return Ok(singleton);
        }


    }
}
