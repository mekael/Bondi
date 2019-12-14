using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace NewYorkerConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ConverterOptions>(args)    
                                      .WithParsed<ConverterOptions>(opts => RunOptionsAndReturnExitCode(opts))
                                      .WithNotParsed<ConverterOptions>((errs) => HandleParseError(errs));
        }

        static void RunOptionsAndReturnExitCode(ConverterOptions converterOptions) {


           FMManagedLoader.MInitialize();

            var issues = Directory.GetFiles(converterOptions.InputFolderPath);

            for (int i = 0; i < issues.Count(); i++)
            { 
                    NewYorkerIssueConversionHandler newYorkerIssueConversionHandler = new NewYorkerIssueConversionHandler();
                    newYorkerIssueConversionHandler.Handle(issues[i], converterOptions.OutputFolderPath);
                 
            }

        }
        static void HandleParseError(IEnumerable<Error> errors) {
        
          //maybe do something? 
        }
   
    
    }
}
