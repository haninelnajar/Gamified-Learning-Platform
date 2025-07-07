using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ML3.Models;

namespace ML3.Controllers
{
    public class SignUpController : Controller
    {
        private readonly Milestone22Context _context;

        public SignUpController(Milestone22Context context)
        {
            _context = context;
        }

        // GET: SignUp/Details
        public IActionResult Details()
        {
            return View();
        }

        // GET: SignUp/SignUpInstructor
        [HttpGet]
        public IActionResult SignUpInstructor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInstructor(
    [Bind("InstructorId,Name,LatestQualification,ExpertiseArea,Email,Password")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                // Add the new instructor to the database
                _context.Add(instructor);
                await _context.SaveChangesAsync();

                // Redirect to the Details action with the InstructorId
                return RedirectToAction("Details", "Instructors", new { id = instructor.InstructorId });
            }

            // If ModelState is invalid, return the same view
            return View(instructor);
        }

        //---------------------------------------------


        // GET: SignUp/SignUpLearner
        [HttpGet]
        public IActionResult SignUpLearner()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLearner(
            [Bind("LearnerId,FirstName,LastName,Gender,BirthDate,Country,CulturalBackground,Password")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                // Add the new learner to the database
                _context.Add(learner);
                await _context.SaveChangesAsync();

                // Redirect to the Details action in LearnersController
                return RedirectToAction("Details", "Learners", new { id = learner.LearnerId });
            }

            // If ModelState is invalid, return the same view
            return View(learner);
        }

        //---------------------------------------------------

        // GET: SignUp/SignUpAdmin
        [HttpGet]
        public IActionResult SignUpAdmin()
        {
            return View();
        }

        // POST: SignUp/SignUpAdmin

        public async Task<IActionResult> CreateAdmin(
   [Bind("AdminId,FirstName,LastName,Gender,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                // Add the new instructor to the database
                _context.Add(admin);
                await _context.SaveChangesAsync();

                // Redirect to the Details action with the InstructorId
                return RedirectToAction("Details", "Admins", new { id = admin.AdminId });
            }

            // If ModelState is invalid, return the same view
            return View(admin);
        }


        // GET: SignUp/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
