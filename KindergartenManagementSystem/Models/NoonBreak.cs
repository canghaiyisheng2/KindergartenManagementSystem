using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenManagementSystem.Models
{
    [Table("NoonBreak")]
    public partial class NoonBreak
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("学生ID")]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("姓名")]
        public string StudentName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("性别")]
        public string Sex { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("年龄")]
        public string Age { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("老师")]
        public string TeacherName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("班级")]
        public string ClassName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("是否半小时入睡")]
        public string IsHalfSleep { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("是否自行穿衣")]
        public string IsSelfDress { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("是否叠被子")]
        public string IsMakeBed { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("起床情况")]
        public string GetupInto { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("身体健康情况")]
        public string Healthy { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("异常情况")]
        public string Abnormal { get; set; }

        [DisplayName("综合评分")]
        public int TotalFen { get; set; }

        [DisplayName("创建日期")]
        public DateTime CreateTime { get; set; }
    }
}
