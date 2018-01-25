using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentsAPI.Models;
using IncidentsAPI.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IncidentsAPI.Controllers
{
    [Route("incidents")]
    public class IncidentsController : Controller
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [Route("/")]
        public List<Incident> Get()
        {
            return _incidentService.GetAll();
        }


        [HttpPost]
        [Route("/")]
        public bool Post(Incident incident)
        {
          var result =  _incidentService.Add(incident);
            return result;
        }

        [HttpPost]
        [Route("/incidents/:incidentId/archive")]
        public bool Archive(string incidentId)
        {
            var result = _incidentService.Archived(incidentId);
            return result;
        }
    }
}