using GameComm.Data;
using GameComm.Models;
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
        public IQueryable<Company> GetCompanies() {
            return _dbc.Companies.Where(x => x.IsDeleted == false);
        }
    }
}
