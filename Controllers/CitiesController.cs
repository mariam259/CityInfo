// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet()]
        // Older version of code
        // public JsonResult GetCities()
        // {
        //     // return new JsonResult(
        //     //      new List<object>
        //     //      {
        //     //         new {id = 1 , Name = "Cairo"},

        //     //         new {id = 2 , Name = "Alex"}
        //     //      }
        //     //  );
        //     //updated code is to use city model
        //     return new JsonResult(CitiesDataStores.Current.Cities);
        // }
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStores.Current.Cities);
        }
        [HttpGet("{id}")]
        // Older version of code
        // public JsonResult GetCity(int id)
        // {
        //     return new JsonResult(CitiesDataStores.Current.Cities.FirstOrDefault(city => city.Id == id));
        // }
        public ActionResult<CityDto> GetCity(int id)
        {
            //find the city
            var cityToReturn = CitiesDataStores.Current.Cities.FirstOrDefault(city => city.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);


        }
    }
}