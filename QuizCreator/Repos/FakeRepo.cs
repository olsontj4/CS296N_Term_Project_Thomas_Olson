using Microsoft.EntityFrameworkCore;
using QuizCreator.Models;
using System.Runtime.Intrinsics.X86;

namespace QuizCreator.Repos
{
    public class FakeRepo : IRepo
    {
        private List<Quiz> quizzes = new List<Quiz>();
        public List<Quiz> GetAllQuizzes()
        {
            throw new NotImplementedException();
        }

        public Quiz GetQuizById(int id)
        {
            AppUser user2 = new AppUser { UserName = "Than" };
            return new Quiz()
            {
                Id = 2,
                Title = "Are you Than?",
                Description = "Take this quiz to figure out if you're a certified Than!",
                Type = "Trivia",
                AppUser = user2,
                Date = DateTime.Parse("12/06/2024"),
                IsComplete = true,
                Questions = new List<Question>()
                    {
                        new Question()
                        {
                            Q = "What's your name?",
                            A = new()
                            {
                                new() { AString = "Dylan." },
                                new() { AString = "Logan." },
                                new() {AString = "Than." },
                                new() {AString = "Thomas." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "What's your opinion on toast?",
                            A = new()
                            {
                                new() { AString = "I love it." },
                                new() { AString = "I hate it." },
                                new() { AString = "I'm toast." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = true }
                            }
                        },
                        new Question()
                        {
                            Q = "What's your profile picture?",
                            A = new()
                            {
                                new() { AString = "Aubrey." },
                                new() { AString = "Basil." },
                                new() { AString = "Kel." },
                                new() { AString = "Sprout mole." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Yummy Thomas?",
                            A = new()
                            {
                                new() { AString = "Yummy Thomas. >:3" },
                                new() { AString = "Yes." },
                                new() { AString = "Maybe." },
                                new() { AString = "Not really." },
                                new() { AString = "No." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                    },
                EndResult = new EndResult()
                {
                    EndTitles = new()
                        {
                            new() { EndResultString = "You're a certified Than!!" },
                            new() { EndResultString = "You might be a Than." },
                            new() { EndResultString = "You're not a Than." }
                        },
                    EndMessages = new()
                        {
                            new() { EndResultString = "You're the coolest guy bestest guy." },
                            new() { EndResultString = "Not a fully fledged one, though." },
                            new() { EndResultString = "What's wrong with you?" }
                        },
                    DisplayScore = false
                }
            };
        }

        public int StoreQuiz(Quiz model)
        {
            throw new NotImplementedException();
        }
    }
}