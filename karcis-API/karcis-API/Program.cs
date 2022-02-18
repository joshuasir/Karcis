using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace karcis_API
{
    public class Program
    {
    public static IConfiguration Configuration { get; set; }
    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // menentukan path program
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // setting program berupa json file
            .AddEnvironmentVariables(); // tambah env variable program

        Configuration = builder.Build();

        CreateHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>() // start web program
            .UseUrls(Configuration.GetSection("HostingURL").Value) // set url yang digunakan ad di appsetting.json
            .UseIISIntegration() // set integrasi IIS (internet informati setting)
            .UseIIS(); /// gunakan IIS
}
}
