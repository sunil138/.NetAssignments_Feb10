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
    public class TBorrowDetailsController : Controller
    {
        private readonly LibraryContext _context;

        public TBorrowDetailsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TBorrowDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.TBorrowDetails.ToListAsync());
        }

        // GET: TBorrowDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBorrowDetails == null)
            {
                return NotFound();
            }

            var tBorrowDetail = await _context.TBorrowDetails
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (tBorrowDetail == null)
            {
                return NotFound();
            }

            return View(tBorrowDetail);
        }

        // GET: TBorrowDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBorrowDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowId,Takendate,Broughtdate,StudentId,BookId")] TBorrowDetail tBorrowDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBorrowDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBorrowDetail);
        }

        // GET: TBorrowDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBorrowDetails == null)
            {
                return NotFound();
            }

            var tBorrowDetail = await _context.TBorrowDetails.FindAsync(id);
            if (tBorrowDetail == null)
            {
                return NotFound();
            }
            return View(tBorrowDetail);
        }

        // POST: TBorrowDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowId,Takendate,Broughtdate,StudentId,BookId")] TBorrowDetail tBorrowDetail)
        {
            if (id != tBorrowDetail.BorrowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBorrowDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBorrowDetailExists(tBorrowDetail.BorrowId))
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
            return View(tBorrowDetail);
        }

        // GET: TBorrowDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBorrowDetails == null)
            {
                return NotFound();
            }

            var tBorrowDetail = await _context.TBorrowDetails
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (tBorrowDetail == null)
            {
                return NotFound();
            }

            return View(tBorrowDetail);
        }

        // POST: TBorrowDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBorrowDetails == null)
            {
                return Problem("Entity set 'LibraryContext.TBorrowDetails'  is null.");
            }
            var tBorrowDetail = await _context.TBorrowDetails.FindAsync(id);
            if (tBorrowDetail != null)
            {
                _context.TBorrowDetails.Remove(tBorrowDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBorrowDetailExists(int id)
        {
          return _context.TBorrowDetails.Any(e => e.BorrowId == id);
        }
    }
}
