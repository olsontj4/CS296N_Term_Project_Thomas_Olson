using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> userManager;
        public EditorController(IRepo r, UserManager<AppUser> userMngr)
        {
            userManager = userMngr;
            repo = r;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var searchVM = new SearchVM();
            var appUser = await userManager.GetUserAsync(User);
            searchVM.Quizzes = await repo.GetUserQuizzesAsync(appUser.Id);
            return View(searchVM);
        }
        [HttpPost]
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
        public async Task<IActionResult> DeleteQuiz(int quizId)
        {
            if (await repo.DeleteQuizAsync(quizId) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Quiz", "Quiz", quizId);
            }
        }
    }
}
