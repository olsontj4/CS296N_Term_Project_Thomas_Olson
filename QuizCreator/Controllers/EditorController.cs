using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;

namespace QuizCreator.Controllers
{
    public class EditorController : Controller
    {
        private readonly IRepo repo;
        public EditorController(IRepo r)
        {
            repo = r;
        }
        public IActionResult Index()
        {
            var searchVM = new SearchVM();
            return View(searchVM);
        }
        public IActionResult Index(SearchVM searchVM)
        {
            if (searchVM.CreateAccount == true)
            {
                return View(searchVM);
            }

            searchVM.Password = null;
            var quizzes = repo.GetAllQuizzes().Where(q => q.IsComplete == true).ToList();
            searchVM.Quizzes = quizzes;
            return View(searchVM);
        }
    }
}
