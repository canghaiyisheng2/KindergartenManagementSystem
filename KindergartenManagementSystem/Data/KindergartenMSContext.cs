using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.EnterModels;
using KindergartenManagementSystem.Models.shared;
using KindergartenManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace KindergartenManagementSystem.Data
{
    public class KindergartenMSContext : DbContext
    {
        public KindergartenMSContext(DbContextOptions<KindergartenMSContext> options) : base(options)
        {
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enter_Request> enter_Requests { get; set; }

        // 请假管理
        public DbSet<Absence> Absences { get; set; }
    }
}
