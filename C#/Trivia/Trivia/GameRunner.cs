using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _notAWinner;

        public static void Main(String[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                var players = new Players();
                players.AddPlayer("Chet");
                players.AddPlayer("Pat");
                players.AddPlayer("Sue");

                var questions = new Questions();
                questions.AddQuestionStack("Pop");
                questions.AddQuestionStack("Science");
                questions.AddQuestionStack("Sports");
                questions.AddQuestionStack("Rock");

                questions.GenerateQuestions();

                var aGame = new Game(players, questions);

                Random rand = new Random(i);

                do
                {
                    aGame.Roll(rand.Next(5) + 1);

                    if (rand.Next(9) == 7)
                    {
                        _notAWinner = aGame.WrongAnswer();
                    }
                    else
                    {
                        _notAWinner = aGame.WasCorrectlyAnswered();
                    }
                } while (_notAWinner);
            }
        }
    }
}

