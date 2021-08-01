using Grpc.Net.Client;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GrpcAuthorClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serverAddress = "https://localhost:5001";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // The following statement allows you to call insecure services. To be used only in development environments.
                AppContext.SetSwitch(
                    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                serverAddress = "http://localhost:5000";
            }

            using var channel = GrpcChannel.ForAddress(serverAddress);
            var client = new Author.AuthorClient(channel);
            var reply = await client.GetAuthorAsync(new AuthorRequest { Name = "Antonio Gonzales" });

            Console.WriteLine("Author: " + reply.ToString());

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
