namespace SkillRecommendationAPI.Models
{
    public class RecommendationResult
    {
        public int InternshipId { get; set; }

        public string Title { get; set; } = "";

        public string Company { get; set; } = "";

        public int MatchScore { get; set; }

        public List<string> MissingSkills { get; set; } = new List<string>();
    }
}
