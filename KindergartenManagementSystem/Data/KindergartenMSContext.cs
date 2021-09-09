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

        //公共模块
        public DbSet<Child> Children { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        //入托模块
        public DbSet<Enter_Request> enter_Requests { get; set; }

        // 请假管理
        public DbSet<Absence> Absences { get; set; }

        // 就餐管理
        public DbSet<EatScore> EatScores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EatScore>().HasData(
                new EatScore
                {
                    Id = 1,
                    StuId = 1,
                    Teacher = "fnsflm",
                    Date = "2021-09-08",
                    Score = 4,
                    Note = "hhh"
                },
                new EatScore
                {
                    Id = 2,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "2021-09-01",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 3,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "2021-09-02",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 4,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "2021-09-03",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 5,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "2021-09-04",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 6,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "2021-09-05",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 7,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "2021-09-05",
                    Score = 5,
                    Note = "eeeee"
                }
                );
            modelBuilder.Entity<Child>().HasData(
                new Child
                {
                    id = 1,
                    name = "Tom"
                },
                new Child
                {
                    id = 2,
                    name = "Joe",
                    sex = true
                }
                );
        }
    }
}
