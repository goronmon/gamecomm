using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameComm.Models.BacklogViewModels {
    public class CompanyViewModel {
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
