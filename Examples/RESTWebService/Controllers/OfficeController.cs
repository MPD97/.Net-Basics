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
using SimpleOfficeRepositoryCore.Data;
using SimpleOfficeRepositoryCore.Data.Entities;

namespace RESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private ISimpleOfficeRepository _repo;
        private ILogger<OfficeContext> _logger;

        public OfficeController(ISimpleOfficeRepository repository, ILogger<OfficeContext> logger)
        {
            _repo = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation($"Requested: [{MethodBase.GetCurrentMethod().ReflectedType.Name}], in: [{GetType().Name}] calass.");

                return Ok(await _repo.GetAllOfficesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load data from database");
            }
        }
        [HttpGet("{OfficeId}")]
        public async Task<IActionResult> Get(int officeId)
        {
            try
            {
                _logger.LogInformation($"Requested: [{MethodBase.GetCurrentMethod().ReflectedType.Name}], in: [{GetType().Name}] calass with.");
                
                return Ok(await _repo.GetOfficeAsync(officeId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load data from database");
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Add([FromBody]Office model)
        //{
        //    try
        //    {
        //        var addedOffice = _officeContext.Add(model).State;

        //        _logger.LogInformation($"Requested: [{MethodBase.GetCurrentMethod().ReflectedType.Name.Replace(">d__3", "").Replace("<", "")}], in: [{GetType().Name}] calass.");
        //        return CreatedAtRoute("GetById", new { id = model.OfficeId}, addedOffice);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.ToString());
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load data from database");
        //    }
        //}
    }
}