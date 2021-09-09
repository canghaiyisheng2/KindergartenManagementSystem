using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Data;
using KindergartenManagementSystem.Models.shared;

namespace KindergartenManagementSystem.Services
{
    class LoginService : ILoginService
    {
        KindergartenMSContext _context;

        public LoginService(KindergartenMSContext context)
        {
            _context = context;
        }

        public bool CheckLogin(string username, string password, int auth)
        {
            User user = _context.Users.FirstOrDefault(b => b.user_name == username && b.auth == auth);
            if (user == null) return false;
            else return user.password == password;
        }

        public bool Register(string username, string password, int auth, string name, string cla)
        {
            User user = _context.Users.FirstOrDefault(b => b.user_name == username);
            if (user != null) return false;
            else {
                _context.Users.Add(new User(username, password, auth));
                if(auth == 1)
                {
                    _context.Teachers.Add(new Teacher(name, cla));
                    _context.SaveChanges();
                    User teacher = _context.Users.FirstOrDefault(m => m.user_name == username);
                    teacher.banding = _context.Teachers.FirstOrDefault(m => m.name == name && m.cla == cla).id;
                }
                _context.SaveChanges();
                return true;
            }
        }

    }
}
