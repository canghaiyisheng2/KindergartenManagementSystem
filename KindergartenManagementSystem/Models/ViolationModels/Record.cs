using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KindergartenManagementSystem.Models.ViolationModels
{
    public class Record
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please type id")]
        public int childId { get; set; }

        [Required(ErrorMessage = "Please type name")]
        public string childName { get; set; }

        [Required(ErrorMessage = "Please input score")]
        [Range(80,100)]
        public int score{ get; set; }

        [Required(ErrorMessage = "Please type reason")]
        public string reason { get; set; }
    }
}
