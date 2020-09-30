#region Using Statements
using AutoMapper;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Repositories.Interfaces;
using Company.SampleApp.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
#endregion

namespace Company.SampleApp.Services.Core
{
    public class ResourceService : ServiceBase<IResourceRepository>, IResourceService
    {
	    protected readonly ILogger _logger;
        protected IMapper _mapper;

        public ResourceService(IResourceRepository repository, ILogger<ResourceService> logger, IMapper mapper) : base(repository)
        {
		    _logger = logger;
            _mapper = mapper;
        }

        public Domain.Client.Dtos.Resource Create(Domain.Client.Dtos.Resource entity)
        {
            try
            {
                Domain.Models.Resource ormEntity = _mapper.Map<Domain.Client.Dtos.Resource, Domain.Models.Resource>(entity);
				
                ormEntity = _repository.Create(ormEntity);
                entity = _mapper.Map<Domain.Models.Resource, Domain.Client.Dtos.Resource>(ormEntity);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return entity;
        }

        public Domain.Client.Dtos.Resource Read(int id, string includeProperties = null)
        {
            Domain.Client.Dtos.Resource toReturn = null;
            try
            {
                Domain.Models.Resource ormEntity = _repository.Read(id, includeProperties);
                toReturn = _mapper.Map<Domain.Models.Resource, Domain.Client.Dtos.Resource>(ormEntity);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

		public List<Domain.Client.Dtos.Resource> ReadAll(string includeProperties = null)
        {
            List<Domain.Client.Dtos.Resource> toReturn = null;
            try
            {
                List<Domain.Models.Resource> ormEntities = _repository.ReadAll(includeProperties);
                toReturn = new List<Domain.Client.Dtos.Resource>();
                foreach(var ormEntity in ormEntities)
                {
                    toReturn.Add(_mapper.Map<Domain.Models.Resource, Domain.Client.Dtos.Resource>(ormEntity));
                }
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

        public PagingList<Domain.Client.Dtos.Resource> Search(ResourceSearchCriteria criteria, string includeProperties = null)
        {
            PagingList<Domain.Client.Dtos.Resource> toReturn = null;

            try
            {
                PagingList<Domain.Models.Resource> ormEntities = _repository.Search(criteria, includeProperties);
                toReturn = new PagingList<Domain.Client.Dtos.Resource>();
                toReturn.TotalCount = ormEntities.TotalCount;
                foreach (var ormEntity in ormEntities)
                {
                    toReturn.Add(_mapper.Map<Domain.Models.Resource, Domain.Client.Dtos.Resource>(ormEntity));
                }
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

        public Domain.Client.Dtos.Resource Update(Domain.Client.Dtos.Resource entity)
        {
            try
            {
                Domain.Models.Resource ormEntity = _mapper.Map<Domain.Client.Dtos.Resource, Domain.Models.Resource>(entity);
                ormEntity = _repository.Update(ormEntity);
                entity = _mapper.Map<Domain.Models.Resource, Domain.Client.Dtos.Resource>(ormEntity);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return entity;
        }

        public void Delete(int id, string includeProperties = null)
        {
            try
            {
                _repository.Delete(id, includeProperties);
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
