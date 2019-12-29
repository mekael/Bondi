using Dapper;
using OldSkoulDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace OldSkoulDesktop.Logic
{
   public class IssuePageLoadHandler
    {
        public List<IssuePage> Handle(int issueId) {

            // Get all of the articles for the issue
            // Get a list of all of the pages, load their thumbnails, and get the  
            IDbConnection dbConnection = new SQLiteConnection("Data Source=D:\\MyDocuments\\ny-sqlite-3.db;Version=3");
            dbConnection.Open();

            List<IssuePage> issuePages = new List<IssuePage>();

            DynamicParameters dp = new DynamicParameters(new Dictionary<string, object>() { { "@issueId", issueId } });

            List<IssuePage> rawIssuePages = dbConnection.Query<IssuePage>(      " Select i.IssueID, " +
                                                                                " p.PageID, " +
                                                                                " p.Offset as PageNumber, " +
                                                                                " m.StorageFolderPath || p.ThumbnailFilePath as ThumbnailFilePath, " +
                                                                                " m.StorageFolderPath || p.PageFilePath as FullSizedPageFilePath," +
                                                                                " p.CoverIndicator, " +
                                                                                " null as ThumbnailImageSource " +
                                                                                " from Pages P, " +
                                                                                " Issues i, " +
                                                                                " Magazines m " +
                                                                                " where p.IssueID=i.IssueId " +
                                                                                " and m.MagazineId = i.MagazineId " +
                                                                                " and i.IssueId = @issueId ", dp  ).ToList();

            foreach(var rawPage in rawIssuePages)
            {
                // only load a page into the final list if it has both a thumbnail and an actual page
                if(File.Exists(rawPage.FullSizedPageFilePath) && File.Exists(rawPage.ThumbnailFilePath))
                {
                    rawPage.ThumbnailImageSource = new BitmapImage(new Uri(rawPage.ThumbnailFilePath));
                    issuePages.Add(rawPage);
                }  

            }

            return issuePages;
        }
    }
}
