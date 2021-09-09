using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.shared;
using KindergartenManagementSystem.Data;

namespace KindergartenManagementSystem.Services.UserService
{
    public class UserService : IUserService
    {
        private KindergartenMSContext _context;
        
        public UserService(KindergartenMSContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUserByName(string name)
        {
            return _context.Users.SingleOrDefault(c => c.user_name == name);
        }
    }
}
