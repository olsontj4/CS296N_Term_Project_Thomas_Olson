using QuizCreator.Models;
using QuizCreator.Models.ViewModels;

namespace QuizCreator.Repos
{
    public interface IRepo
    {
        public Task<List<Quiz>> GetAllQuizzesAsync();// Returns all Quiz objects
        public Task<List<Quiz>> FilterAllQuizzesAsync(string search);//Search for specific quizzes.
        public Task<Quiz> GetQuizByIdAsync(int id);// Returns a model object
        public Task<int> StoreQuizAsync(Quiz model);// Saves a model object to the db
    }
}