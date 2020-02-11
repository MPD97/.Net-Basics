using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOfficeRepository.Data.Entities
{
    class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfWindows { get; set; }
        public ICollection<Desk> Desks { get; set; }
    }
}
