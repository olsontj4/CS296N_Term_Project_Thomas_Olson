using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizCreator.Models;

namespace QuizCreator.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        // constructor just calls the base class constructor
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        // one DbSet for each domain model class
        public DbSet<Quiz> Quizzes { get; set; }
        //public DbSet<Question> Questions { get; set; }
    }
}