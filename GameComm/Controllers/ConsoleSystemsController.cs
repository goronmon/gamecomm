using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameComm.Data;
using GameComm.Models;

namespace GameComm.Controllers
{
    public class ConsoleSystemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsoleSystemsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ConsoleSystems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConsoleSystems.Include(c => c.Company);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConsoleSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleSystem = await _context.ConsoleSystems
                .Include(c => c.Company)
                .SingleOrDefaultAsync(m => m.ConsoleSystemId == id);
            if (consoleSystem == null)
            {
                return NotFound();
            }

            return View(consoleSystem);
        }

        // GET: ConsoleSystems/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId");
            return View();
        }

        // POST: ConsoleSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsoleSystemId,CompanyId,Title,CreateDate,LastModified,IsActive,IsDeleted")] ConsoleSystem consoleSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consoleSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", consoleSystem.CompanyId);
            return View(consoleSystem);
        }

        // GET: ConsoleSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleSystem = await _context.ConsoleSystems.SingleOrDefaultAsync(m => m.ConsoleSystemId == id);
            if (consoleSystem == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", consoleSystem.CompanyId);
            return View(consoleSystem);
        }

        // POST: ConsoleSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsoleSystemId,CompanyId,Title,CreateDate,LastModified,IsActive,IsDeleted")] ConsoleSystem consoleSystem)
        {
            if (id != consoleSystem.ConsoleSystemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consoleSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsoleSystemExists(consoleSystem.ConsoleSystemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", consoleSystem.CompanyId);
            return View(consoleSystem);
        }

        // GET: ConsoleSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleSystem = await _context.ConsoleSystems
                .Include(c => c.Company)
                .SingleOrDefaultAsync(m => m.ConsoleSystemId == id);
            if (consoleSystem == null)
            {
                return NotFound();
            }

            return View(consoleSystem);
        }

        // POST: ConsoleSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consoleSystem = await _context.ConsoleSystems.SingleOrDefaultAsync(m => m.ConsoleSystemId == id);
            _context.ConsoleSystems.Remove(consoleSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ConsoleSystemExists(int id)
        {
            return _context.ConsoleSystems.Any(e => e.ConsoleSystemId == id);
        }
    }
}
