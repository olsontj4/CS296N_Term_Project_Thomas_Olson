using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;
using QuizCreator.Tools;
using System.Diagnostics;

namespace QuizCreator.Controllers
{
    public class QuizController : Controller
    {
        private readonly IRepo repo;
        public QuizController(IRepo r)
        {
            repo = r;
        }
        public async Task<IActionResult> Index()
        {
            var quizzes = await repo.GetAllQuizzesAsync();
            var searchVM = new SearchVM();
            searchVM.Quizzes = quizzes;
            return View(searchVM);
        }
        public async Task<IActionResult> Search(SearchVM searchVM)
        {
            if (searchVM.Search != null)
            {
                List<Quiz> quizzes = await repo.FilterAllQuizzesAsync(searchVM.Search);
                searchVM.Quizzes = quizzes;
                return View("Index", searchVM);
            }
            else
            {
                var quizzes = await repo.GetAllQuizzesAsync();
                searchVM = new SearchVM();
                searchVM.Quizzes = quizzes;
                return View("Index", searchVM);
            }
        }
        public async Task<IActionResult> Quiz(int id)  //First page of quiz.
        {
            var quiz = await repo.GetQuizByIdAsync(id);
            QuizVM vm = new QuizVM();
            vm.Quiz = quiz;
            return View(vm);
        }
        public async Task<IActionResult> QuizQuestionAsync([FromForm]QuizVM quizVM)  //Each question in quiz.
        {
            if (quizVM.AnswerInput != null)
            {
                quizVM.UserA.Add(quizVM.AnswerInput);
            }
            quizVM.Quiz = await repo.GetQuizByIdAsync(quizVM.Quiz.Id);
            if (quizVM.Page > quizVM.Quiz.Questions.Count)  //End results.
            {
                quizVM = Scoring.CheckAll(quizVM);
                return View("Quiz", quizVM);
            }
            List<A> answers = quizVM.Quiz.Questions[quizVM.Page - 1].A;
            foreach (var a in answers)
            {

                quizVM.AnswersInView.Add(a.AString);
            }
            return View("Quiz", quizVM);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}