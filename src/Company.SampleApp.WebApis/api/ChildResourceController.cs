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
    [Route("api/v1/childresources")]
    [ApiController]
    public class ChildResourcesController : BaseController<IChildResourceService>
    {
        public ChildResourcesController(IChildResourceService service) : base(service)
        {
        }

        ///// <summary>
        ///// Returns all ChildResources.
        ///// </summary>
        ///// <returns>A collection of ChildResources.</returns>
        ///// <remarks>
        ///// Sample request:
        ///// 
        /////     GET /childresources
        /////     
        ///// </remarks>
        ///// <response code="200">Returns all ChildResources.</response>		
        //[HttpGet]
		//[Route("", Name = "GetAllChildResources")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public IActionResult Get()
        //{
        //    var results = new List<ChildResource>();
        //    results = _service.ReadAll();
        //    return Ok(results);
        //}

        /// <summary>
        /// Returns a specific ChildResource.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a specific ChildResource.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /childresources/1
        ///     
        /// </remarks>
        /// <response code="200">Returns a specific ChildResource.</response>
        /// <response code="404">ChildResource was not found.</response>
        [HttpGet]
		[Route("{id}", Name = "GetChildResourceById")]
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
        /// Creates a ChildResource.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>A newly created ChildResource.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /childresources
        ///     {
        ///        "id": 1,
        ///        "name": "Item1"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created ChildResource.</response>
        /// <response code="400">If the ChildResource is null.</response> 
        /// <response code="500">If internal system error.</response>
        [HttpPost]
		[Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody]ChildResource entity)
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
            return CreatedAtRoute("GetChildResourceById", new { id = result.Id }, result);
        }

        /// <summary>
        /// Updates a ChildResource.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns>The updated ChildResource.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /childresources/1
        ///     {
        ///        "id": 1,
        ///        "name": "Item1"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated ChildResource.</response>
        /// <response code="400">If the ChildResource is null.</response> 
        /// <response code="500">If internal system error.</response> 
        [HttpPut]
		[Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody]ChildResource entity)
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
        /// Deletes a specific ChildResource.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /childresources/1
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
        /// Returns all ChildResources matching the specified criteria.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>All ChildResources matching the specified criteria.</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /childresources/search?pageNumber=1&amp;pageSize=10&amp;sortDirection=0&amp;sortField=name&amp;nameStartsWith=test
        ///     
        /// </remarks>
        /// <response code="200">Returns all ChildResources matching the specified criteria.</response>        
        [HttpGet]
        [Route("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Search([FromQuery]ChildResourceSearchCriteria criteria)
        {
			if (criteria == null)
            {
                return BadRequest();
            }
            var response = new ChildResourceGetWithCriteriaResponse();
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