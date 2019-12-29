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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ThumbnailController : ControllerBase
    {
        private readonly ILogger<ThumbnailController> _logger;
        CoverThumbnailQueryHandler _coverThumbnailQueryHandler;
        IssuePagesThumbnailQueryHandler _issuePagesThumbnailQueryHandler;


        public ThumbnailController(ILogger<ThumbnailController> logger,
                                   CoverThumbnailQueryHandler coverThumbnailQueryHandler,
                                   IssuePagesThumbnailQueryHandler issuePagesThumbnailQueryHandler)
        {
            _logger = logger;
            _coverThumbnailQueryHandler = coverThumbnailQueryHandler;
            _issuePagesThumbnailQueryHandler = issuePagesThumbnailQueryHandler;
        }


        [HttpGet]
        public IEnumerable<CoverThumbnailResult> CoverThumbnails([FromQuery] CoverThumbnailQuery issueThumbnailQuery)
        {
            return _coverThumbnailQueryHandler.Handle(issueThumbnailQuery);
        }

        [HttpGet]
        public IEnumerable<IssuePageResult> IssuePageThumbnails(int issueId)
        {
            return _issuePagesThumbnailQueryHandler.Handle(issueId);
        }

    }
}
