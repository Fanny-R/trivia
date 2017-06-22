using System;

namespace Trivia
{
    public class Player
    {
        private readonly IQuestionUI _questionUi;
        public string Name { get; private set; }

        public int Place { get; private set; }

        public int GoldCoins { get; private set; }

        public bool InPenaltyBox { get; set; }

        public Player(string name, IQuestionUI questionUi)
        {
            Name = name;
            Place = 0;
            GoldCoins = 0;
            InPenaltyBox = false;
            _questionUi = questionUi;
        }


        public void Move(int roll)
        {
            Place += roll;
            if (Place > 11) Place -= 12;
        }

        public void WinAGoldCoin()
        {
            GoldCoins++;
            _questionUi.DisplayMessage(Name + " now has " + GoldCoins + " Gold Coins.");
        }

        public void GoToPenaltyBox()
        {
            InPenaltyBox = true;
            _questionUi.DisplayMessage(Name + " was sent to the penalty box");
        }
    }
}