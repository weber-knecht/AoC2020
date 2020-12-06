using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day6
    {
        private List<string> Input {get; set;}

        public Day6(List<string> input) {
            Input = input;
        }
        
        public int Execute() {
            int totalCount = 0;
            foreach (string personGroup in Input)
            {
                CustomsForm cf = new CustomsForm(new List<string>(personGroup.TrimStart().Split(" ")));
                //int count = cf.CountDistinctYesAnswers();
                int count = cf.CountCollectivYesAnswers();
                Console.WriteLine(count.ToString());
                totalCount += count;
            }
            return totalCount;
        }
    }
}