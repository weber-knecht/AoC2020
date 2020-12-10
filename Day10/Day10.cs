using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day10
    {
        public List<int> Input { get; set;}

        public List<int> AdapterDiff1 {get; set;}
        public List<int> AdapterDiff3 {get; set;}

        public Day10(List<int> input) {
            Input = input;
            AdapterDiff1 = new List<int>();
            AdapterDiff3 = new List<int>();
        }

        public long FindAllDistinctArrangements() {
            Input.Add(Input[Input.Count-1]+3);
            Input.Add(0);
            Input.Sort();
            List<long> arrangsments = new List<long>();
            arrangsments.Add(1);
            for(int i = 1; i<Input.Count; i++) {
                long x = 0;
                for(int j = 0; j<i; j++) {
                    if(Input[j]+3 >= Input[i]) {
                        x+=arrangsments[j];
                    }
                }
                arrangsments.Add(x);
            }
            return arrangsments[arrangsments.Count-1];
        }

        public int Execute(int ratingStart) {
            int baseRating = ratingStart;
            Input.Sort();
            foreach (int item in Input)
            {
                List<int> adaptersInRange = Input.FindAll(x => x <= baseRating+3 && 
                                                                    !AdapterDiff1.Contains(x) && 
                                                                    !AdapterDiff3.Contains(x));
                adaptersInRange.Sort();
                if (adaptersInRange[0]-baseRating == 1)
                    AdapterDiff1.Add(item);
                else
                    AdapterDiff3.Add(item);
                    
                baseRating = item;
            }
            AdapterDiff3.Add(Input[Input.Count-1]);
            //Console.WriteLine("Diff1:"+AdapterDiff1.Count);
            //Console.WriteLine("Diff3:"+AdapterDiff3.Count);
            return AdapterDiff1.Count*AdapterDiff3.Count;
        }

        
    }
}