using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillRecommendationAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInternshipModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiredSkills",
                table: "Internships",
                newName: "Domain");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Internships",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Internships",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Internships");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Internships");

            migrationBuilder.RenameColumn(
                name: "Domain",
                table: "Internships",
                newName: "RequiredSkills");
        }
    }
}
