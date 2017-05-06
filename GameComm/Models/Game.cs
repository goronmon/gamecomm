using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameComm.Models {
    public class Game {
        [Key]
        public long GameId { get; set; }
        public string Title { get; set; }

        public int ConsoleSystemId { get; set; }
        public ConsoleSystem ConsoleSystem { get; set; }

        public bool Approved { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public bool FlaggedForApproval { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
