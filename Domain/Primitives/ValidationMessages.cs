using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public class ValidationMessages
    {
        public static string IsNull { get; set; } = "Сущность не может быть NULL";
        public static string IsEmpty { get; set; } = "Сущность не может быть пустой";
        public static string IsRight { get; set; } = "Сущность содержит неправильное значение";
    }
}