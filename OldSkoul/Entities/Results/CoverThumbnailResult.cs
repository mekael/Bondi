using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Results
{
    public class CoverThumbnailResult
    {
        public int IssueId { get; set; }
        public DateTime PublishedOnDate { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}
