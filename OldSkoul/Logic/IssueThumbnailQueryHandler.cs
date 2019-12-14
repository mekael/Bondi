using OldSkoul.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using OldSkoul.Entities.Results;


namespace OldSkoul.Logic
{
    public class IssueThumbnailQueryHandler
    {
        ApplicationDbContext _applicationDbContext;

        public IssueThumbnailQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            
        }

        public List<IssueThumbnailResult> Handle(int magazineId, int year = 0)
        {

            List<IssueThumbnailResult> issueThumbnailResults = new List<IssueThumbnailResult>();
            try
            {

                var results = _applicationDbContext.Pages.Where(w => w.Folio == "CV1" && w.Issue.MagazineId == magazineId)
                                                          .Select(s => new { s.IssueId, s.Issue.Magazine.MagazineRootFolderPath, s.Issue.IssueFolderPath, s.ThumbnailFilePath, s.Issue.PublishedOnDate });


                results = year != 0 ? results.Where(w => w.PublishedOnDate.Year == year) : results;

                foreach (var result in results)
                {
                    var fullThumbnailFilePath = Path.Combine(result.MagazineRootFolderPath, result.IssueFolderPath, result.ThumbnailFilePath);
                    var thumbnailByteArray = File.ReadAllBytes(fullThumbnailFilePath);
                    issueThumbnailResults.Add(new IssueThumbnailResult()
                    {
                        IssueId = result.IssueId,
                        PublishedDate = result.PublishedOnDate,
                        Thumbnail = thumbnailByteArray
                    });
                }

            }
            catch (Exception ex)
            {

            }

            return issueThumbnailResults;
        }

    }
}
