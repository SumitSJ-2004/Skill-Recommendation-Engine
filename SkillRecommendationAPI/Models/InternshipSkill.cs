using System.Text.Json.Serialization;

namespace SkillRecommendationAPI.Models
{
    public class InternshipSkill
    {
        public int InternshipId { get; set; }

        [JsonIgnore]
        public Internship? Internship { get; set; }

        public int SkillId { get; set; }

        [JsonIgnore]
        public Skill? Skill { get; set; }
    }
}
