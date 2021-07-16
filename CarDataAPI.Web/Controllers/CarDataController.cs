using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDataApi.Service;
using CarDataApi.Service.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDataAPI.Web.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CarDataController : ControllerBase
    {
        public readonly ICarDataService CarDataService;

        public CarDataController(ICarDataService carDataService)
        {
            CarDataService = carDataService;
        }


        [ProducesResponseType(200, Type = typeof(CarDataModel[]))]
        [HttpGet("GetAllCar")]
        public async Task<IActionResult> GetAllCarData()
        {
            IEnumerable<CarDataModel> carList = await CarDataService.GetAllCarData();

            return Ok(carList);
        }

        [ProducesResponseType(200, Type = typeof(CarDataModel[]))]
        [HttpGet("GetCar")]

        public async Task<IActionResult> GetCar([FromQuery] int id)
        {
            CarDataModel car = await CarDataService.GetCar(id);

            return Ok(car);
        }


        [ProducesResponseType(200, Type = typeof(CarDataModel[]))]
        [HttpPost("AddCar")]

        public async Task<IActionResult> AddCar([FromBody] CarDataModel carDataModel)
         {
            IEnumerable<CarDataModel> car = await CarDataService.AddCar(carDataModel);

            return Ok(car);
        }

        [ProducesResponseType(200, Type = typeof(CarDataModel[]))]
        [HttpPut("ModifyCarData")]

        public async Task<IActionResult> UpdateCarData([FromBody] CarDataModel carDataModel)
        {
            CarDataModel car = await CarDataService.UpdateCarData(carDataModel);

            return Ok(car);
        }

        [ProducesResponseType(200, Type = typeof(CarDataModel[]))]
        [HttpGet("RemoveCarData")]

        public async Task<IActionResult> DeleteCarData([FromQuery] int id)
        {
            var result = await CarDataService.DeleteCarData(id);

            return Ok(result);
        }

    }
}
