using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day3
    {
        private const int AREA_SIZE_X = 323; 
        private const int AREA_SIZE_Y = 31; 

        public string[,] Area { get; set; }
        public int TreeCounter { get; set; }
        
        public Day3(List<string> input) {
            Area = new string[AREA_SIZE_X,AREA_SIZE_Y];
            TreeCounter = 0;
            ParseInput(input);
        }

        public int Execute(int stepsRight, int stepsDown) {
            TreeCounter = 0;
            MapRoute(stepsRight,stepsDown);        
            
            return TreeCounter;
        }

        private void MapRoute(int stepsRight, int stepsDown) {
            int startX = 0;
            int startY = 0;
            
            while(startX!=AREA_SIZE_X-1) {
                DoSteps(stepsRight, stepsDown, ref startX, ref startY);
            }
        }

        private void DoSteps(int stepsRight, int stepsDown, ref int startX, ref int startY) {
            startX = startX + stepsDown;
            if ((startY + stepsRight) > (AREA_SIZE_Y-1)) {
                int diff = ((startY + stepsRight) - (AREA_SIZE_Y-1));
                startY = 0 + (diff-1);                 
            } else {
                startY = startY + stepsRight;
            }
                
            if (Area[startX, startY] == "#") {
                TreeCounter++;
            }                
        }

        private void ParseInput(List<string> input)
        {
            int rowIndex = 0;
            foreach (string areaLine in input)
            {
                char[] areaFields =  areaLine.ToCharArray();
                for (int columnIndex = 0; columnIndex < AREA_SIZE_Y; columnIndex++) {
                    Area[rowIndex, columnIndex] = areaFields[columnIndex].ToString();
                }
                rowIndex++;
            }
        }
    }
}