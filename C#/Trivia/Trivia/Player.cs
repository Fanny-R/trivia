using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    class Player
    {
        private string _name;

        public Player(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
