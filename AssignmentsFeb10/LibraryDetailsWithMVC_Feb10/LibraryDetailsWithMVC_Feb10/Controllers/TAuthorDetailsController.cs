using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryDetailsWithMVC_Feb10.Models;

namespace LibraryDetailsWithMVC_Feb10.Controllers
{
    public class TAuthorDetailsController : Controller
    {
        private readonly LibraryContext _context;

        public TAuthorDetailsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TAuthorDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.TAuthorDetails.ToListAsync());
        }

        // GET: TAuthorDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TAuthorDetails == null)
            {
                return NotFound();
            }

            var tAuthorDetail = await _context.TAuthorDetails
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (tAuthorDetail == null)
            {
                return NotFound();
            }

            return View(tAuthorDetail);
        }

        // GET: TAuthorDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TAuthorDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorName,Surname")] TAuthorDetail tAuthorDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tAuthorDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tAuthorDetail);
        }

        // GET: TAuthorDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TAuthorDetails == null)
            {
                return NotFound();
            }

            var tAuthorDetail = await _context.TAuthorDetails.FindAsync(id);
            if (tAuthorDetail == null)
            {
                return NotFound();
            }
            return View(tAuthorDetail);
        }

        // POST: TAuthorDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName,Surname")] TAuthorDetail tAuthorDetail)
        {
            if (id != tAuthorDetail.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tAuthorDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TAuthorDetailExists(tAuthorDetail.AuthorId))
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
            return View(tAuthorDetail);
        }

        // GET: TAuthorDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TAuthorDetails == null)
            {
                return NotFound();
            }

            var tAuthorDetail = await _context.TAuthorDetails
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (tAuthorDetail == null)
            {
                return NotFound();
            }

            return View(tAuthorDetail);
        }

        // POST: TAuthorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TAuthorDetails == null)
            {
                return Problem("Entity set 'LibraryContext.TAuthorDetails'  is null.");
            }
            var tAuthorDetail = await _context.TAuthorDetails.FindAsync(id);
            if (tAuthorDetail != null)
            {
                _context.TAuthorDetails.Remove(tAuthorDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TAuthorDetailExists(int id)
        {
          return _context.TAuthorDetails.Any(e => e.AuthorId == id);
        }
    }
}
