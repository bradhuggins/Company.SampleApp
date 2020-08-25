#region Using Statements
using Company.SampleApp.Repositories.Interfaces;
using Dapper;
using System.Data.SqlClient;
using System;
using Company.SampleApp.Domain.Models;
using System.Collections.Generic;
using Company.SampleApp.Domain.Client.Messages;
using System.Linq;
#endregion

namespace Company.SampleApp.Repositories.DataSource2
{
    public class OtherResourceRepository : IOtherResourceRepository
    {
        private string _connectionString;

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new System.Exception("Error: ConnectionString not set!");
                }
                return _connectionString;
            }
            set { _connectionString = value; }
        }

        public OtherResource Create(OtherResource entity)
        {
            OtherResource toReturn = null;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                toReturn = connection.QuerySingleOrDefault<OtherResource>(OtherResourceQueries.Create,
                    new
                    {
                        //Id = entity.Id,
                        Name = entity.Name
                    });
            }
            return toReturn;
        }

        public OtherResource Read(int id)
        {
            OtherResource toReturn = null;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                toReturn = connection.QuerySingleOrDefault<OtherResource>(OtherResourceQueries.Read,
                    new
                    {
                        Id = id
                    });
            }
            return toReturn;
        }

        public List<OtherResource> ReadAll()
        {
            List<OtherResource> toReturn = new List<OtherResource>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                toReturn = connection.Query<OtherResource>(OtherResourceQueries.ReadAll).ToList();
            }
            return toReturn;
        }

        public List<OtherResource> Search(OtherResourceSearchCriteria criteria)
        {
            List<OtherResource> toReturn = new List<OtherResource>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                toReturn = connection.Query<OtherResource>(this.BuildQuery(criteria)).ToList();
            }
            return toReturn;
        }

        public OtherResource Update(OtherResource entity)
        {
            OtherResource toReturn = null;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                toReturn = connection.QuerySingleOrDefault<OtherResource>(OtherResourceQueries.Update,
                    new
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    });
            }
            return toReturn;
        }
        public void Delete(int id)
        {
            int result = -1;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                result = connection.ExecuteScalar<int>(OtherResourceQueries.Delete,
                    new
                    {
                        Id = id
                    });
            }
        }

        private string BuildQuery(OtherResourceSearchCriteria criteria)
        {
            string toReturn = OtherResourceQueries.SearchBase;
            toReturn += " WHERE 1=1";
            if (criteria.Id.HasValue)
            {
                toReturn += " AND Id=" + criteria.Id.ToString();
            }

            if (!string.IsNullOrEmpty(criteria.NameStartsWith))
            {
                toReturn += " AND Name LIKE '" + criteria.NameStartsWith +"%'";
            }

            if(!string.IsNullOrEmpty(criteria.SortFieldName))
            {
                switch (criteria.SortFieldName)
                {
                    case "Id":
                        toReturn += " ORDER BY Id";
                        break;
                    case "Name":
                        toReturn += " ORDER BY Name";
                        break;
                    default:                        
                        break;
                }
                if(criteria.SortDirection == Domain.Client.Enumerations.SortDirection.Ascending)
                {
                    toReturn += " ASC";
                }
                else
                {
                    toReturn += " DESC";
                }

            }

            return toReturn;
        }
    }
}
