// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet()]
        public JsonResult GetCities()
        {
            // return new JsonResult(
            //      new List<object>
            //      {
            //         new {id = 1 , Name = "Cairo"},

            //         new {id = 2 , Name = "Alex"}
            //      }
            //  );
            //updated code is to use city model
            return new JsonResult(CitiesDataStores.Current.Cities);
        }
        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            return new JsonResult(CitiesDataStores.Current.Cities.FirstOrDefault(city => city.Id == id));
        }
    }
}