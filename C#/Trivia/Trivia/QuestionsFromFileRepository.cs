using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionsFromFileRepository : IQuestionsRepository
    {
        public LinkedList<string> GetQuestions(string category)
        {
            return new LinkedList<string>(System.IO.File.ReadAllLines(@"F:\dotNet\trivia\C#\Trivia\Trivia.Tests\" + category + ".txt"));
        }
    } 
}