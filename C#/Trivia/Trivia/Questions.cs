using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Questions
    {
        private List<QuestionStack> ListQuestionStack;

        public Questions()
        {
            ListQuestionStack = new List<QuestionStack>();
        }
        public void AddQuestionStack(String name)
        {
            ListQuestionStack.Add(new QuestionStack(name));
        }

        public void GenerateQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                foreach (QuestionStack currentQuestionStack in ListQuestionStack)
                {
                    currentQuestionStack.AddQuestion();
                }
            }
        }

        public String AskQuestion(int currentQuestionStack)
        {
            return ListQuestionStack[currentQuestionStack].GetQuestion();
        }

        public String GetQuestionStackName(int currentQuestionStack)
        {
            return ListQuestionStack[currentQuestionStack].Name;
        }
    }
}
