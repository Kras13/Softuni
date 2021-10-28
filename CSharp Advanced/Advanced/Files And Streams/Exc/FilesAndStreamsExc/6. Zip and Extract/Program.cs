using System;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\MyFiles", @"C:\Test1\TestArchive.zip");
            ZipFile.ExtractToDirectory(@"C:\Test1\TestArchive.zip", @"C:\Test1");
        }
    }
}
