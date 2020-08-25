#region Using Statements
using Company.SampleApp.Domain.Client.Dtos;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
#endregion

namespace Company.SampleApp.WebApis.api
{
    //[Authorize]
	[Produces("application/json")]
    [Route("api/v1/otherresources")]
    public class OtherResourcesController : BaseController<IOtherResourceService>
    {
        public OtherResourcesController(IOtherResourceService service) : base(service)
        {
        }
		
        //[HttpGet]
		//[Route("", Name = "GetAllOtherResources")]
        //public IActionResult Get()
        //{
        //    var results = new List<OtherResource>();
        //    results = _service.ReadAll();
        //    return Ok(results);
        //}

        [HttpGet]
		[Route("{id}", Name = "GetOtherResourceById")]
        public IActionResult Get(int id)
        {
            var result = _service.Read(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
		[Route("")]
        public IActionResult Post([FromBody]OtherResource entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            var result = _service.Create(entity);
            if (_service.HasError)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(_service.ErrorMessage));
            }
            return CreatedAtRoute("GetOtherResourceById", new { id = result.Id }, result);
        }

        [HttpPut]
		[Route("{id}")]
        public IActionResult Put(int id, [FromBody]OtherResource entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            var result = _service.Update(entity);
            if (_service.HasError)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(_service.ErrorMessage));
            }
            return Ok(result);
        }

        [HttpDelete]
		[Route("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            if (_service.HasError)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(_service.ErrorMessage));
            }
            return Ok();
        }
        
        [HttpGet]
        [Route("search")]
        public IActionResult Search([FromQuery]OtherResourceSearchCriteria criteria)
        {
			if (criteria == null)
            {
                return BadRequest();
            }
            var response = new OtherResourceGetWithCriteriaResponse();
            var results = _service.Search(criteria);
            response.Results = results;
            //response.TotalCount = results.TotalCount;
            response.ErrorMessage = _service.ErrorMessage;
            return Ok(response);
        }

    }
}