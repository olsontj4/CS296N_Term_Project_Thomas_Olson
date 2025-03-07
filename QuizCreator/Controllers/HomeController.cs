using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;

namespace QuizCreator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepo repo;
        public HomeController(ILogger<HomeController> logger, IRepo r)
        {
            repo = r;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var quizzes = new List<Quiz>
            {
                repo.GetQuizById(6)
            };
            return View(quizzes);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserPage(AppUser user)
        {
            List<Quiz> quizzes = new();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
