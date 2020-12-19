using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace AoC2020
{
    class Program
    {
        private static Stopwatch sw;
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
                case "7":
                    RunDay7();
                    break;                    
                case "8":
                    RunDay8();
                    break;
                case "9":
                    RunDay9();
                    break;
                case "10":
                    RunDay10();
                    break;                                               
                case "11":
                    RunDay11();
                    break;
                case "12":
                    RunDay12();
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

        public static void RunDay7() {
            sw = new Stopwatch();

            Console.WriteLine("Day7: ");
            List<string> input = ReadFileByLineAsString(".//Day7/input");
            Day7 day7 = new Day7(input);

            sw.Start();
            day7.Execute("shiny gold bag");
            sw.Stop();
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));

            int count = day7.foundBagColors.Count;
            Console.WriteLine("No of Bag Colors that can contain one shine gold bag: "+ count.ToString());

            sw = new Stopwatch();
            sw.Start();
            int countPart2 = day7.ExecutePart2("shiny gold bag");
            sw.Stop();
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));

            Console.WriteLine("Bags required inside my bag: "+countPart2.ToString());
        }

        public static void RunDay8() {
            Console.WriteLine("Day8: ");
            List<string> input = ReadFileByLineAsString(".//Day8/input");
            Day8 day8 = new Day8(input);   
            int value = day8.Execute(); 
            //Console.WriteLine("Accumulator value before any second execution: "+value.ToString());
            Console.WriteLine("Accumulator after program terminates: "+value.ToString());
        }

        public static void RunDay9() {
            sw = new Stopwatch();
            Console.WriteLine("Day9:");
            List<Int64> input = ReadFileByLineAsInt64(".//Day9/input");
            sw.Start();
            Day9 day9 = new Day9(input);
            Int64 result = day9.Execute(25);
            sw.Stop();
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));
            Console.WriteLine("First number that doesn't sum to 2 pervious numbers: "+result.ToString());

            sw = new Stopwatch();
            sw.Start();
            Int64 weakness = day9.FindWeakness(result);
            sw.Stop();
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));
            Console.WriteLine("Encryption weakness: "+ weakness.ToString());
        }

        private static void RunDay10()
        {
            sw = new Stopwatch();
            Console.WriteLine("Day10:");
            List<int> input = ReadFileByLineAsInt(".//Day10/input");
            sw.Start();
            Day10 day10 = new Day10(input);
            int result = day10.Execute(0);
            sw.Stop();
            Console.WriteLine("1-jolt diff * 3-jolt diff = "+result.ToString());
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));
            
            sw = new Stopwatch();
            sw.Start();
            long distArr = day10.FindAllDistinctArrangements();
            sw.Stop();
            Console.WriteLine("Distinct Arrangements: "+ distArr.ToString());            
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));
        }

        private static void RunDay11()
        {
            sw = new Stopwatch();
            Console.WriteLine("Day11:");
            List<string> input = ReadFileByLineAsString(".//Day11/input");
            sw.Start();
            Day11 day11 = new Day11(input);
            int result = day11.Execute();
            sw.Stop();
            Console.WriteLine("Seats occupied: "+result.ToString());
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));
            
            sw = new Stopwatch();
            sw.Start();
            day11 = new Day11(input);
            result = day11.ExecutePart2();
            sw.Stop();
            Console.WriteLine("Seats occupied: "+result.ToString());
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));
        }
        private static void RunDay12()
        {
            sw = new Stopwatch();
            Console.WriteLine("Day12:");
            List<string> input = ReadFileByLineAsString(".//Day12/input");
            sw.Start();
            Day12 day12 = new Day12(input);
            int result = day12.ExecutePart1();
            sw.Stop();
            Console.WriteLine("Manhatten distance: "+result.ToString());
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));
            
            sw = new Stopwatch();
            sw.Start();
            day12 = new Day12(input);
            result = day12.ExecutePart2();
            sw.Stop();
            Console.WriteLine("Manhatten distance part2: "+result.ToString());
            Console.WriteLine("RunTime: " + ParseTimeSpan(sw.Elapsed));
        }        

        private static string ParseTimeSpan(TimeSpan ts)
        {
            return String.Format("{0:0} ms",
                                    ts.Milliseconds);
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

        private static List<Int64> ReadFileByLineAsInt64(string location) {
            List<Int64> input = new List<Int64>();
            StreamReader reader = new StreamReader(location);
            string line = String.Empty;
            while((line = reader.ReadLine()) != null) {
                input.Add(Int64.Parse(line));               
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
