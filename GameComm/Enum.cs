using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameComm
{
    public class Enum
    {
        public enum UserGameStatus {
            Unplayed,
            Unbeaten,
            Beaten,
            Complete
        }

        public enum OwnershipStatus {
            Owned,
            Rented,
            Borrowed,
            Lent,
            Service,
            PreviouslyOwned,
            Lost
        }
    }
}
