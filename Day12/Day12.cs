using System;
using System.Collections.Generic;

namespace AoC2020
{
    public class Day12
    {
        public List<string> Input {get; set;}
        
        public Day12(List<string> input) {
            Input = input;
        }

        public int ExecutePart1() {
            var pos = (0,0); 
            var direction = 1;

            List<MoveAction> actions = new List<MoveAction>();
            actions.Add(new MoveAction("N", 1,0));
            actions.Add(new MoveAction("E", 0,1));
            actions.Add(new MoveAction("S", -1,0));
            actions.Add(new MoveAction("W", 0,-1));

            foreach (string instruction in Input)
            {
                string action = instruction.Substring(0,1); 
                MoveAction act = new MoveAction(action);
                int value = int.Parse(instruction.Substring(1));

                //Console.WriteLine("Action: " + action);
                //Console.WriteLine("Value: "+ value.ToString());
                //Console.WriteLine(" ");

                if(actions.Contains(act)) {
                    pos.Item1 += actions.Find(x => x.Desc == action).MoveNorth * value;
                    pos.Item2 += actions.Find(x => x.Desc == action).MoveEast * value;
                } else if (action == "R") {
                    int steps = value / 90;
                    direction = (direction + steps) % 4;
                } else if (action == "L") {
                    int steps = value / 90;
                    direction = (direction - steps);
                    if (direction < 0) {
                        direction+=4;
                    }
                } else {
                    pos.Item1 += actions[direction].MoveNorth * value;
                    pos.Item2 += actions[direction].MoveEast * value;                    
                }
                //Console.WriteLine("Direction: "+direction.ToString());

                //Console.WriteLine("x:"+pos.Item1.ToString() + " : y:" + pos.Item2.ToString());
                //Console.WriteLine(" ");
            }
            
            return Math.Abs(pos.Item1) + Math.Abs(pos.Item2);
        }

        public int ExecutePart2() {
            var pos = (0,0); 
            var waypoint = (10,1);

            List<MoveAction> actions = new List<MoveAction>();
            actions.Add(new MoveAction("N", 0,1));
            actions.Add(new MoveAction("E", 1,0));
            actions.Add(new MoveAction("S", 0,-1));
            actions.Add(new MoveAction("W", -1,0));

            foreach (string instruction in Input)
            {
                string action = instruction.Substring(0,1); 
                MoveAction act = new MoveAction(action);
                int value = int.Parse(instruction.Substring(1));

                //Console.WriteLine("Action: " + action);
                //Console.WriteLine("Value: "+ value.ToString());

                if(actions.Contains(act)) {
                    waypoint.Item1 += actions.Find(x => x.Desc == action).MoveNorth * value;
                    waypoint.Item2 += actions.Find(x => x.Desc == action).MoveEast * value;
                } else {
                    if (action == "L") {
                        var tmpItem1 = waypoint.Item1;
                        var tmpItem2 = waypoint.Item2;
                        var turns = value / 90;
                        switch(turns) {
                            case 1:
                                waypoint.Item1 = -tmpItem2;
                                waypoint.Item2 = tmpItem1;
                                break;
                            case 2:
                                waypoint.Item1 = -tmpItem1;
                                waypoint.Item2 = -tmpItem2;
                                break;
                            case 3:
                                waypoint.Item1 = tmpItem2;
                                waypoint.Item2 = -tmpItem1;
                                break;
                        }
                    } else if (action == "R") {
                            var turns = value / 90;
                            var tmpItem1 = waypoint.Item1;
                            var tmpItem2 = waypoint.Item2;
                            switch(turns) {
                                case 1:
                                    waypoint.Item1 = tmpItem2;
                                    waypoint.Item2 = -tmpItem1;
                                    break;
                                case 2:
                                    waypoint.Item1 = -tmpItem1;
                                    waypoint.Item2 = -tmpItem2;
                                    break;
                                case 3:
                                    waypoint.Item1 = -tmpItem2;
                                    waypoint.Item2 = tmpItem1;
                                    break;
                            }                        
                        } else {
                            pos.Item1 += waypoint.Item1 * value;
                            pos.Item2 += waypoint.Item2 * value;                    
                        }
                    }
                    //Console.WriteLine("x:"+pos.Item1.ToString() + " : y:" + pos.Item2.ToString());
                    //Console.WriteLine("wx:"+waypoint.Item1.ToString() + " : wy:" + waypoint.Item2.ToString());
                    //Console.WriteLine(" ");
            }
            return Math.Abs(pos.Item1) + Math.Abs(pos.Item2);
        }
    }

    internal class MoveAction {
        public string Desc { get; set;}
        public int MoveNorth { get; set; }
        public int MoveEast { get; set; }

        public MoveAction(string desc, int north, int east) {
            Desc = desc;
            MoveNorth = north;
            MoveEast = east;
        }

        public MoveAction(string desc) : this(desc, 0, 0) {}

        public override bool Equals(object obj)
        {
            return ((MoveAction)obj).Desc == this.Desc ? true : false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() * 42; 
        }
    }
}