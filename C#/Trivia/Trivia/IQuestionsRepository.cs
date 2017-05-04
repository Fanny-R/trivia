using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Trivia
{
    public interface IQuestionsRepository
    {
        LinkedList<String> GetQuestions(String category);
    }
}