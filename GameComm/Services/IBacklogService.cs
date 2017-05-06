using GameComm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameComm.Services {
    public interface IBacklogService {
        IQueryable<Company> GetCompanies();
    }
}
