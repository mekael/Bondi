using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Models
{
    public class Magazine : BaseModel
    {
        public string MagazineName { get; set; }
        public string MagazineRootFolderPath { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }

    }
}
