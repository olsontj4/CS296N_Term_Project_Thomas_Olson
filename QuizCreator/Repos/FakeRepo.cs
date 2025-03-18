using Microsoft.EntityFrameworkCore;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using System.Runtime.Intrinsics.X86;

namespace QuizCreator.Repos
{
    public class FakeRepo : IRepo
    {
        private List<Quiz> quizzes = new List<Quiz>();
        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<Quiz>> GetUserQuizzesAsync(string id, string search)
        {
            throw new NotImplementedException();
        }
        public Task<List<Quiz>> FilterAllQuizzesAsync(SearchVM searchVM)
        {
            throw new NotImplementedException();
        }
        public async Task<Quiz> GetQuizByIdAsync(int id)
        {
            AppUser user2 = new AppUser { UserName = "Than" };
            return new Quiz()
            {
                QuizId = 2,
                Title = "Are you Than?",
                Description = "Take this quiz to figure out if you're a certified Than!",
                Type = "Trivia",
                AppUser = user2,
                Date = DateTime.Parse("12/06/2024"),
                IsComplete = true,
                Questions = new List<Question>()
                    {
                        new()
                        {
                            Q = "",
                            A = new()
                            {
                                new() { AId = 1 },
                                new() { AId = 2 },
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                            }
                        },
                        new()
                        {
                            Q = "",
                            A = new()
                            {
                                new() { AId = 3 },
                                new() { AId = 4 },
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                            }
                        },
                        new()
                        {
                            Q = "",
                            A = new()
                            {
                                new() { AId = 5 },
                                new() { AId = 6 },
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                            }
                        },
                        new()
                        {
                            Q = "",
                            A = new()
                            {
                                new() { AId = 7 },
                                new() { AId = 8 },
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                            }
                        },
                        new()
                        {
                            Q = "",
                            A = new()
                            {
                                new() { AId = 9 },
                                new() { AId = 10 },
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                            }
                        },
                        new()
                        {
                            Q = "",
                            A = new()
                            {
                                new() { AId = 11 },
                                new() { AId = 12 },
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                            }
                        },
                    },
                EndResult = new EndResult()
                {
                    EndTitles = new()
                    {
                        new() { EndResultString = "100" },
                        new() { EndResultString = "87" },
                        new() { EndResultString = "62" },
                        new() { EndResultString = "37" },
                        new() { EndResultString = "12" }
                    },
                    EndMessages = new()
                    {
                        new() { EndResultString = "88" },
                        new() { EndResultString = "63" },
                        new() { EndResultString = "38" },
                        new() { EndResultString = "13" },
                        new() { EndResultString = "0" }
                    },
                    DisplayScore = false
                }
            };
        }
        public async Task<int> StoreQuizAsync(Quiz model)
        {
            throw new NotImplementedException();
        }
        public async Task<int> UpdateQuizAsync(Quiz model)
        {
            throw new NotImplementedException();
        }
        public async Task<int> DeleteQuizAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}