using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RESTWebService.ViewModels;
using SimpleOfficeRepositoryCore.Data;
using SimpleOfficeRepositoryCore.Data.Entities;

namespace RESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly ISimpleOfficeRepository _repo;
        private readonly ILogger<OfficeContext> _logger;
        private readonly IMapper _mapper;

        public OfficeController(ISimpleOfficeRepository repository, ILogger<OfficeContext> logger, IMapper mapper)
        {
            _repo = repository;
            _logger = logger;
            _mapper = mapper;
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

        public async Task<ActionResult<Office>> Post([FromBody]OfficeModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    //TODO map
                    //_repo.Add(model);
                }


                if (await _repo.SaveChangesAsync() == false)
                {
                    return StatusCode(StatusCodes.Status304NotModified, "Failed to save data into database");
                }
                _logger.LogInformation($"Requested: [{MethodBase.GetCurrentMethod().ReflectedType.Name.Replace(">d__3", "").Replace("<", "")}], in: [{GetType().Name}] calass.");
                return CreatedAtRoute("Get", new { OfficeId = office.OfficeId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load data from database");
            }
        }
    }
}