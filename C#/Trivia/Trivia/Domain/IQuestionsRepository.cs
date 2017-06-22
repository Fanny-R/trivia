using System;
using System.Collections.Generic;

namespace Trivia.Domain
{
    public interface IQuestionsRepository
    {
        LinkedList<String> GetQuestions(String category);
    }
}