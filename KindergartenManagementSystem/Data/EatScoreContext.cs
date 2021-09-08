using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KindergartenManagementSystem.Models;

namespace KindergartenManagementSystem.Data
{
    public class EatScoreContext:DbContext
    {
        public EatScoreContext(DbContextOptions<EatScoreContext> options): base(options)
        {

        }

        public DbSet<EatScore> EatScores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
