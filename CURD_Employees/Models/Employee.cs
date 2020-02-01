using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CURD_Employees.Models
{
    public class Employee
    {
       [Key]
       [Required]
       public int EmpId { set; get; }

        [Required]
        [MaxLength(3)]
        [MinLength(20)]
        [RegularExpression("[a-zA-Z]", ErrorMessage = "Please Enter Letters only")]
        public string FirstName { set; get; }

        [Required]
        [MaxLength(3)]
        [MinLength(20)]
        [RegularExpression("[a-zA-Z]", ErrorMessage = "Please Enter Letters only")]
        public string LastName { set; get; }

        [Required]
        [MaxLength(50)]
        [MinLength(20)]
        [RegularExpression("[a-zA-Z0-9]", ErrorMessage = "Please Enter Letters from (aA t zZ) and numbers from(0 to 9)")]
        public string Address { set; get; }

        [Required]
        [RegularExpression("[0-9]" , ErrorMessage = "Please Enter Salary in correctly way")]
        public float Salary { set; get; }

        [Required]
        [Phone]
        [RegularExpression("[0-9]{11}")]
        public string Phone { set; get; }

        [Required]
        public string Image { set; get; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { set; get; }

        [Required]
        public bool Active { set; get; }
        [Required]
        public string JobTitle { get; set; }
    }
}