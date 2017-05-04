using NUnit.Framework;

namespace Trivia.Tests
{
    public class QuestionsFromFileRepositoryShould
    {
        [Test]
        public void GetQuestionsInFileAccordingToCategoryName()
        {
            IQuestionsRepository generatesQuestionsRepository = new QuestionsFromFileRepository();

            Assert.That(generatesQuestionsRepository.GetQuestions("Pop").Contains("Question Pop 1"), Is.True);
        }
    }
}