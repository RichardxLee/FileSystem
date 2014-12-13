using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystem
{
    class ReaderWriter
    {
        // declare variables
        private string inputfile = "";

        // constructor
        public ReaderWriter(string _inputfile, string _outputfile)
        {
            this.inputfile = _inputfile;
        }

        // function for reading from input file reside in the same directory of .exe
        public List<string> Read()
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(inputfile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}
