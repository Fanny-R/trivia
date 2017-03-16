using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Player
    {
        public Player(string name)
        {
            Name = name;
            Place = 0;
            Purse = 0;
        }

        public string Name { get; set; }

        public int Place { get; set; }

        public int Purse { get; set; }
    }
}
