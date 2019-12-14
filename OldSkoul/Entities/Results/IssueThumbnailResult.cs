using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Results
{
    public class IssueThumbnailResult
    {
        public int IssueId { get; set; }
        public DateTime PublishedDate { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}
