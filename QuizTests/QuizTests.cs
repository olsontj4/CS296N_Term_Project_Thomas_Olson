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
            quizVM.UserA.Add(1);
            quizVM.UserA.Add(4);
            quizVM.UserA.Add(6);
            quizVM.UserA.Add(8);
            quizVM.UserA.Add(10);
            quizVM.UserA.Add(12);
            Assert.NotNull(quizVM.Quiz);
            quizVM = Scoring.CheckAll(quizVM);
            Assert.Equal(17, Scoring.CheckAll(quizVM).Score);//Expected score.
            Assert.Equal("37", quizVM.EndTitle);//Score maximum.
            Assert.Equal("13", quizVM.EndMessage);//Score minimum.
        }
        [Fact]
        public void ImageValidation()
        {
            ImageValidator imageValidator = new();
            Assert.True(imageValidator.IsValid("https://media.discordapp.net/attachments/841054851215654943/1350192102843089006/coding_quiz_banner.jpg?ex=67d5d7e2&is=67d48662&hm=58bd5a5d444a993bb2d73ca05225df547a7592c754f6b8272369d9cf26023ac6&=&format=webp&width=1006&height=1006"));
            Assert.True(imageValidator.IsValid("https://cdn.discordapp.com/attachments/1219790975216390145/1350242582826848402/sddefault_2_1.jpg?ex=67d606e6&is=67d4b566&hm=b4da0ea4756ddd5088147391eef31458860eb5ceb19401e60761430536d560ef&"));
            Assert.False(imageValidator.IsValid("https://media.discordapp.net/attachments/841054851215654943/1350192102843089006/coding_quiz_banner.exe?ex=67d5d7e2&is=67d48662&hm=58bd5a5d444a993bb2d73ca05225df547a7592c754f6b8272369d9cf26023ac6&=&format=webp&width=1006&height=1006"));
        }
    }
}