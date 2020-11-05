
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Adeverinte : Controller
    {
        private readonly GhiseuDigitalContext _context;

        public Adeverinte(GhiseuDigitalContext context)
        {
            _context = context;
        }

        // GET: Persoanes
        public async Task<IActionResult> Index()
        {
           

            return View();
        }



       
    }
}


