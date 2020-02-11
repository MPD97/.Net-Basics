using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOfficeRepository.Data.Entities
{
    class Office
    {
        public int OfficeId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public ICollection<Person> Employees { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
