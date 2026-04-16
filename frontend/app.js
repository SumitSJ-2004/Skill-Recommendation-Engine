const API_BASE_URL = "https://localhost:7033/api";

// NAVIGATION (keep same)
function navigate(viewId) {
    document.querySelectorAll('.page-view').forEach(view => {
        view.classList.remove('active');
    });

    document.querySelectorAll('.nav-btn').forEach(btn => {
        btn.classList.remove('active');
    });

    document.getElementById(`view-${viewId}`).classList.add('active');
    document.getElementById(`nav-${viewId}`).classList.add('active');
}

// STATUS MESSAGE
function showStatus(formId, message, isError = false) {
    const msgDiv = document.querySelector(`#${formId} .status-msg`);
    msgDiv.textContent = message;
    msgDiv.style.color = isError ? "red" : "lightgreen";
}

// ----------------------
// ADD STUDENT
// ----------------------
document.getElementById('form-student').addEventListener('submit', async (e) => {
    e.preventDefault();

    const name = document.getElementById("studentName").value;
    const email = document.getElementById("studentEmail").value;

    try {
        const res = await fetch(API_BASE_URL + "/Students", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ name, email })
        });

        if (res.ok) {
            showStatus("form-student", "Student added successfully");
            e.target.reset();
        } else {
            showStatus("form-student", "Error adding student", true);
        }

    } catch {
        showStatus("form-student", "Backend not running", true);
    }
});

// ----------------------
// ADD SKILL
// ----------------------
document.getElementById('form-skill').addEventListener('submit', async (e) => {
    e.preventDefault();

    const name = document.getElementById("skillName").value;
    const category = document.getElementById("skillCategory").value;

    try {
        const res = await fetch(API_BASE_URL + "/Skills", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ name, category })
        });

        if (res.ok) {
            showStatus("form-skill", "Skill added successfully");
            e.target.reset();
        } else {
            showStatus("form-skill", "Error adding skill", true);
        }

    } catch {
        showStatus("form-skill", "Backend not running", true);
    }
});

// ----------------------
// ADD INTERNSHIP
// ----------------------
document.getElementById('form-internship').addEventListener('submit', async (e) => {
    e.preventDefault();

    const title = document.getElementById("internshipTitle").value;
    const company = document.getElementById("internshipCompany").value;
    const domain = document.getElementById("internshipDomain").value;
    const description = document.getElementById("internshipDesc").value;

    try {
        const res = await fetch(API_BASE_URL + "/Internships", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ title, company, domain, description })
        });

        if (res.ok) {
            showStatus("form-internship", "Internship added successfully");
            e.target.reset();
        } else {
            showStatus("form-internship", "Error adding internship", true);
        }

    } catch {
        showStatus("form-internship", "Backend not running", true);
    }
});

// ----------------------
// GET RECOMMENDATION
// ----------------------
document.getElementById('form-recommendation').addEventListener('submit', async (e) => {
    e.preventDefault();

    const studentId = document.getElementById("recStudentId").value;
    const resultsList = document.getElementById("results-list");
    const container = document.getElementById("recommendation-results");

    resultsList.innerHTML = "";

    try {
        const res = await fetch(API_BASE_URL + "/Recommendations/advanced/" + studentId);
        const data = await res.json();

        if (data.length === 0) {
            showStatus("form-recommendation", "No results found");
            return;
        }

        data.forEach(item => {
            const card = document.createElement("div");
            card.className = "result-card";

            card.innerHTML = `
                <div class="res-header">
                    <div>
                        <div class="res-title">${item.title}</div>
                        <div class="res-company">${item.company}</div>
                    </div>
                    <div class="res-score">${item.matchScore}%</div>
                </div>
                <div class="res-missing">
                    Missing: ${item.missingSkills.join(", ")}
                </div>
            `;

            resultsList.appendChild(card);
        });

        container.classList.remove("hidden");

    } catch {
        showStatus("form-recommendation", "Error fetching data", true);
    }
});

// INIT
document.addEventListener("DOMContentLoaded", () => {
    navigate("home");
});