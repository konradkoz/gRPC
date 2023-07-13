using Grpc.Core;

namespace GrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine("SayHello has been called.");

            return await Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<GoodbyeResponse> SayGoodBye(GoodbyeRequest request, ServerCallContext context)
        {
            Console.WriteLine("SayGoodBye has been called.");

            return Task.FromResult(new GoodbyeResponse { Message = "Goodbye " + request.Name });
        }
    }
}