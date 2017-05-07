using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameComm.Data;
using GameComm.Models;
using GameComm.Services;
using GameComm.Models.BacklogViewModels;

namespace GameComm.Controllers
{
    public class CompaniesController : Controller
    {
        private IBacklogService _backlogService;
        public CompaniesController(IBacklogService backlogService)
        {
            _backlogService = backlogService;    
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _backlogService.GetCompanies().ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _backlogService.GetCompanies()
                .SingleOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,Title,IsActive,IsDeleted")] Company company)
        {
            if (ModelState.IsValid)
            {
                await _backlogService.AddCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _backlogService.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,Title,LastModified,CreateDate,IsActive,IsDeleted")] CompanyViewModel companyVM)
        {
            if (id != companyVM.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    await _backlogService.UpdateCompany(company);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
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
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _backlogService.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _backlogService.DeleteCompany(id);
            return RedirectToAction("Index");
        }

        private bool CompanyExists(int id)
        {
            return _backlogService.CompanyExists(id);
        }
    }
}
