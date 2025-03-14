using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using QuizCreator.Repos;

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
            ModelState.Remove("Quiz.AppUser");
            if (creatorVM.Quiz?.QuizId > 0 && creatorVM.NextPage == 0)
            {
                creatorVM.Quiz = await repo.GetQuizByIdAsync(creatorVM.Quiz.QuizId);
                creatorVM.Quiz.IsComplete = false;
                return View("Creator", creatorVM);
            }
            ModelState.Remove("Quiz.EndResult.EndTitles");
            ModelState.Remove("Quiz.EndResult.EndMessages");
            ModelState.Remove("Quiz.EndResult.DisplayScore");
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
            }
            else  //Failure condition.
            {
                creatorVM.Page = 0;
                return View("Creator", creatorVM);
            }
        }
        public IActionResult CreatorQuestion(CreatorVM creatorVM)
        {
            ModelState.Remove("Quiz.AppUser");
            if (creatorVM.AddAnswer == true)  //Add answer button.
            {
                creatorVM.Quiz.Questions[creatorVM.Page - 1].A.Add(new());
                creatorVM.Quiz.Questions[creatorVM.Page - 1].AKey.Add(new AKey() { AKeyBool = false });
                creatorVM.AddAnswer = false;
                return View("Creator", creatorVM);
            }
            else if (creatorVM.DeleteAnswer > -1)
            {
                if (creatorVM.Quiz.Questions[creatorVM.Page - 1].A.Count > 1)//Delete if more than two answers exist.
                {
                    creatorVM.Quiz.Questions[creatorVM.Page - 1].A.RemoveAt(creatorVM.DeleteAnswer);
                    creatorVM.Quiz.Questions[creatorVM.Page - 1].AKey.RemoveAt(creatorVM.DeleteAnswer);
                }
                return View("Creator", creatorVM);
            }
            else if (creatorVM.DeleteQuestion > -1)
            {
                if (creatorVM.Quiz.Questions.Count > 1)//Delete if more than two questions exist.
                {
                    creatorVM.Page = Math.Min(creatorVM.Quiz.Questions.Count - 1, creatorVM.Page);
                    creatorVM.Quiz.Questions.RemoveAt(creatorVM.DeleteQuestion);
                }
                return View("Creator", creatorVM);
            }
            ModelState.Remove("Quiz.EndResult.EndTitles");
            ModelState.Remove("Quiz.EndResult.EndMessages");
            ModelState.Remove("Quiz.EndResult.DisplayScore");
            if (creatorVM.Quiz.Questions[creatorVM.Page - 1] != null && ModelState.IsValid)  //Success condition.
            {
                if (creatorVM.Quiz.IsComplete == true)  //Last question complete.
                {
                    if (creatorVM.Quiz.EndResult?.EndTitles != null)
                    {
                        return View("Creator", creatorVM);
                    }
                    else
                    {
                        creatorVM.Quiz.EndResult = new()
                        {
                            EndTitles = new(),
                            EndMessages = new()
                        };
                        creatorVM.Quiz.EndResult.EndTitles.Add(new());
                        creatorVM.Quiz.EndResult.EndMessages.Add(new());
                        return View("Creator", creatorVM);
                    }

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
                return View("Creator", creatorVM);
            }
        }
        public async Task<IActionResult> CreatorPost(CreatorVM creatorVM)
        {
            ModelState.Remove("Quiz.AppUser");
            creatorVM.Page = (creatorVM.Quiz.Questions.Count + 1);
            if (creatorVM.NextPage != 0)
            {
                creatorVM.Quiz.IsComplete = false;
                creatorVM.Page = creatorVM.Quiz.Questions.Count;
                return View("Creator", creatorVM);
            }
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
            else if (creatorVM.DeleteQuestion > -1)
            {
                if (creatorVM.Quiz.EndResult.EndTitles.Count > 1)//Delete if more than two results exist.
                {
                    creatorVM.Quiz.EndResult.EndTitles.RemoveAt(creatorVM.DeleteQuestion);
                    creatorVM.Quiz.EndResult.EndMessages.RemoveAt(creatorVM.DeleteQuestion);
                }
                return View("Creator", creatorVM);
            }
            creatorVM.Quiz.AppUser = await userManager.GetUserAsync(User);
            if (creatorVM.Quiz.EndResult != null && ModelState.IsValid)  //Success condition.
            {
                if (creatorVM.Quiz.QuizId > 0)//Check whether quiz is new or being updated.
                {
                    if (creatorVM.Quiz.AppUser.UserName == User.Identity?.Name)//Check if user signed in is still the original creator.
                    {
                        if (await repo.DeleteQuizAsync(creatorVM.Quiz.QuizId) > 0)//Check if delete of original quiz was successful.
                        {
                            await repo.StoreQuizAsync(creatorVM.Quiz);//I was going to use my update method for the database, but it duplicated child classes in the quiz model.
                            return RedirectToAction("Index", "Quiz");
                        }
                        return View("Creator", creatorVM);
                    }
                }
                await repo.StoreQuizAsync(creatorVM.Quiz);
                return RedirectToAction("Index", "Quiz");
            }
            else  //Failure condition.
            {
                return View("Creator", creatorVM);
            }
        }
    }
}