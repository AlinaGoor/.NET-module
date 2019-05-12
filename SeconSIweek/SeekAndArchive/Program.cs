using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];
            Search.RecursiveFileSearch(fileName, directoryName);
        }
    }

    class Search
    {
        internal static void RecursiveFileSearch(string fileName, string directoryName)
        {
            DirectoryInfo di = new DirectoryInfo(directoryName);
            WalkdirectoryTree(di, fileName);
            Console.WriteLine("Press any key.");
            Console.ReadKey();

        }

        internal static void WalkdirectoryTree(DirectoryInfo rootDir, string fileName)
        {
            FileInfo[] files = null;
            try
            {
                files = rootDir.GetFiles(fileName);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }

            if (files != null)
            {
                foreach (var fileInfo in files)
                {
                    Console.WriteLine("\n The file  path of the requested file(s): {0}", fileInfo.FullName);
                }

                foreach (var subDir in rootDir.GetDirectories())
                {
                    WalkdirectoryTree(subDir, fileName);
                }
            }
        }
    }
}
