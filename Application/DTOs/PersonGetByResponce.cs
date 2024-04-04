using System;
using Domain.Primitives;

namespace Application.DTOs
{
    public class PersonGetByResponce
    {
        public Guid id;
        public DateTime BirthDay { get; set; }
        public int Age => DateTime.Now.Year - BirthDay.Year;
        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
        public Gender Gender { get; set; }
    }
}