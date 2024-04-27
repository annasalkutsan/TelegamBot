using System;
using Domain.Primitives;
using Domain.ValueObject;

namespace Application.DTOs
{
    public class BaseDTO
    {
        public Guid Id;
        public FullName FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age => DateTime.Now.Year - BirthDay.Year;
        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
        public Gender Gender { get; set; }
    }
}