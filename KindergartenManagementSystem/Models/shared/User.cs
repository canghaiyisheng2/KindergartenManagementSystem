using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KindergartenManagementSystem.Models.shared
{
    public class User
    {
        [Key]
        public string user_name { get; set; }
        public string password { get; set; }
        public int auth { get; set; }
        public int banding { get; set; }

        public User() { }
        public User(string username, string password, int auth)
        {
            this.user_name = username;
            this.password = password;
            this.auth = auth;
        }
    }
}
