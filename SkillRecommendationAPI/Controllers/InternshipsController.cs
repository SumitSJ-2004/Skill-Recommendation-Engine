using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillRecommendationAPI.Data;
using SkillRecommendationAPI.Models;

namespace SkillRecommendationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InternshipsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InternshipsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Internship>>> GetInternships()
        {
            return await _context.Internships.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Internship>> CreateInternship(Internship internship)
        {
            _context.Internships.Add(internship);
            await _context.SaveChangesAsync();

            return Ok(internship);
        }
    }
}