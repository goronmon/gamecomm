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
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Games.Include(g => g.ConsoleSystem);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.ConsoleSystem)
                .SingleOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["ConsoleSystemId"] = new SelectList(_context.ConsoleSystems, "ConsoleSystemId", "ConsoleSystemId");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,Title,ConsoleSystemId,Approved,Deleted,Active,FlaggedForApproval,CreateDate,LastModified")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ConsoleSystemId"] = new SelectList(_context.ConsoleSystems, "ConsoleSystemId", "ConsoleSystemId", game.ConsoleSystemId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.SingleOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["ConsoleSystemId"] = new SelectList(_context.ConsoleSystems, "ConsoleSystemId", "ConsoleSystemId", game.ConsoleSystemId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("GameId,Title,ConsoleSystemId,Approved,Deleted,Active,FlaggedForApproval,CreateDate,LastModified")] Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.GameId))
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
            ViewData["ConsoleSystemId"] = new SelectList(_context.ConsoleSystems, "ConsoleSystemId", "ConsoleSystemId", game.ConsoleSystemId);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.ConsoleSystem)
                .SingleOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var game = await _context.Games.SingleOrDefaultAsync(m => m.GameId == id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GameExists(long id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
