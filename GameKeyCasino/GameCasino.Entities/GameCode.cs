using System;
using System.Collections.Generic;
using System.Text;

namespace GameCasino.Entities
{
    public class GameCode
    {
        public string Code { get; set; }
        public int Enabled { get; set; }
        public GameCode(string gameCode, int enabled)
        {
            Code = gameCode;
            Enabled = enabled;
        }
    }
}

