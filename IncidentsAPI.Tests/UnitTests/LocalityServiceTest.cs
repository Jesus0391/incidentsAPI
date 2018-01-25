using IncidentsAPI.Controllers;
using IncidentsAPI.Models;
using IncidentsAPI.Models.Interfaces;
using IncidentsAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IncidentsAPI.Tests
{
    public class LocalityControllerTests
    {
        private List<Locality> list;

        private List<Locality> GetTestLocalities()
        {
            list = new List<Locality>();
            list.Add(new Locality() {
                _id = Guid.NewGuid().ToString(),
                name = "Los Alcarrizos"
            });

            list.Add(new Locality()
            {
                _id = "23TplPdS",
                name = "Los Mina"
            });
            return list;
        }

        //It should allow retrieving a list of all localities in the city
        //Endpoint: GET /localities
         [Fact]
        public async Task GetAllLocalities()
        {
            var mockService = new Mock<ILocalityService>();
            mockService.Setup(service => service.GetAll(null)).Returns(GetTestLocalities());

            var controller = new LocalityController(mockService.Object);
            var result = controller.Get();

            Assert.Equal(2, result.Count);
        }

        //GET /localities/:localityId
        [Fact]
        public async Task GetSingleLocalities()
        {
            var mockService = new Mock<ILocalityService>();
            mockService.Setup(service => service.GetAll(null)).Returns(GetTestLocalities());

            var controller = new LocalityController(mockService.Object);
            var result = controller.Get("23TplPdS");

            Assert.NotNull(result);
        }
    }
}
