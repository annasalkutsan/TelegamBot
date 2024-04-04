using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public static class ValidetorsMessages
    {
        //TODO:Как сделать шаблон StringFormatter
        public static string IsNullOrEmpty { get; set; } = "Сущность не может быть NULL или пустой";
        public static string IsRight { get; set; } = "Сущность содержит неправильное значение";
        //TODO:Отдельно 
    }
}
