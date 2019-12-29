using MahApps.Metro.Controls;
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
using OldSkoulDesktop.Entities;
using System.IO;
using System.Deployment;
using System.Deployment.Application;
using System.Reflection;
using OldSkoulDesktop.Entities;

namespace OldSkoulDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        int currentIssue =1;


        public MainWindow()
        {
            InitializeComponent();
            InitialLoad();
        }

        void InitialLoad() {
            VersionNumber.Text = string.Format("Version: {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            new Logic.IssueIndexCacheHandler().Handle();
            this.MainApplicationFrame.Content = new Pages.IssueIndex();
        }





        private void Navigate(object sender, MouseButtonEventArgs e)
        {
            if (sender.GetType() == typeof(Label))
            {
                Label l = (Label)sender;

                if (l.Name == "ReadNavigate")
                {
                    this.MainApplicationFrame.Content = new Pages.Issue(currentIssue);
                }
                else if (l.Name == "IndexNavigate")
                {
                    this.MainApplicationFrame.Content = new Pages.IssueIndex();
                }
                else if (l.Name == "SearchNavigate")
                {
                    this.MainApplicationFrame.Content = new Pages.Search();
                }
                else if (l.Name == "SettingsNavigate")
                {
                    this.MainApplicationFrame.Content = new Pages.Settings();
                }
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationFlyout.IsOpen = true;
        }
    }
}
