using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using ApprovalUtilities.Utilities;
using NUnit.Framework;

namespace Trivia.Tests
{
    class QuestionsShould
    {
        [Test]
        public void AllowToUse5Categories()
        {
            //Arrange/actors
            var stringWriter = new StringWriter();
            var previousConsoleOut = Console.Out;
            Console.SetOut(stringWriter);
            var category5 = "Category 5";
            var questions = new Questions(new [] { "Category 1", "Category 2", "Category 3", "Category 4", category5}, new GeneratedQuestionsRepository());

            //Act
            String question = questions.AskQuestion(4);

            //Assert
            Assert.That(question.Contains(category5), Is.True);
            Console.SetOut(previousConsoleOut);
        }
    }
}
