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
    public class ChildResourceService : ServiceBase<IChildResourceRepository>, IChildResourceService
    {
	    protected readonly ILogger _logger;
        protected IMapper _mapper;

        public ChildResourceService(IChildResourceRepository repository, ILogger<ChildResourceService> logger, IMapper mapper) : base(repository)
        {
		    _logger = logger;
            _mapper = mapper;
        }

        public Domain.Client.Dtos.ChildResource Create(Domain.Client.Dtos.ChildResource entity)
        {
            try
            {
                Domain.Models.ChildResource ormEntity = _mapper.Map<Domain.Client.Dtos.ChildResource, Domain.Models.ChildResource>(entity);
				
                ormEntity = _repository.Create(ormEntity);
                entity = _mapper.Map<Domain.Models.ChildResource, Domain.Client.Dtos.ChildResource>(ormEntity);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return entity;
        }

        public Domain.Client.Dtos.ChildResource Read(int id, string includeProperties = null)
        {
            Domain.Client.Dtos.ChildResource toReturn = null;
            try
            {
                Domain.Models.ChildResource ormEntity = _repository.Read(id, includeProperties);
                toReturn = _mapper.Map<Domain.Models.ChildResource, Domain.Client.Dtos.ChildResource>(ormEntity);
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

		public List<Domain.Client.Dtos.ChildResource> ReadAll(string includeProperties = null)
        {
            List<Domain.Client.Dtos.ChildResource> toReturn = null;
            try
            {
                List<Domain.Models.ChildResource> ormEntities = _repository.ReadAll(includeProperties);
                toReturn = new List<Domain.Client.Dtos.ChildResource>();
                foreach(var ormEntity in ormEntities)
                {
                    toReturn.Add(_mapper.Map<Domain.Models.ChildResource, Domain.Client.Dtos.ChildResource>(ormEntity));
                }
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

        public PagingList<Domain.Client.Dtos.ChildResource> Search(ChildResourceSearchCriteria criteria, string includeProperties = null)
        {
            PagingList<Domain.Client.Dtos.ChildResource> toReturn = null;

            try
            {
                PagingList<Domain.Models.ChildResource> ormEntities = _repository.Search(criteria, includeProperties);
                toReturn = new PagingList<Domain.Client.Dtos.ChildResource>();
                toReturn.TotalCount = ormEntities.TotalCount;
                foreach (var ormEntity in ormEntities)
                {
                    toReturn.Add(_mapper.Map<Domain.Models.ChildResource, Domain.Client.Dtos.ChildResource>(ormEntity));
                }
            }
            catch (Exception ex)
            {
			    _logger.LogError(ex.ToString());
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

        public Domain.Client.Dtos.ChildResource Update(Domain.Client.Dtos.ChildResource entity)
        {
            try
            {
                Domain.Models.ChildResource ormEntity = _mapper.Map<Domain.Client.Dtos.ChildResource, Domain.Models.ChildResource>(entity);
                ormEntity = _repository.Update(ormEntity);
                entity = _mapper.Map<Domain.Models.ChildResource, Domain.Client.Dtos.ChildResource>(ormEntity);
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
