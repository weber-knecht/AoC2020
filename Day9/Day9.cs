using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day9
    {
        public List<Int64> Input { get; set; }

        public Day9(List<Int64> input) {
            Input = input;
        }

        public Int64 Execute(int preambleLenght) {
            Int64 result = 0;
            for(int i = preambleLenght; i<Input.Count; i++)
            {
                //Console.WriteLine(Input[i].ToString());
                if(CheckSumInPreamble(Input[i], preambleLenght, i-preambleLenght)==false) {
                    result = Input[i];
                    return result;
                }
            }
            return result;
        }

        private bool CheckSumInPreamble(Int64 number, int preambleLenght, int preambleStart)
        {
            for(int i=preambleStart;i<(preambleLenght+preambleStart);i++) {
                for(int j=preambleStart+1;j<(preambleLenght+preambleStart)-1;j++) {
                    //condition: numbers must be different
                    if(Input[i]!=Input[j] && Input[i]+Input[j]==number) {
                        return true;
                    }
                }
            }
            return false;
        }

        public long FindWeakness(long result)
        {
            List<long> numbers = new List<long>();
            long sum = 0;
            for(int i=0;i<Input.Count;i++) {
                sum = Input[i];
                numbers.Add(Input[i]);
                for(int j=i+1;j<Input.Count;j++) {
                    numbers.Add(Input[j]);
                    sum += Input[j];
                    if(sum>=result) {
                        break;
                    }
                }
                if(sum == result) {
                    break;
                }
                numbers = new List<long>();
            }

            numbers.Sort();
            return numbers.Count>2 ? numbers[0] + numbers[numbers.Count-1] : 0;
        }
    }
}