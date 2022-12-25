using Grpc.Net.Client;
using GrpcWithDotNetCore.Client.Interfaces;
using GrpcWithDotNetCore.Client.Models;
using GrpcWithDotNetCoreClient;
using Microsoft.Extensions.Configuration;

namespace GrpcWithDotNetCore.Client.Services
{
    public class GreeterService : IGreeterService
    {
        private readonly ApplicationSettings? applicationSettings;
        public GreeterService(IConfiguration configuration) => 
            applicationSettings = configuration?.GetSection(nameof(ApplicationSettings))?.Get<ApplicationSettings>();

        public async Task GetMessage()
        {

            using var channel = GrpcChannel.ForAddress(applicationSettings?.ServiceURL);

            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "Client Ugur" });

            Console.WriteLine("Greeting: " + reply.Message);
        }
    }
}
