using CollegeApp.Model.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Model
{
    public class studentDTO
    {
        //public int studentID { get; set; }
        //public string? name { get; set; }
        //public int age { get; set; }
        //public string email { get; set; }
        [ValidateNever]
        public int studentID { get; set; }


        //[Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]
        [CapitalCheck]
        public string name {  get; set; }

        [Range(10,30)]
        public int age { get; set; }



        [EmailAddress(ErrorMessage = "check email")]
        
        public string email { get; set; }

        //[SpaceCheck]
        //public string Password { get; set; }
        
        
        //[Compare(nameof(Password))]
        //public string? ConfirmPassword { get; set; }
      



    }
}
