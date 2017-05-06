using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameComm.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string Title { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
