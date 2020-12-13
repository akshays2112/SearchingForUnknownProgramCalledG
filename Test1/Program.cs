using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Searching C Drive\n");
            FindFile(@"C:\");
            Console.WriteLine("Searching D Drive\n");
            FindFile(@"D:\");
            Console.ReadLine();
        }

        static void FindFile(string dir)
        {
            try {
                Regex r = new Regex(@"(?<FileName>^[G][.].*)");
                IEnumerable<string> files = Directory.EnumerateFiles(dir);
                foreach (string fileName in files)
                {
                    FileInfo fi = new FileInfo(fileName);
                    Match m = r.Match(fi.Name);
                    if(fi.Name == "G" || m.Groups["FileName"].Value.Length > 0)
                    {
                        Console.WriteLine("{0}", fileName);
                    }
                }
                IEnumerable<string> dirs = Directory.EnumerateDirectories(dir);
                foreach (string dirName in dirs)
                {
                    FindFile(dirName);
                }
            }
            catch {
                Console.WriteLine("Not allowed to access: {0}\n", dir);
            }
        }
    }
}
