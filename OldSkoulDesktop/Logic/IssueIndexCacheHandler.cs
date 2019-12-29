using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Dapper;
using System.Runtime.Caching;
using System.Data.SqlClient;
using System.Data;
using OldSkoulDesktop.Entities;
using System.Data.SQLite;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OldSkoulDesktop.Logic
{
    public class IssueIndexCacheHandler
    {

        public void Handle()
        {
            // first we check to see if we have already have cached the index. 
            ObjectCache cache = MemoryCache.Default;

            if (!cache.Contains("IssueIndexListing"))
            {


                List<IssueIndexItem> issueIndexItems = new List<IssueIndexItem>();
                 
                IDbConnection dbConnection   = new SQLiteConnection("Data Source=D:\\MyDocuments\\ny-sqlite-3.db;Version=3");
                dbConnection.Open();
                

                List<IssueIndexItem> rawIssueIndexItems = dbConnection.Query<IssueIndexItem>("select i.IssueID, " +
                    "p.PageID as IssueCoverPageId,m.StorageFolderPath || p.ThumbnailFilePath as ThumbnailFilePath, " +
                    "i.IssueDate as IssuePublicationDate " +
                    "from Pages P, " +
                    "Issues i, " +
                    "Magazines m " +
                    "where p.IssueID=i.IssueId " +
                    "and m.MagazineId = i.MagazineId " +
                    "and p.CoverIndicator = 1").ToList();

                foreach(var issueIndexItem in rawIssueIndexItems)
                {
                    if (File.Exists(issueIndexItem.ThumbnailFilePath))
                    {
                        issueIndexItem.ImageSource = new BitmapImage(new Uri(issueIndexItem.ThumbnailFilePath));
                        issueIndexItems.Add(issueIndexItem);
                    }

                }
                 
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();

                cache.Add("IssueIndexItems", issueIndexItems, cacheItemPolicy);
            }
            else
            {
                //no clue as of yet. 
            }

        }


    }
}

 