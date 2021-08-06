using System.Collections.Generic;
using System;
using System.Linq;

namespace GenericBoxOfString
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //int elementsCount = int.Parse(Console.ReadLine());
            //var list = new List<int>();

            //for (int i = 0; i < elementsCount; i++)
            //{
            //    var input = int.Parse(Console.ReadLine());
            //    list.Add(input);
            //}

            //    //var box = new Box<int>(list);
            //    //var indexes = Console.ReadLine()
            //    //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    //    .Select(int.Parse)
            //    //    .ToArray();

            //    //box.Swap(list, indexes[0], indexes[1]);
            //    //Console.WriteLine(box);

            //    int numberOfLine = int.Parse(Console.ReadLine());
            //    var list = new List<double>();
            //    for (int i = 0; i < numberOfLine; i++)
            //    {
            //        double input = double.Parse(Console.ReadLine());
            //        list.Add(input);
            //    }

            //    var box = new Box<double>(list);
            //    double elementToCompare = double.Parse(Console.ReadLine());
            //    var count = box.CountOfGreaterElements(list, elementToCompare);
            //    Console.WriteLine(count);
            //

            //// Task 7 Tuple

            //var personInfo = Console.ReadLine().Split();
            //var fullName = $"{personInfo[0]} {personInfo[1]}";
            //var city = $"{personInfo[2]}";

            //var nameAndBeer = Console.ReadLine().Split();
            //var name = nameAndBeer[0];
            //var numberOfLiters = int.Parse(nameAndBeer[1]);

            //var numbersInput = Console.ReadLine().Split();
            //var intNum = int.Parse(numbersInput[0]);
            //var doubleNum = double.Parse(numbersInput[1]);

            //Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, city);
            //Tuple<string, int> secondTuple = new Tuple<string, int>(name, numberOfLiters);
            //Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);
            //Console.WriteLine(firstTuple);
            //Console.WriteLine(secondTuple);
            //Console.WriteLine(thirdTuple);

            // Task 8 threeuple

            string[] personInfo = Console.ReadLine().Split();
            string name = $"{personInfo[0]} {personInfo[1]}";
            string address = $"{personInfo[2]}";
            string city = null;
            if (personInfo.Length > 4)
            {
                for (int i = 3; i < personInfo.Length; i++)
                {
                    city += $"{personInfo[i]} ";
                }
            }
            else
            {
                city = personInfo[3];
            }
            city = city.TrimEnd();

            string[] secondLine = Console.ReadLine().Split();
            string nameSec = secondLine[0];
            int age = int.Parse(secondLine[1]);
            while (age % 10 == 0)
            {
                age = age / 10;
            }
            bool drunk = false;
            if (secondLine[2] != "not")
            {
                drunk = true;
            }

            string[] thirdLine = Console.ReadLine().Split();
            string nameThird = thirdLine[0];
            double accBalance = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];

            Tuple<string, string, string> firstTuple = new Tuple<string, string, string>(name, address, city);
            Tuple<string, int, bool> secondTuple = new Tuple<string, int, bool>(nameSec, age, drunk);
            Tuple<string, double, string> thirdTuple = new Tuple<string, double, string>(nameThird, accBalance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
