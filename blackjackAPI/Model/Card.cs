using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blackjackAPI.Model
{
    public enum Suits
    {
        Spade,
        Heart,
        Diamond,
        Club
    }
    public class Card
    {
        public int id { get; set; }
        public int value { get; set; }
        public Suits suit { get; set; }
        public string imageStr { get; set; }
        public string image { get; set; }
        public int realValue { get; set; }
    }
}