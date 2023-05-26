using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Membership.Data;
using Membership.Models;

namespace Membership.Controllers
{
    public class MemberTypesController : Controller
    {
        private readonly MembershipContext _context;

        public MemberTypesController(MembershipContext context)
        {
            _context = context;
        }

        // GET: MemberTypes
        public async Task<IActionResult> Index()
        {
              return _context.MemberType != null ? 
                          View(await _context.MemberType.ToListAsync()) :
                          Problem("Entity set 'MembershipContext.MemberType'  is null.");
        }

        // GET: MemberTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MemberType == null)
            {
                return NotFound();
            }

            var memberType = await _context.MemberType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberType == null)
            {
                return NotFound();
            }

            return View(memberType);
        }

        // GET: MemberTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemberTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName")] MemberType memberType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberType);
        }

        // GET: MemberTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MemberType == null)
            {
                return NotFound();
            }

            var memberType = await _context.MemberType.FindAsync(id);
            if (memberType == null)
            {
                return NotFound();
            }
            return View(memberType);
        }

        // POST: MemberTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName")] MemberType memberType)
        {
            if (id != memberType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberTypeExists(memberType.Id))
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
            return View(memberType);
        }

        // GET: MemberTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MemberType == null)
            {
                return NotFound();
            }

            var memberType = await _context.MemberType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberType == null)
            {
                return NotFound();
            }

            return View(memberType);
        }

        // POST: MemberTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MemberType == null)
            {
                return Problem("Entity set 'MembershipContext.MemberType'  is null.");
            }
            var memberType = await _context.MemberType.FindAsync(id);
            if (memberType != null)
            {
                _context.MemberType.Remove(memberType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberTypeExists(int id)
        {
          return (_context.MemberType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
