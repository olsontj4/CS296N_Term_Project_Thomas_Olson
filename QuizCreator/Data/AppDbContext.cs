using Microsoft.EntityFrameworkCore;
using QuizCreator.Models;

namespace QuizCreator.Data
{
    public class AppDbContext : DbContext
    {
        // constructor just calls the base class constructor
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        // one DbSet for each domain model class
        public DbSet<Quiz> Quizzes { get; set; }
        //public DbSet<Question> Questions { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}