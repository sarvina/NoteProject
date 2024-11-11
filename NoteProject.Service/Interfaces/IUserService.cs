using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Service.Interfaces
{

    public interface IUserService
    {
        bool ValidateUser(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>
    {
        new User { Username = "sarvina", Password = "1234" },
       
    };

        public bool ValidateUser(string username, string password)
        {
            return _users.Any(user => user.Username == username && user.Password == password);
        }
    }

}
