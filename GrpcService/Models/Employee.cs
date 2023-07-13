namespace GrpcService.Models
{
    public record Employee
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Title { get; init; }
        public string? Address { get; init; }
        public string? City { get; init; }
        public string? Region { get; init; }
        public string? PostalCode { get; init; }
        public string? Country { get; init; }
        public string? Phone { get; init; }
        public string? Fax { get; init; }
        public string? HomePhone { get; init; }
        public string? Extension { get; init; }
        public string? FaxNumber { get; init; }
        public string? PhoneNumber { get; init; }
        public string? FaxName { get; init; }  
    }
}
