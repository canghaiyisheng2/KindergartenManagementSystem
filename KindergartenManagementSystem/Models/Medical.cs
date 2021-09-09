using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindergartenManagementSystem.Models
{
    public class Medical
    {
        [Key]
        public int id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "姓名"), Required(ErrorMessage = "请输入学生的姓名")]
        public string name { get; set; }

        [Display(Name = "性别"), Required(ErrorMessage = "请选择学生的性别")]
        public string sex { get; set; }

        [Display(Name = "出生日期"), Required(ErrorMessage = "请输入学生的出生日期(xxxx-xx-xx)")]
        public string birth { get; set; }

        [Display(Name = "班级"), Required(ErrorMessage = "请选择学生的班级")]
        public string class_id { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [Display(Name = "家庭住址"), Required(ErrorMessage = "请输入学生的家庭住址")]
        public string home_addr { get; set; }

        [Display(Name = "就医日期"), Required(ErrorMessage = "请输入学生的就医日期")]
        public string Med_date { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [Display(Name = "就医地点"), Required(ErrorMessage = "请输入学生就医地点")]
        public string out_place { get; set; }
    }
}
