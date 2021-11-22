using System;
using Serilog;
using System.Drawing;
using System.IO;

namespace UseSerilog
{
    class Program
    {
        static void Main(string[] args)
        {
            //using var log = new LoggerConfiguration().WriteTo.Console()
            //    .WriteTo.File("logs/myapp.txt", Serilog.Events.LogEventLevel.Information, rollingInterval: RollingInterval.Day)
            //    .CreateLogger();
            //log.Information("Hello, Serilog!");
            //Console.WriteLine("Hello World!");

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            Log.Information("Hello, world!");

            var position = new { Latitude = 25, Longitude = 134 };
            var elapsedMs = 34;

            Log.Information("Processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            using var image = Image.FromFile("demo.png");
            using var graphics = Graphics.FromImage(image);
            using Pen blackPen = new Pen(Color.Black, 3);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            graphics.DrawLine(blackPen, new Point(0, 0), new Point(100, 100));
            graphics.Save();
            image.Save("demo2.png");
        }
    }
}
