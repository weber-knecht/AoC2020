using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day5
    {
        private List<string> Input { get; set ;}

        private List<int> Rows { get; set;}
        private List<int> Columns { get; set;}

        private List<int> SeatIds { get; set; }

        public Day5(List<string> input) {
            Input = input;
            SeatIds = new List<int>();
        }

        private void InitRows() {
            this.Rows = new List<int>();
            for(int i=0; i<128;i++) {
                Rows.Add(i);
            }
        }

        private void InitColumns() {
            this.Columns = new List<int>();
            for(int i=0; i<8;i++) {
                Columns.Add(i);
            }
        }

        public int Execute() {
            foreach (var boardingPass in Input)
            {
                int row = ProcessBoardingPassRow(boardingPass);
                int column = ProcessBoardingPassColumn(boardingPass);
                int seatID = (row*8)+column;
                SeatIds.Add(seatID);
            }
            SeatIds.Sort();
            return SeatIds[SeatIds.Count-1];
        }

        public int MySeat() {
            int mySeat = 0;
            for (var i = 0; i < SeatIds.Count; i++)
            {
                if (i!=(SeatIds.Count-1) && SeatIds[i]+1 != SeatIds[i+1]) {
                    mySeat = SeatIds[i]+1;
                    Console.WriteLine(SeatIds[i+1].ToString());
                }
            }
            return mySeat;
        }
        
        private int ProcessBoardingPassRow(string parBoardingPass) {
            InitRows();  
            var boardingPass = parBoardingPass.ToCharArray();
            for(int i = 0; i<7; i++) {
                if (boardingPass[i].Equals('F')) {
                    int startIndex = ((Rows.Count/2));
                    int Count = ((Rows.Count/2));
                    Rows.RemoveRange(startIndex,Count);
                } else if (boardingPass[i].Equals('B')) {
                    int startIndex = 0;
                    int Count = ((Rows.Count/2));
                    Rows.RemoveRange(startIndex,Count);
                }
            }
            return Rows[0];
        }

        private int ProcessBoardingPassColumn(string parBoardingPass) {
            InitColumns();  
            var boardingPass = parBoardingPass.ToCharArray();
            for(int i = 7; i<10; i++) {
                if (boardingPass[i].Equals('L')) {
                    int startIndex = ((Columns.Count/2));
                    int Count = ((Columns.Count/2));
                    Columns.RemoveRange(startIndex,Count);
                } else if (boardingPass[i].Equals('R')) {
                    int startIndex = 0;
                    int Count = ((Columns.Count/2));
                    Columns.RemoveRange(startIndex,Count);
                }
            }
            return Columns[0];
        }

    }
}