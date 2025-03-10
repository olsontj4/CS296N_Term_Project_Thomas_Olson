using QuizCreator.Controllers;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;
using QuizCreator.Tools;

namespace QuizTests
{
    public class QuizTests
    {
        private readonly IRepo repo = new FakeRepo();
        private readonly QuizController controller;
        public QuizTests()
        {
            controller = new QuizController(repo);
        }
        [Fact]
        public async Task CheckAnswersAsync()
        {
            QuizVM quizVM = new()
            {
                Quiz = await repo.GetQuizByIdAsync(1)
            };
            quizVM.UserA.Add("Than.");
            quizVM.UserA.Add("I hate it.");
            quizVM.UserA.Add("Aubrey.");
            quizVM.UserA.Add("No.");
            Assert.NotNull(quizVM.Quiz);
            quizVM = Scoring.CheckAll(quizVM);
            Assert.Equal(25, Scoring.CheckAll(quizVM).Score);
            Assert.Equal("You're not a Than.", quizVM.EndTitle);
        }
    }
}