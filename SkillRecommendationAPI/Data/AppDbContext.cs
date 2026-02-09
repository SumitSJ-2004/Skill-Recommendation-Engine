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
        public DbSet<Student> Students { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<StudentSkill> StudentSkills { get; set; }
        public DbSet<InternshipSkill> InternshipSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSkill>()
                .HasKey(ss => new { ss.StudentId, ss.SkillId });

            modelBuilder.Entity<InternshipSkill>()
                .HasKey(isx => new { isx.InternshipId, isx.SkillId });
        }

    }
}
