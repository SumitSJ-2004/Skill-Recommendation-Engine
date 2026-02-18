namespace SkillRecommendationAPI.Models
{
    public class Internship
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<InternshipSkill> InternshipSkills { get; set; } = new List<InternshipSkill>();

    }
}