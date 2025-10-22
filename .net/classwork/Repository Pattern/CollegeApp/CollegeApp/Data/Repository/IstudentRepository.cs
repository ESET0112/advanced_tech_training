namespace CollegeApp.Data.Repository
{
    public interface IstudentRepository
    {
        Task<List<Student>> GetAll();

        Task<Student> getstudentsbyid(int id);
        Task<Student> getstudentsbyname(string Name);
        Task<int> createstudent(Student student);
        Task<int> updatestudent(Student student);

        Task<bool> deletestudent(int id);

    }
}
