using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine(@"   ___        _       ____             _      _   _       
  / _ \ _   _(_)____ |  _ \ ___  _   _| | ___| |_| |_ ___ 
 | | | | | | | |_  / | |_) / _ \| | | | |/ _ \ __| __/ _ \
 | |_| | |_| | |/ /  |  _ < (_) | |_| | |  __/ |_| |_  __/
  \__\_\\__,_|_/___| |_| \_\___/ \__,_|_|\___|\__|\__\___|");

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
