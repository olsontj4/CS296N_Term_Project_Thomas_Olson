using System.ComponentModel.DataAnnotations;

namespace QuizCreator.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
    }
}