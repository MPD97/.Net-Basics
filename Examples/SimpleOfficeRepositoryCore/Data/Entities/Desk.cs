using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOfficeRepository.Data.Entities
{
    public class Desk
    {
        public int DeskId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Person Owner { get; set; }
        public Room Room { get; set; }
    }
}
