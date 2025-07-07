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
    public class LearnerDiscussionsController : Controller
    {
        private readonly Milestone22Context _context;

        public LearnerDiscussionsController(Milestone22Context context)
        {
            _context = context;
        }

        // GET: LearnerDiscussions
        public async Task<IActionResult> Index()
        {
            var milestone22Context = _context.LearnerDiscussions.Include(l => l.Forum).Include(l => l.Learner);
            return View(await milestone22Context.ToListAsync());
        }

        // GET: LearnerDiscussions/Details/5
        public async Task<IActionResult> Details(int? forumId, int? learnerId)
        {
            if (forumId == null || learnerId == null)
            {
                return NotFound();
            }

            var learnerDiscussion = await _context.LearnerDiscussions
                .Include(i => i.Forum)
                .Include(i => i.Learner)
                .FirstOrDefaultAsync(m => m.ForumId == forumId && m.LearnerId == learnerId);

            if (learnerDiscussion == null)
            {
                return NotFound();
            }

            return View(learnerDiscussion);
        }

        // GET: LearnerDiscussions/Create
        public IActionResult Create()
        {
            ViewData["ForumId"] = new SelectList(_context.DiscussionForums, "ForumId", "ForumId");
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId");
            return View();
        }

        // POST: LearnerDiscussions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForumId,LearnerId,Post,Time")] LearnerDiscussion learnerDiscussion)
        {
            learnerDiscussion.Time = DateTime.Now;
            if (!ModelState.IsValid)
            {
                _context.Add(learnerDiscussion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForumId"] = new SelectList(_context.DiscussionForums, "ForumId", "ForumId", learnerDiscussion.ForumId);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", learnerDiscussion.LearnerId);
            return View(learnerDiscussion);
        }

        // GET: LearnerDiscussions/Edit/5
        public async Task<IActionResult> Edit(int? forumId, int? learnerId)
        {
            if (forumId == null || learnerId == null)
            {
                return NotFound();
            }

            var learnerDiscussion = await _context.LearnerDiscussions
                .FirstOrDefaultAsync(m => m.ForumId == forumId && m.LearnerId == learnerId);

            if (learnerDiscussion == null)
            {
                return NotFound();
            }

            ViewData["ForumId"] = new SelectList(_context.DiscussionForums, "ForumId", "ForumId", learnerDiscussion.ForumId);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", learnerDiscussion.LearnerId);

            return View(learnerDiscussion);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int forumId, int learnerId, [Bind("ForumId,LearnerId,Post")] LearnerDiscussion learnerDiscussion)
        {
            if (forumId != learnerDiscussion.ForumId || learnerId != learnerDiscussion.LearnerId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    var existingDiscussion = await _context.LearnerDiscussions
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ForumId == forumId && m.LearnerId == learnerId);

                    if (existingDiscussion == null)
                    {
                        return NotFound();
                    }


                    learnerDiscussion.Time = existingDiscussion.Time;

                    _context.Update(learnerDiscussion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = _context.LearnerDiscussions.Any(e => e.ForumId == forumId && e.LearnerId == learnerId);
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

            ViewData["ForumId"] = new SelectList(_context.DiscussionForums, "ForumId", "ForumId", learnerDiscussion.ForumId);
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", learnerDiscussion.LearnerId);

            return View(learnerDiscussion);
        }
        // GET: LearnerDiscussions/Delete/5
        public async Task<IActionResult> Delete(int? forumId, int? learnerId)
        {
            if (forumId == null || learnerId == null)
            {
                return NotFound();
            }

            var learnerDiscussion = await _context.LearnerDiscussions
                .Include(i => i.Forum)
                .Include(i => i.Learner)
                .FirstOrDefaultAsync(m => m.ForumId == forumId && m.LearnerId == learnerId);

            if (learnerDiscussion == null)
            {
                return NotFound();
            }

            return View(learnerDiscussion);
        }

        // POST: LearnerDiscussions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int forumId, int learnerId)
        {
            var learnerDiscussion = await _context.LearnerDiscussions
                .FirstOrDefaultAsync(m => m.ForumId == forumId && m.LearnerId == learnerId);

            if (learnerDiscussion != null)
            {
                _context.LearnerDiscussions.Remove(learnerDiscussion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LearnerDiscussionExists(int id)
        {
            return _context.LearnerDiscussions.Any(e => e.ForumId == id);
        }
    }
}