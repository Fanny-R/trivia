using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trivia;

namespace UglyTrivia
{
    public class Game
    {


        List<Player> _players = new List<Player>();

        int[] _purses = new int[6];

        bool[] _inPenaltyBox = new bool[6];

        LinkedList<string> _popQuestions = new LinkedList<string>();
        LinkedList<string> _scienceQuestions = new LinkedList<string>();
        LinkedList<string> _sportsQuestions = new LinkedList<string>();
        LinkedList<string> _rockQuestions = new LinkedList<string>();

        int _currentPlayer = 0;
        bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            for (int i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public String CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool IsPlayable()
        {
            return (HowManyPlayers() >= 2);
        }

        public bool Add(String playerName)
        {

            Player player = new Player(playerName);
            _players.Add(player);
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int HowManyPlayers()
        {
            return _players.Count;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players[_currentPlayer].Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_inPenaltyBox[_currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players[_currentPlayer].Name + " is getting out of the penalty box");
                    _players[_currentPlayer].Place = _players[_currentPlayer].Place + roll;
                    if (_players[_currentPlayer].Place > 11) _players[_currentPlayer].Place = _players[_currentPlayer].Place - 12;

                    Console.WriteLine(_players[_currentPlayer].Name
                            + "'s new location is "
                            + _players[_currentPlayer].Place);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(_players[_currentPlayer].Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {

                _players[_currentPlayer].Place = _players[_currentPlayer].Place + roll;
                if (_players[_currentPlayer].Place > 11) _players[_currentPlayer].Place = _players[_currentPlayer].Place - 12;

                Console.WriteLine(_players[_currentPlayer].Name
                        + "'s new location is "
                        + _players[_currentPlayer].Place);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }


        private String CurrentCategory()
        {
            if (_players[_currentPlayer].Place == 0) return "Pop";
            if (_players[_currentPlayer].Place == 4) return "Pop";
            if (_players[_currentPlayer].Place == 8) return "Pop";
            if (_players[_currentPlayer].Place == 1) return "Science";
            if (_players[_currentPlayer].Place == 5) return "Science";
            if (_players[_currentPlayer].Place == 9) return "Science";
            if (_players[_currentPlayer].Place == 2) return "Sports";
            if (_players[_currentPlayer].Place == 6) return "Sports";
            if (_players[_currentPlayer].Place == 10) return "Sports";
            return "Rock";
        }

        public bool WasCorrectlyAnswered()
        {
            if (_isGettingOutOfPenaltyBox || !_inPenaltyBox[_currentPlayer])
            {
                Console.WriteLine("Answer was correct!!!!");
                _purses[_currentPlayer]++;
                Console.WriteLine(_players[_currentPlayer].Name
                        + " now has "
                        + _purses[_currentPlayer]
                        + " Gold Coins.");

                bool winner = DidPlayerWin();
                _currentPlayer++;
                if (_currentPlayer == _players.Count) _currentPlayer = 0;

                return winner;
            }
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            return true;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(_players[_currentPlayer].Name + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return !(_purses[_currentPlayer] == 6);
        }
    }

}
