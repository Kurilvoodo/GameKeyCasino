using System;
using System.Collections.Generic;
using System.Text;

namespace GameCasino.Entities
{
    public class Game
    {
        public int _id { get; }
        public string _name { get; }
        public string _type { get; }
        public float _price { get; }
        public float _ourPrice { get; }
        public byte[] _image { get; }

        public Game(int id,string name, string type, float price, float ourPrice, byte[] image)
        {
            _id = id;
            _name = name;
            _type = type;
            _price = price;
            _ourPrice = price;
            _image = image;
        }
    }
}
