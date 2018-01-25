using IncidentsAPI.Models;
using IncidentsAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IncidentsAPI.Services
{
    public class LocalityService : ILocalityService
    {
        private List<Locality> list;
        public LocalityService()
        {
            list = new List<Locality>();
        }

        public bool Add(Locality entity)
        {
            if (list.Any(l => l.name.ToLower() == entity.name.ToLower())) {
                throw new Exception("The locality is already exist");
            }
            else
            {
                entity._id = Guid.NewGuid().ToString();
                list.Add(entity);
            }
            return false;
        }

        public long Count(Func<Locality, bool> whereCondition)
        {
            return list.Where(whereCondition).Count();
        }

        public long Count()
        {
            return list.Count();
        }

        public void Delete(Locality entity)
        {
            if (list.Any(l => l.name.ToLower() == entity.name.ToLower()))
            {
                var locality = list.FirstOrDefault(l => l.name.ToLower() == entity.name.ToLower());
                list.Remove(locality);
            }

            else
            {
                throw new Exception("The locality don't exist");
            }
        }

        public List<Locality> GetAll(Func<Locality, bool> whereCondition, Func<Locality, bool> orderBy = null)
        {
            return list.Where(whereCondition).ToList();
        }

        public List<Locality> GetAll(Func<Locality, bool> orderBy = null)
        {
            return list;
        }

        public Locality GetSingle(Func<Locality, bool> whereCondition)
        {
            return list.Where(whereCondition).SingleOrDefault();
        }

        public IQueryable<Locality> Query(Func<Locality, bool> whereCondition)
        {
            throw new NotImplementedException();
        }

        public void Update(Locality entity)
        {
            throw new NotImplementedException();
        }
    }
}
