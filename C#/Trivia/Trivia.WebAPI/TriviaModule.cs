using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ModelBinding;

namespace Trivia.WebAPI
{
    class TriviaModule : NancyModule
    {
        public TriviaModule()
        {
            Post["/newGame"] = NewGame;
        }

        private dynamic NewGame(dynamic o)
        {
            this.Bind<NewGame>();

            var questionUi = new ConsoleUI();

            var players = new Players(questionUi); 
            players.AddPlayer("Chet");
            players.AddPlayer("Pat");
            players.AddPlayer("Sue");

            var questions = new Questions(new QuestionsFromFileRepository());
            questions.AddQuestionStack("Pop");
            questions.AddQuestionStack("Science");
            questions.AddQuestionStack("Sports");
            questions.AddQuestionStack("Rock");

            var aGame = new Game(players, questions, questionUi);

            throw new NotImplementedException();
        }
    }

    public class NewGame
    {
        public List<string> UserNames { get; set; }
        public List<string> QuestionCategories { get; set; }
    }
}
