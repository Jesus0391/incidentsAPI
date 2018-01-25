using IncidentsAPI.Models;
using IncidentsAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IncidentsAPI.Services
{
    public class IncidentService : IIncidentService
    {
        private List<Incident> list;
        public IncidentService()
        {
            list = new List<Incident>();
        }
        /// <summary>
        /// Add Incidents
        /// </summary>
        /// <param name="entity"></param>
        public bool Add(Incident entity)
        {
            var incident = list.FirstOrDefault(l => l.kind == entity.kind && l.happenedAt == entity.happenedAt && l.locationId == entity.locationId);
            if (incident != null)
            {
                throw new Exception("The locality is already exist");
            }
            else
            {
                entity._id = Guid.NewGuid().ToString();
                entity.isArchived = false; 
                list.Add(entity);
            }
            return true;
        }
        /// <summary>
        /// Get All Incidents
        /// </summary>
        /// <returns></returns>
        public List<Incident> GetAll(Func<Incident, bool> orderby = null)
        {
            var incidents = list.Where(l => l.isArchived == false).OrderBy(orderby).ToList();
            return incidents;
        }

        public List<Incident> GetAll(Func<Incident, bool> whereCondition, 
                                        Func<Incident, bool> orderby)
        {
            var incidents = list.Where(l => l.isArchived == false)
                                        .Where(whereCondition)
                                        .OrderBy(orderby).ToList();
            return incidents;
        }

        public bool Archived(string incidentId)
        {
            var incident = list.FirstOrDefault(l => l._id == incidentId);
            if (incident == null)
            {
                throw new Exception("Don't exist incident related");
            }
            list[list.IndexOf(incident)].isArchived = true;
            return true;
        }

        public long Count(Func<Incident, bool> whereCondition)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Incident entity)
        {
            throw new NotImplementedException();
        }
  
        public Incident GetSingle(Func<Incident, bool> whereCondition)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Incident> Query(Func<Incident, bool> whereCondition)
        {
            throw new NotImplementedException();
        }

        public void Update(Incident entity)
        {
            throw new NotImplementedException();
        }
    }
}
