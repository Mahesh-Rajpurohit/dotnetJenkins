using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDataApi.Service;
using CarDataApi.Service.DependantInterface;
using CarDataApi.Service.Models;
namespace CarDataApi.Repository.Sql
{
   public class CarDataRepository:ICarDataRepository
   {
         public readonly AppDBContext _AppDBContext;
        //public readonly IDbContextFactory<AppDBContext> _AppDBContext;


        public CarDataRepository(AppDBContext appDbContext)
        {
            _AppDBContext = appDbContext;
        }

        // public CarDataRepository(IDbContextFactory<AppDBContext> appDbContext)
        //{
        //    _AppDBContext = appDbContext;
        //}

        public async Task<IEnumerable<CarDataModel>> GetAllCarData()
       {
          // await using var buildingDbContext = _AppDBContext.CreateDbContext();

            //var dt = await buildingDbContext.CarDatatbl.Where(x=>x.IsDeleted==false).ToListAsync();
            var dt = await _AppDBContext.CarDatatbl.Where(x => x.IsDeleted == false).ToListAsync();

            IEnumerable<CarDataModel> carData = new List<CarDataModel>();
           if (dt.Count > 0)
           {
               carData = dt;
           }

           return carData;
       }

       public async Task<CarDataModel> GetCar(int id)
       {
           //await using var buildingDbContext = _AppDBContext.CreateDbContext();

            //CarDataModel dt = await buildingDbContext.CarDatatbl.Where(x => x.CarId == id).SingleOrDefaultAsync();
            CarDataModel dt = await _AppDBContext.CarDatatbl.Where(x => x.CarId == id).SingleOrDefaultAsync();

            return dt;
       }

       public async Task<IEnumerable<CarDataModel>> AddCar(CarDataModel car)
       {
           //await using var buildingDbContext = _AppDBContext.CreateDbContext();
            // await buildingDbContext.CarDatatbl.AddAsync(car);
            //await buildingDbContext.SaveChangesAsync();
            //var dt = await buildingDbContext.CarDatatbl.ToListAsync();

            await _AppDBContext.CarDatatbl.AddAsync(car);
            await _AppDBContext.SaveChangesAsync();
            var dt = await _AppDBContext.CarDatatbl.ToListAsync();
            return dt;
       }

       public async Task<CarDataModel> UpdateCarData(CarDataModel car)
       {
           //await using var buildingDbContext = _AppDBContext.CreateDbContext();
           //CarDataModel carobject = await buildingDbContext.CarDatatbl.Where(x=>x.CarId == car.CarId).SingleOrDefaultAsync();
            CarDataModel carobject = await _AppDBContext.CarDatatbl.Where(x => x.CarId == car.CarId).SingleOrDefaultAsync();
            carobject.CarName = car.CarName;
           carobject.IsDeleted = car.IsDeleted;
           carobject.ManufacturingYear = car.ManufacturingYear;
           carobject.SerialNo = car.SerialNo;
           carobject.ModifiedDate = DateTime.Now;
            //buildingDbContext.CarDatatbl.Update(carobject);
            //await buildingDbContext.SaveChangesAsync();

            _AppDBContext.CarDatatbl.Update(carobject);
            await _AppDBContext.SaveChangesAsync();
            return carobject;
       }

        public async Task<bool> DeleteCarData(int Id)
        {
            //await using var buildingDbContext = _AppDBContext.CreateDbContext();
            bool isDeleted = false;
            //CarDataModel Carobject = await buildingDbContext.CarDatatbl.Where(x => x.CarId == Id).SingleOrDefaultAsync();

             CarDataModel Carobject = await _AppDBContext.CarDatatbl.Where(x => x.CarId == Id).SingleOrDefaultAsync();

            if (Carobject != null)
            {
                Carobject.IsDeleted = true;
                Carobject.ModifiedDate = DateTime.Now;
                //buildingDbContext.CarDatatbl.Update(Carobject);
                //await buildingDbContext.SaveChangesAsync();

                _AppDBContext.CarDatatbl.Update(Carobject);
                await _AppDBContext.SaveChangesAsync();

                isDeleted = true;
            }
            return isDeleted;
        }
    }
}
