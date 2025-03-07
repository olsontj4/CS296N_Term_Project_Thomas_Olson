namespace QuizCreator.Models.ViewModels
{
    public class CreatorVM
    {
        public Quiz? Quiz { get; set; } = new();
        public int Page { get; set; }
        public bool AddAnswer { get; set; } = false;
        public bool DeleteAnswer { get; set; } = false;
    }
}
