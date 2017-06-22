using Trivia.Presentation;

namespace Trivia.Domain
{
    public class Game
    {
        private readonly Players _players;

        private readonly Questions _questions;

        private readonly IQuestionUI _questionUi;

        bool _isGettingOutOfPenaltyBox;

        public Game(Players players, Questions questions, IQuestionUI questionUi)
        {
            _players = players;
            _questions = questions;
            _questionUi = questionUi;
        }

        public void Roll(int roll)
        {
            _questionUi.DisplayMessage(_players.CurrentPlayer.Name + " is the current player");
            _questionUi.DisplayMessage("They have rolled a " + roll);

            if (_players.CurrentPlayer.InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    _questionUi.DisplayMessage(_players.CurrentPlayer.Name + " is getting out of the penalty box");
                    _players.CurrentPlayer.Move(roll);

                    _questionUi.DisplayMessage(_players.CurrentPlayer.Name
                            + "'s new location is "
                            + _players.CurrentPlayer.Place);
                    _questionUi.DisplayMessage("The category is " + _questions.GetQuestionStackName(_players.CurrentPlayer.Place));
                    AskQuestion();
                }
                else
                {
                    _questionUi.DisplayMessage(_players.CurrentPlayer.Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }

            }
            else
            {
                _players.CurrentPlayer.Move(roll);

                _questionUi.DisplayMessage(_players.CurrentPlayer.Name
                        + "'s new location is "
                        + _players.CurrentPlayer.Place);
                _questionUi.DisplayMessage("The category is " + _questions.GetQuestionStackName(_players.CurrentPlayer.Place));
                AskQuestion();
            }

        }

        private void AskQuestion()
        {
            _questionUi.DisplayMessage(_questions.AskQuestion(_players.CurrentPlayer.Place));
        }

        public bool WasCorrectlyAnswered()
        {
            bool winner;
            if (_players.CurrentPlayer.InPenaltyBox)
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    _questionUi.DisplayMessage("Answer was correct!!!!");
                    _players.CurrentPlayer.WinAGoldCoin();

                    winner = DidPlayerWin();
                    _players.ChangeCurrentPlayer();

                    return winner;
                }

                _players.ChangeCurrentPlayer();
    
                return true;
            }

            _questionUi.DisplayMessage("Answer was corrent!!!!");
            _players.CurrentPlayer.WinAGoldCoin();

            winner = DidPlayerWin();
            _players.ChangeCurrentPlayer();

            return winner;
        }

        public bool WrongAnswer()
        {
            _questionUi.DisplayMessage("Question was incorrectly answered");
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
