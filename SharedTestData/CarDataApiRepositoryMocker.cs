using System;
using System.Collections.Generic;

namespace SharedTestData
{
    using System.Linq;
    using CarDataApi.Repository.Sql;
    using CarDataApi.Service;
    using CarDataApi.Service.DependantInterface;
    using CarDataApi.Service.Models;
    using FakeItEasy;
    using Microsoft.EntityFrameworkCore;

    public class CarDataApiRepositoryMocker
    {


        public static ICarDataRepository CreateCarDataRepositoryWithMockedCarDataTbl()
        {
            string mockFacilityId = "Banglore17";

            DateTimeOffset timeStamp = DateTime.Now;

           //AppDBContext  dbContextFactory = A.Fake<AppDBContext>();
           AppDBContext dbContext = FakeDBContext.Fake<AppDBContext>();

           // A.CallTo(() => dbContextFactory).Returns(dbContext);

            var data = new List<CarDataModel>
            {
                new CarDataModel{CarId = 1,FacilityId = mockFacilityId,TimeStamp = timeStamp.AddHours(-2),CarName = "Bently",ManufacturingYear = "2019",SerialNo = "XPS123",CreatedDate = timeStamp.AddHours(-2),ModifiedDate = timeStamp,IsDeleted = false},
                new CarDataModel{CarId = 2,FacilityId = mockFacilityId,TimeStamp = timeStamp.AddHours(-1),CarName = "BMW",ManufacturingYear = "2018",SerialNo = "ABC1234",CreatedDate = timeStamp.AddHours(-3),ModifiedDate = timeStamp,IsDeleted = false},
                new CarDataModel{CarId = 3,FacilityId = mockFacilityId,TimeStamp = timeStamp.AddHours(-3),CarName = "Mercedese",ManufacturingYear = "2017",SerialNo = "CVF8799",CreatedDate = timeStamp.AddHours(-4),ModifiedDate = timeStamp,IsDeleted = false},
                new CarDataModel{CarId = 4,FacilityId = mockFacilityId,TimeStamp = timeStamp.AddHours(-4),CarName = "Ducati",ManufacturingYear = "2021",SerialNo = "DUCA123",CreatedDate = timeStamp.AddHours(-5),ModifiedDate = timeStamp,IsDeleted = false},
                new CarDataModel{CarId = 5,FacilityId = mockFacilityId,TimeStamp = timeStamp.AddHours(-5),CarName = "Maruthi",ManufacturingYear = "2021",SerialNo = "MARU3456",CreatedDate = timeStamp.AddHours(-6),ModifiedDate = timeStamp,IsDeleted = false},
            }.AsQueryable();
            //var data = new List<CarDataModel>().AsQueryable();
            dbContext.MockData(data.ToList(), () => dbContext.CarDatatbl);

            //return new CarDataRepository(dbContextFactory);
            return new CarDataRepository(dbContext);
        }
    }
}
