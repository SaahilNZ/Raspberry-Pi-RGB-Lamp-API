using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LampWebApi
{
    public class Program
    {
        static string HostUrl;
        static int RedPin;
        static int GreenPin;
        static int BluePin;

        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            
            HostUrl = configuration["hosturl"];

            if (!int.TryParse(configuration["redpin"], out RedPin))
            {
                RedPin = 17;
            }
            if (!int.TryParse(configuration["greenpin"], out GreenPin))
            {
                GreenPin = 22;
            }
            if (!int.TryParse(configuration["bluepin"], out BluePin))
            {
                BluePin = 24;
            }

            if (string.IsNullOrEmpty(HostUrl))
            {
                HostUrl = "http://0.0.0.0:5000";
            }
            
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls(HostUrl)
                .UseStartup<Startup>()
                .Build();
    }
}
