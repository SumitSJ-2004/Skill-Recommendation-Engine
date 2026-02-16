using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // POST
        [HttpPost]
        public async Task<IActionResult> AddSkillToInternship(InternshipSkill dto)
        {
            _context.InternshipSkills.Add(dto);
            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        // GET ← ADD THIS
        [HttpGet]
        public async Task<IActionResult> GetInternshipSkills()
        {
            var data = await _context.InternshipSkills
                .Include(isx => isx.Internship)
                .Include(isx => isx.Skill)
                .ToListAsync();

            return Ok(data);
        }
    }
}
