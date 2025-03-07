using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizCreator.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignUpDate { get; set; }
        [NotMapped]
        public IList<string>? RoleNames { get; set; }
    }
}