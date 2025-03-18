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
        public async Task<IActionResult> Index()
        {
            var featured = new List<int>()
            {
                6,
                4
            };
            var quizzes = new List<Quiz>();
            for (int i = 0; i < featured.Count; i++)
            {
                var quiz = await repo.GetQuizByIdAsync(featured[i]);
                if (quiz != null)
                {
                    quizzes.Add(quiz);
                }
            }
            return View(quizzes);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
