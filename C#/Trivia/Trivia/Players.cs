using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    class Players
    {
        private List<Player> ListPlayer { get; set; }
        public Player CurrentPlayer { get; set; }

        public Players()
        {
            ListPlayer = new List<Player>();
        }
        public void AddPlayer(Player player)
        {
            ListPlayer.Add(player);
        }

        public int NumberOfPlayers()
        {
            return ListPlayer.Count();
        }
    }
}
