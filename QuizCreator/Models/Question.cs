using System.ComponentModel.DataAnnotations;

namespace QuizCreator.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? ImageUrl { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Q {  get; set; }
        [Required]
        public List<A> A { get; set; } = new();
        [Required]
        public List<AKey>? AKey { get; set; } = new();
        public int QuizId { get; set; }
    }
    public class A
    {
        public int AId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string AString { get; set; }
        public int QuestionId { get; set; }
    }
    public class AKey
    {
        public int AKeyId { get; set; }
        [Required]
        public bool AKeyBool { get; set; } = false;
        public int QuestionId { get; set; }
    }
}