using QuizCreator.Models;

namespace QuizCreator.Repos
{
    public interface IRepo
    {
        public List<Quiz> GetAllQuizzes();  // Returns all Quiz objects
        public Quiz GetQuizById(int id); // Returns a model object
        public int StoreQuiz(Quiz model);  // Saves a model object to the db
    }
}