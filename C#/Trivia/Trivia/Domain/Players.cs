using System.Collections.Generic;
using System.Linq;
using Trivia.Presentation;

namespace Trivia.Domain
{
    public class Players
    {
        private readonly IQuestionUI _questionUi;
        private List<Player> ListPlayer { get; set; }
        public Player CurrentPlayer { get; set; }

        public Players(IQuestionUI questionUi)
        {
            ListPlayer = new List<Player>();
            CurrentPlayer = null;
            _questionUi = questionUi;
        }
        public void AddPlayer(string playerName)
        {
            var player = new Player(playerName, _questionUi);

            if (ListPlayer.Count == 0)
            {
                CurrentPlayer = player;
            }

            ListPlayer.Add(player);
            _questionUi.DisplayMessage(playerName + " was added");
            _questionUi.DisplayMessage("They are player number " + NumberOfPlayers());
            
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
