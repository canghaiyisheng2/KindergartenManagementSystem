using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KindergartenManagementSystem.Models.shared;

namespace KindergartenManagementSystem.Models
{
    // 请假实体类
    public class Absence
    {
        [Key]
        public int id { get; set; }

        //[ForeignKey("Child_id")]
        //public virtual Child starter { get; set; }
        public string starter { get; set; }

        [Display(Name = "开始时间")]
        [Required(ErrorMessage = "必须填写开始时间")]
        public DateTime fromTime { get; set; }

        [Display(Name = "结束时间")]
        [Required(ErrorMessage = "必须填写结束时间")]
        public DateTime toTime { get; set; }

        [Display(Name = "前往地点")]
        [Required(ErrorMessage = "必须填写前往地点")]
        public string location { get; set; }

        [Display(Name = "请假原因")]
        [Required(ErrorMessage = "必须填写请假原因")]
        public string reason { get; set; }

        public string rejectReason { get; set; }

        public int status { get; set; }
    }

    enum AbsenceStatus
    {
        TO_BE_REVIEWED,
        REJECTED,
        ACCEPTED,
        COMPLETED
    }
}


