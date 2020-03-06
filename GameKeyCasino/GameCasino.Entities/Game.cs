using System;
using System.Collections.Generic;
using System.Text;

namespace GameCasino.Entities
{
    public class Game
    {
        public int _id { get; set; }
        public string _name { get; }
        public int _type { get; }
        public decimal _price { get; }
        public decimal _ourPrice { get; }
        //public byte[] _image { get; }

        public Game(string name, int type, decimal price, decimal ourPrice)
        {
            _name = name;
            _type = type;
            _price = price;
            _ourPrice = ourPrice;
        }
    }
}
