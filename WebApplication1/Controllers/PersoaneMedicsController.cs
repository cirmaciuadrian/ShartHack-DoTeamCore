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
    public class PersoaneMedicsController : Controller
    {
        private readonly GhiseuDigitalContext _context;

        public PersoaneMedicsController(GhiseuDigitalContext context)
        {
            _context = context;
        }

        // GET: PersoaneMedics
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersoaneMedic.ToListAsync());
        }

        // GET: PersoaneMedics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoaneMedic = await _context.PersoaneMedic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persoaneMedic == null)
            {
                return NotFound();
            }

            return View(persoaneMedic);
        }

        // GET: PersoaneMedics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersoaneMedics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Cnp,BoliCronice")] PersoaneMedic persoaneMedic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persoaneMedic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persoaneMedic);
        }

        // GET: PersoaneMedics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoaneMedic = await _context.PersoaneMedic.FindAsync(id);
            if (persoaneMedic == null)
            {
                return NotFound();
            }
            return View(persoaneMedic);
        }

        // POST: PersoaneMedics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,Cnp,BoliCronice")] PersoaneMedic persoaneMedic)
        {
            if (id != persoaneMedic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persoaneMedic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersoaneMedicExists(persoaneMedic.Id))
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
            return View(persoaneMedic);
        }

        // GET: PersoaneMedics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoaneMedic = await _context.PersoaneMedic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persoaneMedic == null)
            {
                return NotFound();
            }

            return View(persoaneMedic);
        }

        // POST: PersoaneMedics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persoaneMedic = await _context.PersoaneMedic.FindAsync(id);
            _context.PersoaneMedic.Remove(persoaneMedic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersoaneMedicExists(int id)
        {
            return _context.PersoaneMedic.Any(e => e.Id == id);
        }
    }
}
