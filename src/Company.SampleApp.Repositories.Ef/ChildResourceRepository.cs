#region Using Statements
using Company.SampleApp.Data.Ef;
using Company.SampleApp.Domain.Client.Messages;
using Company.SampleApp.Domain.Models;
using Company.SampleApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
#endregion

namespace Company.SampleApp.Repositories.Ef
{
    public partial class ChildResourceRepository : RepositoryBase<ChildResource>, IChildResourceRepository
    {
        public ChildResourceRepository(AppDbContext context) : base(context)
        {
        }

        public new ChildResource Create(ChildResource entity)
        {
            return base.Create(entity);
        }

        public ChildResource Read(int id, string includeProperties = null)
        {
            return base.Read(q => q.Id == id, includeProperties);
        }

        public new List<ChildResource> ReadAll(string includeProperties = null)
        {
            return base.ReadAll(includeProperties);
        }

        public PagingList<ChildResource> Search(ChildResourceSearchCriteria criteria, string includeProperties = null)
        {
            PagingList<ChildResource> results = base.GetWithCriteria(this.BuildQuery(criteria)
                            , criteria
                            , includeProperties
                            );
            return results;
        }

		public ChildResource Update(ChildResource entity)
        {
            return base.Update(q => q.Id == entity.Id, entity);
        }

        public void Delete(int id, string includeProperties = null)
        {
            base.Delete(q => q.Id == id, includeProperties);
            return;
        }

        private Expression<Func<ChildResource, bool>> BuildQuery(ChildResourceSearchCriteria criteria)
        {
            Expression<Func<ChildResource, bool>> expression = (q => true);

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
