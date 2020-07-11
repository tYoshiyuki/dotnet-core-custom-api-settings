using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2ToCore.Controllers.V1
{
    public class HelloController : ControllerBase
    {
        // Hello/Get
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "hello1", "hello2" };
        }

        // Hello/Get/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            return new[] { $"hello{id}" };
        }
    }
}
