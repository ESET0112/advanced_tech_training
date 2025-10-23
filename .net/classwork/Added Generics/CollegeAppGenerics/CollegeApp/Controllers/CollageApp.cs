using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollageApp : ControllerBase
    {
        private readonly ICollegeRepository<Student> _studentRepository;
        private readonly ICollegeRepository<Course> _courseRepository;



        public CollageApp(
            ICollegeRepository<Student> studentRepository,
            ICollegeRepository<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        // Student Endpoints
        [HttpGet("students/all")]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var students = await _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("students/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var student = await _studentRepository.GetById(id);

            if (student == null)
            {
                return NotFound($"Student with ID {id} not found");
            }

            return Ok(student);
        }

        [HttpGet("students/name/{name}")]
        public async Task<ActionResult<Student>> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty");
            }

            var student = await _studentRepository.GetByName(name);

            if (student == null)
            {
                return NotFound($"Student with name '{name}' not found");
            }

            return Ok(student);
        }



        [HttpPost("students/create")]
        public async Task<ActionResult<int>> CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student cannot be null");
            }

            var result = await _studentRepository.Create(student);
            return Ok(new { message = "Student created successfully", id = result });
        }

        [HttpPut("students/update")]
        public async Task<ActionResult<int>> UpdateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student cannot be null");
            }

            var result = await _studentRepository.Update(student);
            return Ok(new { message = "Student updated successfully", id = result });
        }

        [HttpDelete("students/delete/{id}")]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = await _studentRepository.Delete(id);

            if (!result)
            {
                return NotFound($"Student with ID {id} not found");
            }

            return Ok(new { message = "Student deleted successfully", success = true });
        }

        // Course Endpoints
        [HttpGet("courses/all")]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAll();
            return Ok(courses);
        }

        [HttpGet("courses/{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var course = await _courseRepository.GetById(id);

            if (course == null)
            {
                return NotFound($"Course with ID {id} not found");
            }

            return Ok(course);
        }

        [HttpGet("courses/name/{name}")]
        public async Task<ActionResult<Course>> GetCourseByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty");
            }

            var course = await _courseRepository.GetByName(name);

            if (course == null)
            {
                return NotFound($"Course with name '{name}' not found");
            }

            return Ok(course);
        }

        [HttpPost("courses/create")]
        public async Task<ActionResult<int>> CreateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Course cannot be null");
            }

            var result = await _courseRepository.Create(course);
            return Ok(new { message = "Course created successfully", id = result });
        }

        [HttpPut("courses/update")]
        public async Task<ActionResult<int>> UpdateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Course cannot be null");
            }

            var result = await _courseRepository.Update(course);
            return Ok(new { message = "Course updated successfully", id = result });
        }

        [HttpDelete("courses/delete/{id}")]
        public async Task<ActionResult<bool>> DeleteCourse(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = await _courseRepository.Delete(id);

            if (!result)
            {
                return NotFound($"Course with ID {id} not found");
            }

            return Ok(new { message = "Course deleted successfully", success = true });
        }
    }



}



//using CollegeApp.Data;
//using CollegeApp.Data.Repository;
//using CollegeApp.Model;
//using Microsoft.AspNetCore.Mvc;

//namespace CollegeApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CollageApp : ControllerBase
//    {
//        private readonly IServiceProvider _serviceProvider;

//        public CollageApp(IServiceProvider serviceProvider)
//        {
//            _serviceProvider = serviceProvider;
//        }

//        [HttpGet("all/{entityType}")]
//        public async Task<ActionResult> GetAll(string entityType)
//        {
//            try
//            {
//                dynamic repository = GetRepository(entityType);
//                dynamic result = await repository.GetAll();
//                return Ok(result);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("{entityType}/id/{id}")]
//        public async Task<ActionResult> GetById(string entityType, int id)
//        {
//            if (id <= 0) return BadRequest("ID must be greater than 0");

//            try
//            {
//                dynamic repository = GetRepository(entityType);
//                dynamic result = await repository.GetById(id);

//                if (result == null)
//                    return NotFound($"{entityType} with ID {id} not found");

//                return Ok(result);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("{entityType}/name/{name}")]
//        public async Task<ActionResult> GetByName(string entityType, string name)
//        {
//            if (string.IsNullOrEmpty(name)) return BadRequest("Name cannot be empty");

//            try
//            {
//                dynamic repository = GetRepository(entityType);
//                dynamic result = await repository.GetByName(name);

//                if (result == null)
//                    return NotFound($"{entityType} with name '{name}' not found");

//                return Ok(result);
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPost("{entityType}/create")]
//        public async Task<ActionResult> Create(string entityType, [FromBody] object entity)
//        {
//            if (entity == null) return BadRequest("Entity cannot be null");

//            try
//            {
//                dynamic repository = GetRepository(entityType);
//                dynamic result = await repository.Create(entity);
//                return Ok(new { message = $"{entityType} created successfully", id = result });
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPut("{entityType}/update")]
//        public async Task<ActionResult> Update(string entityType, [FromBody] object entity)
//        {
//            if (entity == null) return BadRequest("Entity cannot be null");

//            try
//            {
//                dynamic repository = GetRepository(entityType);
//                dynamic result = await repository.Update(entity);
//                return Ok(new { message = $"{entityType} updated successfully", id = result });
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpDelete("{entityType}/delete/{id}")]
//        public async Task<ActionResult> Delete(string entityType, int id)
//        {
//            if (id <= 0) return BadRequest("ID must be greater than 0");

//            try
//            {
//                dynamic repository = GetRepository(entityType);
//                dynamic result = await repository.Delete(id);

//                if (!result)
//                    return NotFound($"{entityType} with ID {id} not found");

//                return Ok(new { message = $"{entityType} deleted successfully", success = true });
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        private dynamic GetRepository(string entityType)
//        {
//            return entityType.ToLower() switch
//            {
//                "student" => _serviceProvider.GetService<ICollegeRepository<Student>>(),
//                "course" => _serviceProvider.GetService<ICollegeRepository<Course>>(),
//                _ => throw new ArgumentException($"Unknown entity type: {entityType}")
//            };
//        }
//    }
//}