using Item1.Collection;
using Item1.UserException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyTypeException myTypeException = new MyTypeException("Мое исключение");
            ExceptionCollection exceptionCollection = new ExceptionCollection();
            exceptionCollection.ProcessCompleted += ExceptionCollection_ProcessCompleted;

            //Добавляем исключения в массив
            exceptionCollection.AddErrors(myTypeException);
            exceptionCollection.AddErrors(new StackOverflowException());
            exceptionCollection.AddErrors(new DivideByZeroException());
            exceptionCollection.AddErrors(new IndexOutOfRangeException());
            exceptionCollection.AddErrors(new OverflowException());

            Exception[] exceptions = exceptionCollection.Errors;

            foreach (Exception item in exceptions)
            {
                try
                {

                    throw item;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Caught {ex.GetType().Name}: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Finally block executed.");
                }
            }

            //exceptionCollection.ReadErrors(exceptionCollection.Errors);
            exceptionCollection.ClearErrors(exceptionCollection.Errors);
            Console.ReadKey();
        }

        private static void ExceptionCollection_ProcessCompleted(string message)
        {
            Console.WriteLine(message);
        }
    }
}
