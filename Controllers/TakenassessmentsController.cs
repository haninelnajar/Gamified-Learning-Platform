using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ML3.Models;

namespace ML3.Controllers
{
    public class TakenassessmentsController : Controller
    {
        private readonly Milestone22Context _context;

        public TakenassessmentsController(Milestone22Context context)
        {
            _context = context;
        }

        // GET: Takenassessments
        public async Task<IActionResult> Index(int learnerId)
        {
            // Filter Takenassessments by LearnerID
            var milestone22Context = _context.Takenassessments
                                             .Include(t => t.IdNavigation)  // Include the related Assessment entity (IdNavigation)
                                             .Include(t => t.Learner)       // Include the related Learner entity
                                             .Where(t => t.LearnerId == learnerId);  // Filter by LearnerID

            // Execute the query asynchronously and pass the results to the view
            return View(await milestone22Context.ToListAsync());
        }
    
        // GET: Takenassessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takenassessment = await _context.Takenassessments
                .Include(t => t.IdNavigation)
                .Include(t => t.Learner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (takenassessment == null)
            {
                return NotFound();
            }

            return View(takenassessment);
        }

        // GET: Takenassessments/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Assessments, "Id", "Id");
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId");
            return View();
        }

        // POST: Takenassessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LearnerId,ScoredPoint")] Takenassessment takenassessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(takenassessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Assessments, "Id", "Id", takenassessment.Id);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", takenassessment.LearnerId);
            return View(takenassessment);
        }

        // GET: Takenassessments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takenassessment = await _context.Takenassessments.FindAsync(id);
            if (takenassessment == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Assessments, "Id", "Id", takenassessment.Id);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", takenassessment.LearnerId);
            return View(takenassessment);
        }

        // POST: Takenassessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LearnerId,ScoredPoint")] Takenassessment takenassessment)
        {
            if (id != takenassessment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(takenassessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TakenassessmentExists(takenassessment.Id))
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
            ViewData["Id"] = new SelectList(_context.Assessments, "Id", "Id", takenassessment.Id);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", takenassessment.LearnerId);
            return View(takenassessment);
        }

        // GET: Takenassessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takenassessment = await _context.Takenassessments
                .Include(t => t.IdNavigation)
                .Include(t => t.Learner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (takenassessment == null)
            {
                return NotFound();
            }

            return View(takenassessment);
        }

        // POST: Takenassessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var takenassessment = await _context.Takenassessments.FindAsync(id);
            if (takenassessment != null)
            {
                _context.Takenassessments.Remove(takenassessment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TakenassessmentExists(int id)
        {
            return _context.Takenassessments.Any(e => e.Id == id);
        }
    }
}
