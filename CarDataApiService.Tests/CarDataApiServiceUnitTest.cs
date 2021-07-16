using System;
using CarDataApi.Service;
using Xunit;
using FakeItEasy;
using CarDataApi.Service.Models;
using System.Linq;
using System.Collections.Generic;

namespace CarDataApiService.Tests
{
    public class CarDataApiServiceUnitTest
    {
        private readonly ICarDataService _carDataService;

        public CarDataApiServiceUnitTest()
        {
            _carDataService = A.Fake<ICarDataService>();

        }

        [Fact]
        public async void Service_GetCarData()
        {
            //Arrange
            CarDataModel expected = new CarDataModel
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
            A.CallTo(() => _carDataService.GetCar(A<int>.Ignored)).Returns(expected);
            CarDataModel response = await _carDataService.GetCar(expected.CarId);

            //Assert

            Assert.Equal(response, expected);
        }


        [Fact]
        public async void Service_GetAllCarData()
        {
            //var CarDataList = new CarDataApiServiceMocker.CreateCarDataServiceWithMockedCarDataTbl();


            //Arrange

            var expectedCarList = new List<CarDataModel>
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

            A.CallTo(() => _carDataService.GetAllCarData()).Returns(expectedCarList);
            IEnumerable<CarDataModel> response = await _carDataService.GetAllCarData();


            //Assert

            Assert.Equal(response, expectedCarList);

        }

        [Fact]
        public async void Service_UpdateCarData()
        {
            //Arrange
            CarDataModel expected = new CarDataModel()
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
            A.CallTo(() => _carDataService.UpdateCarData(A<CarDataModel>.Ignored)).Returns(expected);
            CarDataModel carData = await _carDataService.UpdateCarData(expected);

            //Assert
            Assert.Equal(carData, expected);

        }

        [Fact]
        public async void Service_AddCar()
        {
            //Arrange
            CarDataModel expected = new CarDataModel
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

            var expectedCarList = new List<CarDataModel>
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
            A.CallTo(() => _carDataService.AddCar(A<CarDataModel>.Ignored)).Returns(expectedCarList);
            IEnumerable<CarDataModel> carData = await _carDataService.AddCar(expected);

            //Assert
            Assert.Equal(carData, expectedCarList);

        }

        [Fact]
        public async void Service_DeleteCarData()
        {
            //Arrange
            //bool Expected = true;
            var expected = new CarDataModel()
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
            A.CallTo(() => _carDataService.DeleteCarData(A<int>.Ignored)).Returns(expected.IsDeleted);

            //Act
            var response = await _carDataService.DeleteCarData(expected.CarId);


            //Assert
            Assert.Equal(response, expected.IsDeleted);

        }
    }
}
