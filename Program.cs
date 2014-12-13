using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // variable for input and output file name reside in the same directory of .exe
            string inputfile = "input.txt";
            string outputfile = "output.txt";
            // list to store lines to be read in
            List<string> lines = new List<string>();

            // initialize ReaderWriter
            ReaderWriter rw = new ReaderWriter(inputfile, outputfile);
            // read lines from inputfile
            lines = rw.Read();
            // initialize command processor
            CommandProcessor cp = new CommandProcessor();
            // process each command in the list
            for (int i = 0; i < lines.Count; i++)
            {
                cp.Process(lines[i]);
            }

            // pause before quiting
            Console.WriteLine("Program executed successfully, press any key to quit ... ");
            Console.ReadLine();
        }
    }
}
