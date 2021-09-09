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

        [Display(Name = "学号：")]
        [Required(ErrorMessage = "请填写学生学号！")]
        [Range(1, 2147483647, ErrorMessage = "请输入正整数！")]
        public int StuId { get; set; }

        [Display(Name = "教师：")]
        public string Teacher { get; set; }

        [Display(Name = "日期")]
        public string Date { get; set; }

        [Required(ErrorMessage = "请给出学生就餐评分！")]
        [Display(Name = "评分")]
        [Range(1,5, ErrorMessage = "请给出学生就餐评分！")]
        public int Score { get; set; }

        [Display(Name = "备注：")]
        public string Note { get; set; }

        public virtual ICollection<EatScore> EatScores { get; set; }
    }
}
