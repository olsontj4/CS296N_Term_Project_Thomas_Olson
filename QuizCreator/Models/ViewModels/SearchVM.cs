namespace QuizCreator.Models.ViewModels
{
    public class SearchVM
    {
        public List<Quiz>? Quizzes { get; set; } 
        public string? Search { get; set; }
        public int ResultsPerPage { get; set; }
        public int Page { get; set; }
        public string? SortBy { get; set; }
        public DateTime? Date { get; set; }
    }
}
