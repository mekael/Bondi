using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Models
{
    public class Page : BaseModel
    {
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public string Folio { get; set; }
        public int Offset { get; set; }
        public string PageFilePath { get; set; }
        public string ThumbnailFilePath { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
