using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace NewYorkerConverter
{
    public class ConverterOptions 
    {
        [Option("inputFolder", Required =true)]
        public string InputFolderPath { get; set; }
        [Option("outputFolder", Required =true)]
        public string OutputFolderPath { get; set; }

    }
}
