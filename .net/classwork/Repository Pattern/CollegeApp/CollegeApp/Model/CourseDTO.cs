using CollegeApp.Model.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Model
{
    public class CourseDTO
    {
        [Required]
        public int Id { get; set; }

        //[StringLength(100)]
        public string CourseName { get; set; }

        
        public int Rank { get; set; }

    }
}
