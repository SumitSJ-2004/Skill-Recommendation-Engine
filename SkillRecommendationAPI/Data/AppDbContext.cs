using Microsoft.EntityFrameworkCore;
using SkillRecommendationAPI.Models;

namespace SkillRecommendationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Internship> Internships { get; set; }
    }
}
