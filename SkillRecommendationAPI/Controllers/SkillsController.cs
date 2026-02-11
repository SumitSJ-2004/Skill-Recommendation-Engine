using Microsoft.AspNetCore.Mvc;
using SkillRecommendationAPI.Data;
using SkillRecommendationAPI.Models;

namespace SkillRecommendationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SkillsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return Ok(skill);
        }

        [HttpGet]
        public IActionResult GetSkills()
        {
            return Ok(_context.Skills.ToList());
        }
    }
}
