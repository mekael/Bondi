using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.IO;
using System.Runtime.Caching;
using OldSkoulDesktop.Entities;

namespace OldSkoulDesktop.Pages
{
    /// <summary>
    /// Interaction logic for IssueIndex.xaml
    /// </summary>
    public partial class IssueIndex : Page
    {

        List<IssueIndexItem> issueIndexItems = new List<IssueIndexItem>();

        public IssueIndex()
        {
            InitializeComponent();
            LoadThumbnailImages();
        }


        void LoadThumbnailImages() {

            ObjectCache cache = MemoryCache.Default;
            this.IssueList.ItemsSource = (List<IssueIndexItem>)cache.Get("IssueIndexItems");
        }

      
        private void ClickIssueEventHandler(object sender, MouseButtonEventArgs e)
        {        
            var issueId =  int.Parse(((Grid)sender).Tag.ToString());
            NavigationService.Navigate(new Pages.Issue(issueId));
        }
  
    }
}
