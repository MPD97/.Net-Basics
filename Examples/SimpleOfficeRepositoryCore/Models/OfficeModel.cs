using SimpleOfficeRepositoryCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTWebService.ViewModels
{
    public class OfficeModel
    {
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(40)]
        public string Location { get; set; }
        public ICollection<Person> Employees { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
