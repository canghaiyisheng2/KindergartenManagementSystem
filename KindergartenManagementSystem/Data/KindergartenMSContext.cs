using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.EnterModels;
using KindergartenManagementSystem.Models.shared;
using Microsoft.EntityFrameworkCore;

namespace KindergartenManagementSystem.Data
{
    public class KindergartenMSContext : DbContext
    {
        public KindergartenMSContext(DbContextOptions<KindergartenMSContext> options) : base(options)
        {
        }

        //公共模块
        public DbSet<Child> Children { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        //入托模块
        public DbSet<Enter_Request> enter_Requests { get; set; }
    }
}
