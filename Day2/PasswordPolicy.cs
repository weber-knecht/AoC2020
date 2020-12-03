using System.Collections.Generic;

namespace AoC2020
{
    public class PasswordPolicy
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public List<string> ReqChar { get; set; }
    

        public PasswordPolicy(int min, int max, List<string> letters) {
            MinValue = min;
            MaxValue = max;
            ReqChar = letters;
        }
    }
}