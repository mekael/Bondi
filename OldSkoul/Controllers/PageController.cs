using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OldSkoul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {



        [HttpGet]
        public IEnumerable<string> Get(int pageId)
        {
            return new string[] { "value1", "value2" };
        }

       
    }
}
