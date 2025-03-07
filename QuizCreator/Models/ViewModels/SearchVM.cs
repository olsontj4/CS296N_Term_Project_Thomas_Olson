namespace QuizCreator.Models.ViewModels
{
    public class SearchVM
    {
        public List<Quiz>? Quizzes { get; set; } 
        public string? Search { get; set; }
        public string? Password { get; set; } = null;
        public bool SupressWarning { get; set; } = false;
        public bool CreateAccount { get; set;} = false;
    }
}
