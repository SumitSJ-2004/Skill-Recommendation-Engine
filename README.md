Skill & Internship Recommendation Engine


Overview

A backend-driven recommendation system that suggests internships to students based on their skills.
The system calculates match score, identifies missing skills, and ranks internships accordingly.
This project is built using ASP.NET Core Web API, PostgreSQL, and Entity Framework Core.

Key Features
• Student profile management
• Skill management with categories
• Internship management
• Many-to-many relationships
• Recommendation engine (match score + skill gap detection)
• RESTful APIs using ASP.NET Core
• PostgreSQL database integration
• Swagger for API testing

Technology Stack
Backend:
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
Tools:
- Visual Studio 2022
- GitHub
- Swagger
- pgAdmin
Frontend:
- HTML, CSS, JavaScript (basic UI)

  
System Architecture
Frontend (Optional)
↓
ASP.NET Core Web API
↓
Entity Framework Core
↓
PostgreSQL Database


Database Schema
Tables:
Students
Skills
Internships
StudentSkills
InternshipSkills

Relationships:
Student ↔ Skills (Many-to-Many)
Internship ↔ Skills (Many-to-Many)



Setup Instructions
1. Clone repository
git clone https://github.com/YOUR_USERNAME/YOUR_REPOSITORY.git
2. Create database: SkillRecommendationDB
3. Update connection string in appsettings.json
4. Run migrations:
Update-Database
5. Run project (F5)
   
Swagger:
https://localhost:7033/swagger
API Endpoints
GET /api/Students
POST /api/Students
GET /api/Skills
POST /api/Skills
GET /api/Internships
POST /api/Internships
GET /api/StudentSkills
POST /api/StudentSkills
GET /api/InternshipSkills
POST /api/InternshipSkills
GET /api/Recommendations/{studentId}
GET /api/Recommendations/advanced/{studentId}


Recommendation Logic
MatchScore = (MatchedSkills / RequiredSkills) × 100
Example:
Match Score: 50%

Output :-
Missing Skills: ASP.NET


Future Enhancements
• User authentication
• Student and company accounts
• React frontend
• Cloud deployment
• Machine learning recommendations


Conclusion
This project demonstrates backend system design and recommendation engine implementation.
It can be extended into a full production-level system.
