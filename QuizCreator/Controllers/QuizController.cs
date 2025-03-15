using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;
using QuizCreator.Tools;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var searchVM = new SearchVM();
            searchVM.ResultsPerPage = 8;
            var quizzes = await repo.FilterAllQuizzesAsync(searchVM);
            searchVM.ResultsPerPage = 0;
            searchVM.Quizzes = quizzes;
            return View(searchVM);
        }
        public async Task<IActionResult> Search(SearchVM searchVM)
        {
            if (searchVM.ResultsPerPage == 0)
            {
                searchVM.ResultsPerPage = 8;
                searchVM.Quizzes = await repo.FilterAllQuizzesAsync(searchVM);
                searchVM.ResultsPerPage = 0;
            }
            else
            {
                searchVM.Quizzes = await repo.FilterAllQuizzesAsync(searchVM);
            }
            return View("Index", searchVM);
        }
        public async Task<IActionResult> Quiz(int id)  //First page of quiz.
        {
            var quiz = await repo.GetQuizByIdAsync(id);
            if (quiz != null)
            {
                QuizVM vm = new()
                {
                    Quiz = quiz
                };
                return View(vm);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> QuizQuestionAsync([FromForm]QuizVM quizVM)  //Each question in quiz.
        {
            if (quizVM.Quiz == null)
            {
                return RedirectToAction("Index");
            }
            if (quizVM.AnswerInput != 0 && quizVM.AnswerInput != null)
            {
                quizVM.UserA.Add(quizVM.AnswerInput);
            }
            quizVM.Quiz = await repo.GetQuizByIdAsync(quizVM.Quiz.QuizId);
            if (quizVM.Page > quizVM.Quiz.Questions.Count)  //End results.
            {
                quizVM = Scoring.CheckAll(quizVM);
                return View("Quiz", quizVM);
            }
            List<A> answers = quizVM.Quiz.Questions[quizVM.Page - 1].A;
            foreach (var a in answers)
            {
                quizVM.AnswersInView.Add(a);
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