using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashBeGone.Data;
using TrashBeGone.Models;

namespace TrashBeGone
{
    public class CompanyUsersController : Controller
    {
        private readonly TrashBeGoneContext _context;

        public CompanyUsersController(TrashBeGoneContext context)
        {
            _context = context;
        }

        // GET: CompanyUsers
        public async Task<IActionResult> Index()
        {
              return _context.CompanyUser != null ? 
                          View(await _context.CompanyUser.ToListAsync()) :
                          Problem("Entity set 'TrashBeGoneContext.CompanyUser'  is null.");
        }

        // GET: CompanyUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CompanyUser == null)
            {
                return NotFound();
            }

            var companyUser = await _context.CompanyUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyUser == null)
            {
                return NotFound();
            }

            return View(companyUser);
        }

        // GET: CompanyUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,UserId")] CompanyUser companyUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyUser);
        }

        // GET: CompanyUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CompanyUser == null)
            {
                return NotFound();
            }

            var companyUser = await _context.CompanyUser.FindAsync(id);
            if (companyUser == null)
            {
                return NotFound();
            }
            return View(companyUser);
        }

        // POST: CompanyUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,UserId")] CompanyUser companyUser)
        {
            if (id != companyUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyUserExists(companyUser.Id))
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
            return View(companyUser);
        }

        // GET: CompanyUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CompanyUser == null)
            {
                return NotFound();
            }

            var companyUser = await _context.CompanyUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyUser == null)
            {
                return NotFound();
            }

            return View(companyUser);
        }

        // POST: CompanyUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CompanyUser == null)
            {
                return Problem("Entity set 'TrashBeGoneContext.CompanyUser'  is null.");
            }
            var companyUser = await _context.CompanyUser.FindAsync(id);
            if (companyUser != null)
            {
                _context.CompanyUser.Remove(companyUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyUserExists(int id)
        {
          return (_context.CompanyUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
