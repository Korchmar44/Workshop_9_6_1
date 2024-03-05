using Item2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item2.Collection
{
    public class UsersCollections
    {
        public delegate void SortedCollection(string message);
        public event SortedCollection OnCollectionChanged;


        public List<User> Users { get; }
        public User NewUser { get; private set; } 

        public UsersCollections()
        {
            Users = new List<User>();
        }

        public void AddUser(string username, string email)
        {
            NewUser = new User(username, email);
            Users.Add(NewUser);
        }

        public void SortedList(List<User> users, int sorting_direction)
        {
            switch (sorting_direction)
            {
                case 0: //без сортировки
                    OnCollectionChanged?.Invoke("Без сортировки");
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.UserName);
                    }
                    break;
                case 1: //Сортировка по возврастанию
                    var sortedUserASC = users.OrderBy(n=>n.UserName);
                    OnCollectionChanged?.Invoke("Сортировка по возврастанию");
                    foreach (var user in sortedUserASC)
                    {
                        Console.WriteLine(user.UserName);
                    }
                    break;
                case 2: //Сортировка по убыванию
                    var sortedUserDESC = users.OrderByDescending(n=>n.UserName);
                    OnCollectionChanged?.Invoke("Сортировка по убыванию");
                    foreach (var user in sortedUserDESC)
                    {
                        Console.WriteLine(user.UserName);
                    }
                    break;
                default: 
                    Console.WriteLine("Не корректный ввод");
                    break;
            }
        }
    }
}
