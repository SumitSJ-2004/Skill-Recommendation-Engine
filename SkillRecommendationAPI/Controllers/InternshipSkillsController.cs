using Microsoft.AspNetCore.Mvc;
using SkillRecommendationAPI.Data;
using SkillRecommendationAPI.Models;

namespace SkillRecommendationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InternshipSkillsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InternshipSkillsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddSkillToInternship(InternshipSkill dto)
        {
            _context.InternshipSkills.Add(dto);
            await _context.SaveChangesAsync();
            return Ok(dto);
        }
    }
}
