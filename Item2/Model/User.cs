using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item2.Model
{
    public class User
    {
        public string UserName { get; }
        public string Email { get; }

        public User(string username, string email)
        {
            UserName = username;
            Email = email;
        }
    }
}
