using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace RollingStoneConverter
{
    public class ConverterOptions
    {
        [Option("inputFolder", Required = true)]
        public string InputFolderPath { get; set; }

        [Option("outputFolder", Required = true)]
        public string OutputFolderPath { get; set; }
        
        [Option("userName", Required = true)]
        public string UserName { get; set; }
        
        [Option("password", Required = true)]
        public string Password { get; set; }

        [Option("magazine", Required =true)]
        public string Magazine { get; set; }
    }
}
