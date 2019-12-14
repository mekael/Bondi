using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Models
{
    public class Issue : BaseModel
    {
        public int MagazineId { get; set; }
        public Magazine Magazine { get; set; }
        public DateTime PublishedOnDate { get; set; }
        public int PageCount { get; set; }
        public string IssueFolderPath { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
