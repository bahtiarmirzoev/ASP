using Academy.Core.Models;

namespace Project.DataLayer.Repositories
{
    public interface IStudentRepository
    {
        Task<Guid> CreateStudent(Student student);
        Task<Guid> DeleteStudent(Guid id);
        Task<List<Student>> GetStudents();
        Task<Guid> UpdateStudent(Guid id, string name, string surname, string email, string phone, string username);
    }
}