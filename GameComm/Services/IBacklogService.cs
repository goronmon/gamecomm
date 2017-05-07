using GameComm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameComm.Services {
    public interface IBacklogService {
        bool CompanyExists(int id);
        Task<Company> GetCompany(int? id);
        IQueryable<Company> GetCompanies();
        Task AddCompany(Company addCompany);
        Task UpdateCompany(Company company);
        Task DeleteCompany(int id);
    }
}
