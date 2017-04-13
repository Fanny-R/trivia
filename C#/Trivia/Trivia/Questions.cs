using System;
using System.Collections.Generic;
namespace Trivia
{
    public class Questions
    {
        private readonly List<QuestionStack> _listQuestionStack;

        public Questions()
        {
            _listQuestionStack = new List<QuestionStack>();
        }
        public void AddQuestionStack(String name)
        {
            _listQuestionStack.Add(new QuestionStack(name));
        }

        public void GenerateQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                foreach (QuestionStack currentQuestionStack in _listQuestionStack)
                {
                    currentQuestionStack.AddQuestion();
                }
            }
        }

        public String AskQuestion(int playerPlace)
        {
            return CurrentQuestionStack(playerPlace).GetQuestion();
        }

        public String GetQuestionStackName(int playerPlace)
        {
            return CurrentQuestionStack(playerPlace).Name;
        }

        private QuestionStack CurrentQuestionStack(int playerPlace)
        {
            return _listQuestionStack[playerPlace % _listQuestionStack.Count];
        }
    }
}
