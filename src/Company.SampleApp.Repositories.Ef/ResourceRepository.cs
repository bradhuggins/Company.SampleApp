#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Company.SampleApp.Data.Ef;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Company.SampleApp.Repositories.Interfaces;
#endregion

namespace Company.SampleApp.Repositories.Ef
{
    public partial class ResourceRepository : RepositoryBase<Resource>, IResourceRepository
    {
        public ResourceRepository(AppDbContext context) : base(context)
        {
        }

        public new Resource Create(Resource entity)
        {
            return base.Create(entity);
        }

        public Resource Read(int id, string includeProperties = null)
        {
            return base.Read(q => q.Id == id, includeProperties);
        }

        public new List<Resource> ReadAll(string includeProperties = null)
        {
            return base.ReadAll(includeProperties);
        }

        public PagingList<Resource> Search(ResourceSearchCriteria criteria, string includeProperties = null)
        {
            PagingList<Resource> results = base.GetWithCriteria(this.BuildQuery(criteria)
                            , criteria
                            , includeProperties
                            );
            return results;
        }

		public Resource Update(Resource entity)
        {
            return base.Update(q => q.Id == entity.Id, entity);
        }

        public void Delete(int id, string includeProperties = null)
        {
            base.Delete(q => q.Id == id, includeProperties);
            return;
        }

        private Expression<Func<Resource, bool>> BuildQuery(ResourceSearchCriteria criteria)
        {
            Expression<Func<Resource, bool>> expression = (q => true);

            if (criteria.Id.HasValue)
            {
                expression = expression.And(q => q.Id == criteria.Id.Value);
            }

            if (!string.IsNullOrEmpty(criteria.NameStartsWith))
            {
                expression = expression.And(q => q.Name.StartsWith(criteria.NameStartsWith));
            }

            return expression;
        }		

    }

}
