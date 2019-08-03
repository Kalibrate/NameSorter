using Microsoft.AspNetCore.Mvc;
using NameSorter.Business;
using System.Collections.Generic;
using System.IO;


namespace NameSorter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISorter _sorter;

        public ValuesController (ISorter sorter)
        {
            _sorter = sorter;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var data = _sorter.SortingList();
            return Ok(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

    }
}
