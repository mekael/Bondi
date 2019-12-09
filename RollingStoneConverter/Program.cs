using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;


namespace RollingStoneConverter
{
    class Program
    {
       static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ConverterOptions>(args)
                                        .WithParsed<ConverterOptions>(opts => RunOptionsAndReturnExitCode(opts))
                                        .WithNotParsed<ConverterOptions>((errs) => HandleParseError(errs));
        }

        static void RunOptionsAndReturnExitCode(ConverterOptions converterOptions)
        {
            logger.Info("Starting to process issues in the folder {0}", converterOptions.OutputFolderPath);

            var issues = Directory.GetFiles(converterOptions.InputFolderPath).Where(s=> s.ToLower().EndsWith("djvu")).ToList();

            if(issues.Count() != 0) {
                logger.Info("{0} issuess found", issues.Count());
                for (int i = 0; i < issues.Count(); i++)
                {
                    IssueConversionHandler rollingStoneIssueConversionHandler = new IssueConversionHandler();
                    rollingStoneIssueConversionHandler.Handle(issues[i], converterOptions.OutputFolderPath, converterOptions.UserName, converterOptions.Password);
                }

            }
            else
            {
                logger.Error("No issue data found, exiting.");
            }



        }
        static void HandleParseError(IEnumerable<Error> errors)
        {

            //maybe do something? 
        }
    }
}
