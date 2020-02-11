using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SimpleOfficeRepository.Data.Entities;

namespace RESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private OfficeContext _officeContext;

        public OfficeController(OfficeContext context)
        {
            _officeContext = context;
        }
        public IActionResult GetAll()
        {
            var offices = _officeContext.Offices.ToList();
           
            return new ObjectResult(offices);
        }
    }
}