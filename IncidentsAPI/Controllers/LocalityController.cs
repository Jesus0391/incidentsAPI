using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncidentsAPI.Models;
using IncidentsAPI.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IncidentsAPI.Controllers
{
    [Route("localities")]
    public class LocalityController : Controller
    {
        private readonly ILocalityService _serviceRepository;

        public LocalityController(ILocalityService localityService)
        {
            _serviceRepository = localityService;
            _serviceRepository.Add(new Locality()
            {
                name = "Los Alcarrizos"
            });
        }

        [Route("/")]
        public List<Locality> Get()
        {
          
            return _serviceRepository.GetAll();
        }

        [Route("/localities/{localityId}")]
        public Locality Get(string localityId){
            var localities =  _serviceRepository.GetAll();

            return localities.Where(l => l._id == localityId).FirstOrDefault();
        }
    }
}
