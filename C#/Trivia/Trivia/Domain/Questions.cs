using System;
using System.Collections.Generic;
using Trivia.DataAccess;

namespace Trivia.Domain
{
    public class Questions
    {
        private IQuestionsRepository _questionsRepository;
        private readonly List<QuestionStack> _listQuestionStack;

        public Questions(IQuestionsRepository questionsRepository)
        {
            _listQuestionStack = new List<QuestionStack>();
            _questionsRepository = questionsRepository;

        }

        public Questions(IEnumerable<String> questions, IQuestionsRepository questionsRepository)
        {
            _listQuestionStack = new List<QuestionStack>();
            _questionsRepository = questionsRepository;
            foreach (var question in questions)
            {
                AddQuestionStack(question);
            }
        }
        public void AddQuestionStack(String name)
        {
            _listQuestionStack.Add(new QuestionStack(name, _questionsRepository));

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
