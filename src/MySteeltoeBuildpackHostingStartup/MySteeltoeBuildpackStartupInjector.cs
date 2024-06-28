using System.Net;
using MySteeltoeBuildpackHostingStartup;
using Steeltoe.Management.Endpoint;

[assembly: HostingStartup(typeof(MySteeltoeBuildpackStartupInjector))]

namespace MySteeltoeBuildpackHostingStartup;

public class MySteeltoeBuildpackStartupInjector: IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        Console.WriteLine("Injecting Steeltoe");
        builder.AddAllActuators();
    }

}