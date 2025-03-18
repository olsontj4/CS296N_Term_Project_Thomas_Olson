using QuizCreator.Models;
using QuizCreator.Models.ViewModels;
using System.Security.Claims;

namespace QuizCreator.Repos
{
    public interface IRepo
    {
        public Task<List<Quiz>> GetAllQuizzesAsync();// Returns all Quiz objects
        public Task<List<Quiz>> GetUserQuizzesAsync(string id, string search);
        public Task<List<Quiz>> FilterAllQuizzesAsync(SearchVM searchVM);//Search for specific quizzes.
        public Task<Quiz> GetQuizByIdAsync(int id);// Returns a model object
        public Task<int> StoreQuizAsync(Quiz model);// Saves a model object to the db
        public Task<int> UpdateQuizAsync(Quiz model);
        public Task<int> DeleteQuizAsync(int id);
    }
}