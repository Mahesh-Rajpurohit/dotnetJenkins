using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CarDataApi.Service;
using CarDataApi.Service.Models;
using Xunit;
using CarDataAPI.Web.Controllers;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarDataApiController.Tests
{
    public class CarDataApiControllerUnitTest
    {
        private readonly CarDataController _CarDataController;
        private readonly ICarDataService _CarDataService;

        public CarDataApiControllerUnitTest()
        {
            _CarDataService = A.Fake<ICarDataService>();
            _CarDataController = new CarDataController(_CarDataService)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
        }

        [Fact]
        public async void GetCar()
        {
            //Arrange
            CarDataModel Expected = new CarDataModel
            {
                CarId = 1,
                FacilityId = "mockedFacilityId",
                TimeStamp = DateTime.Now.AddHours(-2),
                CarName = "Bently",
                ManufacturingYear = "2019",
                SerialNo = "XPS-2000",
                CreatedDate = DateTime.Now.AddHours(-2),
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            };

            //Act
            A.CallTo(() => _CarDataService.GetCar(A<int>.Ignored)).Returns(Expected);
            var response = await _CarDataController.GetCar(Expected.CarId);

            //Assert
            var okResult = response as OkObjectResult;
            Assert.Equal(okResult.StatusCode,(int)HttpStatusCode.OK);
        }

        [Fact]
        public async void GetAllCarData()
        {
            //var CarDataList = new CarDataApiRepositoryMocker.CreateCarDataRepositoryWithMockedCarDataTbl();


            //Arrange
            IQueryable<CarDataModel> ExpectedCarList = null;

            ExpectedCarList = new List<CarDataModel>
           {
               new CarDataModel
               {
                   CarId = 1, FacilityId = "mockedFacilityId", TimeStamp = DateTime.Now.AddHours(-2),
                   CarName = "Bently", ManufacturingYear = "2019", SerialNo = "XPS1234ABC",
                   CreatedDate = DateTime.Now.AddHours(-2), ModifiedDate = DateTime.Now, IsDeleted = false
               },
               new CarDataModel
               {
                   CarId = 2, FacilityId = "mockedFacilityId", TimeStamp = DateTime.Now.AddHours(-3),
                   CarName = "BMW", ManufacturingYear = "2018", SerialNo = "I3X",
                   CreatedDate = DateTime.Now.AddHours(-3), ModifiedDate = DateTime.Now, IsDeleted = false
               },
               new CarDataModel
               {
                   CarId = 3, FacilityId = "mockedFacilityId", TimeStamp = DateTime.Now.AddHours(-4),
                   CarName = "MERCEDESE", ManufacturingYear = "2020", SerialNo = "ES2000",
                   CreatedDate = DateTime.Now.AddHours(-4), ModifiedDate = DateTime.Now, IsDeleted = false
               },
               new CarDataModel
               {
                   CarId = 4, FacilityId = "mockedFacilityId", TimeStamp = DateTime.Now.AddHours(-5),
                   CarName = "DUCATI", ManufacturingYear = "2021", SerialNo = "XSS1234",
                   CreatedDate = DateTime.Now.AddHours(-5), ModifiedDate = DateTime.Now, IsDeleted = false
               },


           }.AsQueryable();


            //Act

            A.CallTo(() => _CarDataService.GetAllCarData()).Returns(ExpectedCarList);
            var response = await _CarDataController.GetAllCarData();


            //Assert

            //Assert
            var okResult = response as OkObjectResult;
            Assert.Equal(okResult.StatusCode, (int)HttpStatusCode.OK);

        }


        [Fact]
        public async void UpdateCarData()
        {
            //Arrange
            CarDataModel Expected = new CarDataModel()
            {
                CarId = 1,
                FacilityId = "mockedFacilityId",
                TimeStamp = DateTime.Now.AddHours(-2),
                CarName = "Bently",
                ManufacturingYear = "2019",
                SerialNo = "XPS1234ABC",
                CreatedDate = DateTime.Now.AddHours(-2),
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            };

            //Act
            A.CallTo(() => _CarDataService.UpdateCarData(A<CarDataModel>.Ignored)).Returns(Expected);
            var response = await _CarDataController.UpdateCarData(Expected);

            //Assert
            var okResult = response as OkObjectResult;
            Assert.Equal(okResult.StatusCode, (int)HttpStatusCode.OK);

        }

        [Fact]
        public async void AddCar()
        {
            //Arrange
            CarDataModel Expected = new CarDataModel
            {
                CarId = 1,
                FacilityId = "mockedFacilityId",
                TimeStamp = DateTime.Now.AddHours(-2),
                CarName = "Bently",
                ManufacturingYear = "2019",
                SerialNo = "XPS1234ABC",
                CreatedDate = DateTime.Now.AddHours(-2),
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            };

            IQueryable<CarDataModel> ExpectedCarList = null;

            ExpectedCarList = new List<CarDataModel>
            {
                new CarDataModel
                {
                    CarId = 1, FacilityId = "mockedFacilityId", TimeStamp = DateTime.Now.AddHours(-2),
                    CarName = "Bently", ManufacturingYear = "2019", SerialNo = "XPS1234ABC",
                    CreatedDate = DateTime.Now.AddHours(-2), ModifiedDate = DateTime.Now, IsDeleted = false
                },
                new CarDataModel
                {
                    CarId = 2, FacilityId = "mockedFacilityId", TimeStamp = DateTime.Now.AddHours(-3),
                    CarName = "BMW", ManufacturingYear = "2018", SerialNo = "I3X",
                    CreatedDate = DateTime.Now.AddHours(-3), ModifiedDate = DateTime.Now, IsDeleted = false
                },
                new CarDataModel
                {
                    CarId = 3, FacilityId = "mockedFacilityId", TimeStamp = DateTime.Now.AddHours(-4),
                    CarName = "MERCEDESE", ManufacturingYear = "2020", SerialNo = "ES2000",
                    CreatedDate = DateTime.Now.AddHours(-4), ModifiedDate = DateTime.Now, IsDeleted = false
                },
                new CarDataModel
                {
                    CarId = 4, FacilityId = "mockedFacilityId", TimeStamp = DateTime.Now.AddHours(-5),
                    CarName = "DUCATI", ManufacturingYear = "2021", SerialNo = "XSS1234",
                    CreatedDate = DateTime.Now.AddHours(-5), ModifiedDate = DateTime.Now, IsDeleted = false
                },


            }.AsQueryable();

            //Act
            A.CallTo(() => _CarDataService.AddCar(A<CarDataModel>.Ignored)).Returns(ExpectedCarList);
           var response = await _CarDataController.AddCar(Expected);

            //Assert
            var okResult = response as OkObjectResult;
            Assert.Equal(okResult.StatusCode, (int)HttpStatusCode.OK);

        }

        [Fact]
        public async void DeleteCarData()
        {
            //Arrange
            //bool Expected = true;
            var Expected = new CarDataModel()
            {
                CarId = 1,
                FacilityId = "mockedFacilityId",
                TimeStamp = DateTime.Now.AddHours(-2),
                CarName = "Bently",
                ManufacturingYear = "2019",
                SerialNo = "XPS1234ABC",
                CreatedDate = DateTime.Now.AddHours(-2),
                ModifiedDate = DateTime.Now,
                IsDeleted = true
            };
            //Assert
            A.CallTo(() => _CarDataService.DeleteCarData(A<int>.Ignored)).Returns(Expected.IsDeleted);

            //Act
            var response = await _CarDataController.DeleteCarData(Expected.CarId);


            //Assert
            var okResult = response as OkObjectResult;
            Assert.Equal(okResult.StatusCode, (int)HttpStatusCode.OK);

        }
    }
}
