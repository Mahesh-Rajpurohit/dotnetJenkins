using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarDataApi.Service.DependantInterface;
using CarDataApi.Service.Models;


namespace CarDataApi.Service.Implementation
{
   public class CarDataService:ICarDataService
   {
       public readonly ICarDataRepository _CarDataRepository;

       public CarDataService(ICarDataRepository carDataRepository)
       {
           _CarDataRepository = carDataRepository;
       }

        public async Task<IEnumerable<CarDataModel>> GetAllCarData()
        {
            return await _CarDataRepository.GetAllCarData();
        }

        public async Task<CarDataModel> GetCar(int id)
        {
            return await _CarDataRepository.GetCar(id);
        }

        public async Task<IEnumerable<CarDataModel>> AddCar(CarDataModel car)
        {
            return await _CarDataRepository.AddCar(car);
        }

        public async Task<CarDataModel> UpdateCarData(CarDataModel car)
        {
            return await _CarDataRepository.UpdateCarData(car);
        }

        public async Task<bool> DeleteCarData(int Id)
        {
            return await _CarDataRepository.DeleteCarData(Id);
        }
    }
}
