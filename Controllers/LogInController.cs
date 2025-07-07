using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ML3.Models;

namespace ML3.Controllers
{
    public class LogInController : Controller
    {
        private readonly Milestone22Context _context;

        public LogInController(Milestone22Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogInAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsAdmin(int id, string password)
        {
            if (id <= 0 || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Please provide valid login credentials.";
                return View("LogInAdmin"); // Redirect to the login view if inputs are invalid
            }

            // Query the database for the admin with the given credentials
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.AdminId == id && a.Password == password);

            if (admin != null)
            {
                // Return the Admins/Details.cshtml view and pass the admin object
                return View("~/Views/Admins/Details.cshtml", admin);
            }

            // Show an error message if the credentials are invalid
            ViewBag.ErrorMessage = "Invalid ID or Password. Please try again.";
            return View("LogInAdmin");
        }

        public IActionResult LogInLearner()
        {
            return View();
        }
        public async Task<IActionResult> DetailsLearner(int id, string password)
        {
            if (id <= 0 || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Please provide valid login credentials.";
                return View("LogInLearner"); // Returns to the login view if inputs are invalid
            }

            // Query the database for the learner with the given credentials
            var learner = await _context.Learners
                .FirstOrDefaultAsync(l => l.LearnerId == id && l.Password == password);

            if (learner != null)
            {
                // Return the Learners/Details.cshtml view and pass the learner object
                return View("~/Views/Learners/Details.cshtml", learner);
            }

            // Show an error message if the credentials are invalid
            ViewBag.ErrorMessage = "Invalid ID or Password. Please try again.";
            return View("LogInLearner");
        }
        public IActionResult LogInInstructor()
        {
            return View();
        }
        public async Task<IActionResult> DetailsInstructor(int id, string password)
        {
            // Query the database for the admin with the given credentials
            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(a => a.InstructorId == id && a.Password == password);

            if (instructor != null)
            {
                // Redirect to the Details action if the admin is found
                return RedirectToAction("Details", "Instructors", new { id = instructor.InstructorId });
            }

            // Show an error message if the credentials are invalid
            ViewBag.ErrorMessage = "Invalid ID or Password. Please try again.";
            return View();
        }
    }
}