namespace SkillRecommendationAPI.Models
{
    public class Internship
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string RequiredSkills { get; set; } = string.Empty;
    }
}
