using System;
using System.IO;
using System.Collections.Generic;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = "0";
            if(args != null && args.GetLength(0) > 0) {
                day = args[0];
            }
            switch (day)
            {
                case "1":
                    RunDay1();        
                    break;
                case "2":
                    RunDay2();
                    break;
                case "3":
                    RunDay3();
                    break;
                case "4":
                    RunDay4();
                    break;
                case "5":
                    RunDay5();
                    break;
                case "6":
                    RunDay6();
                    break;
                default:
                    Console.WriteLine("Not implemented.");
                    break;
            }
        }

        private static void RunDay1() {
            Console.WriteLine("Day1:");
            List<int> expenses = ReadFileByLineAsInt(".//Day1//input");
            Day1 day1 = new Day1(expenses);
            int result = day1.Execute();
            Console.WriteLine(day1.Expense1.ToString() + " * " + day1.Expense2.ToString() + " * " + day1.Expense3.ToString() + " = " + result.ToString());
        }

        private static void RunDay2() {
            Console.WriteLine("Day2:");
            List<string> passwords = ReadFileByLineAsString(".//Day2//input");
            Day2 day2 = new Day2(passwords);
            int validPasswords = day2.Exceute();
            Console.WriteLine("Valid Passwords in input: " + validPasswords.ToString());
        }

        public static void RunDay3() {
            Console.WriteLine("Day3:");
            List<string> areaString = ReadFileByLineAsString(".//Day3//input");
            Day3 day3 = new Day3(areaString);
            Int64 endResult = 0;
            endResult = day3.Execute(1, 1);
            endResult *= day3.Execute(3, 1);
            endResult *= day3.Execute(5, 1);
            endResult *= day3.Execute(7, 1);
            endResult *= day3.Execute(1, 2);
            
            Console.WriteLine(endResult.ToString());
        }

        public static void RunDay4() {
            Console.WriteLine("Day4:");
            List<string> input = ReadFileByMultipleLinesAsString(".//Day4/input", "");
            Day4 day4 = new Day4(input);
            int count = day4.Execute();
            Console.WriteLine("Valid Passports: "+count.ToString());
        }

        public static void RunDay5() {
            Console.WriteLine("Day5:");
            List<string> input = ReadFileByLineAsString(".//Day5/input");
            Day5 day5 = new Day5(input);
            int highestSeatId = day5.Execute();
            Console.WriteLine("Highest SeatId: "+ highestSeatId.ToString());
            int mySeat = day5.MySeat();
            Console.WriteLine("My Seat: "+ mySeat.ToString());
        }

        public static void RunDay6() {
            Console.WriteLine("Day6: ");
            List<string> input = ReadFileByMultipleLinesAsString(".//Day6/input", "");
            Day6 day6 = new Day6(input);
            int count = day6.Execute();
            Console.WriteLine("Sum of questions answered yes: "+count.ToString());

        }

        private static List<int> ReadFileBySeperator(string location, string seperator) {
            List<int> input = new List<int>();
            StreamReader reader = new StreamReader(location);
            string line = String.Empty;
            while((line = reader.ReadLine()) != null) {
                string[] s = line.Split(seperator);
                for(int i=0; i<s.Length; i++) {
                    input.Add(int.Parse(s[i]));
                }
            }
            return input;
        }

        private static List<int> ReadFileByLineAsInt(string location) {
            List<int> input = new List<int>();
            StreamReader reader = new StreamReader(location);
            string line = String.Empty;
            while((line = reader.ReadLine()) != null) {
                input.Add(int.Parse(line));               
            }
            return input;
        }

        private static List<string> ReadFileByLineAsString(string location) {
            List<string> input = new List<string>();
            StreamReader reader = new StreamReader(location);
            string line = String.Empty;
            while((line = reader.ReadLine()) != null) {
                input.Add(line);               
            }
            return input;
        }

        private static List<string> ReadFileByMultipleLinesAsString(string location, string seperator) {
            List<string> input = new List<string>();
            StreamReader reader = new StreamReader(location);
            string line = String.Empty;
            string combinedLine = String.Empty;
            while((line = reader.ReadLine()) != null) {
                if(line.Equals(String.Empty)) {
                    input.Add(combinedLine);
                    combinedLine = String.Empty;
                } else {
                    combinedLine = combinedLine + " " + line;
                }
            }
            input.Add(combinedLine);
            return input;            
        }
    }
}
