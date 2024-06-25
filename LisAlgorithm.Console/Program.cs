using LisAlgorithm.Application.Abstraction;
using LisAlgorithm.Application.Operation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Numerics;

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger("Program");

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<ILongestIncreasingSequence, LongestIncreasingSequence>();

using IHost host = builder.Build();
Start(logger);



await host.RunAsync();

static void Start(ILogger logger)
{

    try
    {

        var service = new LongestIncreasingSequence();

        //var input = "6 1 5 9 2";
        var input = Console.ReadLine();
        logger.LogInformation($"The Input is : {input}");

        if (string.IsNullOrWhiteSpace(input))
            return;

        var output = service.FindLongestSequence(input);
        
        output = !string.IsNullOrWhiteSpace(output) ? output : "Empty Array => Please input numbers only";
        logger.LogInformation($"The Output is : {output}");



    }
    catch (Exception ex)
    {
        logger.LogError($"Error occoured:  {ex.Message}  - Detailed Message{ex.InnerException}");
        throw;
    }


    Console.ReadLine();
}


