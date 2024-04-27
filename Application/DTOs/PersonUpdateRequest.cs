using System;

namespace Application.DTOs
{
    public class PersonUpdateRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; } = null;
        public string PhoneNumber { get; set; }
    }
}