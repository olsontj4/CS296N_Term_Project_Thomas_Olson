using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;

namespace QuizCreator.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Index(SearchVM searchVM)
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
    }
}
