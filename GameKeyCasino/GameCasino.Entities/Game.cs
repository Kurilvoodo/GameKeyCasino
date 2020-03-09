using System;
using System.Collections.Generic;
using System.Text;

namespace GameCasino.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
        public decimal OurPrice { get; set; }
        

        public Game(string name, int type, decimal price, decimal ourPrice)
        {
            Name = name;
            Type = type;
            Price = price;
            OurPrice = ourPrice;
        }
    }
}
