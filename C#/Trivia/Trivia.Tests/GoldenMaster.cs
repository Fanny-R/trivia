using ApprovalTests;
using NUnit.Framework;
using System;
using System.IO;
using ApprovalTests.Reporters;

namespace Trivia.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class GoldenMaster
    {
        [Test]
        public void ShouldNotChange()
        {
            var stringWriter = new StringWriter();
            var previousConsoleWriter = Console.Out;
            Console.SetOut(stringWriter);
            GameRunner.Main(null);
            Console.SetOut(previousConsoleWriter);
            Approvals.Verify(stringWriter.ToString());
        }

    }
}
