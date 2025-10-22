using CollegeApp.Model.Validations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeApp.Data
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int studentID { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public string email { get; set; }
        //public string Password { get; set; }


        //public required string ConfirmPassword { get; set; }
        
    }
}





//Commands -> Add-Migration (migration name) -->Update-Database
