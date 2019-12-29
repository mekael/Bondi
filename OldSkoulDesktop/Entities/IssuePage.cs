using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OldSkoulDesktop.Entities
{
    public class IssuePage
    {
        public int IssueID { get; set; }
        public int PageId { get; set; }
        public string PageNumber { get; set; }
        public string ThumbnailFilePath { get; set; }
        public string FullSizedPageFilePath { get; set; }
        public bool CoverIndicator { get; set; }
        public ImageSource ThumbnailImageSource { get; set; }
    }
}
