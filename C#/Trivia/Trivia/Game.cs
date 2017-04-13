using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Game
    {
        private Players _players;
        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>() {{0, "Pop"}, {1, "Science"}, {2, "Sports"}, {3, "Rock"}};

        private Questions _questions = new Questions();
        private QuestionStack _questionStackPop = new QuestionStack("Pop");
        private QuestionStack _questionStackScience = new QuestionStack("Science");
        private QuestionStack _questionStackSports = new QuestionStack("Sports");
        private QuestionStack _questionStackRock = new QuestionStack("Rock");

        bool _isGettingOutOfPenaltyBox;

        public Game(Players players)
        {
            _players = players;
            _questions.AddQuestionStack("Pop");
            _questions.AddQuestionStack("Science");
            _questions.AddQuestionStack("Sports");
            _questions.AddQuestionStack("Rock"); 

            _questions.GenerateQuestions();
            for (var i = 0; i < 50; i++)
            {
                _questionStackPop.AddQuestion();
                _questionStackScience.AddQuestion();
                _questionStackSports.AddQuestion();
                _questionStackRock.AddQuestion();
            }
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
                    Console.WriteLine("The category is " + _questions.GetQuestionStackName(CurrentCategory()));
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
                Console.WriteLine("The category is " + _questions.GetQuestionStackName(CurrentCategory()));
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            Console.WriteLine(_questions.AskQuestion(CurrentCategory()));
            /*
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(_questionStackPop.GetQuestion());
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(_questionStackScience.GetQuestion());
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(_questionStackSports.GetQuestion());
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(_questionStackRock.GetQuestion());
            }
              */
        }


        private int CurrentCategory()
        {
            return _players.CurrentPlayer.Place % 4;
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
