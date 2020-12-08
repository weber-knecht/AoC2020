namespace AoC2020
{
    public class Instruction
    {
        public Operation Operation { get; set; }

        public int Argument { get; set; }

        public int ExecutionCount { get; set; }

        public Instruction(Operation operation, int argument) {
            Operation = operation;
            Argument = argument;
            ExecutionCount = 0;
        }
        
        public int Run(int Accumulator, ref int i) {
            int newValue = 0;
            switch (Operation)
            {
                case Operation.acc:
                    newValue = Accumulator + this.Argument;
                    break;
                case Operation.jmp:
                    i += (this.Argument-1);
                    newValue = Accumulator;
                    break;
                case Operation.nop:
                    newValue = Accumulator;
                    break;
                default:
                    break;
            }
            ExecutionCount++;
            return newValue;            
        }

        public override string ToString()
        {
            return "Operation: " + this.Operation.ToString() + " || " + "Argument: " + this.Argument.ToString();
        }
    }



    public enum Operation {
        acc,
        jmp,
        nop
    }
}