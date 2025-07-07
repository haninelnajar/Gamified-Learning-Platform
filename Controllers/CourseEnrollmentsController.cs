using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ML3.Models;

namespace Mile3.Controllers
{
    public class CourseEnrollmentsController : Controller
    {
        private readonly Milestone22Context _context;

        public CourseEnrollmentsController(Milestone22Context context)
        {
            _context = context;
        }

        // GET: CourseEnrollments
        public async Task<IActionResult> Index()
        {
            var milestone2Context = _context.CourseEnrollments.Include(c => c.Course).Include(c => c.Learner);
            return View(await milestone2Context.ToListAsync());
        }

        // GET: CourseEnrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments
                .Include(c => c.Course)
                .Include(c => c.Learner)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (courseEnrollment == null)
            {
                return NotFound();
            }

            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId");
            return View();
        }

        // POST: CourseEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,CourseId,LearnerId,CompletionDate,EnrollmentDate,Status")] CourseEnrollment courseEnrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseEnrollment.CourseId);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", courseEnrollment.LearnerId);
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments.FindAsync(id);
            if (courseEnrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseEnrollment.CourseId);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", courseEnrollment.LearnerId);
            return View(courseEnrollment);
        }
        // GET: CourseEnrollments/EnrolledCourses/5
        // GET: CourseEnrollments/EnrolledCourses/5
        public async Task<IActionResult> EnrolledCourses(int learnerId)
        {
            // Fetch all courses that the learner is enrolled in
            var enrollments = await _context.CourseEnrollments
                .Where(e => e.LearnerId == learnerId)
                .Include(e => e.Course) // Include related course details
                .ToListAsync();

            if (!enrollments.Any())
            {
                TempData["Message"] = "No enrolled courses found for this learner.";
                return RedirectToAction("Details", "Learners", new { id = learnerId });
            }

            // Pass learnerId to the view (to enable back navigation to learner details)
            ViewBag.LearnerId = learnerId;
            return View(enrollments);
        }

        // POST: CourseEnrollments/Enroll
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enroll(int learnerId, int courseId)
        {
            // Check if the learner is already enrolled in the course
            var existingEnrollment = await _context.CourseEnrollments
                .FirstOrDefaultAsync(e => e.LearnerId == learnerId && e.CourseId == courseId);

            if (existingEnrollment != null)
            {
                TempData["Message"] = "The learner is already enrolled in this course.";
                return RedirectToAction(nameof(Index));
            }

            // Create new enrollment
            var newEnrollment = new CourseEnrollment
            {
                LearnerId = learnerId,
                CourseId = courseId,
                EnrollmentDate = DateOnly.FromDateTime(DateTime.Now),
                Status = "Ongoing"
            };

            _context.CourseEnrollments.Add(newEnrollment);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Enrollment successful!";
            return RedirectToAction(nameof(Index));
        }


        // POST: CourseEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,CourseId,LearnerId,CompletionDate,EnrollmentDate,Status")] CourseEnrollment courseEnrollment)
        {
            if (id != courseEnrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseEnrollmentExists(courseEnrollment.EnrollmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseEnrollment.CourseId);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", courseEnrollment.LearnerId);
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments
                .Include(c => c.Course)
                .Include(c => c.Learner)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (courseEnrollment == null)
            {
                return NotFound();
            }

            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseEnrollment = await _context.CourseEnrollments.FindAsync(id);
            if (courseEnrollment != null)
            {
                _context.CourseEnrollments.Remove(courseEnrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseEnrollmentExists(int id)
        {
            return _context.CourseEnrollments.Any(e => e.EnrollmentId == id);
        }
    }
}
