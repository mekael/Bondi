using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Entities.Models
{
    public class Article : BaseModel
    {
        public int PageId { get; set; }
        public Page Page { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? AuthorId { get; set; }
        public Author Author { get; set; }

        public string Title { get; set; }
        public string Byline { get; set; }
        public string Abstract { get; set; }
        public bool IsDuplicate { get; set; }
    }
}
