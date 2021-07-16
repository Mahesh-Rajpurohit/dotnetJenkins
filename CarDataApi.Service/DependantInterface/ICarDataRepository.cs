using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarDataApi.Service.Models;

namespace CarDataApi.Service.DependantInterface
{
   public interface ICarDataRepository
   {
        Task<IEnumerable<CarDataModel>> GetAllCarData();

        Task<CarDataModel> GetCar(int id);

        Task<IEnumerable<CarDataModel>> AddCar(CarDataModel car);

        Task<CarDataModel> UpdateCarData(CarDataModel car);

        Task<bool> DeleteCarData(int Id);

   }
}
