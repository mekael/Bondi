using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OldSkoulDesktop.Entities;
using Dapper;


namespace OldSkoulDesktop.Logic
{
    public class IssueArticleInformationLoadHandler
    {


        public List<IssueArticle> Handle(int issueId)
        {

            IDbConnection dbConnection = new SQLiteConnection("Data Source=D:\\MyDocuments\\ny-sqlite-3.db;Version=3");
            dbConnection.Open();

            DynamicParameters dp = new DynamicParameters(new Dictionary<string, object>() { { "@issueId", issueId } });

            List<IssueArticle> issueArticles = dbConnection.Query<IssueArticle>(    " SELECT " +
                                                                                    " a.ArticleID, " +
                                                                                    " a.IssueID, " +
                                                                                    " a.PageID, " +
                                                                                    " a.RubricID, " +
                                                                                    " a.AuthorID, " +
                                                                                    " i.IssueDate, " +
                                                                                    " p.Folio, " +
                                                                                    " a.Title, " +
                                                                                    " a.Byline, " +
                                                                                    " aa.Abstract, " +
                                                                                    " u.Author, " +
                                                                                    " r.Rubric, " +
                                                                                    " k.Keywords " +
                                                                                    " from Articles A " +
                                                                                    " inner join Pages p  on a.PageID=p.PageID " +
                                                                                    " inner join issues i on a.IssueID = i.IssueID " +
                                                                                    " INNER join ArticleAbstracts aa on aa.AbstractID= a.AbstractID " +
                                                                                    " inner join Authors u on a.AuthorID=u.AuthorID " +
                                                                                    " inner join Rubrics r on r.RubricID = a.RubricID " +
                                                                                    " inner join  ( select akm.ArticleID , " +
                                                                                    "                     group_concat(k.Keyword, '; ') as Keywords " +
                                                                                    "              from ArticleKeywordMap akm " +
                                                                                    "                   inner join Keywords k on akm.KeywordID = k.KeywordID " +
                                                                                    "              group by akm.ArticleID ) k on k.ArticleID = a.ArticleID " +
                                                                                    " where a.IssueId= @issueId", dp).ToList();




            return issueArticles;

        }
    }
}
