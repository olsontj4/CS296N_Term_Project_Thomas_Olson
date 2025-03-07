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
        public IActionResult Index()
        {
            var quizzes = repo.GetAllQuizzes().Where(q => q.IsComplete == true).ToList();
            var searchVM = new SearchVM();
            searchVM.Quizzes = quizzes;
            return View(searchVM);
        }
        public IActionResult Search(SearchVM searchVM)
        {
            if (searchVM.Search != null)
            {
                var quizzes = repo.GetAllQuizzes().Where(q => q.Title.Contains(searchVM.Search) || q.Description.Contains(searchVM.Search) || q.AppUser.UserName.Contains(searchVM.Search)).Where(q => q.IsComplete == true).ToList();
                searchVM.Quizzes = quizzes;
                return View("Index", searchVM);
            }
            else
            {
                var quizzes = repo.GetAllQuizzes().Where(q => q.IsComplete == true).ToList();
                searchVM = new SearchVM();
                searchVM.Quizzes = quizzes;
                return View("Index", searchVM);
            }
        }
        public IActionResult Quiz(int id)  //First page of quiz.
        {
            var quiz = repo.GetQuizById(id);
            QuizVM vm = new QuizVM();
            vm.Quiz = quiz;
            return View(vm);
        }
        public IActionResult QuizQuestion([FromForm]QuizVM quizVM)  //Each question in quiz.
        {
            if (quizVM.AnswerInput != null)
            {
                quizVM.UserA.Add(quizVM.AnswerInput);
            }
            quizVM.Quiz = repo.GetQuizById(quizVM.Quiz.Id);
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