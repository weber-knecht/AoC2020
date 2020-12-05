using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AoC2020
{
    public class Passport
    {
        public int BirthYear { get; set; }
        public int IssueYear { get; set; }
        public int ExpirationYear { get; set; }
        public string Height { get ; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public Passport(int byr, int iyr, int eyr, string hgt, 
                        string hcl, string ecl, string pid, 
                        string cid) {
            BirthYear = byr;
            IssueYear = iyr;
            ExpirationYear = eyr;
            Height = hgt;
            HairColor = hcl;
            EyeColor = ecl;
            PassportId = pid;
            CountryId = cid;
        }

        public Passport() : this(0,0,0,"","","","","") {}

        private void InitFields() {
            BirthYear = 0;
            IssueYear = 0;
            ExpirationYear = 0;
            Height = "";
            HairColor = "";
            EyeColor = "";
            PassportId = "";
            CountryId = "";
        }

        public Passport(string[] passportKeyValuePairs) {
            InitFields();
            foreach (string item in new List<string>(passportKeyValuePairs))
            {
                string[] passportParts = item.Split(":");
                switch (passportParts[0])
                {
                    case "byr":
                        int byr;
                        int.TryParse(passportParts[1], out byr);
                        this.BirthYear = byr;
                        break;
                    case "iyr":
                        int iyr;
                        int.TryParse(passportParts[1], out iyr);
                        this.IssueYear = iyr;                    
                        break;
                    case "eyr":
                        int eyr;
                        int.TryParse(passportParts[1], out eyr);
                        this.ExpirationYear = eyr;   
                        break;
                    case "hgt":
                        this.Height = passportParts[1];
                        break;
                    case "hcl":
                        this.HairColor = passportParts[1];
                        break;
                    case "ecl":
                        this.EyeColor = passportParts[1];
                        break;
                    case "pid":
                        this.PassportId = passportParts[1];
                        break;
                    case "cid":
                        this.CountryId = passportParts[1];
                        break;
                    default:
                        break;
                }
            }
        } 

        public bool IsValid() {
            if (   BirthYear!=0 && IssueYear!=0 && ExpirationYear!=0 
                && Height!="" && HairColor!="" && EyeColor!="" 
                && PassportId !="") {
                    if (CheckBirthYear() && CheckIssueYear() && CheckExpirationYear() 
                        && CheckHeight() && CheckHairColor() && CheckEyeColor()
                        && CheckPassportId()) {
                            return true;
                        } else {
                            return false;
                        }
                } else {
                    return false;
                }
        }

        private bool CheckBirthYear() {
            return this.BirthYear >=1920 && this.BirthYear <= 2002 ? true : false;
        }
        private bool CheckIssueYear() {
            return this.IssueYear >=2010 && this.IssueYear <= 2020 ? true : false;
        }
        private bool CheckExpirationYear() {
            return this.ExpirationYear >=2020 && this.ExpirationYear <= 2030 ? true : false;
        }
        private bool CheckHeight() {
            string pattern = "\\d+(cm|in)";
            int height = 0;
            MatchCollection matches = Regex.Matches(this.Height, pattern);
            if (matches.Count != 0 && matches[0].Groups[1].ToString() =="cm") {
                string h = matches[0].Groups[0].ToString();
                height = int.Parse(h.Substring(0,h.Length-2));
                return height >= 150 && height <= 193 ? true : false;
            } else if (matches.Count !=0 && matches[0].Groups[1].ToString() =="in") {
                string h = matches[0].Groups[0].ToString();
                height = int.Parse(h.Substring(0,h.Length-2));
                return height >= 59 && height <= 76 ? true : false;
            } else {
                return false;
            }
        }
        private bool CheckHairColor() {
            string pattern = "^#[0-9a-f]{6}$";
            return Regex.IsMatch(this.HairColor, pattern);
        }

        private bool CheckEyeColor() {
            string pattern = "(amb|blu|brn|gry|grn|hzl|oth)";
            return Regex.IsMatch(this.EyeColor, pattern);
        }
        private bool CheckPassportId() {
            string pattern = "^\\d{9}$";
            return Regex.IsMatch(this.PassportId, pattern);
        }

        public override string ToString()
        {
            return "byr: " + this.BirthYear.ToString()
             + " - iyr: " +this.IssueYear.ToString() 
             + " - eyr:" + this.ExpirationYear.ToString() 
             + " - hgt:" + this.Height 
             + " - hcl:" + this.HairColor 
             + " - ecl:" + this.EyeColor 
             + " - pid:" + this.PassportId;
        }
    }
}