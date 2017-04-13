using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    class QuestionStack
    {
        public string Name { get; private set; }

        private LinkedList<String> ListQuestions { get; set; }

        public QuestionStack(string name)
        {
            Name = name;
            ListQuestions = new LinkedList<string>();
        }

        public void AddQuestion()
        {
            ListQuestions.AddLast(Name + " " + ListQuestions.Count);
        }

        public String GetQuestion()
        {
            var question = ListQuestions.First();
            ListQuestions.RemoveFirst();
            return question;
        }
    }
}
