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
    [Route("api/resources")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ResourcesController : BaseController<IResourceService>
    {
        public ResourcesController(IResourceService service) : base(service)
        {
        }

        ///// <summary>
        ///// Returns all Resources.
        ///// </summary>
        ///// <returns>A collection of Resources.</returns>
        ///// <remarks>
        ///// Sample request:
        ///// 
        /////     GET /resources
        /////     
        ///// </remarks>
        ///// <response code="200">Returns all Resources.</response>		
        //[HttpGet]
		//[Route("", Name = "GetAllResources")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult Get()
        //{
        //    var results = new List<Resource>();
        //    results = _service.ReadAll();
        //    return Ok(results);
        //}

        /// <summary>
        /// Returns a specific Resource.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a specific Resource.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /resources/1
        ///     
        /// </remarks>
        /// <response code="200">Returns a specific Resource.</response>
        /// <response code="404">Resource was not found.</response>
        [HttpGet]
		[Route("{id}", Name = "GetResourceById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var result = _service.Read(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Creates a Resource.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>A newly created Resource.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /resources
        ///     {
        ///        "id": 1,
        ///        "name": "Item1"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created Resource.</response>
        /// <response code="400">If the Resource is null.</response> 
        /// <response code="500">If internal system error.</response>
        [HttpPost]
		[Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody]Resource entity)
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
            return CreatedAtRoute("GetResourceById", new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a Resource.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns>The updated Resource.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /resources/1
        ///     {
        ///        "id": 1,
        ///        "name": "Item1"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated Resource.</response>
        /// <response code="400">If the Resource is null.</response> 
        /// <response code="500">If internal system error.</response> 
        [HttpPut]
		[Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody]Resource entity)
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

        /// <summary>
        /// Deletes a specific Resource.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /resources/1
        ///     
        /// </remarks>
        /// <response code="204">Operation was successful.</response>
        /// <response code="500">If internal system error.</response>
        [HttpDelete]
		[Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            if (_service.HasError)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Exception(_service.ErrorMessage));
            }
            return NoContent();
        }

        /// <summary>
        /// Returns all Resources matching the specified criteria.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>All Resources matching the specified criteria.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /resources/search?pageNumber=1&amp;pageSize=10&amp;sortDirection=0&amp;sortField=name&amp;nameStartsWith=test
        ///     
        /// </remarks>
        /// <response code="200">Returns all Resources matching the specified criteria.</response>        
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Search([FromQuery]ResourceSearchCriteria criteria)
        {
			if (criteria == null)
            {
                return BadRequest();
            }
            var response = new ResourceGetWithCriteriaResponse();
            var results = _service.Search(criteria);
            if (results != null)
            {
                response.Results = results;
                response.TotalCount = results.TotalCount;
            }
            response.ErrorMessage = _service.ErrorMessage;
            return Ok(response);
        }

    }
}