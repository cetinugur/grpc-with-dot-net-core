using GrpcWithDotNetCore.Client.Extensions;
using GrpcWithDotNetCore.Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;

try
{
    var services = new ServiceCollection();
    services.AddClientServices();

    await using var scope = services.BuildServiceProvider().CreateAsyncScope();
    await scope.ServiceProvider.GetRequiredService<IGreeterService>().GetMessage();
}
catch (Exception exp)
{
    Console.WriteLine(exp);
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();