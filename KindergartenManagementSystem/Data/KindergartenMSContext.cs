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
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    user_name = "chi1",
                    password = "1234",
                    auth = 0,
                    banding = 1
                },
                new User
                {
                    user_name = "chi2",
                    password = "1234",
                    auth = 0,
                    banding = 2
                },
                new User
                {
                    user_name = "chi3",
                    password = "1234",
                    auth = 0,
                    banding = 3
                },
                new User
                {
                    user_name = "chi4",
                    password = "1234",
                    auth = 0,
                    banding = 4
                }, new User
                {
                    user_name = "tea1",
                    password = "1234",
                    auth = 1,
                    banding = 1001
                }, new User
                {
                    user_name = "tea2",
                    password = "1234",
                    auth = 1,
                    banding = 1002
                }
            );
            modelBuilder.Entity<Child>().HasData(
                new Child
                {
                    id = 1,
                    name = "chi1",
                    birth = new DateTime(2015, 1, 1),
                    sex = true,
                    cla = "class1",
                    gua_name = "gua1",
                    gua_phone = "1111111",
                    home_addr = "xian"
                },
                new Child
                {
                    id = 2,
                    name = "chi2",
                    birth = new DateTime(2015, 1, 1),
                    sex = true,
                    cla = "class1",
                    gua_name = "gua2",
                    gua_phone = "1111111",
                    home_addr = "xian"
                },
                new Child
                {
                    id = 3,
                    name = "chi3",
                    birth = new DateTime(2015, 1, 1),
                    sex = true,
                    cla = "class1",
                    gua_name = "gua3",
                    gua_phone = "1111111",
                    home_addr = "xian"
                },
                new Child
                {
                    id = 4,
                    name = "chi4",
                    birth = new DateTime(2015, 1, 1),
                    sex = true,
                    cla = "class2",
                    gua_name = "gua4",
                    gua_phone = "1111111",
                    home_addr = "xian"
                }
            );
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    id = 1001,
                    name = "tea1",
                    cla = "class1"
                },
                new Teacher
                {
                    id = 1002,
                    name = "tea2",
                    cla = "class1"
                }
            );
            modelBuilder.Entity<Absence>().HasData(
            new Absence
            {
                id = 1,
                starter = "chi1",
                fromTime = new DateTime(2021, 3, 1),
                toTime = new DateTime(2021, 4, 1),
                location = "xian",
                reason = "travel",
                rejectReason = "",
                status = (int)AbsenceStatus.TO_BE_REVIEWED
            },
            new Absence
            {
                id = 2,
                starter = "chi2",
                fromTime = new DateTime(2021, 3, 1),
                toTime = new DateTime(2021, 4, 1),
                location = "xian",
                reason = "travel",
                rejectReason = "",
                status = (int)AbsenceStatus.TO_BE_REVIEWED
            },
            new Absence
            {
                id = 3,
                starter = "chi1",
                fromTime = new DateTime(2021, 3, 1),
                toTime = new DateTime(2021, 4, 1),
                location = "xian",
                reason = "travel",
                rejectReason = "",
                status = (int)AbsenceStatus.TO_BE_REVIEWED
            }
            );

            modelBuilder.Entity<EatScore>().HasData(
                new EatScore
                {
                    Id = 1,
                    StuId = 1,
                    Teacher = "fnsflm",
                    Date = "20210908",
                    Score = 4,
                    Note = "hhh"
                },
                new EatScore
                {
                    Id = 2,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "20210901",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 3,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "20210902",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 4,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "20210903",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 5,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "20210904",
                    Score = 1,
                    Note = "eee"
                },
                new EatScore
                {
                    Id = 6,
                    StuId = 2,
                    Teacher = "fnsflm",
                    Date = "20210905",
                    Score = 1,
                    Note = "eee"
                });
        }
    }
}
