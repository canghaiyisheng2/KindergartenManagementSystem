using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KindergartenManagementSystem.Models.EnterModels
{
    public class Enter_Request
    {
        [Key]
        [Display(Name="流程号：")]
        public int Pro_id { get; set; }

        [Display(Name = "流程状态：")]
        public int Status { get; set; }

        [Display(Name = "流程发起者：")]
        public string Starter { get; set; }

        [Display(Name = "流程审核者：")]
        public string Approver { get; set; }

        [Display(Name = "学号：")]
        public int Child_Id { get; set; }

        [Display(Name = "姓名：")]
        [Required(ErrorMessage = "请输入孩子的姓名")]
        public string Name { get; set; }

        [Display(Name = "出生日期：")]
        [Required(ErrorMessage = "请输入孩子的出生日期")]
        [DisplayFormat(DataFormatString = "yy/MM/dd")]
        public DateTime Birthday { get; set; }

        [Display(Name = "性别：")]
        public bool Sex { get; set; }

        [Display(Name = "监护人姓名：")]
        [Required(ErrorMessage = "请输入孩子的监护人姓名")]
        public string Gua_name { get; set; }

        [Display(Name = "监护人联系方式：")]
        [Required(ErrorMessage = "请输入孩子的监护人联系方式")]
        public string Gua_phone { get; set; }

        [Display(Name = "家庭住址：")]
        [Required(ErrorMessage = "请输入孩子的家庭住址")]
        public string Home_addr { get; set; }

        [Display(Name = "入托班级：")]
        [Required(ErrorMessage = "请输入孩子的入托的班级")]
        public string Cla { get; set; }

        [Display(Name = "审批意见：")]
        public string Suggest { get; set; }
    }
}
