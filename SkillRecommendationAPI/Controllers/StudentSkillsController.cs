using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillRecommendationAPI.Data;
using SkillRecommendationAPI.Models;

namespace SkillRecommendationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentSkillsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentSkillsController(AppDbContext context)
        {
            _context = context;
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> AddStudentSkill(StudentSkill dto)
        {
            _context.StudentSkills.Add(dto);
            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        // GET ← ADD THIS
        [HttpGet]
        public async Task<IActionResult> GetStudentSkills()
        {
            var data = await _context.StudentSkills
                .Include(ss => ss.Student)
                .Include(ss => ss.Skill)
                .ToListAsync();

            return Ok(data);
        }
    }
}
