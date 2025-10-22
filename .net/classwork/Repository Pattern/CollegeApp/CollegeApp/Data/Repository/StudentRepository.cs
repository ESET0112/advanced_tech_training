
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Repository
{
    public class StudentRepository : IstudentRepository
    {
        private readonly CollageDBContext _dbcontext;
        public StudentRepository(CollageDBContext dbcontext) { 
            _dbcontext = dbcontext;
        }
        

        public async Task<List<Student>> GetAll()
        {
            return await _dbcontext.Students.ToListAsync();
        }

        public async Task<Student> getstudentsbyid(int id)
        {
            
            var students = await _dbcontext.Students
                   .Where(n => n.studentID == id)
                   .FirstOrDefaultAsync();


            return students;
        }

        public async Task<Student> getstudentsbyname(string Name)
        {
            var students = await _dbcontext.Students
                   .Where(n => n.name == Name)
                   .FirstOrDefaultAsync();

            if (students == null)
                return null;

            return students;
        }



        public async Task<int> createstudent(Student student)
        {
            Student newstudent = new Student
            {
                name = student.name,
                age = student.age,
                email = student.email

            };

            _dbcontext.Students.Add(newstudent);
            await _dbcontext.SaveChangesAsync();
            return 0;


        }


        public async Task<int> updatestudent(Student student)
        {
            var existingStudent = await _dbcontext.Students.Where(s => s.studentID == student.studentID).FirstOrDefaultAsync();


            existingStudent.name = student.name;
            existingStudent.age = student.age;
            existingStudent.email = student.email;

            await _dbcontext.SaveChangesAsync();
            return 0;
        }



        public async Task<bool> deletestudent(int id)
        {
            var deleting = await _dbcontext.Students
                           .Where(n => n.studentID == id)
                           .FirstOrDefaultAsync();

            _dbcontext.Students.Remove(deleting);

            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}

