using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class InstitutiiController : Controller
    {
        private readonly GhiseuDigitalContext _context;

        public InstitutiiController(GhiseuDigitalContext context)
        {
            _context = context;
        }

        // GET: Institutiis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Institutii.ToListAsync());
        }

        // GET: Institutiis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutii = await _context.Institutii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institutii == null)
            {
                return NotFound();
            }

            return View(institutii);
        }

        // GET: Institutiis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institutiis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeInstitutie")] Institutii institutii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutii);
        }

        // GET: Institutiis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutii = await _context.Institutii.FindAsync(id);
            if (institutii == null)
            {
                return NotFound();
            }
            return View(institutii);
        }

        // POST: Institutiis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeInstitutie")] Institutii institutii)
        {
            if (id != institutii.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutiiExists(institutii.Id))
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
            return View(institutii);
        }

        // GET: Institutiis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutii = await _context.Institutii
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institutii == null)
            {
                return NotFound();
            }

            return View(institutii);
        }

        // POST: Institutiis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institutii = await _context.Institutii.FindAsync(id);
            _context.Institutii.Remove(institutii);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutiiExists(int id)
        {
            return _context.Institutii.Any(e => e.Id == id);
        }
    }
}
