using CollegeApp.Data;
using CollegeApp.Model;
using CollegeApp.Mylogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Controllers
{

    



    [Route("api/[controller]")]
    [ApiController]
    public class CollageApp : ControllerBase
    {
        //[HttpGet]

        //public ActionResult<IEnumerable<Student>> getstudents()
        //{
        //    return Ok(collageRepository.students);
        //}


        private readonly IMylogger _mylogger;

        private readonly CollageDBContext _dbcontext;
        

        public CollageApp(IMylogger mylogger, CollageDBContext dbcontext)
        {
            _mylogger = mylogger;
            _dbcontext = dbcontext;
            
        }



        [HttpGet]
        [Route("AllStudents")]
        public ActionResult<IEnumerable<studentDTO>> getstudents()
        {
            _mylogger.Log("Hello");

            //var students = _dbcontext.Students.Select(s => new studentDTO()
            //{
            //    studentID = s.studentID,
            //    name = s.name,
            //    age = s.age,
            //    email = s.email,

            //}).ToList();
            var students = _dbcontext.Students.ToList();

            return Ok(students);

        }

        //For Course
        [HttpGet]
        [Route("AllCourse")]
        public ActionResult<IEnumerable<CourseDTO>> getcoursess()
        {
            _mylogger.Log("Hello");

            var courses = _dbcontext.Courses.Select(s => new CourseDTO()
            {
                Id = s.Id,
                CourseName = s.CourseName,
                Rank = s.Rank

            });

            return Ok(courses);

        }




        //[HttpGet("{id:int}", Name = "getstudentsbyid")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //public ActionResult<Student> getstudentsbyid(int id)
        //{
        //    if (id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    var students = collageRepository.students
        //           .Where(n => n.studentID == id)
        //           .FirstOrDefault();
        //    if (students == null)
        //    {
        //        return NotFound($"this {id} is not present in record");
        //    }

        //    return Ok(students);
        //}


        [HttpGet("{id:int}", Name = "getstudentsbyid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<studentDTO> getstudentsbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var students = _dbcontext.Students
                   .Where(n => n.studentID == id)
                   .FirstOrDefault();
            var studentDTO = new studentDTO
            {
                //studentID = students.studentID,
                name = students.name,
                age = students.age,
                email = students.email,
            };
            if (studentDTO == null)
            {
                return NotFound($"this {id} is not present in record");
            }

            return Ok(studentDTO);
        }


        //[HttpGet("name/{Name}")]

        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]

        //[ProducesResponseType(404)]
        //public ActionResult<studentDTO> getstudentsbyname(string Name)
        //{
        //    if (String.IsNullOrEmpty(Name))
        //    {
        //        return BadRequest();
        //    }
        //    var students = collageRepository.students
        //           .Where(n => n.name == Name)
        //           .FirstOrDefault();

        //    if (students == null)
        //    {
        //        return NotFound($"this {Name} is not present in record");
        //    }
        //    return Ok(students);
        //}




        [HttpGet("name/{Name}")]

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        [ProducesResponseType(404)]
        public ActionResult<studentDTO> getstudentsbyname(string Name)
        {
            if (String.IsNullOrEmpty(Name))
            {
                return BadRequest();
            }
            var students = _dbcontext.Students
                   .Where(n => n.name == Name)
                   .FirstOrDefault();
            var studentDTO = new studentDTO
            {
                //studentID = students.studentID,
                name = students.name,
                age = students.age,
                email = students.email,
            };
            if (studentDTO == null)
            {
                return NotFound($"this {Name} is not present in record");
            }
            return Ok(studentDTO);
        }



        [HttpPost("CreateStudent")]

        public ActionResult<studentDTO> CreateStudent([FromBody]studentDTO Model)
        {
            if(Model == null)
            {
                return BadRequest();
            }

            //int newid = _dbcontext.Students.LastOrDefault().studentID + 1;    //Auto Increment is happening so commented out
            Student studentnew = new Student
            {
                //studentID = newid,
                name = Model.name,
                age = Model.age,
                email = Model.email,
                //Password=Model.Password,
                //ConfirmPassword=Model.ConfirmPassword
            };

            _dbcontext.Students.Add(studentnew);
            _dbcontext.SaveChanges();
            return Ok(studentnew);
        }




        [HttpPost("Createcourse")]

        public ActionResult<CourseDTO> CreateCourse([FromBody] CourseDTO Model)
        {
            if (Model == null)
            {
                return BadRequest();
            }

            //int newid = _dbcontext.Students.LastOrDefault().studentID + 1;    //Auto Increment is happening so commented out
            Course newCourse = new Course
            {
                //studentID = newid,
                Id = Model.Id,
                CourseName= Model.CourseName,
                Rank = Model.Rank,
                
            };

            _dbcontext.Courses.Add(newCourse);
            _dbcontext.SaveChanges();
            return Ok(newCourse);
        }




        [HttpPut]
        [Route("UpdateStudent")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<studentDTO> UpdateStudent([FromBody] studentDTO Model)
        {
            if (Model == null || Model.studentID < 0)
            {
                return BadRequest();
            }

            var existingStudent = _dbcontext.Students.Where(s => s.studentID == Model.studentID).FirstOrDefault();

            if (existingStudent == null)
            {
                return NotFound($"The student with id {Model.studentID} not found");
            }

            existingStudent.name = Model.name;
            existingStudent.email = Model.email;
            existingStudent.age = Model.age;

            _dbcontext.SaveChanges();

            return Ok(existingStudent);

        }





        [HttpPut]
        [Route("UpdateCourse")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<CourseDTO> UpdateCourse([FromBody] CourseDTO Model)
        {
            if (Model == null || Model.Id < 0)
            {
                return BadRequest();
            }

            var existingCourse = _dbcontext.Courses.Where(s => s.Id == Model.Id).FirstOrDefault();

            if (existingCourse == null)
            {
                return NotFound($"The Course with id {Model.Id} not found");
            }

            existingCourse.Id = Model.Id;
            existingCourse.CourseName = Model.CourseName;
            existingCourse.Rank = Model.Rank;

            _dbcontext.SaveChanges();

            return Ok(existingCourse);

        }

        //[HttpPut]
        //[Route("Update")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]

        //public ActionResult UpdateStudent([FromBody] studentDTO Model)
        //{
        //    if (Model == null || Model.studentID <= 0)
        //    {
        //        return BadRequest();
        //    }

        //    var existingStudent = collageRepository.students.Where(s => s.studentID == Model.studentID).FirstOrDefault();

        //    if (existingStudent == null)
        //    {
        //        return NotFound($"The student with id {Model.studentID} not found");
        //    }

        //    existingStudent.name = Model.name;
        //    existingStudent.email = Model.email;
        //    existingStudent.age = Model.age;

        //_dbcontext.SaveChanges();

        //    return NoContent();

        //}









        [HttpPatch]
        [Route("{id:int}/UpdatePartialStudent")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<studentDTO> UpdateStudentPartial(int id,[FromBody] JsonPatchDocument<studentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }

            var existingStudent = _dbcontext.Students.Where(s => s.studentID == id).FirstOrDefault();

            if (existingStudent == null)
            {
                return NotFound($"The student with id {id} not found");
            }

            var studentDto = new studentDTO()
            {
                studentID = existingStudent.studentID,
                name = existingStudent.name,
                email = existingStudent.email,
                age = existingStudent.age
            };
            
            patchDocument.ApplyTo(studentDto,ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingStudent.name = studentDto.name;
            existingStudent.email = studentDto.email;
            existingStudent.age = studentDto.age;

            _dbcontext.SaveChanges();

            return NoContent();

        }











        [HttpPatch]
        [Route("{id:int}/UpdatePartialCourse")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<CourseDTO> UpdateCoursePartial(int id, [FromBody] JsonPatchDocument<CourseDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }

            var existingCourse = _dbcontext.Courses.Where(s => s.Id == id).FirstOrDefault();

            if (existingCourse == null)
            {
                return NotFound($"The course with id {id} not found");
            }

            var courseDto = new CourseDTO()
            {
                Id = existingCourse.Id,
                CourseName = existingCourse.CourseName,
                Rank = existingCourse.Rank
            };

            patchDocument.ApplyTo(courseDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingCourse.Id = courseDto.Id;
            existingCourse.CourseName = courseDto.CourseName;
            existingCourse.Rank = courseDto.Rank;

            _dbcontext.SaveChanges();

            return NoContent();

        }











        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        [ProducesResponseType(404)]
        public ActionResult<bool> deletestudent(int id)
        {
            
            if (id == 0)
            {
                return BadRequest();
            }
            var deleting = _dbcontext.Students
                           .Where(n=> n.studentID == id)
                           .FirstOrDefault();

            if (deleting == null)
            {
                return NotFound($"this {deleting} is not present in record");
            }
            _dbcontext.Students.Remove(deleting);

            _dbcontext.SaveChanges();
            return true;
        }
    }
}
