using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameComm.Models {
    public class UserGame {
        [Key]
        public long UserGameId { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public long GameId { get; set; }
        public Game Game { get; set; }

        public int Score { get; set; }
        public Enum.UserGameStatus Status { get; set;}
        public bool IsPlaying { get; set; }
        public Enum.OwnershipStatus OwnershipStatus { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
