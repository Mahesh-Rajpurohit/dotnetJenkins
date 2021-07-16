using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CarDataApi.Service.DependantInterface;
using CarDataApi.Service.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using SharedTestData;
using Xunit;

namespace CarDataControllerIntegrationTest
{
    public class CarDataControllerTest
    {
        private readonly int CarId = 1;
        private readonly HttpClient _client;
        public CarDataControllerTest()
        {
            _client = CreateHttpClientWithDependencies(CarDataApiRepositoryMocker.CreateCarDataRepositoryWithMockedCarDataTbl());
        }

        public HttpClient CreateHttpClientWithDependencies(ICarDataRepository carDataRepository)
        {
            var testServer = new TestServerProvider(
                serviceCollection =>
                {
                    serviceCollection.Replace(ServiceDescriptor.Singleton(carDataRepository));
                });
            var testClient = testServer.Client;
            return testClient;
        }

        [Fact]
        public async Task GetAllCarData()
        {
            //Arrange
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Act
            var response = await _client.GetAsync($"api/CarData/GetAllCar").ConfigureAwait(true);

            //Assert
            Assert.Equal((int)response.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetCarData() 
        {
            //Arrange
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Act
            var response = await _client.GetAsync($"api/CarData/GetCar?id{CarId}").ConfigureAwait(true);
            
            //Assert
            Assert.Equal((int)response.StatusCode,(int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddCar()
        {
            //Arrange
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var carDataList = new CarDataModel
                { CarId = 1, FacilityId = "mockFacilityId",
                    TimeStamp = DateTime.Now.AddHours(-2),
                    CarName = "Bently",
                    ManufacturingYear = "2019",
                    SerialNo = "XPS123", 
                    CreatedDate = DateTime.Now.AddHours(-2), 
                    ModifiedDate = DateTime.Now, 
                    IsDeleted = false
                };
            string json = JsonConvert.SerializeObject(carDataList, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF32, "application/json");

            //Act
            var response = await _client.PostAsync($"api/CarData/AddCar", httpContent).ConfigureAwait(true);

            //Assert
            Assert.Equal((int)response.StatusCode,(int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateCarData()
        {
            //Arrange
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var carDataList = new CarDataModel
            {
                CarId = 1,
                FacilityId = "mockFacilityId",
                TimeStamp = DateTime.Now.AddHours(-2),
                CarName = "Bently",
                ManufacturingYear = "2019",
                SerialNo = "XPS123",
                CreatedDate = DateTime.Now.AddHours(-2),
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            };
            string json = JsonConvert.SerializeObject(carDataList, Formatting.Indented);
            var httpContent = new StringContent(json);

            //Act
            var response = await _client.PostAsync($"api/CarData/ModifyCarData", httpContent).ConfigureAwait(true);

            //Assert
            Assert.Equal((int)response.StatusCode, (int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteCarData()
        {
            //Arrange
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Act
            var response = await _client.GetAsync($"api/CarData/RemoveCarData?id{CarId}").ConfigureAwait(true);

            //Assert
            Assert.Equal((int)response.StatusCode, (int)HttpStatusCode.OK);
        }

    }
}
