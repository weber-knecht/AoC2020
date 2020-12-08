using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day7
    {
        public List<string> Input { get; set;}

        public List<LuggageRule> Rules { get; set; }

        public List<string> foundBagColors { get; set; }

        public Day7(List<string> input) {
            Input = input;
            Rules = new List<LuggageRule>();
            foundBagColors = new List<string>();
            PraseInput();
        }

        public int Execute(string srcBagColor) {
            int count = 0;

            foreach (LuggageRule rule in Rules)
            {
                if (rule.CanContainBagColor(srcBagColor.Trim())) {
                    if (!foundBagColors.Contains(rule.BagColor)) {
                        foundBagColors.Add(rule.BagColor);
                        count++;
                        //Console.WriteLine("Found Color: " + rule.BagColor + " Current Count: " + count.ToString());
                        int result = Execute(rule.BagColor);
                        //Console.WriteLine("Result for that: " + result.ToString());
                        count += result;
                    }
                }
            }
            return count;
        }

        public int ExecutePart2(string srcBagColor)
        {
            int count = 0;
            List<BagContent> contents = new List<BagContent>();

            count += GetContentAmount(srcBagColor);

            return count;
        }

        private int GetContentAmount(string srcBagColor)
        {
            int result = 0;
            LuggageRule rule = FindFirstRule(srcBagColor);
            if (rule==null || rule.BagContent.Count == 0)
                return 0;
            foreach (BagContent item in rule.BagContent)
            {
                result += item.Amount + item.Amount * GetContentAmount(item.BagColor);
            }
            return result;
        }

        private LuggageRule FindFirstRule(string srcBagColor)
        {
            return Rules.Find(x => x.BagColor == srcBagColor);
        }

        private void PraseInput() {
            foreach (string rule in Input)
            {
                string[] ruleParts = rule.Split("contain");
                string bagColor = NormalizeInputString(ruleParts[0]);

                List<string> bagContent = new List<string>(ruleParts[1].Split(","));
                List<BagContent> normalizedBagContent = new List<BagContent>();
                foreach (string content in bagContent)
                {
                    string contentBagColor = "";
                    int contentAmount = 0;

                    string contentString = NormalizeInputString(content);
                    if (!contentString.Equals("no other bag")) {
                        string[] s = contentString.Split(" ",2);
                        contentBagColor = s[1].Trim();
                        contentAmount = int.Parse(s[0].Trim());

                    } else {
                        contentBagColor = contentString;
                        contentAmount = 0;
                    }
                    normalizedBagContent.Add(new BagContent(contentBagColor, contentAmount));
                }
                Rules.Add(new LuggageRule(bagColor, normalizedBagContent));
            }
        }

        private string NormalizeInputString(string orgString) {
            string newString = "";
            orgString = orgString.Trim();
            if(orgString.Contains("."))
                orgString = orgString.Replace(".", "");
            if (orgString.EndsWith('s'))
                orgString = orgString.Substring(0, orgString.Length-1);
            newString = orgString;
            return newString;
        }
    }
}