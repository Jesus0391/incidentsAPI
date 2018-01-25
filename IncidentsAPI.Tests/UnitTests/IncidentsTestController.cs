using IncidentsAPI.Controllers;
using IncidentsAPI.Models;
using IncidentsAPI.Models.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IncidentsAPI.Tests
{
    public class IncidentsTestController
    {
        private List<Incident> list;

        private List<Incident> GetTestIncidents()
        {
            list = new List<Incident>();
            list.Add(new Incident()
            {
                _id = Guid.NewGuid().ToString(),
                isArchived = false,
                locationId = "23TplPdS",
                happenedAt = DateTime.Now.AddDays(3),
                kind = Kinds.ASSAULT
            });

            list.Add(new Incident()
            {
                _id = "322323",
                isArchived = false,
                locationId =Guid.NewGuid().ToString(),
                happenedAt = DateTime.Now.AddDays(3),
                kind = Kinds.ASSAULT
            });
            return list;
        }

        //It should allow retrieving a list of incidents
        //Endpoint: GET /incidents
        [Fact]
        public async Task GetIncidents()
        {
            var mockService = new Mock<IIncidentService>();
            mockService.Setup(service => service.GetAll(null)).Returns(GetTestIncidents());

            var controller = new IncidentsController(mockService.Object);
            var result = controller.Get();

            Assert.Equal(2, result.Count);
        }

        //It should allow registering new incidents
        //Endpoint: POST /incidents
        [Fact]
        public async Task PostIncident()
        {
            var mockService = new Mock<IIncidentService>();
            mockService.Setup(service => service.GetAll(null)).Returns(GetTestIncidents());

            var controller = new IncidentsController(mockService.Object);
            var result = controller.Post(new Incident()
            {
                _id = Guid.NewGuid().ToString(),
                isArchived = false,
                locationId = "23TplPdS",
                happenedAt = DateTime.Now.AddDays(3),
                kind = Kinds.ROBBERY
            });

            var incidents = controller.Get();
            Assert.Equal(3, incidents.Count);
        }

        /*
         It should allow archiving incidents
        Endpoint: POST /incidents/:incidentId/archive
        Remarks: Archived incidents should not appear in GET /incidents
        */
        [Fact]
        public async Task ArchiveIncident()
        {
            var mockService = new Mock<IIncidentService>();
            mockService.Setup(service => service.GetAll(null)).Returns(GetTestIncidents());

            var controller = new IncidentsController(mockService.Object);
            var result = controller.Archive("322323");

            var incidents = controller.Get();
            Assert.Single(incidents);
        }
    }
}