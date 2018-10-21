using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace LampWebApi
{
    public class Program
    {
        static string HostUrl;
        public static int RedPin;
        public static int GreenPin;
        public static int BluePin;

        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            
            HostUrl = configuration["hosturl"];

            if (!int.TryParse(configuration["redpin"], out RedPin))
            {
                RedPin = 0;
            }
            if (!int.TryParse(configuration["greenpin"], out GreenPin))
            {
                GreenPin = 3;
            }
            if (!int.TryParse(configuration["bluepin"], out BluePin))
            {
                BluePin = 5;
            }

            if (string.IsNullOrEmpty(HostUrl))
            {
                HostUrl = "http://0.0.0.0:5000";
            }

            InitializePins();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls(HostUrl)
                .UseStartup<Startup>()
                .Build();
        
        private static void InitializePins()
        {
            var redPin = Pi.Gpio[RedPin];
            var greenPin = Pi.Gpio[GreenPin];
            var bluePin = Pi.Gpio[BluePin];

            redPin.PinMode = GpioPinDriveMode.Output;
            greenPin.PinMode = GpioPinDriveMode.Output;
            bluePin.PinMode = GpioPinDriveMode.Output;

            redPin.StartSoftPwm(0, 255);
            greenPin.StartSoftPwm(0, 255);
            bluePin.StartSoftPwm(0, 255);
        }
    }
}
