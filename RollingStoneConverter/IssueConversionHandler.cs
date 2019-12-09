using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingStoneConverter
{
    public class IssueConversionHandler
    {

        public void Handle(string issueFilePath, string outputFolderPath, string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(issueFilePath))
            {
                //error 
            }

            string fileName = Path.GetFileNameWithoutExtension(issueFilePath);
            string issueDate = fileName.Split('_')[1];

            string issueYear = issueDate.Substring(0, 4);
            string issueMonth = issueDate.Substring(4, 2);
            string issueOutputFolderPath = Path.Combine(outputFolderPath, issueYear, issueMonth, issueDate);

            if (!Directory.Exists(issueOutputFolderPath))
            {
                Console.WriteLine("Creating folder for issue {0} at {1}", issueDate, issueOutputFolderPath);
                Directory.CreateDirectory(issueOutputFolderPath);
            }
            var conversionActions = new BondiDJVUActions();
            conversionActions.Open(issueFilePath, userName, password);

            int pageCount = conversionActions.PageCount;

            Console.WriteLine("Starting to process issue {0}.", issueDate);
            Console.WriteLine("Issue {0} has {1} pages.", issueDate, pageCount);

       try
            {
                for (int i = 0; i < pageCount; i++)
                {
                    Console.WriteLine("Starting to process page {0} of issue {1}", i + 1, issueDate);

                   
                    var pageSize = conversionActions.GetPageSize(i); 

                    var height = pageSize.Height;
                    var width = pageSize.Width;

                    Console.WriteLine("Issue:{0} Page:{1} Height:{2} Width:{3}", issueDate, i + 1, height, width);

                     var pageFileName = string.Format("{0}.{1}", (i + 1), "jpeg");
                    var pageOutputFilePath = Path.Combine(issueOutputFolderPath, pageFileName);

                    Console.WriteLine("Issue:{0} Page:{1} OutputFilePath:{2}", issueDate, i + 1, pageOutputFilePath);
                    conversionActions.SavePageBitmap(pageOutputFilePath, i, width, height); 
                    
                    GC.Collect();
                }
            }
             catch (Exception ex)
            {
                //TODO: decide what the hell to do? 
                // maybe we just delete the folder and stop caring? 
            }

            conversionActions.Close(); 
        }
    }
}
