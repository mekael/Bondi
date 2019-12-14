using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OldSkoul.Entities.Queries;
using OldSkoul.Entities.Results;
using OldSkoul.Logic;

namespace OldSkoul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueThumbnailController : ControllerBase
    {
        private readonly ILogger<IssueThumbnailController> _logger;
        IssueThumbnailQueryHandler _issueThumbnailQueryHandler;
        public IssueThumbnailController(ILogger<IssueThumbnailController> logger, IssueThumbnailQueryHandler issueThumbnailQueryHandler)
        {
            _logger = logger;
            _issueThumbnailQueryHandler = issueThumbnailQueryHandler;
        }


         
        [HttpGet]
        public IEnumerable<IssueThumbnailResult> Get(IssueThumbnailQuery issueThumbnailQuery)
        {
            return _issueThumbnailQueryHandler.Handle(1); 
        }
 

    }
}
