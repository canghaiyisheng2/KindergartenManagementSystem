using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenManagementSystem.Services
{
    public interface ILoginService
    {
        bool CheckLogin(string username, string password, int auth);
        bool Register(string username, string password, int auth, string name, string cla);
    }
}
