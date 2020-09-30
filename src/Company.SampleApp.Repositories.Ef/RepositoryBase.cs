#region Using Statements
using Company.SampleApp.Data.Ef;
using Company.SampleApp.Domain.Client.Enumerations;
using Company.SampleApp.Domain.Client.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
#endregion

namespace Company.SampleApp.Repositories.Ef
{
    public abstract class RepositoryBase<T> where T : class
    {
        internal readonly AppDbContext _context;
		
        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        internal IQueryable<T> GetEntitySet()
        {
            return _context.Set<T>();
        }

        internal PagingList<T> GetWithCriteria(Expression<Func<T, bool>> selector, ISearchCriteria criteria, string includeProperties = null)
        {
            var toReturn = new PagingList<T>();
            IQueryable<T> queryBuilder = GetWithCriteriaQueryable(selector, includeProperties);

            if (!string.IsNullOrEmpty(criteria.SortFieldName))
            {
                queryBuilder = queryBuilder.OrderBy(
                    property: criteria.SortFieldName,
                    direction: (criteria.SortDirection == SortDirection.Ascending) ? "ASC" : "DESC");
            }

            toReturn.TotalCount = queryBuilder.Count();

            //Skip can only be used with sorting
            if (criteria.PageSize != -1 && !string.IsNullOrEmpty(criteria.SortFieldName))
            {
                queryBuilder = queryBuilder
                    .Skip(criteria.PageSize * (criteria.PageNumber - 1))
                    .Take(criteria.PageSize);
            }

            toReturn.AddRange(queryBuilder);

            return toReturn;
        }

        internal IEnumerable<T> GetWithCriteria(Expression<Func<T, bool>> selector, string includeProperties = null) 
        {
            return this.GetWithCriteriaQueryable(selector, includeProperties).ToList();
        }

        internal IQueryable<T> GetWithCriteriaQueryable(Expression<Func<T, bool>> selector, string includeProperties = null)
        {
            return GetEntitySet()
                       .Where(selector)
                       .IncludePropertyListCsv(includeProperties);
        }

        internal T Create(T entity)
        {
            _context.Add<T>(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Read(Expression<Func<T, bool>> selector, string includeProperties = null)
        {
            return GetWithCriteria(selector, includeProperties).FirstOrDefault();
        }

        internal List<T> ReadAll(string includeProperties = null)
        {
            return GetEntitySet()
                 .IncludePropertyListCsv(includeProperties)
                .ToList();
        }

        //internal long GetCount(Expression<Func<T, bool>> selector)
        //{
        //    return GetEntitySet().Where(selector).Count();
        //}

        internal T Update(Expression<Func<T, bool>> selector, T entity)
        {
            var existingEntity = _context.Set<T>().FirstOrDefault(selector);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        internal void Delete(Expression<Func<T, bool>> selector, string includeProperties = null) 
        {
            var entities = GetEntitySet()
                            .Where(selector)
                            .IncludePropertyListCsv(includeProperties)
                            .ToList();

            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    _context.Set<T>().Remove(entity);
                }
                _context.SaveChanges();
            }
        }



    }
}
