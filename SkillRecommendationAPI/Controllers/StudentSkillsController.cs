using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> AddSkillToStudent(StudentSkill dto)
        {
            _context.StudentSkills.Add(dto);
            await _context.SaveChangesAsync();
            return Ok(dto);
        }
    }
}
