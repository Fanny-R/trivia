using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
            isInPenaltyBox = false;
        }

        public string Name { get; set; }

        public int Place { get; set; }

        public int Purse { get; set; }

        public bool isInPenaltyBox { get; set; }
    }
}
