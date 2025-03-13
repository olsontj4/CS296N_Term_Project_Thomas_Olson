using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;
using System.Threading.Tasks;

namespace QuizCreator.Controllers
{
    [Authorize]
    public class CreatorController : Controller
    {
        private readonly IRepo repo;
        private readonly UserManager<AppUser> userManager;
        public CreatorController(IRepo r, UserManager<AppUser> userMngr)
        {
            userManager = userMngr;
            repo = r;
        }
        public IActionResult Creator()
        {
            var creatorVM = new CreatorVM();
            return View(creatorVM);
        }
        public async Task<IActionResult> CreatorStart(CreatorVM creatorVM)
        {
            if (creatorVM.Quiz?.Id > 0)
            {
                creatorVM.Quiz = await repo.GetQuizByIdAsync(creatorVM.Quiz.Id);
                creatorVM.Quiz.IsComplete = false;
                return View("Creator", creatorVM);
            }
            if (creatorVM.Quiz != null && ModelState.IsValid )  //Success condition.
            {
                if (creatorVM.NextPage > creatorVM.Quiz.Questions.Count)  //New question.
                {
                    creatorVM.Quiz.Questions.Add(new());
                    creatorVM.Quiz.Questions[creatorVM.Page].A.Add(new());
                    creatorVM.Quiz.Questions[creatorVM.Page].AKey.Add(new AKey() { AKeyBool = false });
                    creatorVM.Page = creatorVM.Quiz.Questions.Count;
                    return View("Creator", creatorVM);
                }
                else
                {
                    creatorVM.Page = creatorVM.NextPage;
                    return View("Creator", creatorVM);
                }
                creatorVM.Quiz.Questions.Add(new());
                creatorVM.Quiz.Questions[0].A.Add(new());
                creatorVM.Quiz.Questions[0].AKey.Add(new AKey() { AKeyBool = false });
                creatorVM.Page = 1;
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
                else
                {
                    if (creatorVM.NextPage != creatorVM.Page)  //Different question.
                    {
                        if (creatorVM.NextPage > creatorVM.Quiz.Questions.Count)  //New question.
                        {
                            creatorVM.Quiz.Questions.Add(new());
                            creatorVM.Quiz.Questions[creatorVM.Page].A.Add(new());
                            creatorVM.Quiz.Questions[creatorVM.Page].AKey.Add(new AKey() { AKeyBool = false });
                            creatorVM.Page = creatorVM.Quiz.Questions.Count;
                            return View("Creator", creatorVM);
                        }
                        else
                        {
                            creatorVM.Page = creatorVM.NextPage;
                            return View("Creator", creatorVM);
                        }
                    }
                    else
                    {
                        return View("Creator", creatorVM);
                    }
                }
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
        public async Task<IActionResult> CreatorPost(CreatorVM creatorVM)
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
            creatorVM.Quiz.AppUser = await userManager.GetUserAsync(User);
            if (creatorVM.Quiz.EndResult != null && ModelState.IsValid)  //Success condition.
            {
                await repo.StoreQuizAsync(creatorVM.Quiz);
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