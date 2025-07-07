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
    public class InstructorDiscussionsController : Controller
    {
        private readonly Milestone22Context _context;

        public InstructorDiscussionsController(Milestone22Context context)
        {
            _context = context;
        }

        // GET: InstructorDiscussions
        public async Task<IActionResult> Index()
        {
            var milestone22Context = _context.InstructorDiscussions.Include(i => i.Forum).Include(i => i.Instructor);
            return View(await milestone22Context.ToListAsync());
        }

        // GET: InstructorDiscussions/Details/5
        public async Task<IActionResult> Details(int? forumId, int? instructorId)
        {
            if (forumId == null || instructorId == null)
            {
                return NotFound();
            }

            var instructorDiscussion = await _context.InstructorDiscussions
                .Include(i => i.Forum)
                .Include(i => i.Instructor)
                .FirstOrDefaultAsync(m => m.ForumId == forumId && m.InstructorId == instructorId);

            if (instructorDiscussion == null)
            {
                return NotFound();
            }

            return View(instructorDiscussion);
        }

        // GET: InstructorDiscussions/Create
        public IActionResult Create()
        {
            ViewData["ForumId"] = new SelectList(_context.DiscussionForums, "ForumId", "ForumId");
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "InstructorId");
            return View();
        }


        // POST: InstructorDiscussions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("ForumId,InstructorId,Post,Time")] InstructorDiscussion instructorDiscussion)
        {
            instructorDiscussion.Time = DateTime.Now;
            if (_context.InstructorDiscussions.Any(d => d.ForumId == instructorDiscussion.ForumId
                                                     && d.InstructorId == instructorDiscussion.InstructorId))
            {
                ModelState.AddModelError(string.Empty, "This discussion entry already exists.");
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Add(instructorDiscussion);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            // Re-populate dropdown lists if the model state is invalid
            ViewData["ForumId"] = new SelectList(_context.DiscussionForums, "ForumId", "ForumId", instructorDiscussion.ForumId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "InstructorId", instructorDiscussion.InstructorId);

            return View(instructorDiscussion);
        }

        // GET: InstructorDiscussions/Edit/5
        public async Task<IActionResult> Edit(int? forumId, int? instructorId)
        {
            if (forumId == null || instructorId == null)
            {
                return NotFound();
            }

            var instructorDiscussion = await _context.InstructorDiscussions
                .FirstOrDefaultAsync(m => m.ForumId == forumId && m.InstructorId == instructorId);

            if (instructorDiscussion == null)
            {
                return NotFound();
            }

            ViewData["ForumId"] = new SelectList(_context.DiscussionForums, "ForumId", "ForumId", instructorDiscussion.ForumId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "InstructorId", instructorDiscussion.InstructorId);

            return View(instructorDiscussion);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int forumId, int instructorId, [Bind("ForumId,InstructorId,Post")] InstructorDiscussion instructorDiscussion)
        {
            if (forumId != instructorDiscussion.ForumId || instructorId != instructorDiscussion.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingDiscussion = await _context.InstructorDiscussions
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ForumId == forumId && m.InstructorId == instructorId);

                    if (existingDiscussion == null)
                    {
                        return NotFound();
                    }


                    instructorDiscussion.Time = existingDiscussion.Time;

                    _context.Update(instructorDiscussion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = _context.InstructorDiscussions.Any(e => e.ForumId == forumId && e.InstructorId == instructorId);
                    if (!exists)
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

            ViewData["ForumId"] = new SelectList(_context.DiscussionForums, "ForumId", "ForumId", instructorDiscussion.ForumId);
            ViewData["InstructorId"] = new SelectList(_context.Instructors, "InstructorId", "InstructorId", instructorDiscussion.InstructorId);

            return View(instructorDiscussion);
        }



        // GET: InstructorDiscussions/Delete/5
        public async Task<IActionResult> Delete(int? forumId, int? instructorId)
        {
            if (forumId == null || instructorId == null)
            {
                return NotFound();
            }

            var instructorDiscussion = await _context.InstructorDiscussions
                .Include(i => i.Forum)
                .Include(i => i.Instructor)
                .FirstOrDefaultAsync(m => m.ForumId == forumId && m.InstructorId == instructorId);

            if (instructorDiscussion == null)
            {
                return NotFound();
            }

            return View(instructorDiscussion);
        }

        // POST: InstructorDiscussions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int forumId, int instructorId)
        {
            var instructorDiscussion = await _context.InstructorDiscussions
                .FirstOrDefaultAsync(m => m.ForumId == forumId && m.InstructorId == instructorId);

            if (instructorDiscussion != null)
            {
                _context.InstructorDiscussions.Remove(instructorDiscussion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool InstructorDiscussionExists(int id)
        {
            return _context.InstructorDiscussions.Any(e => e.ForumId == id);
        }
    }
}