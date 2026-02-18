using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillRecommendationAPI.Data;

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

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetRecommendations(int studentId)
        {
            // Step 1: Get student's skill IDs
            var studentSkillIds = await _context.StudentSkills
                .Where(ss => ss.StudentId == studentId)
                .Select(ss => ss.SkillId)
                .ToListAsync();

            // Step 2: Get internships matching those skills
            var matchingInternships = await _context.InternshipSkills
                .Where(isx => studentSkillIds.Contains(isx.SkillId))
                .Include(isx => isx.Internship)
                .Select(isx => isx.Internship)
                .Distinct()
                .ToListAsync();

            // Step 3: Return result
            return Ok(matchingInternships);
        }
    }
}
