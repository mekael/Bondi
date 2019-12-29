using Microsoft.Extensions.Logging;
using OldSkoul.Data;
using OldSkoul.Entities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace OldSkoul.Logic
{
    public class IssuePagesThumbnailQueryHandler
    {
        ApplicationDbContext _applicationDbContext;
        Logger _logger = LogManager.GetCurrentClassLogger();
        public IssuePagesThumbnailQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }


        public List<IssuePageResult> Handle(int issueId)
        {

            List<IssuePageResult> issuePageResults = new List<IssuePageResult>();

            try
            {
                var results = _applicationDbContext.Pages
                                                        .Where(w => w.IssueId == issueId)
                                                        .Select(s => new { PageId = s.Id, s.IssueId, s.Issue.Magazine.MagazineRootFolderPath, s.Issue.IssueFolderPath, s.ThumbnailFilePath })
                                                        .ToList();


                foreach (var result in results)
                {
                    var fullThumbnailFilePath = (result.MagazineRootFolderPath + result.IssueFolderPath + result.ThumbnailFilePath);

                    issuePageResults.Add(new IssuePageResult()
                    {
                        IssueId = result.IssueId,
                        PageId = result.PageId,
                        PageThumbnail = File.ReadAllBytes(fullThumbnailFilePath)

                    });
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Exception while attempting to get thumbnails for issue {0} : {1}", issueId, ex);
                throw;
            }

            return issuePageResults;
        }
    }
}
