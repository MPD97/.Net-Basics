﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOfficeRepositoryCore.Data.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string Surename { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public DateTime HireDate { get; set; }
        public Office Office { get; set; }
    }
    public enum Sex
    {
        Other = 0,
        Female = 1,
        Male = 2
    }
}
