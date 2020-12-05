using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day4
    {
        public List<Passport> Passports { get; set; }
        
        public Day4(List<string> input) {
            Passports = new List<Passport>();
            ParseInput(input);
        }

        private void ParseInput(List<string> input) {
            foreach (string item in input)
            {
                string[] passportKeyValuePairs = item.TrimStart().Split(" ");
                Passport newPassport = new Passport(passportKeyValuePairs);
                Passports.Add(newPassport);
            }
        }
        public int Execute() {
            int validPassportCount = 0;
            foreach (Passport passport in this.Passports)
            {
                if (passport.IsValid()) {
                    validPassportCount++;
                } else {
                    Console.WriteLine(passport.ToString());
                }
            }
            return validPassportCount;
        }

    }
}