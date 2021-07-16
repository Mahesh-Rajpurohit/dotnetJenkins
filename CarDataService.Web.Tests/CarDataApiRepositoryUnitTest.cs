using System;
using System.Collections.Generic;
using System.Linq;
using CarDataApi.Service;
using CarDataApi.Service.DependantInterface;
using CarDataApi.Service.Implementation;
using CarDataApi.Service.Models;
using Xunit;
using FakeItEasy;
using SharedTestData;



namespace CarDataService.Web.Tests
{
    using CarDataApi.Service.Implementation;
    using SharedTestData;
    public class CarDataApiRepositoryUnitTest
    {
        private readonly ICarDataRepository _CarDataRepository;
        private readonly ICarDataService _CarDataService;

        public CarDataApiRepositoryUnitTest()
        {
            _CarDataRepository = A.Fake<ICarDataRepository>();
            _CarDataService = new CarDataService(_CarDataRepository);
        }

        [Fact]
        public async void Repository_GetCarData()
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
            A.CallTo(() => _CarDataRepository.GetCar(A<int>.Ignored)).Returns(Expected);
            CarDataModel response = await _CarDataService.GetCar(Expected.CarId);

            //Assert

            Assert.Equal(response,Expected);
        }

        [Fact]
        public async void Repository_GetAllCarData()
        {
           // var CarDataList = new CarDataApiRepositoryMocker.CreateCarDataRepositoryWithMockedCarDataTbl();


            //Arrange
           IQueryable<CarDataModel> ExpectedCarList =null;

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

           A.CallTo(() => _CarDataRepository.GetAllCarData()).Returns(ExpectedCarList);
           IEnumerable<CarDataModel> response = await _CarDataService.GetAllCarData();


           //Assert

           Assert.Equal(response,ExpectedCarList);

        }


        [Fact]
        public async void Repository_UpdateCarData()
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
            A.CallTo(() => _CarDataRepository.UpdateCarData(A<CarDataModel>.Ignored)).Returns(Expected);
            CarDataModel CarData = await _CarDataService.UpdateCarData(Expected);

            //Assert
            Assert.Equal(CarData, Expected);

        }

        [Fact]
        public async void Repository_AddCar()
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
            A.CallTo(() => _CarDataRepository.AddCar(A<CarDataModel>.Ignored)).Returns(ExpectedCarList);
            IEnumerable<CarDataModel> CarData = await _CarDataService.AddCar(Expected);

            //Assert
            Assert.Equal(CarData, ExpectedCarList);

        }

        [Fact]
        public async void Repository_DeleteCarData()
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
            A.CallTo(() => _CarDataRepository.DeleteCarData(A<int>.Ignored)).Returns(Expected.IsDeleted);

            //Act
            var response = await _CarDataService.DeleteCarData(Expected.CarId);


            //Assert
            Assert.Equal(response, Expected.IsDeleted);

        }
    }
}
