using AutoFixture;
using EmployeeGrpcService;
using Grpc.Core;
using static EmployeeGrpcService.EmployeeService;

namespace GrpcService.Services
{
    class EmployeeServiceImplementation : EmployeeServiceBase
    {
        public override async Task<GetEmployeesResponse> GetEmployees(GetEmployeesRequest request, ServerCallContext context)
        {
            Console.WriteLine("GetEmployees has been called.");
            await Task.Delay(500);
            var employee = new Fixture().Create<GetEmployeesResponse>();

            return employee;
        }
    }
}
