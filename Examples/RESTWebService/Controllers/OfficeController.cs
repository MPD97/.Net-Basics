using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleOfficeRepositoryCore.Data.Entities;

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

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var offices = await _officeContext.Offices.ToListAsync();
                return Ok(offices);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load data from database");
            }
        }
    }
}