using System.Collections.Generic;

namespace AoC2020
{
    public class Day1
    {
        private List<int> Expenses { get; set; }
        public int Expense1 { get; set; }
        public int Expense2 { get; set; }
        public int Expense3 { get; set; }

        public Day1(List<int> expenses) {
            this.Expenses = expenses;
            this.Expense1 = 0;
            this.Expense2 = 0;
            this.Expense3 = 0;
        }

        private void FindEntriesWithSum2020() {
            List<int> entries = new List<int>();
            const int CHECK = 2020;

            for (int i = 0; i < Expenses.Count; i++) {
                for (int j = 1; j < Expenses.Count; j++) {
                    for (int k = 2; k < Expenses.Count; k++) {
                        if((Expenses[i] + Expenses[j] + Expenses[k]) == CHECK) {
                            this.Expense1 = Expenses[i];
                            this.Expense2 = Expenses[j];
                            this.Expense3 = Expenses[k];
                        }
                    }
                }
            }
        }

        public int Execute() {
            this.FindEntriesWithSum2020();

            return this.Expense1 * this.Expense2 * this.Expense3;
        }
        
    }
}