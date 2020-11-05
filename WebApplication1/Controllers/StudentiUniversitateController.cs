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
    public class StudentiUniversitateController : Controller
    {
        private readonly GhiseuDigitalContext _context;

        public StudentiUniversitateController(GhiseuDigitalContext context)
        {
            _context = context;
        }

        // GET: StudentiUniversitate
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentiUniversitate.ToListAsync());
        }

        // GET: StudentiUniversitate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentiUniversitate = await _context.StudentiUniversitate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentiUniversitate == null)
            {
                return NotFound();
            }

            return View(studentiUniversitate);
        }

        // GET: StudentiUniversitate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentiUniversitate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Cnp,Facultate,Specializare,Stadiu,An")] StudentiUniversitate studentiUniversitate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentiUniversitate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentiUniversitate);
        }

        // GET: StudentiUniversitate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentiUniversitate = await _context.StudentiUniversitate.FindAsync(id);
            if (studentiUniversitate == null)
            {
                return NotFound();
            }
            return View(studentiUniversitate);
        }

        // POST: StudentiUniversitate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,Cnp,Facultate,Specializare,Stadiu,An")] StudentiUniversitate studentiUniversitate)
        {
            if (id != studentiUniversitate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentiUniversitate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentiUniversitateExists(studentiUniversitate.Id))
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
            return View(studentiUniversitate);
        }

        // GET: StudentiUniversitate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentiUniversitate = await _context.StudentiUniversitate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentiUniversitate == null)
            {
                return NotFound();
            }

            return View(studentiUniversitate);
        }

        // POST: StudentiUniversitate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentiUniversitate = await _context.StudentiUniversitate.FindAsync(id);
            _context.StudentiUniversitate.Remove(studentiUniversitate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentiUniversitateExists(int id)
        {
            return _context.StudentiUniversitate.Any(e => e.Id == id);
        }
    }
}
