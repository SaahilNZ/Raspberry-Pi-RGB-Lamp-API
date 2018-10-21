using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            return Ok(new LampResponse()
            {
                Red = Pi.Gpio[Program.RedPin].SoftPwmValue,
                Green = Pi.Gpio[Program.GreenPin].SoftPwmValue,
                Blue = Pi.Gpio[Program.BluePin].SoftPwmValue
            });
        }

        // POST api/lamp
        [HttpPost]
        public IActionResult Post([FromBody]LampResponse colour)
        {
            int redValue = Math.Max(Math.Min(colour.Red, 255), 0);
            int greenValue = Math.Max(Math.Min(colour.Green, 255), 0);
            int blueValue = Math.Max(Math.Min(colour.Blue, 255), 0);

            Console.WriteLine($"Changing colour to ({redValue}, {greenValue}, {blueValue})");

            Pi.Gpio[Program.RedPin].SoftPwmValue = redValue;
            Pi.Gpio[Program.GreenPin].SoftPwmValue = greenValue;
            Pi.Gpio[Program.BluePin].SoftPwmValue = blueValue;
            return Ok();
        }
    }
}
