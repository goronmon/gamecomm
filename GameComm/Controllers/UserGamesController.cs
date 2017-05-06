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
    public class UserGamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserGamesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: UserGames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserGames.Include(u => u.Game).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserGames/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _context.UserGames
                .Include(u => u.Game)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.UserGameId == id);
            if (userGame == null)
            {
                return NotFound();
            }

            return View(userGame);
        }

        // GET: UserGames/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserGameId,UserId,GameId,Score,Status,IsPlaying,OwnershipStatus,LastModified,CreateDate,IsDeleted")] UserGame userGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userGame);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", userGame.GameId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userGame.UserId);
            return View(userGame);
        }

        // GET: UserGames/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _context.UserGames.SingleOrDefaultAsync(m => m.UserGameId == id);
            if (userGame == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", userGame.GameId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userGame.UserId);
            return View(userGame);
        }

        // POST: UserGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("UserGameId,UserId,GameId,Score,Status,IsPlaying,OwnershipStatus,LastModified,CreateDate,IsDeleted")] UserGame userGame)
        {
            if (id != userGame.UserGameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserGameExists(userGame.UserGameId))
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
            ViewData["GameId"] = new SelectList(_context.Games, "GameId", "GameId", userGame.GameId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userGame.UserId);
            return View(userGame);
        }

        // GET: UserGames/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _context.UserGames
                .Include(u => u.Game)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.UserGameId == id);
            if (userGame == null)
            {
                return NotFound();
            }

            return View(userGame);
        }

        // POST: UserGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userGame = await _context.UserGames.SingleOrDefaultAsync(m => m.UserGameId == id);
            _context.UserGames.Remove(userGame);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserGameExists(long id)
        {
            return _context.UserGames.Any(e => e.UserGameId == id);
        }
    }
}
