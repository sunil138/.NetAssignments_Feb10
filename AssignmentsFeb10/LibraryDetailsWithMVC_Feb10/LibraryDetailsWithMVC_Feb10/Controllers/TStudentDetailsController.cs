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
    public class TStudentDetailsController : Controller
    {
        private readonly LibraryContext _context;

        public TStudentDetailsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TStudentDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.TStudentDetails.ToListAsync());
        }

        // GET: TStudentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TStudentDetails == null)
            {
                return NotFound();
            }

            var tStudentDetail = await _context.TStudentDetails
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (tStudentDetail == null)
            {
                return NotFound();
            }

            return View(tStudentDetail);
        }

        // GET: TStudentDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TStudentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,Surname,Gender,Age,Address")] TStudentDetail tStudentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tStudentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tStudentDetail);
        }

        // GET: TStudentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TStudentDetails == null)
            {
                return NotFound();
            }

            var tStudentDetail = await _context.TStudentDetails.FindAsync(id);
            if (tStudentDetail == null)
            {
                return NotFound();
            }
            return View(tStudentDetail);
        }

        // POST: TStudentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Surname,Gender,Age,Address")] TStudentDetail tStudentDetail)
        {
            if (id != tStudentDetail.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tStudentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TStudentDetailExists(tStudentDetail.StudentId))
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
            return View(tStudentDetail);
        }

        // GET: TStudentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TStudentDetails == null)
            {
                return NotFound();
            }

            var tStudentDetail = await _context.TStudentDetails
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (tStudentDetail == null)
            {
                return NotFound();
            }

            return View(tStudentDetail);
        }

        // POST: TStudentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TStudentDetails == null)
            {
                return Problem("Entity set 'LibraryContext.TStudentDetails'  is null.");
            }
            var tStudentDetail = await _context.TStudentDetails.FindAsync(id);
            if (tStudentDetail != null)
            {
                _context.TStudentDetails.Remove(tStudentDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TStudentDetailExists(int id)
        {
          return _context.TStudentDetails.Any(e => e.StudentId == id);
        }
    }
}
