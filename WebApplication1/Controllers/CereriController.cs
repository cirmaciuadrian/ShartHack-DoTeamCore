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
    public class CereriController : Controller
    {
        private readonly GhiseuDigitalContext _context;

        public CereriController(GhiseuDigitalContext context)
        {
            _context = context;
        }

        // GET: Cereri
        public async Task<IActionResult> Index()
        {
            var ghiseuDigitalContext = _context.Cereri.Include(c => c.Institutie).Include(c => c.User);
            return View(await ghiseuDigitalContext.ToListAsync());
        }

        // GET: Cereri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cereri = await _context.Cereri
                .Include(c => c.Institutie)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cereri == null)
            {
                return NotFound();
            }

            return View(cereri);
        }

        // GET: Cereri/Create
        public IActionResult Create()
        {
            ViewData["InstitutieId"] = new SelectList(_context.Institutii, "Id", "NumeInstitutie");
            ViewData["UserId"] = new SelectList(_context.Persoane, "Cnp", "Cnp");
            return View();
        }

        // POST: Cereri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TipCerere,InstitutieId,Status,Data")] Cereri cereri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cereri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstitutieId"] = new SelectList(_context.Institutii, "Id", "NumeInstitutie", cereri.InstitutieId);
            ViewData["UserId"] = new SelectList(_context.Persoane, "Cnp", "Cnp", cereri.UserId);
            return View(cereri);
        }

        // GET: Cereri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cereri = await _context.Cereri.FindAsync(id);
            if (cereri == null)
            {
                return NotFound();
            }
            ViewData["InstitutieId"] = new SelectList(_context.Institutii, "Id", "NumeInstitutie", cereri.InstitutieId);
            ViewData["UserId"] = new SelectList(_context.Persoane, "Cnp", "Cnp", cereri.UserId);
            return View(cereri);
        }

        // POST: Cereri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TipCerere,InstitutieId,Status,Data")] Cereri cereri)
        {
            if (id != cereri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cereri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CereriExists(cereri.Id))
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
            ViewData["InstitutieId"] = new SelectList(_context.Institutii, "Id", "NumeInstitutie", cereri.InstitutieId);
            ViewData["UserId"] = new SelectList(_context.Persoane, "Cnp", "Cnp", cereri.UserId);
            return View(cereri);
        }

        // GET: Cereri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cereri = await _context.Cereri
                .Include(c => c.Institutie)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cereri == null)
            {
                return NotFound();
            }

            return View(cereri);
        }

        // POST: Cereri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cereri = await _context.Cereri.FindAsync(id);
            _context.Cereri.Remove(cereri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CereriExists(int id)
        {
            return _context.Cereri.Any(e => e.Id == id);
        }
    }
}
