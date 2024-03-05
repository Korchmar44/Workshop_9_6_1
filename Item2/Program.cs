using Item2.Collection;
using Item2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsersCollections usersCollections = new UsersCollections();
            usersCollections.OnCollectionChanged += UsersCollections_OnCollectionChanged;
            MyTypeException exceptionnew = new MyTypeException("Не верный формат ввода");
            try
            {
                //Добавление пользователей
                usersCollections.AddUser("Денис", "amigo36@mail.ru");
                usersCollections.AddUser("Ярослав", "amigo36@mail.ru");
                usersCollections.AddUser("Антон", "amigo36@mail.ru");
                usersCollections.AddUser("Северус", "amigo36@mail.ru");
                usersCollections.AddUser("Потап", "amigo36@mail.ru");

                //Сортировка
                Console.WriteLine("Для просмотра списка без сортировки необходимо нажать цифру 0\nДля сортировки списка по возврастанию необходимо нажать цифру 1\nДля сортировки списка по возврастанию необходимо нажать цифру 2");
                int sorting_direction = default;
                sorting_direction = Convert.ToInt32(Console.ReadLine());

                //проверка на првильность ввода цифр
                if (sorting_direction != 0 && sorting_direction != 1 && sorting_direction != 2)
                    throw exceptionnew;

                usersCollections.SortedList(usersCollections.Users, sorting_direction);
            }
            catch (MyTypeException ex) 
            {
                Console.WriteLine("Не верный формат");
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void UsersCollections_OnCollectionChanged(string message)
        {
            Console.WriteLine(message);
        }
    }
}
