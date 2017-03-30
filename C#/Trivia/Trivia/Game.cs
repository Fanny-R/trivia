using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Player> _listPlayers = new List<Player>();
        private Players players = new Players();
        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() {{0, "Pop"}, {1, "Science"}, {2, "Sports"}, {3, "Rock"}};

        LinkedList<string> popQuestions = new LinkedList<string>();
        LinkedList<string> scienceQuestions = new LinkedList<string>();
        LinkedList<string> sportsQuestions = new LinkedList<string>();
        LinkedList<string> rockQuestions = new LinkedList<string>();

        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= 2);
        }

        public bool Add(string playerName)
        {
            Player player = new Player(playerName);
            _listPlayers.Add(player);
            players.AddPlayer(player);

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.NumberOfPlayers());
            return true;
        }

        public int HowManyPlayers()
        {
            return players.NumberOfPlayers();
        }

        public void Roll(int roll)
        {
            Console.WriteLine(players.CurrentPlayer.Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (players.CurrentPlayer.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(players.CurrentPlayer.Name + " is getting out of the penalty box");
                    players.CurrentPlayer.Move(roll);

                    Console.WriteLine(players.CurrentPlayer.Name
                            + "'s new location is "
                            + players.CurrentPlayer.Place);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(players.CurrentPlayer.Name + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                players.CurrentPlayer.Move(roll);

                Console.WriteLine(players.CurrentPlayer.Name
                        + "'s new location is "
                        + players.CurrentPlayer.Place);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }


        private string CurrentCategory()
        {
            return _categories[players.CurrentPlayer.Place % 4];
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (players.CurrentPlayer.InPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    players.CurrentPlayer.WinAGoldCoin();

                    winner = DidPlayerWin();
                    players.ChangeCurrentPlayer();

                    return winner;
                }

                players.ChangeCurrentPlayer();
    
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            players.CurrentPlayer.WinAGoldCoin();

            winner = DidPlayerWin();
            players.ChangeCurrentPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            players.CurrentPlayer.GoToPenaltyBox();

            players.ChangeCurrentPlayer();

            return true;
        }

        private bool DidPlayerWin()
        {
            return players.CurrentPlayer.GoldCoins != 6;
        }
    }
}
