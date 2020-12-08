using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day8
    {
        public List<string> Input { get; set; }
        
        public List<Instruction> Instructions { get; set; }

        public int Accumulator { get; set; }

        public Day8(List<string> input) {
            Input = input;
            Accumulator = 0;
            ParseInput();
        }

        public int Execute()
        {
            int result = 0;
            int i = 0;
            do {
                Accumulator = 0;
                result = RunCode();
                if(result==-1) {
                    ParseInput();
                    i = ReplaceInstruction(i);
                    //Console.WriteLine("Try: "+ i.ToString());
                }
            } while (result == -1);
            return result;
        }

        private int ReplaceInstruction(int i)
        {
            List<Instruction> instList = Instructions.FindAll(x => x.Operation == Operation.jmp);
            instList[i].Operation = Operation.nop;
            return i+1;
        }

        private int RunCode()
        {
            for (int i = 0; i < Instructions.Count; i++)
            {
                Instruction instruction = Instructions[i];
                if (instruction.ExecutionCount == 0)
                {
                    //Console.WriteLine(instruction.ToString());
                    Accumulator = instruction.Run(Accumulator, ref i);
                    //Console.WriteLine(Accumulator.ToString());
                }
                else
                    return -1;

            }
            return Accumulator;
        }

        private void ParseInput() {
            Instructions = new List<Instruction>();
            foreach (string item in Input)
            {
                string[] s = item.Split(" ");
                Operation op = Enum.Parse<Operation>(s[0].Trim());
                Instructions.Add(new Instruction(op, int.Parse(s[1].Trim())));
            }
        }

    }
}