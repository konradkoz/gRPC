using AutoFixture;
using GrpcService.Models;
using GrpcService.Services;


var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<EmployeeServiceImplementation>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapGet("/GetEmployeesRest", async () => { await Task.Delay(500); var employee = new Fixture().Create<Employee>(); return Results.Ok(employee); });

app.Logger.LogInformation("GRPC app is starting...");
app.Run();
