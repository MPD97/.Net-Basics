using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleOfficeRepositoryCore.Data.Entities;

namespace RESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private OfficeContext _officeContext;
        private ILogger<OfficeContext> _logger;

        public OfficeController(OfficeContext context, ILogger<OfficeContext> logger)
        {
            _officeContext = context;
            _logger = logger;
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var offices = await _officeContext.Offices.ToListAsync();
                _logger.LogInformation($"Requested: [{MethodBase.GetCurrentMethod().ReflectedType.Name.Replace(">d__3","").Replace("<","")}], in: [{GetType().Name}] calass.");

                return Ok(offices);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load data from database");
            }
        }
    }
}