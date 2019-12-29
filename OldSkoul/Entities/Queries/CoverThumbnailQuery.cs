using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Queries
{
    public class CoverThumbnailQuery
    {
        public int MagazineId { get; set; }
        public int? IssueYear { get; set; }
    }
}
