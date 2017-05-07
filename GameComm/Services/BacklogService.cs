using GameComm.Data;
using GameComm.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameComm.Services {
    public class BacklogService : IBacklogService {

        private ApplicationDbContext _dbc;
        public BacklogService(ApplicationDbContext dbc) {
            _dbc = dbc;
        }

        public bool CompanyExists(int id) {
            return _dbc.Companies.Any(x => x.CompanyId == id);
        }
        public async Task<Company> GetCompany(int? id) {
            return await _dbc.Companies.FirstOrDefaultAsync(x => x.CompanyId == id);
        }
        public IQueryable<Company> GetCompanies() {
            return _dbc.Companies.Where(x => x.IsDeleted == false);
        }
        public async Task AddCompany(Company newCompany) {
            _dbc.Add(newCompany);
            await _dbc.SaveChangesAsync();
        }
        public async Task UpdateCompany(Company company) {
            company.LastModified = DateTime.Now;
            _dbc.Update(company);
            await _dbc.SaveChangesAsync();
        }
        public async Task DeleteCompany(int id) {
            var company = GetCompany(id);
            _dbc.Remove(company);
            await _dbc.SaveChangesAsync();
        }
    }
}
