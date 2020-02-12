using SimpleOfficeRepositoryCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTWebService.ViewModels
{
    public class OfficeModel
    {
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public ICollection<Person> Employees { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
