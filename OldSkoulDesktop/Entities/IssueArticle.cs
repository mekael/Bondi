using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSkoulDesktop.Entities
{
    public class IssueArticle
    {
        public int ArticleID { get; set; }
        public int IssueID { get; set; }
        public int PageID { get; set; }
        public int RubricID { get; set; }
        public int AuthorId { get; set; }
        public DateTime IssueDate { get; set; }
        public string Folio { get; set; }
        public string Title { get; set; }
        public string Byline { get; set; }
        public string Abstract { get; set; }
        public string Author { get; set; }
        public string Rubric { get; set; }
   
    }
}