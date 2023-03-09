using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logpath = Path.Combine(Directory.GetCurrentDirectory(), "LogHolder");
            NLog.GlobalDiagnosticsContext.Set("LogDirectory", logpath);
            var logger=NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("application Stared");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex) 
            {
                logger.Error("Some issue in application ");
                throw ex;
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureLogging(logging=>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            }).UseNLog();
    }
}
