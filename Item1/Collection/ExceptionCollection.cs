using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item1.Collection
{
    /// <summary>
    /// Представляет коллекцию исключений.
    /// </summary>
    public class ExceptionCollection : Exception
    {
        /// <summary>
        /// Делегат для очистки массива ошибок.
        /// </summary>
        public delegate void ClearErrorsArray(string message);

        /// <summary>
        /// Событие, срабатывающее по завершению процесса.
        /// </summary>
        public event ClearErrorsArray ProcessCompleted;

        private int counter = 0;

        /// <summary>
        /// Массив исключений фиксированной длины, равной 5.
        /// </summary>
        public Exception[] Errors { get; } = new Exception[5];

        /// <summary>
        /// Инициализирует новый экземпляр класса ExceptionCollection.
        /// </summary>
        public ExceptionCollection() : base() { }

        /// <summary>
        /// Добавляет исключение в массив ошибок.
        /// </summary>
        /// <param name="exception">Добавляемое исключение.</param>
        public void AddErrors(Exception exception)
        {
            Errors[counter++] = exception;
        }

        /// <summary>
        /// Очищает массив ошибок и запускает событие ProcessCompleted.
        /// </summary>
        /// <param name="Errors">Массив ошибок для очистки.</param>
        public void ClearErrors(Exception[] Errors)
        {
            for (int i = 0; i < Errors.Length; i++)
            {
                Errors[i] = null;
            }
            ProcessCompleted?.Invoke("Массив очищен");
        }

        
        /// <summary>
        /// Выводит ненулевые элементы массива ошибок в консоль.
        /// </summary>
        /// <param name="Errors">Массив ошибок для чтения.</param>
        public void ReadErrors(Exception[] Errors)
        {
            for (int i = 0; i < Errors.Length; i++)
            {
                if (Errors[i] == null) break;
                else Console.WriteLine(Errors[i].ToString());
            }
        }

        /// <summary>
        /// Возвращает строку, представляющую текущий объект.
        /// </summary>
        /// <returns>Строка, представляющая текущий объект.</returns>
        public override string ToString()
        {
            return $"{Message}";
        }
    }
}
