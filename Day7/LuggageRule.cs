using System;
using System.Collections.Generic;
namespace AoC2020
{
    public class LuggageRule
    {
        public string BagColor {get; set;}
        public List<BagContent> BagContent {get; set;}

        public LuggageRule(string bagColor, List<BagContent> bagContent) {
            BagColor = bagColor;
            BagContent = bagContent;
        }

        public bool CanContainBagColor(string bagColor) {
            var result = BagContent.Find(x => x.BagColor == bagColor);
            return result != null ? true : false;
        }
    }

    public class BagContent
    {
        public string BagColor { get; set; }
        public int Amount {get; set; }

        public BagContent(string color, int amount) {
            BagColor = color;
            Amount = amount;
        }



    }
}