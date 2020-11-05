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
    public class PersoaneController : Controller
    {
        private readonly GhiseuDigitalContext _context;

        public PersoaneController(GhiseuDigitalContext context)
        {
            _context = context;
        }

        // GET: Persoanes
        public async Task<IActionResult> Index()
        {
            Persoane Persoana = _context.Persoane.FirstOrDefault(e => e.Cnp == "1980305134126");
            StudentiUniversitate studentiFacultate = _context.StudentiUniversitate.FirstOrDefault(e => e.Cnp == "1980305134126");
            PersoaneMedic persoaneMedic = _context.PersoaneMedic.FirstOrDefault(e => e.Cnp == "1980305134126");
            PersoanePolitie persoanePolitie = _context.PersoanePolitie.FirstOrDefault(e => e.Cnp == "1980305134126");
            if (persoanePolitie.Cazier)
            {
                Persoana.StatusPolitie = Persoana.StatusPolitie + "Are cazier, ";
            }
            else
            {
                Persoana.StatusPolitie = Persoana.StatusPolitie + "Nu are cazier, ";
            }

            if (persoanePolitie.Permis)
                Persoana.StatusPolitie = Persoana.StatusPolitie + "are permis de conducere.";
            else
                Persoana.StatusPolitie = Persoana.StatusPolitie + "nu are permis de conducere.";

            if (persoaneMedic.BoliCronice)
                Persoana.StatusMedic = "Are boli cronice";
            else
                Persoana.StatusMedic = "Nu are boli cronice";

            
            DetailsViewModel PersoanaDetalii = new DetailsViewModel();
            PersoanaDetalii.Cnp = Persoana.Cnp;
            PersoanaDetalii.Adresa = Persoana.Adresa;
            PersoanaDetalii.Cereri = Persoana.Cereri;
            PersoanaDetalii.DataNasterii = Persoana.DataNasterii.Date;          
            PersoanaDetalii.Numar = Persoana.Numar;
            PersoanaDetalii.Nume = Persoana.Nume;
            PersoanaDetalii.Oras = Persoana.Oras;
            PersoanaDetalii.Prenume = Persoana.Prenume;
            PersoanaDetalii.Serie = Persoana.Serie;          
            PersoanaDetalii.StatusMedic = Persoana.StatusMedic;
            PersoanaDetalii.StatusPolitie = Persoana.StatusPolitie;
            PersoanaDetalii.StatusUniversitate = Persoana.StatusUniversitate;
            PersoanaDetalii.An = studentiFacultate.An;
            PersoanaDetalii.Facultate = studentiFacultate.Facultate;
            PersoanaDetalii.Specializare = studentiFacultate.Specializare;
            PersoanaDetalii.Stadiu = studentiFacultate.Stadiu;



            return View(await _context.Persoane.ToListAsync());
        }

        // GET: Persoanes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoane = await _context.Persoane
                .FirstOrDefaultAsync(m => m.Cnp == id);
            if (persoane == null)
            {
                return NotFound();
            }

            Persoane Persoana = _context.Persoane.FirstOrDefault(e => e.Cnp == "1980305134126");
            StudentiUniversitate studentiFacultate = _context.StudentiUniversitate.FirstOrDefault(e => e.Cnp == "1980305134126");
            PersoaneMedic persoaneMedic = _context.PersoaneMedic.FirstOrDefault(e => e.Cnp == "1980305134126");
            PersoanePolitie persoanePolitie = _context.PersoanePolitie.FirstOrDefault(e => e.Cnp == "1980305134126");
            if (persoanePolitie.Cazier)
            {
                Persoana.StatusPolitie = "Are cazier, ";
            }
            else
            {
                Persoana.StatusPolitie =  "Nu are cazier, ";
            }

            if (persoanePolitie.Permis)
                Persoana.StatusPolitie = Persoana.StatusPolitie + "are permis de conducere.";
            else
                Persoana.StatusPolitie = Persoana.StatusPolitie + "nu are permis de conducere.";

            if (persoaneMedic.BoliCronice)
                Persoana.StatusMedic = "Are boli cronice";
            else
                Persoana.StatusMedic = "Nu are boli cronice";


            DetailsViewModel PersoanaDetalii = new DetailsViewModel();
            PersoanaDetalii.Cnp = Persoana.Cnp;
            PersoanaDetalii.Adresa = Persoana.Adresa;
            PersoanaDetalii.Cereri = Persoana.Cereri;
            PersoanaDetalii.DataNasterii = Persoana.DataNasterii;
            PersoanaDetalii.Numar = Persoana.Numar;
            PersoanaDetalii.Nume = Persoana.Nume;
            PersoanaDetalii.Oras = Persoana.Oras;
            PersoanaDetalii.Prenume = Persoana.Prenume;
            PersoanaDetalii.Serie = Persoana.Serie;
            PersoanaDetalii.StatusMedic = Persoana.StatusMedic;
            PersoanaDetalii.StatusPolitie = Persoana.StatusPolitie;
            PersoanaDetalii.StatusUniversitate = Persoana.StatusUniversitate;
            PersoanaDetalii.An = studentiFacultate.An;
            PersoanaDetalii.Facultate = studentiFacultate.Facultate;
            PersoanaDetalii.Specializare = studentiFacultate.Specializare;
            PersoanaDetalii.Stadiu = studentiFacultate.Stadiu;



            return View(PersoanaDetalii);


           
        }

        // GET: Persoanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persoanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cnp,Nume,Prenume,Serie,Numar,Adresa,Oras,DataNasterii,StatusPolitie,StatusMedic,StatusUniversitate")] Persoane persoane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persoane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persoane);
        }

        // GET: Persoanes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoane = await _context.Persoane.FindAsync(id);
            if (persoane == null)
            {
                return NotFound();
            }
            return View(persoane);
        }

        // POST: Persoanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cnp,Nume,Prenume,Serie,Numar,Adresa,Oras,DataNasterii,StatusPolitie,StatusMedic,StatusUniversitate")] Persoane persoane)
        {
            if (id != persoane.Cnp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persoane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersoaneExists(persoane.Cnp))
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
            return View(persoane);
        }

        // GET: Persoanes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persoane = await _context.Persoane
                .FirstOrDefaultAsync(m => m.Cnp == id);
            if (persoane == null)
            {
                return NotFound();
            }

            return View(persoane);
        }

        // POST: Persoanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var persoane = await _context.Persoane.FindAsync(id);
            _context.Persoane.Remove(persoane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersoaneExists(string id)
        {
            return _context.Persoane.Any(e => e.Cnp == id);
        }
    }
}
