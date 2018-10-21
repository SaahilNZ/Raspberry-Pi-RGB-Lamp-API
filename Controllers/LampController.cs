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
            int clampedRed = Math.Max(Math.Min(colour.Red, 255), 0);
            int clampedGreen = Math.Max(Math.Min(colour.Green, 255), 0);
            int clampedBlue = Math.Max(Math.Min(colour.Blue, 255), 0);

            int redValue = (int)Math.Round((clampedRed * 100) / 255f);
            int greenValue = (int)Math.Round((clampedGreen * 100) / 255f);
            int blueValue = (int)Math.Round((clampedBlue * 100) / 255f);

            Console.WriteLine($"Changing colour to ({clampedRed}, {clampedGreen}, {clampedBlue})");

            Pi.Gpio[Program.RedPin].SoftPwmValue = redValue;
            Pi.Gpio[Program.GreenPin].SoftPwmValue = greenValue;
            Pi.Gpio[Program.BluePin].SoftPwmValue = blueValue;
            return Ok();
        }
    }
}
