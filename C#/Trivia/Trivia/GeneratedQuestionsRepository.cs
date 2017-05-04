using System;
using System.Collections.Generic;

namespace Trivia
{
    public class GeneratedQuestionsRepository : IQuestionsRepository
    {

        public System.Collections.Generic.LinkedList<string> GetQuestions(string category)
        {
            LinkedList<String> ListQuestions = new LinkedList<string>();
            for (var i = 0; i < 50; i++)
            {
                ListQuestions.AddLast(category + " Question " + ListQuestions.Count);
            }
            return ListQuestions;
        }

    }
}