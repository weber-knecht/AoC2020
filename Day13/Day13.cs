using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day13
    {
        private List<string> Input { get; set; }

        private int EarliestDepartTime { get; set;}
        private List<string> BusIDs {get; set;}

        public Day13(List<string> input) {
            Input = input;
            BusIDs = new List<string>();
        }

        private void ParseInput(bool withX) {
            EarliestDepartTime = int.Parse(Input[0]);
            foreach (var item in Input[1].Split(","))
            {   
                if(item != "x" || withX == true)
                    BusIDs.Add(item);
            } 
        }

        private List<Bus> ParseInputv2() {
            List<Bus> busses = new List<Bus>();
            EarliestDepartTime = int.Parse(Input[0]);
            int offset = 0;
            foreach (var item in Input[1].Split(","))
            {   
                if(item != "x") {
                    busses.Add(new Bus(int.Parse(item), offset));
                }
                offset++;
            } 
            return busses;
        }

        public int ExecutePart1() {
            ParseInput(false);
            int lastTime = 0;
            int lastBus = 0;
            foreach (var bus in BusIDs)
            {
                var time = ((EarliestDepartTime / int.Parse(bus)) * int.Parse(bus)) + int.Parse(bus);
                if (lastTime == 0 || time < lastTime) {
                    lastTime = time;
                    lastBus = int.Parse(bus);
                }
            }
            Console.WriteLine("time: "+lastTime.ToString());
            Console.WriteLine("bus: "+lastBus.ToString());
            return (lastTime-EarliestDepartTime) * lastBus;
        }

        public long ExecutePart2() {
            List<Bus> schedule = ParseInputv2();

            long step = schedule[0].ID;
            int search_idx = 1;
            for (long t = step; t < long.MaxValue; t += step) {
                bool success = true;
                for (int i = 0; i <= search_idx; i++) {
                    if ((t + schedule[i].Offset) % schedule[i].ID != 0) {
                        success = false;
                        break;
                    }
                }
                if (success && search_idx == schedule.Count - 1) 
                    return t;
                if (success) {
                    step *= schedule[search_idx].ID;
                    search_idx++;
                }
            }
            return -1;
        }
    }

    internal class Bus {
        public int ID { get; set; }
        public int Offset { get; set; }

        public Bus(int id, int offset) {
            ID = id;
            Offset = offset;
        }
    }
}