using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item1.UserException
{
    // Создаем новый тип исключения MyTypeException, наследуясь от базового типа Exception
    public class MyTypeException : Exception
    {
        public MyTypeException() { }
        public MyTypeException(string message) : base(message) { }
        public MyTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
