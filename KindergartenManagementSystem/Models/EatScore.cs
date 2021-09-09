using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KindergartenManagementSystem.Models
{
    public class EatScore
    {
        [Key]
        public int Id { get; set; }

        public int StuId { get; set; }
        public string Teacher { get; set; }
        public string Date { get; set; }
        public int Score { get; set; }
        public string Note { get; set; }

        public virtual ICollection<EatScore> EatScores { get; set; }

        //public EatScore(int stu_id, string teacher, string date, int score, string note)
        //{
        //    StuId = stu_id;
        //    Teacher = teacher;
        //    Date = date;
        //    Score = score;
        //    Note = note;
        //}
    }
}
