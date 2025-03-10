using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            if (searchVM.CreateAccount == true)
            {
                return View(searchVM);
            }

            searchVM.Password = null;
            var quizzes = await repo.GetAllQuizzesAsync();
            searchVM.Quizzes = quizzes;
            return View(searchVM);
        }
    }
}
