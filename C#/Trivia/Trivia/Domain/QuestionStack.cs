using System;
using System.Collections.Generic;
using System.Linq;
using Trivia.DataAccess;

namespace Trivia.Domain
{
    public class QuestionStack
    {
        public string Name { get; private set; }

        private LinkedList<String> ListQuestions { get; set; }

        public QuestionStack(string name, IQuestionsRepository questionsRepository)
        {
            Name = name;
            ListQuestions = new LinkedList<string>();
            ListQuestions = questionsRepository.GetQuestions(name);
        }


        public String GetQuestion()
        {
            var question = ListQuestions.First();
            ListQuestions.RemoveFirst();
            return question;
        }
    }
}
