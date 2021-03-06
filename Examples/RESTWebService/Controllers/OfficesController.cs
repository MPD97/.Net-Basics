﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using RESTWebService.ViewModels;
using SimpleOfficeRepositoryCore.Data;
using SimpleOfficeRepositoryCore.Data.Entities;

namespace RESTWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly ISimpleOfficeRepository _repo;
        private readonly ILogger<OfficeContext> _logger;
        private readonly IMapper _mapper;

        public OfficesController(ISimpleOfficeRepository repository,
            ILogger<OfficeContext> logger,
            IMapper mapper)
        {
            _repo = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Office[]>> GetAll()
        {
            try
            {
                return Ok(await _repo.GetAllOfficesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to load data from database");
            }
        }
        [HttpGet("{officeId}")]
        public async Task<ActionResult<Office>> Get(int officeId)
        {
            try
            {
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
                if (ModelState.IsValid == false)
                {
                    return BadRequest(CollectErrors());
                }

                if (await _repo.GetOfficeByCompanyNameAsync(model.CompanyName) != null)
                {
                    return BadRequest("Office with this company name already exists in database.");
                }

                Office office = _mapper.Map<Office>(model);
                _repo.Add(office);

                if (await _repo.SaveChangesAsync())
                {
                    return Created(Url.Action("Get", "Offices", new { officeId = office.OfficeId }), office);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error occurred.");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Office>> Put(OfficeModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(CollectErrors());
                }

                Office office = await _repo.GetOfficeByCompanyNameAsync(model.CompanyName);

                if (office == null)
                {
                    return NotFound("Could not find office with this company name");
                }

                _mapper.Map(model, office);

                if (await _repo.SaveChangesAsync())
                {
                    return Created(Url.Action("Get", "Offices", new { officeId = office.OfficeId }), office);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error occurred.");
            }
            return BadRequest("Nothing changed.");
        }
        [HttpDelete("{officeId}")]
        public async Task<IActionResult> Delete(int officeId)
        {
            try
            {
                Office office = await _repo.GetOfficeAsync(officeId);
                if (office == null)
                {
                    return NotFound("Could not find office with this company name");
                }

                _repo.Delete(office);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error occurred.");
            }
            return BadRequest();
        }

        private List<ModelErrorCollection> CollectErrors()
        {
            return ModelState.Select(x => x.Value.Errors)
               .Where(y => y.Count > 0)
               .ToList();
        }
    }
}