using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unosquare.RaspberryIO;

namespace LampWebApi.Controllers
{
    [Route("api/[controller]")]
    public class LampController : Controller
    {
        // GET api/lamp
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new Dictionary<string, int>
            {
                { "red", Pi.Gpio[Program.RedPin].SoftPwmValue },
                { "green", Pi.Gpio[Program.GreenPin].SoftPwmValue },
                { "blue", Pi.Gpio[Program.BluePin].SoftPwmValue }
            });
        }

        // POST api/lamp
        [HttpPut()]
        public void Post([FromBody]string value)
        {

        }
    }
}
