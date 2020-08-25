#region Using Statements
using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Repositories.Interfaces;
using Company.SampleApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
#endregion

namespace Company.SampleApp.Services.Core
{
    public class OtherResourceService : SimpleServiceBase, IOtherResourceService
    {
	    protected readonly ILogger _logger;
        protected IMapper _mapper;        
        protected IOtherResourceRepository _repository;
        //protected IConfiguration _configuration;

        public OtherResourceService(
            IOtherResourceRepository repository, 
            ILogger<OtherResourceService> logger, 
            IConfiguration configuration,
            IMapper mapper
            ) 
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            //_configuration = configuration;
            _repository.ConnectionString = configuration.GetConnectionString("DataSource2");
        }

        public Domain.Client.Dtos.OtherResource Create(Domain.Client.Dtos.OtherResource entity)
        {
            try
            {
                Domain.Models.OtherResource ormEntity = _mapper.Map<Domain.Client.Dtos.OtherResource, Domain.Models.OtherResource>(entity);
				
                ormEntity = _repository.Create(ormEntity);
                entity = _mapper.Map<Domain.Models.OtherResource, Domain.Client.Dtos.OtherResource>(ormEntity);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return entity;
        }

        public Domain.Client.Dtos.OtherResource Read(int id)
        {
            Domain.Client.Dtos.OtherResource toReturn = null;
            try
            {
                Domain.Models.OtherResource ormEntity = _repository.Read(id);
                toReturn = _mapper.Map<Domain.Models.OtherResource, Domain.Client.Dtos.OtherResource>(ormEntity);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

		public List<Domain.Client.Dtos.OtherResource> ReadAll()
        {
            List<Domain.Client.Dtos.OtherResource> toReturn = null;
            try
            {
                List<Domain.Models.OtherResource> ormEntities = _repository.ReadAll();
                toReturn = new List<Domain.Client.Dtos.OtherResource>();
                foreach(var ormEntity in ormEntities)
                {
                    toReturn.Add(_mapper.Map<Domain.Models.OtherResource, Domain.Client.Dtos.OtherResource>(ormEntity));
                }
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

        public List<Domain.Client.Dtos.OtherResource> Search(OtherResourceSearchCriteria criteria)
        {
            List<Domain.Client.Dtos.OtherResource> toReturn = null;

            try
            {
                List<Domain.Models.OtherResource> ormEntities = _repository.Search(criteria);
                toReturn = new PagingList<Domain.Client.Dtos.OtherResource>();
                //toReturn.TotalCount = ormEntities.TotalCount;
                foreach (var ormEntity in ormEntities)
                {
                    toReturn.Add(_mapper.Map<Domain.Models.OtherResource, Domain.Client.Dtos.OtherResource>(ormEntity));
                }
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

        public Domain.Client.Dtos.OtherResource Update(Domain.Client.Dtos.OtherResource entity)
        {
            try
            {
                Domain.Models.OtherResource ormEntity = _mapper.Map<Domain.Client.Dtos.OtherResource, Domain.Models.OtherResource>(entity);
                ormEntity = _repository.Update(ormEntity);
                entity = _mapper.Map<Domain.Models.OtherResource, Domain.Client.Dtos.OtherResource>(ormEntity);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return entity;
        }

        public void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return;
        }

    }

}
