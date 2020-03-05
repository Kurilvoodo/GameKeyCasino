using System;
using System.Collections.Generic;
using System.Text;

namespace GameCasino.Entities
{
    public class GameCode
    {
        public string _gameCode { get; }
        public int _enabled { get; }
        public GameCode(string gameCode, int enabled)
        {
            _gameCode = gameCode;
            _enabled = enabled;
        }
    }
}

