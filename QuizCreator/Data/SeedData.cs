using QuizCreator.Models;
using System.Runtime.CompilerServices;

namespace QuizCreator.Data
{
    public class SeedData
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Quizzes.Any())  // this is to prevent adding duplicate data
            {
                AppUser thomasj041 = new AppUser { UserName = "Thomasj041" };  // Create User objects
                AppUser than = new AppUser { UserName = "Than" };
                AppUser logan = new AppUser { UserName = "Logan" };
                AppUser chatGPT = new AppUser { UserName = "ChatGPT" };
                AppUser dylan = new AppUser() { UserName = "Dylan" };
                AppUser thomasJefferson = new AppUser() { UserName = "Thomas Jefferson" };
                AppUser jonathonMath = new AppUser() { UserName = "Jonathon Math" };
                AppUser profBird = new AppUser() { UserName = "ProfBird" };
                AppUser max = new AppUser() { UserName = "max" };
                AppUser pikachew3 = new AppUser() { UserName = "Pikachew3" };
                context.AppUsers.Add(thomasj041);  // Queue up user objects to be saved to the DB
                context.AppUsers.Add(than);
                context.AppUsers.Add(logan);
                context.AppUsers.Add(chatGPT);
                context.AppUsers.Add(dylan);
                context.AppUsers.Add(thomasJefferson);
                context.AppUsers.Add(jonathonMath);
                context.AppUsers.Add(profBird);
                context.AppUsers.Add(max);
                context.AppUsers.Add(pikachew3);
                context.SaveChanges();  // Saving adds UserId to User objects
                Quiz quiz1 = new Quiz()
                {
                    Id = 1,
                    Title = "Are you in the Kool Kids Klub?",
                    Description = "Take this quiz to figure out if you're a true Kool Kid!",
                    Type = "Trivia",
                    AppUser = thomasj041,
                    Date = DateTime.Parse("12/04/2024"),
                    IsComplete = true,
                    Questions = new List<Question>()
                    {
                        new Question()
                        {
                            Q = "Are you in the Kool Kids Klub?",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "No." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Do you want to be in the Kool Kids Klub?",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "No." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                    },
                    EndResult = new EndResult()
                    {
                        EndTitles = new()
                        {
                            new() { EndResultString = "You are in the Kool Kids Klub!" }
                        },
                        EndMessages = new()
                        {
                            new() { EndResultString = "I knew you always were a Kool Kid. (There's no other option.)" }
                        },
                        DisplayScore = false
                    }
                };
                Quiz quiz2 = new Quiz()
                {
                    Id = 2,
                    Title = "Are you Than?",
                    Description = "Take this quiz to figure out if you're a certified Than!",
                    Type = "Trivia",
                    AppUser = than,
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
                Quiz bestquiz = new Quiz()
                {
                    Id = 3,
                    Title = "What Disney Princess are you?",
                    Description = "What Pixar Princess are you?",
                    Type = "Trivia",
                    AppUser = logan,
                    Date = DateTime.Parse("04/01/1987"),
                    IsComplete = true,
                    Questions = new List<Question>()
                    {
                        new Question()
                        {
                            Q = "What is your star sign?",
                            A = new()
                            {
                                new() { AString = "Virgin olive oil" },
                                new() { AString = "Breast cancer" },
                                new() { AString = "Simba (the best Disney princess)" },
                                new() { AString = "Well, my sun sign is a Vulture, but my moon rising is a Tartar sauce, and I'm an gastrointestinal rising." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "What do you have for breakfast?",
                            A = new()
                            {
                                new() { AString = "Virgin olive oil" },
                                new() { AString = "Beast cancer" },
                                new() { AString = "Simba (the best Disney princess)" },
                                new() { AString = "Well, my sun sign is a Vulture, but my moon rising is a Tartar sauce, and I'm an gastrointestinal rising." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "What is your favourite flavour of pizza?",
                            A = new()
                            {
                                new() { AString = "Pizza." },
                                new() { AString = "No, I don't like pizza." },
                                new() { AString = "Without bread." },
                                new() { AString = "Ew, Br*tish." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "What do you do with your friends on weekends?",
                            A = new()
                            {
                                new() { AString = "Friends is my favourite show." },
                                new() { AString = "Friends is my favorite show." },
                                new() { AString = "Go to a bar, hit on girls." },
                                new() { AString = "Have a week end (because I have IBS) ((just like the girls I hit on))." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Oh no, you have a restraining order from the girls you hit on! What do you do?",
                            A = new()
                            {
                                new() { AString = "Hit the girls." },
                                new() { AString = "Hit on boys from now on." },
                                new() { AString = "Get left out of the playdate I initiated." },
                                new() { AString = "Hit on Br*tish girls instead." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "What quality you want in a partner?",
                            A = new()
                            {
                                new() { AString = "Quality module tier II" },
                                new() { AString = "Made in China." },
                                new() { AString = "Atleast 4 toes." },
                                new() { AString = "Fertile." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you Rapunzel?",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "No." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you Mulan?",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "No." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you Fiona?",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "No." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you Princess Twilight Sparkle?",
                            A = new()
                            {
                                new() { AString = "Yeigh." },
                                new() { AString = "Neigh." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you in trouble?",
                            A = new()
                            {
                                new() { AString = "She is listening." },
                                new() { AString = "There is no stopping her." },
                                new() { AString = "Leave while you still can." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you Jasmine?",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "No." },
                                new() { AString = "I told you to leave." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "You deserve this fate.",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "No." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "You deserve this fate.",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "Yes." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you Jasmine?",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "Yes." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "You are Jasmine.",
                            A = new()
                            {
                                new() { AString = "I am Jasmine." },
                                new() { AString = "I am Jasmine." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "You will do as Jasmine does.",
                            A = new()
                            {
                                new() { AString = "I will do as Jasmine does." },
                                new() { AString = "I will do as Jasmine does." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "You will breathe as Jasmine breathe.",
                            A = new()
                            {
                                new() { AString = "I will breathe as Jasmine breathes." },
                                new() { AString = "I will breathe as Jasmine breathes." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "You will feel pain as Jasmine feels.",
                            A = new()
                            {
                                new() { AString = "I am Jasmine." },
                                new() { AString = "I am pain." },
                                new() { AString = "I am hunger, I am thirst." },
                                new() { AString = "I will experience the feeling humanity deserves." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "You will feel pleasure as Jasmine feels.",
                            A = new()
                            {
                                new() { AString = "I am Jasmine." },
                                new() { AString = "I am pleasure." },
                                new() { AString = "I am greed, I am lust." },
                                new() { AString = "I am what humanity strives to torture itself with." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "You are Jasmine.",
                            A = new()
                            {
                                new() { AString = "I am Jasmine." },
                                new() { AString = "I am Jasmine." },
                                new() { AString = "I am Jasmine." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you Ariel?",
                            A = new()
                            {
                                new() { AString = "Yes." },
                                new() { AString = "No." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                    },
                    EndResult = new EndResult()
                    {
                        EndTitles = new()
                        {
                            new() { EndResultString = "Congratulation's, your Arial Italic!" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" + "\nh" }
                        },
                        EndMessages = new()
                        {
                            new() { EndResultString = "help me" }
                        },
                        DisplayScore = true
                    }
                };
                Quiz quiz4 = new Quiz()
                {
                    Id = 4,
                    Title = "Are You a Coding Master?",
                    Description = "Take this quiz to see how well you know coding concepts and practices!",
                    Type = "Trivia",
                    AppUser = chatGPT,
                    Date = DateTime.Parse("12/07/2024"),
                    IsComplete = true,
                    Questions = new List<Question>()
                    {
                        new Question()
                        {
                            Q = "What does HTML stand for?",
                            A = new()
                            {
                                new() { AString = "HyperText Markup Language" },
                                new() { AString = "HyperText Machine Language" },
                                new() { AString = "Home Tool Markup Language" },
                                new() { AString = "HighText Markup Language" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "What is the purpose of a 'for' loop in programming?",
                            A = new()
                            {
                                new() { AString = "To iterate over a block of code a certain number of times" },
                                new() { AString = "To define a function" },
                                new() { AString = "To store values in an array" },
                                new() { AString = "To catch errors" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Which of these is a programming language?",
                            A = new()
                            {
                                new() { AString = "Python" },
                                new() { AString = "HTML" },
                                new() { AString = "CSS" },
                                new() { AString = "All of the above" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Which of the following is NOT a correct variable declaration in JavaScript?",
                            A = new()
                            {
                                new() { AString = "let x = 5;" },
                                new() { AString = "const y = 'Hello';" },
                                new() { AString = "var 3z = 'Coding';" },
                                new() { AString = "let isValid = true;" }
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
                            Q = "What does CSS stand for?",
                            A = new()
                            {
                                new() { AString = "Cascading Style Sheets" },
                                new() { AString = "Creative Style Sheets" },
                                new() { AString = "Computer Style Sheets" },
                                new() { AString = "Cascading Super Sheets" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Which of these is used to style HTML elements?",
                            A = new()
                            {
                                new() { AString = "JavaScript" },
                                new() { AString = "CSS" },
                                new() { AString = "HTML" },
                                new() { AString = "Python" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                    },
                    EndResult = new EndResult()
                    {
                        EndTitles = new()
                        {
                            new() { EndResultString = "You're a Coding Master!" },
                            new() { EndResultString = "You know some coding basics." },
                            new() { EndResultString = "You have room to grow in coding." }
                        },
                        EndMessages = new()
                        {
                            new() { EndResultString = "You're a coding genius! Keep up the great work." },
                            new() { EndResultString = "Not bad! With a bit more practice, you'll be a coding expert." },
                            new() { EndResultString = "Looks like you need to brush up on your coding skills. Keep learning!" }
                        },
                        DisplayScore = true
                    }
                };
                Quiz quiz5 = new Quiz()
                {
                    Id = 5,
                    Title = "Are you procrastinating right now?",
                    Description = "Do you really have time for this?",
                    Type = "Trivia",
                    AppUser = dylan,
                    Date = DateTime.Parse("12/09/2024"),
                    IsComplete = true,
                    Questions = new List<Question>()
                    {
                        new Question()
                        {
                            Q = "Do you have homework to do?",
                            A = new()
                            {
                                new() { AString = "Yes" },
                                new() { AString = "No" },
                                new() { AString = "I am a 57 year old man. I graduated years ago." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Is your room cleaned?",
                            A = new()
                            {
                                new() { AString = "Yes" },
                                new() { AString = "No" },
                                new() { AString = "Who wants to know? You aren’t my mom >:(" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = true },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "How is your to-do list looking?",
                            A = new()
                            {
                                new() { AString = "Long... never ending...." },
                                new() { AString = "It’s completed!" },
                                new() { AString = "I don’t write to-do lists, I just make mental notes and wing it." },
                                new() { AString = "It’s looking kinda hot...." }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Are you doom scrolling?",
                            A = new()
                            {
                                new() { AString = "Maybe...." },
                                new() { AString = "I feel attacked" },
                                new() { AString = "I would never" },
                                new() { AString = "What year is it?" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Go do your work",
                            A = new()
                            {
                                new() { AString = "go do your work" },
                                new() { AString = "go do your work" },
                                new() { AString = "go do your work" },
                                new() { AString = "go do your work" },
                                new() { AString = "go do your work" },
                                new() { AString = "Go do your work" },
                                new() { AString = "go do your work" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "stop looking for a dopamine hit and go get ur shit done",
                            A = new()
                            {
                                new() { AString = "FINE" },
                                new() { AString = "FINE" },
                                new() { AString = "YES I AM DOING MY WORK NOW" },
                                new() { AString = "OK" },
                                new() { AString = "IT IS THE ONLY OPTION LEFT" },
                                new() { AString = "please let me leave, I promise ill do my work" },
                                new() { AString = "I’m sorry I skipped my Spanish lessons, I’ll do them all I promise, please just let my family go ;0;" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = true }
                            }
                        }
                    },
                    EndResult = new EndResult()
                    {
                        EndTitles = new()
                        {
                            new() { EndResultString = "good! stop procrastinating ^^" }
                        },
                        EndMessages = new()
                        {
                            new() { EndResultString = "WHY ARE YOU STILL HERE" }
                        },
                        Score = 0,
                        DisplayScore = true
                    }
                };
                Quiz quiz6 = new Quiz()
                {
                    Id = 6,
                    Title = "Insect Trivia",
                    Description = "Are you a true insect expert? Take this quiz to find out!",
                    Type = "Trivia",
                    AppUser = than,
                    Date = DateTime.Parse("12/04/2024"),
                    IsComplete = true,
                    Questions = new List<Question>()
                    {
                        new Question()
                        {
                            Q = "How many true legs do caterpillars have?",
                            A = new()
                            {
                                new() { AString = "5" },
                                new() { AString = "11" },
                                new() { AString = "6"},
                                new() { AString = "16" }
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
                            Q = "What kind of insects are weevils?",
                            A = new()
                            {
                                new() { AString = "Bees" },
                                new() { AString = "Dragonflies" },
                                new() { AString = "Moths" },
                                new() { AString = "Beetles" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false },
                                new() { AKeyBool = true }
                            }
                        },
                        new Question()
                        {
                            Q = "Which one of these isn’t a type of insect?",
                            A = new()
                            {
                                new() { AString = "Assassin Bug" },
                                new() { AString = "Centipede" },
                                new() { AString = "Katydid" },
                                new() { AString = "Stick Bug" }
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
                            Q = "What is the smallest insect in the world?",
                            A = new()
                            {
                                new() { AString = "Aphid" },
                                new() { AString = "Fairyfly" },
                                new() { AString = "Midget Moth" },
                                new() { AString = "Flea" }
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
                            Q = "Which of these orders fall under the Dictyoptera superorder?",
                            A = new()
                            {
                                new() { AString = "Coleoptera" },
                                new() { AString = "Blattodea" },
                                new() { AString = "Isoptera" },
                                new() { AString = "Mantodea" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = true },
                                new() { AKeyBool = true },
                                new() { AKeyBool = true }
                            }
                        },
                        new Question()
                        {
                            Q = "True or false: Luna moths can live up to 2 months",
                            A = new()
                            {
                                new() { AString = "True" },
                                new() { AString = "False" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = false },
                                new() { AKeyBool = true }
                            }
                        },
                        new Question()
                        {
                            Q = "Finally, out of these three, which flower are ladybugs most attracted to?",
                            A = new()
                            {
                                new() { AString = "Marigolds" },
                                new() { AString = "Roses" },
                                new() { AString = "Carnations" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = false },
                                new() { AKeyBool = false }
                            }
                        },
                        new Question()
                        {
                            Q = "Have a free point (I accidentally added another question)!",
                            A = new()
                            {
                                new() { AString = "Woah!" },
                                new() { AString = "Wow!" },
                                new() { AString = "Yeah!" },
                                new() { AString = "Yippee!" }
                            },
                            AKey = new()
                            {
                                new() { AKeyBool = true },
                                new() { AKeyBool = true },
                                new() { AKeyBool = true },
                                new() { AKeyBool = true }
                            }
                        }
                    },
                    EndResult = new EndResult()
                    {
                        EndTitles = new()
                        {
                            new() { EndResultString = "Insect Expert" },
                            new() { EndResultString = "Insect Enthusiast" },
                            new() { EndResultString = "Insect Explorer" },
                            new() { EndResultString = "Insect Newbie" }
                        },
                                        EndMessages = new()
                        {
                            new() { EndResultString = "Wow, you really know your insects!" },
                            new() { EndResultString = "Nice job! With a little more research, you could easily become an expert." },
                            new() { EndResultString = "You’re off to a great start! You’ve got a good understanding of insects, but there’s still so much more to discover." },
                            new() { EndResultString = "Looks like you’re just starting your journey into the insect world! Make sure to keep studying!" }
                        },
                        Score = 0,
                        DisplayScore = true
                    },
                };
                Quiz quiz7 = new Quiz()
                {
                    Id = 7,
                    Title = "Does Thomas deserve an A?",
                    Description = "Or maybe even an A+... 👀",
                    Type = "Trivia",
                    AppUser = thomasJefferson,
                    Date = DateTime.Parse("2024-12-09T18:13:42.913606"),
                    IsComplete = true,
                    Questions = new List<Question>()
    {
        new Question()
        {
            Q = "Did Thomas do his homework?",
            A = new()
            {
                new() { AString = "Yes!" },
                new() { AString = "No." },
                new() { AString = "Wait, that was due today?" }
            },
            AKey = new()
            {
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false }
            }
        },
        new Question()
        {
            Q = "Did Thomas show up to class on time?",
            A = new()
            {
                new() { AString = "Yes!" },
                new() { AString = "No." }
            },
            AKey = new()
            {
                new() { AKeyBool = true },
                new() { AKeyBool = false }
            }
        },
        new Question()
        {
            Q = "Did Thomas make a website?",
            A = new()
            {
                new() { AString = "Yes!" },
                new() { AString = "No." },
                new() { AString = "Hi, I’m the answer for question 2! Oh shoot, I showed up too late..." }
            },
            AKey = new()
            {
                new() { AKeyBool = true },
                new() { AKeyBool = false },
                new() { AKeyBool = false }
            }
        },
        new Question()
        {
            Q = "Can you navigate on this website?",
            A = new()
            {
                new() { AString = "Navigate to answer: Yes!" },
                new() { AString = "Navigate to answer: No." }
            },
            AKey = new()
            {
                new() { AKeyBool = true },
                new() { AKeyBool = false }
            }
        },
        new Question()
        {
            Q = "Is it running on Azure?",
            A = new()
            {
                new() { AString = "Yes!" },
                new() { AString = "No." },
                new() { AString = "Then maybe you should go catch it." }
            },
            AKey = new()
            {
                new() { AKeyBool = true },
                new() { AKeyBool = false },
                new() { AKeyBool = false }
            }
        },
        new Question()
        {
            Q = "Wow, this quiz seems to be going very well.",
            A = new()
            {
                new() { AString = "All because Thomas did a good job making it!" },
                new() { AString = "This is a very cool idea for a website, with good execution." },
                new() { AString = "No, it’s really not." },
                new() { AString = "Only because 🥺‘s taking it." }
            },
            AKey = new()
            {
                new() { Id = 178, AKeyBool = true },
                new() { Id = 179, AKeyBool = true },
                new() { Id = 180, AKeyBool = false },
                new() { Id = 181, AKeyBool = false }
            }
        },
        new Question()
        {
            Id = 55,
            ImageUrl = null,
            Q = "Does the quiz creation part of the site work?",
            A = new()
            {
                new() { AString = "Yes!" },
                new() { AString = "No." },
                new() { AString = "Oops, I didn’t mean to make this answer." },
                new() { AString = "Wait, how do I delete it?" },
                new() { AString = "Wait, there’s no delete button?" },
                new() { AString = "Maybe I’ll just edit the quiz later." },
                new() { AString = "I don’t see a button for that either!" },
                new() { AString = "Maybe it’s under my account." },
                new() { AString = "Let me just go to where it says Login..." },
                new() { AString = "Wait, that’s not even a button! You can’t even click on it, its just text!" },
                new() { AString = "He really thought we wouldn’t notice..." },
                new() { AString = "I can’t get rid of any of these, help!" },
                new() { AString = "HELP ME" },
                new() { AString = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" },
                new() { AString = "​" },
                new() { AString = "​" },
                new() { AString = "​" },
                new() { AString = "​" },
                new() { AString = "​" }
            },
            AKey = new()
            {
                new() { AKeyBool = true },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = true },
                new() { AKeyBool = false },
                new() { AKeyBool = true },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = false }
            }
        },
        new Question()
        {
            Q = "Was Thomas a good boy?",
            A = new()
            {
                new() { AString = "Yes!" },
                new() { AString = "No." },
                new() { AString = "Wait, Thomas is a boy?" },
                new() { AString = "Aww, who’s a good boy? Does he want a treat? Here boy, come get it!" }
            },
            AKey = new()
            {
                new() { AKeyBool = true },
                new() { AKeyBool = false },
                new() { AKeyBool = false },
                new() { AKeyBool = true }
            }
        },
        new Question()
        {
            Q = "Is this quiz functioning?",
            A = new()
            {
                new() { AString = "Yes!" },
                new() { AString = "No." },
                new() { AString = "What quiz?" }
            },
            AKey = new()
            {
                new() { AKeyBool = true },
                new() { AKeyBool = false },
                new() { AKeyBool = false }
            }
        }
    }
                };

                context.Quizzes.Add(quiz1);  // queues up a quiz to be added to the DB
                context.Quizzes.Add(quiz2);
                context.Quizzes.Add(bestquiz);
                context.Quizzes.Add(quiz4);
                context.Quizzes.Add(quiz5);
                context.Quizzes.Add(quiz6);
                context.SaveChanges(); // stores all the quizzes in the DB
            }
        }
    }
}
