using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Results
{
    public class IssuePageResult
    {
        public int IssueId { get; set; }
        public int PageId { get; set; }
        public byte[] PageThumbnail { get; set; }
    }
}
