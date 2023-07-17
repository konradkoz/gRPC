using EmployeeGrpcService;
using Grpc.Net.Client;
using GrpcService;

AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

using var channel = GrpcChannel.ForAddress("https://localhost:5007", new GrpcChannelOptions() {  });

var client = new Greeter.GreeterClient(channel); 
var employeeClient = new EmployeeService.EmployeeServiceClient(channel);
Console.WriteLine("Client initialized, press any key to send and revive messages...");

while (Console.ReadKey().KeyChar != 'S')
{
    var name = "Jack";

    var replyHello = await client.SayHelloAsync(new HelloRequest { Name = name });
    var replyEmployee = await employeeClient.GetEmployeesAsync(new() { Id = name });
    var relpyGoodbye = await client.SayGoodByeAsync(new GoodbyeRequest() { Name = name });

    Console.WriteLine(replyHello);
    Console.WriteLine();
    Console.WriteLine(replyEmployee);
    Console.WriteLine();
    Console.WriteLine(relpyGoodbye);
    Console.WriteLine();
}