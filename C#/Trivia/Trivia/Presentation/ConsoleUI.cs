using System;
using Trivia.Domain;

namespace Trivia.Presentation
{
    class ConsoleUI : IQuestionUI
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
