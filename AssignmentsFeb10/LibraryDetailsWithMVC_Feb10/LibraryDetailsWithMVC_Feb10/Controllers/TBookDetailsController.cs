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
    public class TBookDetailsController : Controller
    {
        private readonly LibraryContext _context;

        public TBookDetailsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TBookDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.TBookDetails.ToListAsync());
        }

        // GET: TBookDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TBookDetails == null)
            {
                return NotFound();
            }

            var tBookDetail = await _context.TBookDetails
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tBookDetail == null)
            {
                return NotFound();
            }

            return View(tBookDetail);
        }

        // GET: TBookDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBookDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookName,BookPageCount,AuthorId")] TBookDetail tBookDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBookDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBookDetail);
        }

        // GET: TBookDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TBookDetails == null)
            {
                return NotFound();
            }

            var tBookDetail = await _context.TBookDetails.FindAsync(id);
            if (tBookDetail == null)
            {
                return NotFound();
            }
            return View(tBookDetail);
        }

        // POST: TBookDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,BookPageCount,AuthorId")] TBookDetail tBookDetail)
        {
            if (id != tBookDetail.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBookDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBookDetailExists(tBookDetail.BookId))
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
            return View(tBookDetail);
        }

        // GET: TBookDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TBookDetails == null)
            {
                return NotFound();
            }

            var tBookDetail = await _context.TBookDetails
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tBookDetail == null)
            {
                return NotFound();
            }

            return View(tBookDetail);
        }

        // POST: TBookDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TBookDetails == null)
            {
                return Problem("Entity set 'LibraryContext.TBookDetails'  is null.");
            }
            var tBookDetail = await _context.TBookDetails.FindAsync(id);
            if (tBookDetail != null)
            {
                _context.TBookDetails.Remove(tBookDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBookDetailExists(int id)
        {
          return _context.TBookDetails.Any(e => e.BookId == id);
        }
    }
}
