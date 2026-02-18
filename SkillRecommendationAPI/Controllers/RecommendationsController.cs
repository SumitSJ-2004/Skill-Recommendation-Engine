using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillRecommendationAPI.Data;
using SkillRecommendationAPI.Models;


namespace SkillRecommendationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecommendationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("advanced/{studentId}")]
        public async Task<IActionResult> GetAdvancedRecommendations(int studentId)
        {
            // Get student's skill IDs
            var studentSkillIds = await _context.StudentSkills
                .Where(ss => ss.StudentId == studentId)
                .Select(ss => ss.SkillId)
                .ToListAsync();

            // Get all internships with their skills
            var internships = await _context.Internships
                .Include(i => i.InternshipSkills)
                .ThenInclude(isx => isx.Skill)
                .ToListAsync();

            var results = new List<RecommendationResult>();

            foreach (var internship in internships)
            {
                var requiredSkills = internship.InternshipSkills
                    .Select(isx => isx.SkillId)
                    .ToList();

                var matchedSkills = requiredSkills
                    .Where(skillId => studentSkillIds.Contains(skillId))
                    .ToList();

                var missingSkills = internship.InternshipSkills
                    .Where(isx => !studentSkillIds.Contains(isx.SkillId))
                    .Select(isx => isx.Skill.Name)
                    .ToList();

                int matchScore = requiredSkills.Count == 0
                    ? 0
                    : (matchedSkills.Count * 100) / requiredSkills.Count;

                results.Add(new RecommendationResult
                {
                    InternshipId = internship.Id,
                    Title = internship.Title,
                    Company = internship.Company,
                    MatchScore = matchScore,
                    MissingSkills = missingSkills
                });
            }

            var rankedResults = results
                .OrderByDescending(r => r.MatchScore)
                .ToList();

            return Ok(rankedResults);
        }

    }
}
