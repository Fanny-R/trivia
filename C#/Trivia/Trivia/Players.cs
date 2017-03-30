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
            CurrentPlayer = null;
        }
        public void AddPlayer(Player player)
        {
            
            if (ListPlayer.Count == 0)
            {
                CurrentPlayer = player;
            }

            ListPlayer.Add(player);
            
        }

        public int NumberOfPlayers()
        {
            return ListPlayer.Count();
        }

        public void ChangeCurrentPlayer()
        {
            if (ListPlayer.IndexOf(CurrentPlayer) == ListPlayer.Count-1 )
            {
                CurrentPlayer = ListPlayer[0];
            }
            else
            {
                CurrentPlayer = ListPlayer[ListPlayer.IndexOf(CurrentPlayer) + 1];
            }
        }
    }
}
