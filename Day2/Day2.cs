using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC2020
{
    public class Day2
    {
        private List<string> PasswordInput { get; set; }

        private List<PasswordManager> Passwords { get; set; }

        public Day2(List<string> passwords) {
            PasswordInput = passwords;
            Passwords = new List<PasswordManager>();
        }

        public int Exceute() {
            int countValidPasswords = 0;
            ParseInput();
            foreach (PasswordManager pm in Passwords)
            {
                if (pm.CheckIfPasswordIsValidv2()) {
                    countValidPasswords++;
                }
            }
            return countValidPasswords;
        }

        private void ParseInput() {
            foreach (string passwordInput in this.PasswordInput)
            {
                string[] parts = passwordInput.Split(":");
                PasswordPolicy p = GeneratePasswordPolicy(parts[0]);
                string password = parts[1].Trim();
                PasswordManager pm = new PasswordManager(p, password);
                Passwords.Add(pm);
            }
        }

        private PasswordPolicy GeneratePasswordPolicy(string input) {
            string[] parts = input.Split(" ");
            string[] bounderies = parts[0].Split("-");
            List<string> letters = new List<string>();
            letters.Add(parts[1]);
            return new PasswordPolicy(int.Parse(bounderies[0]), int.Parse(bounderies[1]), letters);
        }

    }

    public class PasswordManager
    {
        public PasswordPolicy Policy { get; set; }    
        public string Password { get; set; }

        public PasswordManager(PasswordPolicy policy, string password) {
            Policy = policy;
            Password = password;
        }

        public bool CheckIfPasswordIsValid() {
            string pattern = this.Policy.ReqChar[0]+ "{"+this.Policy.MinValue.ToString()+","+this.Policy.MaxValue.ToString()+"}";
            int count = Password.Split(this.Policy.ReqChar[0]).Length - 1;
            bool ret = false;
            if (count >= this.Policy.MinValue && count <= this.Policy.MaxValue) {
                ret = true;
            } else {
                ret = false;
            }
            Console.WriteLine(pattern + ": " + Password + "   -   "+ ret.ToString());
            return ret;

        }

        public bool CheckIfPasswordIsValidv2() {
            string value1 = "";
            string value2 = "";
            bool ret = false;
            if (Password.Length > this.Policy.MinValue-1)  {
                value1 = Password[this.Policy.MinValue-1].ToString();
            } 
            if ( Password.Length > this.Policy.MaxValue-1) {
                value2 = Password[this.Policy.MaxValue-1].ToString();
            }

            if(value1==value2) {
                ret = false;
            } else if (value1 == this.Policy.ReqChar[0]) {
                ret = true;
            } else if (value2 == this.Policy.ReqChar[0]) {
                ret = true;
            } else {
                ret = false;
            }
            return ret;
        }
    }
}