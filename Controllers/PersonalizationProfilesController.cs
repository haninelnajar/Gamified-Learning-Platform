using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ML3.Models;

namespace ML3.Controllers
{
    public class PersonalizationProfilesController : Controller
    {
        private readonly Milestone22Context _context;

        public PersonalizationProfilesController(Milestone22Context context)
        {
            _context = context;
        }

        // GET: PersonalizationProfiles
        public async Task<IActionResult> Index()
        {
            if (TempData["LearnerId"] == null)
            {
                return View(await _context.PersonalizationProfiles.ToListAsync()); // Redirect back if learnerId is not found
            }

            int learnerId = (int)TempData["LearnerId"];

            var personalizationProfile = await _context.PersonalizationProfiles
                                              .Where(lp => lp.LearnerId == learnerId)
                                              .ToListAsync();

            return View(personalizationProfile);
        }

        // GET: PersonalizationProfiles/Details
        public async Task<IActionResult> Details(int? learnerId, int? profileId)
        {
            if (learnerId == null || profileId == null)
            {
                return NotFound();
            }

            var personalizationProfile = await _context.PersonalizationProfiles
                .Include(p => p.Learner)
                .FirstOrDefaultAsync(m => m.LearnerId == learnerId && m.ProfileId == profileId);

            if (personalizationProfile == null)
            {
                return NotFound();
            }

            return View(personalizationProfile);
        }

        // GET: PersonalizationProfiles/Create
        public IActionResult Create()
        {
            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId");
            return View();
        }

        // POST: PersonalizationProfiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LearnerId,ProfileId,PreferredContentType,EmotionalState,PersonalityType")] PersonalizationProfile personalizationProfile)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(personalizationProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", personalizationProfile.LearnerId);
            return View(personalizationProfile);
        }

        // GET: PersonalizationProfiles/Edit
        public async Task<IActionResult> Edit(int? learnerId, int? profileId)
        {
            if (learnerId == null || profileId == null)
            {
                return NotFound();
            }

            var personalizationProfile = await _context.PersonalizationProfiles.FindAsync(learnerId, profileId);
            if (personalizationProfile == null)
            {
                return NotFound();
            }

            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", personalizationProfile.LearnerId);
            return View(personalizationProfile);
        }

        // POST: PersonalizationProfiles/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int learnerId, int profileId, [Bind("LearnerId,ProfileId,PreferredContentType,EmotionalState,PersonalityType")] PersonalizationProfile personalizationProfile)
        {
            if (learnerId != personalizationProfile.LearnerId || profileId != personalizationProfile.ProfileId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalizationProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalizationProfileExists(personalizationProfile.LearnerId, personalizationProfile.ProfileId))
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

            ViewData["LearnerId"] = new SelectList(_context.Learners, "LearnerId", "LearnerId", personalizationProfile.LearnerId);
            return View(personalizationProfile);
        }

        // GET: PersonalizationProfiles/Delete
        public async Task<IActionResult> Delete(int? learnerId, int? profileId)
        {
            if (learnerId == null || profileId == null)
            {
                return NotFound();
            }

            var personalizationProfile = await _context.PersonalizationProfiles
                .Include(p => p.Learner)
                .FirstOrDefaultAsync(m => m.LearnerId == learnerId && m.ProfileId == profileId);

            if (personalizationProfile == null)
            {
                return NotFound();
            }

            return View(personalizationProfile);
        }

        // POST: PersonalizationProfiles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int learnerId, int profileId)
        {
            var personalizationProfile = await _context.PersonalizationProfiles.FindAsync(learnerId, profileId);
            if (personalizationProfile != null)
            {
                _context.PersonalizationProfiles.Remove(personalizationProfile);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalizationProfileExists(int learnerId, int profileId)
        {
            return _context.PersonalizationProfiles.Any(e => e.LearnerId == learnerId && e.ProfileId == profileId);
        }
    }
}
