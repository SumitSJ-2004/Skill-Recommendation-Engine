namespace SkillRecommendationAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public double Marks { get; set; }

        public string InterestDomain { get; set; } = string.Empty;
    }
}
