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
    public class PollItemsController : Controller
    {
        private readonly PollContext _context;

        public PollItemsController(PollContext context)
        {
            _context = context;
        }

        // GET: PollItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.PollItem.ToListAsync());
        }

        // GET: PollItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollItem = await _context.PollItem
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pollItem == null)
            {
                return NotFound();
            }

            return View(pollItem);
        }

        // GET: PollItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PollItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,Description,TotalVoteCount,disabled")] PollItem pollItem)
        {
            if (ModelState.IsValid)
            {
                pollItem.Id = Guid.NewGuid();
                _context.Add(pollItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pollItem);
        }

        // GET: PollItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollItem = await _context.PollItem.SingleOrDefaultAsync(m => m.Id == id);
            if (pollItem == null)
            {
                return NotFound();
            }
            return View(pollItem);
        }

        // POST: PollItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedBy,Description,TotalVoteCount,disabled")] PollItem pollItem)
        {
            if (id != pollItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pollItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PollItemExists(pollItem.Id))
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
            return View(pollItem);
        }

        // GET: PollItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollItem = await _context.PollItem
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pollItem == null)
            {
                return NotFound();
            }

            return View(pollItem);
        }

        // POST: PollItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pollItem = await _context.PollItem.SingleOrDefaultAsync(m => m.Id == id);
            _context.PollItem.Remove(pollItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PollItemExists(Guid id)
        {
            return _context.PollItem.Any(e => e.Id == id);
        }
    }
}
