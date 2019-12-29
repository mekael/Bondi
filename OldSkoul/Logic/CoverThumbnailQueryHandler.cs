using OldSkoul.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using OldSkoul.Entities.Results;
using OldSkoul.Entities.Queries;
using Microsoft.Extensions.Logging;
using NLog;

namespace OldSkoul.Logic
{
    public class CoverThumbnailQueryHandler
    {
        ApplicationDbContext _applicationDbContext;
        Logger _logger;
        public CoverThumbnailQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public List<CoverThumbnailResult> Handle(CoverThumbnailQuery issueThumbnailQuery)
        {

            List<CoverThumbnailResult> coverThumbnailResults = new List<CoverThumbnailResult>();
            try
            {

                var results = _applicationDbContext.Pages.Where(w => w.IsCoverPage && w.Issue.MagazineId == issueThumbnailQuery.MagazineId)
                                                          .Select(s => new { s.IssueId, s.Issue.Magazine.MagazineRootFolderPath, s.Issue.IssueFolderPath, s.ThumbnailFilePath, s.Issue.PublishedOnDate });

                if (issueThumbnailQuery.IssueYear.HasValue)
                {
                    results = results.Where(w => w.PublishedOnDate.Year == issueThumbnailQuery.IssueYear.Value);
                }


                foreach (var result in results)
                {
                    var fullThumbnailFilePath = (result.MagazineRootFolderPath + result.IssueFolderPath + result.ThumbnailFilePath);

                    coverThumbnailResults.Add(new CoverThumbnailResult()
                    {
                        IssueId = result.IssueId,
                        PublishedOnDate = result.PublishedOnDate,
                        Thumbnail = File.ReadAllBytes(fullThumbnailFilePath)
                    });
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Exception while attempting to obtain thumbails for magazine id {0}", issueThumbnailQuery.MagazineId);
            }

            return coverThumbnailResults;
        }

    }
}
