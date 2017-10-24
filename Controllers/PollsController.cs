using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lunchPollNet.Models;

namespace lunchPollNet.Controllers
{
    public class PollsController : Controller
    {
        private readonly PollContext _context;

        public PollsController(PollContext context)
        {
            _context = context;
        }

        // GET: Polls
        public async Task<IActionResult> Index(bool showPastPolls = true)
        {
            ViewData["ShowPastPolls"] = showPastPolls;

            IQueryable<Poll> polls = from s in _context.Poll
                                        select s;
            
            if(!showPastPolls)
            {
                polls = polls.Where(x => x.ClosingTime > DateTime.Now);
            }

            return View(await polls.ToListAsync());
        }
        

        // GET: Polls/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll = await _context.Poll
                .SingleOrDefaultAsync(m => m.Id == id);
            if (poll == null)
            {
                return NotFound();
            }

            return View(poll);
        }

        // GET: Polls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Polls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Created,ClosingTime")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                poll.Id = Guid.NewGuid();
                _context.Add(poll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poll);
        }

        // GET: Polls/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll = await _context.Poll.SingleOrDefaultAsync(m => m.Id == id);
            if (poll == null)
            {
                return NotFound();
            }
            return View(poll);
        }

        // POST: Polls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Created,ClosingTime")] Poll poll)
        {
            if (id != poll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PollExists(poll.Id))
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
            return View(poll);
        }

        // GET: Polls/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll = await _context.Poll
                .SingleOrDefaultAsync(m => m.Id == id);
            if (poll == null)
            {
                return NotFound();
            }

            return View(poll);
        }

        // POST: Polls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var poll = await _context.Poll.SingleOrDefaultAsync(m => m.Id == id);
            _context.Poll.Remove(poll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PollExists(Guid id)
        {
            return _context.Poll.Any(e => e.Id == id);
        }
    }
}
