using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OldSkoulDesktop.Entities
{
    public class IssueIndexItem
    {
        public int IssueId { get; set; }
        public int IssueCoverPageId { get; set; }
        public string ThumbnailFilePath { get; set; }
        public string IssuePublicationDate { get; set; }
        public ImageSource ImageSource { get; set; }
    }
}
