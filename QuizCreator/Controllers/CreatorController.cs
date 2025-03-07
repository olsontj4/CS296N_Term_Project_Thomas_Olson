using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;

namespace QuizCreator.Controllers
{
    public class CreatorController : Controller
    {
        private readonly IRepo repo;
        public CreatorController(IRepo r)
        {
            repo = r;
        }
        public IActionResult Creator()
        {
            var creatorVM = new CreatorVM();
            creatorVM.Page = 0;
            return View(creatorVM);
        }
        public IActionResult CreatorStart(CreatorVM creatorVM)
        {
            if (creatorVM.Quiz != null && ModelState.IsValid )  //Success condition.
            {
                creatorVM.Quiz.Questions.Add(new());
                creatorVM.Quiz.Questions[0].A.Add(new());
                creatorVM.Quiz.Questions[0].AKey.Add(new AKey() { AKeyBool = false });
                return View("Creator", creatorVM);
            }
            else  //Failure condition.
            {
                if (ModelState.Where(e => e.Value.Errors.Count > 0).ToList()[0].Value.Errors[0].ErrorMessage.ToString() != null)
                {
                    ViewBag.ErrorMessage = ModelState.Where(e => e.Value.Errors.Count > 0).ToList()[0].Value.Errors[0].ErrorMessage.ToString();
                }
                else
                {
                    ViewBag.ErrorMessage = "Error saving quiz.";
                }
                creatorVM.Page = 0;
                return View("Creator", creatorVM);
            }
        }
        public IActionResult CreatorQuestion(CreatorVM creatorVM)
        {
            if (creatorVM.Page == 0 && creatorVM.Quiz.IsComplete == true)
            {
                creatorVM.Page = 1;
            }
            if(creatorVM.AddAnswer == true)  //Add answer button.
            {
                creatorVM.Quiz.Questions[creatorVM.Page - 1].A.Add(new());
                creatorVM.Quiz.Questions[creatorVM.Page - 1].AKey.Add(new AKey() { AKeyBool = false });
                creatorVM.AddAnswer = false;
                creatorVM.Page = creatorVM.Quiz.Questions.Count;
                return View("Creator", creatorVM);
            }
            if (creatorVM.Quiz.Questions[creatorVM.Page - 1] != null && ModelState.IsValid)  //Success condition.
            {
                if (creatorVM.Quiz.IsComplete == true)  //Last question complete.
                {
                    return View("Creator", creatorVM);
                }
                creatorVM.Quiz.Questions.Add(new());
                creatorVM.Quiz.Questions[creatorVM.Page].A.Add(new());
                creatorVM.Quiz.Questions[creatorVM.Page].AKey.Add(new AKey() { AKeyBool = false });
                creatorVM.Page = creatorVM.Quiz.Questions.Count;
                return View("Creator", creatorVM);
            }
            else  //Failure condition.
            {
                if (ModelState.Where(e => e.Value.Errors.Count > 0).ToList()[0].Value.Errors[0].ErrorMessage.ToString() != null)
                {
                    ViewBag.ErrorMessage = ModelState.Where(e => e.Value.Errors.Count > 0).ToList()[0].Value.Errors[0].ErrorMessage.ToString();
                }
                else
                {
                    ViewBag.ErrorMessage = "Error saving quiz.";
                }
                creatorVM.Page = creatorVM.Quiz.Questions.Count;
                return View("Creator", creatorVM);
            }
        }
        public IActionResult CreatorPost(CreatorVM creatorVM)
        {
            creatorVM.Page = 1;
            foreach (var q in creatorVM.Quiz.Questions)
            {
                foreach (var b in q.AKey)
                {
                    if (b.AKeyBool == null)
                    {
                        b.AKeyBool = false;
                    }
                }
            }
            //creatorVM.Quiz.IsComplete = true;
            if (creatorVM.AddAnswer == true)  //Add new result button.
            {
                creatorVM.Quiz.EndResult.EndTitles.Add(new());
                creatorVM.Quiz.EndResult.EndMessages.Add(new());
                creatorVM.AddAnswer = false;
                return View("Creator", creatorVM);
            }
            if (creatorVM.Quiz.EndResult != null && ModelState.IsValid)  //Success condition.
            {
                repo.StoreQuiz(creatorVM.Quiz);
                return RedirectToAction("Index", "Quiz");
            }
            else  //Failure condition.
            {
                if (ModelState.Where(e => e.Value.Errors.Count > 0).ToList()[0].Value.Errors[0].ErrorMessage.ToString() != null)
                {
                    ViewBag.ErrorMessage = ModelState.Where(e => e.Value.Errors.Count > 0).ToList()[0].Value.Errors[0].ErrorMessage.ToString();
                }
                else
                {
                    ViewBag.ErrorMessage = "Error saving quiz.";
                }
                creatorVM.Page = creatorVM.Quiz.Questions.Count;
                return View("Creator", creatorVM);
            }
        }
    }
}