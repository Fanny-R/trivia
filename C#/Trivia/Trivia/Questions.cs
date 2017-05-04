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

        public Questions(IEnumerable<String> questions)
        {
            _listQuestionStack = new List<QuestionStack>();
            foreach (var question in questions)
            {
                AddQuestionStack(question);
            }
        }
        public void AddQuestionStack(String name)
        {
            _listQuestionStack.Add(new QuestionStack(name));
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
