using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();
            context.Database.EnsureCreated();

            Console.WriteLine("Successfully created!");

            context.Database.EnsureDeleted();
        }
    }
}
