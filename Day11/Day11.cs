using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day11
    {
        List<string> Input { get; set; }

        private char[,] SeatMap { get; set; }
        private char[,] newMap { get; set; }

        private int SIZEX = 0;
        private int SIZEY = 0;

        private const char OCC_SEAT = '#';
        private const char EMP_SEAT = 'L';
        private const char FLOOR = '.';

        public Day11(List<string> input) {
            Input = input;
            SIZEX = Input.Count;
            SIZEY = Input[0].ToCharArray().Length;
            GenerateSeatMap(SIZEX, SIZEY);
        }

        private void GenerateSeatMap(int sizeX, int sizeY) {
            SeatMap = new char[sizeX,sizeY];
            for (int i = 0; i < Input.Count; i++)
            {
                char[] spaces = Input[i].ToCharArray();
                for(int j = 0; j<spaces.Length;j++) {
                    SeatMap[i,j] = spaces[j];
                }
            }
        }

        private char[,] CloneMap(char[,] org, int sizeX, int sizeY) {
            char[,] newM = new char[sizeX,sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for(int j = 0; j<sizeY;j++) {
                    newM[i,j] = org[i,j];
                }
            }
            return newM;
        }

        private bool CheckIfSeatIsOccupied(int x, int y) {
            return SeatMap[x,y] == OCC_SEAT ? true: false;
        }

        private int GetNumberOfOccupiedSeats(int x, int y) {
            int numOccSeats = 0;
            
            int startSearchX = 0;
            int startSearchY = 0;

            if(x>0)
                startSearchX = x-1;
            else   
                startSearchX = x;
            
            if(y>0)
                startSearchY = y-1;
            else
                startSearchY = y;

            for(int i = startSearchX; i<=x+1; i++) {
                for(int j = startSearchY; j<=y+1; j++) {
                    if(!(i==x&&j==y)){
                        if (!(i==SIZEX || j==SIZEY)) {
                            if (CheckIfSeatIsOccupied(i,j)) {
                                numOccSeats++;
                            }
                        }
                    }
                }
            }

            return numOccSeats;
        }

        public int GetNumberOfOccupiedSeatsPart2(int x, int y)
        {
            int numOccSeats = 0;

            //x = 3;
            //y = 3;

            //down right
            int shift = 0;
            for(int i=x; i<SIZEX; i++) {
                if(!(y+shift>=SIZEY) && SeatMap[i,y+shift] == OCC_SEAT && shift != 0) {
                    //SeatMap[i,y+shift] = 'x';
                    numOccSeats++;
                    break;
                } else if (!(y+shift>=SIZEY) && SeatMap[i,y+shift] == EMP_SEAT && shift != 0) {
                    break;
                }
                shift++;
            }

            // top right
            shift = 0;
            for(int i = x; i>=0; i--) {
                
                if (!(y+shift>=SIZEY)&&SeatMap[i,y+shift] == OCC_SEAT && shift != 0) {
                    //SeatMap[i,y+shift] = 'x';
                    numOccSeats++;
                    break;
                } else if (!(y+shift>=SIZEY)&&SeatMap[i,y+shift] == EMP_SEAT && shift != 0) {
                    break;
                }
                shift++;
            }

            //down left
            shift = 0;
            for(int i = y; i>=0; i--) {
                
                if (!(x+shift>=SIZEX)&&SeatMap[x+shift,i] == OCC_SEAT && shift != 0) {
                    //SeatMap[x+shift,i] = 'x';
                    numOccSeats++;
                    break;
                } else if (!(x+shift>=SIZEX)&&SeatMap[x+shift,i] == EMP_SEAT && shift != 0) {
                    break;
                }
                shift++;
            }

            //top left
            shift = 0;
            for(int i = x; i>=0; i--) {
                
                if (!(y-shift<0)&&SeatMap[i,y-shift] == OCC_SEAT && shift != 0) {
                    //SeatMap[i,y-shift] = 'x';
                    numOccSeats++;
                    break;
                } else if (!(y-shift<0)&&SeatMap[i,y-shift] == EMP_SEAT && shift != 0) {
                    break;
                }
                shift++;
            }
         
            //stright down
            for(int i = x+1; i<SIZEX; i++) {
                if (SeatMap[i,y] == OCC_SEAT) {
                    numOccSeats++;
                    break;
                } else if (SeatMap[i,y] == EMP_SEAT) {
                    break;
                }
            }

            //stright up
            for(int i = x-1; i>=0; i--) {
                if (SeatMap[i,y] == OCC_SEAT) {
                    numOccSeats++;
                    break;
                } else if (SeatMap[i,y] == EMP_SEAT) {
                    break;
                }
                    
            }
            //right
            for(int j = y+1; j<SIZEY; j++) {
                if (SeatMap[x,j] == OCC_SEAT) {
                    numOccSeats++;
                    break;
                } else if (SeatMap[x,j] == EMP_SEAT) {
                    break;
                }
                    
            }
            //left
            for(int j = y-1; j>=0; j--) {
                if (SeatMap[x,j] == OCC_SEAT) {
                    numOccSeats++;
                    break;
                } else if (SeatMap[x,j] == EMP_SEAT) {
                    break;
                }
            }

            return numOccSeats;
        }

        public int Execute()
        {
            int seatChanges = 0;
            newMap = CloneMap(SeatMap,SIZEX, SIZEY);
            do {
                seatChanges = ApplySeatingRulePart1();
                SeatMap = CloneMap(newMap, SIZEX,SIZEY);
                /*Console.WriteLine("Seatchanges: "+seatChanges.ToString());
                for(int i = 0; i<SIZEX; i++) {
                    for(int j = 0; j<SIZEY; j++) {
                        Console.Write(newMap[i,j]);
                    }
                    Console.WriteLine();
                }*/
            } while (seatChanges!=0);

            return CountOccSeats();
        }

        public int ExecutePart2()
        {
            int seatChanges = 0;
            newMap = CloneMap(SeatMap,SIZEX, SIZEY);
            do {
                seatChanges = ApplySeatingRulePart2();
                SeatMap = CloneMap(newMap, SIZEX,SIZEY);
                //Console.WriteLine("Seatchanges: "+seatChanges.ToString());
/*                for(int i = 0; i<SIZEX; i++) {
                    for(int j = 0; j<SIZEY; j++) {
                        Console.Write(newMap[i,j]);
                    }
                    Console.WriteLine();
                }*/
            } while (seatChanges!=0);

            return CountOccSeats();
        }

        private int CountOccSeats()
        {
            int occCount = 0;
            for (int i = 0; i < SIZEX; i++)
            {
                for (int j = 0; j < SIZEY; j++)
                {
                    if (CheckIfSeatIsOccupied(i,j))
                        occCount++;
                }
            }
            return occCount;
        }

        private int ApplySeatingRulePart1()
        {
            int countSeatChanges = 0;
            for (int i = 0; i < SIZEX; i++)
            {
                for (int j = 0; j < SIZEY; j++)
                {
                    if (SeatMap[i, j] == EMP_SEAT)
                    {
                        if (GetNumberOfOccupiedSeats(i, j) == 0)
                        {
                            newMap[i, j] = OCC_SEAT;
                            countSeatChanges++;
                        }
                    } 
                    else if (CheckIfSeatIsOccupied(i, j) && GetNumberOfOccupiedSeats(i,j)>=4) 
                    {
                        newMap[i, j] = EMP_SEAT;
                        countSeatChanges++;
                    }
                }
            }
            return countSeatChanges;
        }


        private int ApplySeatingRulePart2()
        {
            int countSeatChanges = 0;
            for (int i = 0; i < SIZEX; i++)
            {
                for (int j = 0; j < SIZEY; j++)
                {
                    if (SeatMap[i, j] == EMP_SEAT)
                    {
                        if (GetNumberOfOccupiedSeatsPart2(i, j) == 0)
                        {
                            newMap[i, j] = OCC_SEAT;
                            countSeatChanges++;
                        }
                    } 
                    else if (CheckIfSeatIsOccupied(i, j) && GetNumberOfOccupiedSeatsPart2(i,j)>=5) 
                    {
                        newMap[i, j] = EMP_SEAT;
                        countSeatChanges++;
                    }
                }
            }
            return countSeatChanges;
        }
    }
}