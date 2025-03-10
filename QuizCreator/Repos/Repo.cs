using Microsoft.EntityFrameworkCore;
using QuizCreator.Data;
using QuizCreator.Models;
using QuizCreator.Models.ViewModels;

namespace QuizCreator.Repos
{
    public class Repo : IRepo
    {
        private readonly AppDbContext context;
        public Repo(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            return await context.Quizzes
                .Where(q => q.IsComplete == true)
                .Include(q => q.Questions)
                .ThenInclude(q => q.A)
                .Include(q => q.Questions)
                .ThenInclude(q => q.AKey)
                .Include(q => q.EndResult)
                .ThenInclude(q => q.EndTitles)
                .Include(q => q.EndResult)
                .ThenInclude(q => q.EndMessages)
                .Include(q => q.AppUser)
                .ToListAsync();
        }

        public async Task<List<Quiz>> FilterAllQuizzesAsync(string search)
        {
            return await context.Quizzes
                .Where(q => q.IsComplete == true)
                .Where(q => q.Title.Contains(search) || q.Description.Contains(search) || q.AppUser.UserName.Contains(search))
                .Include(q => q.Questions)
                .ThenInclude(q => q.A)
                .Include(q => q.Questions)
                .ThenInclude(q => q.AKey)
                .Include(q => q.EndResult)
                .ThenInclude(q => q.EndTitles)
                .Include(q => q.EndResult)
                .ThenInclude(q => q.EndMessages)
                .Include(q => q.AppUser)
                .ToListAsync();
        }
        public async Task<Quiz> GetQuizByIdAsync(int id)
        {
            return await context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.A)
                .Include(q => q.Questions)
                .ThenInclude(q => q.AKey)
                .Include(q => q.EndResult)
                .ThenInclude(q => q.EndTitles)
                .Include(q => q.EndResult)
                .ThenInclude(q => q.EndMessages)
                .Include(q => q.AppUser)
                .Where(q => q.Id == id)
                .SingleOrDefaultAsync();
        }
        public async Task<int> StoreQuizAsync(Quiz model)
        {
            model.Date = DateTime.Now;
            context.Quizzes.Add(model);
            return await context.SaveChangesAsync();
            // returns a positive value if succussful
        }
    }
}
