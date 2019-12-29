using OldSkoulDesktop.Entities;
using OldSkoulDesktop.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OldSkoulDesktop.Pages
{
    /// <summary>
    /// Interaction logic for Issue.xaml
    /// </summary>
    public partial class Issue : Page
    {

        List<IssuePage> issuePages = new List<IssuePage>();
        List<IssueArticle> issueArticles = new List<IssueArticle>(); 

        public Issue(int issueId)
        {
            InitializeComponent();
            LoadIssue(issueId);
        }

        void LoadIssue(int issueId)
        {

            this.issuePages = new Logic.IssuePageLoadHandler().Handle(issueId);
            this.issueArticles = new IssueArticleInformationLoadHandler().Handle(issueId);

            this.IssuePageListView.ItemsSource = issuePages;
            this.PageImage.Source = new BitmapImage(new Uri(issuePages.Where(w => w.CoverIndicator).First().FullSizedPageFilePath));

            this.IssueContentsListView.ItemsSource = issueArticles;
        }

        private void ClickIssuePageEventHandler(object sender, MouseButtonEventArgs e)
        {
            var pageId = int.Parse(((Grid)sender).Tag.ToString()) ;
            this.PageImage.Source = new BitmapImage(new Uri(issuePages.Where(w => w.PageId == pageId).First().FullSizedPageFilePath));
            GC.Collect();
        }
    }
}
