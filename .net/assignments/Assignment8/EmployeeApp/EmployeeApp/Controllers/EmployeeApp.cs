using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Data.Repository;
using EmployeeApp.Models;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeApp : ControllerBase
    {
        private readonly IEmployeeRepository<Employee> _employeeRepository;
        private readonly IEmployeeRepository<User> _userRepository;

        public EmployeeApp(
            IEmployeeRepository<Employee> employeeRepository,
            IEmployeeRepository<User> userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        // Employee Endpoints
        [HttpGet("Employees/all")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("Employees/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }

            return Ok(employee);
        }

        [HttpPost("Employees/Create")]
        public async Task<ActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee data cannot be null");
            }

            var employee = new Employee
            {
                FullName = employeeDto.FullName,
                Department = employeeDto.Department,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email
            };

            await _employeeRepository.AddAsync(employee);
            return Ok(new { message = "Employee created successfully", id = employee.EmployeeId });
        }

        [HttpPut("Employees/update/{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDto)
        {
            if (employeeDto == null)
            {
                return BadRequest("Employee data cannot be null");
            }

            var existingEmployee = await _employeeRepository.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }

            existingEmployee.FullName = employeeDto.FullName;
            existingEmployee.Department = employeeDto.Department;
            existingEmployee.Salary = employeeDto.Salary;
            existingEmployee.Email = employeeDto.Email;

            await _employeeRepository.UpdateAsync(id, existingEmployee);
            return Ok(new { message = "Employee updated successfully", id = id });
        }

        [HttpDelete("Employees/delete/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }

            await _employeeRepository.DeleteAsync(id);
            return Ok(new { message = "Employee deleted successfully", success = true });
        }

        // User Endpoints
        [HttpGet("Users/all")]
        
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("Users/{id}")]
        
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            return Ok(user);
        }

        [HttpPost("Users/Create")]
        
        public async Task<ActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data cannot be null");
            }

            var user = new User
            {
                UserName = userDto.UserName,
                Password = userDto.Password, // In real app, hash this password
                Role = userDto.Role
            };

            await _userRepository.AddAsync(user);
            return Ok(new { message = "User created successfully", id = user.UserId });
        }

        [HttpPut("Users/update/{id}")]
        
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data cannot be null");
            }

            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            existingUser.UserName = userDto.UserName;
            existingUser.Password = userDto.Password; // In real app, hash this password
            existingUser.Role = userDto.Role;

            await _userRepository.UpdateAsync(id, existingUser);
            return Ok(new { message = "User updated successfully", id = id });
        }

        [HttpDelete("Users/delete/{id}")]
        
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found");
            }

            await _userRepository.DeleteAsync(id);
            return Ok(new { message = "User deleted successfully", success = true });
        }
    }
}