using System;

namespace Trivia
{
    public class Game
    {
        private Players _players;

        private Questions _questions;

        bool _isGettingOutOfPenaltyBox;

        public Game(Players players, Questions questions)
        {
            _players = players;
            _questions = questions;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(_players.CurrentPlayer.Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_players.CurrentPlayer.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(_players.CurrentPlayer.Name + " is getting out of the penalty box");
                    _players.CurrentPlayer.Move(roll);

                    Console.WriteLine(_players.CurrentPlayer.Name
                            + "'s new location is "
                            + _players.CurrentPlayer.Place);
                    Console.WriteLine("The category is " + _questions.GetQuestionStackName(_players.CurrentPlayer.Place));
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(_players.CurrentPlayer.Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players.CurrentPlayer.Move(roll);

                Console.WriteLine(_players.CurrentPlayer.Name
                        + "'s new location is "
                        + _players.CurrentPlayer.Place);
                Console.WriteLine("The category is " + _questions.GetQuestionStackName(_players.CurrentPlayer.Place));
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            Console.WriteLine(_questions.AskQuestion(_players.CurrentPlayer.Place));
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players.CurrentPlayer.InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    _players.CurrentPlayer.WinAGoldCoin();

                    winner = DidPlayerWin();
                    _players.ChangeCurrentPlayer();

                    return winner;
                }

                _players.ChangeCurrentPlayer();
    
                return true;
            }

            Console.WriteLine("Answer was corrent!!!!");
            _players.CurrentPlayer.WinAGoldCoin();

            winner = DidPlayerWin();
            _players.ChangeCurrentPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            _players.CurrentPlayer.GoToPenaltyBox();

            _players.ChangeCurrentPlayer();

            return true;
        }

        private bool DidPlayerWin()
        {
            return _players.CurrentPlayer.GoldCoins != 6;
        }
    }
}
