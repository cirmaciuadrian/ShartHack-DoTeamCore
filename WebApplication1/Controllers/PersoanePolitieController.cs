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
    public class PersoanePolitieController : Controller
    {
        private readonly GhiseuDigitalContext _context;

        public PersoanePolitieController(GhiseuDigitalContext context)
        {
            _context = context;
        }

        // GET: PersoanePolitie
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersoanePolitie.ToListAsync());
        }

        // GET: PersoanePolitie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoanePolitie = await _context.PersoanePolitie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persoanePolitie == null)
            {
                return NotFound();
            }

            return View(persoanePolitie);
        }

        // GET: PersoanePolitie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersoanePolitie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Cnp,Permis,Cazier")] PersoanePolitie persoanePolitie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persoanePolitie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persoanePolitie);
        }

        // GET: PersoanePolitie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoanePolitie = await _context.PersoanePolitie.FindAsync(id);
            if (persoanePolitie == null)
            {
                return NotFound();
            }
            return View(persoanePolitie);
        }

        // POST: PersoanePolitie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,Cnp,Permis,Cazier")] PersoanePolitie persoanePolitie)
        {
            if (id != persoanePolitie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persoanePolitie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersoanePolitieExists(persoanePolitie.Id))
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
            return View(persoanePolitie);
        }

        // GET: PersoanePolitie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoanePolitie = await _context.PersoanePolitie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persoanePolitie == null)
            {
                return NotFound();
            }

            return View(persoanePolitie);
        }

        // POST: PersoanePolitie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persoanePolitie = await _context.PersoanePolitie.FindAsync(id);
            _context.PersoanePolitie.Remove(persoanePolitie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersoanePolitieExists(int id)
        {
            return _context.PersoanePolitie.Any(e => e.Id == id);
        }
    }
}
