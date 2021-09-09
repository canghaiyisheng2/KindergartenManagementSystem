using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.shared;

namespace KindergartenManagementSystem.Services.UserService
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string name);
    }
}
