using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using CarDataApi.Service.Models;


namespace CarDataApi.Service
{
   public interface ICarDataService
   {
       Task<IEnumerable<CarDataModel>> GetAllCarData();
       Task<CarDataModel> GetCar(int id);

       Task<IEnumerable<CarDataModel>> AddCar(CarDataModel car);

       Task<CarDataModel> UpdateCarData(CarDataModel car);
       Task<bool> DeleteCarData(int Id);
   }
}
