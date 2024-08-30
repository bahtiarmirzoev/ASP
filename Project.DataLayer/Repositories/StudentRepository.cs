using Academy.Core.Models;
using Microsoft.EntityFrameworkCore;
using Project.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataLayer.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private AcademyDbContext _context;

        public StudentRepository(AcademyDbContext context)
        {
            _context = context;

        }

        public async Task<List<Student>> GetStudents()
        {
            var studentModels = await _context.Students.AsNoTracking().ToListAsync();

            var students = studentModels
                .Select(s => Student.Create(s.Id, s.Username, s.Name, s.Email, s.Surname, s.Email).Student)
                .ToList();
            return students;
        }

        public async Task<Guid> CreateStudent(Student student)
        {
            var studentModel = new StudentModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Surname = student.Surname,
                Phone = student.Phone,
            };
            await _context.Students.AddAsync(studentModel);
            await _context.SaveChangesAsync();

            return student.Id;
        }

        public async Task<Guid> UpdateStudent(Guid id, string name, string surname, string email, string phone, string username)
        {
            _context.Students
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.Name, name)
                .SetProperty(s => s.Surname, surname)
                .SetProperty(s => s.Email, email)
                .SetProperty(s => s.Phone, phone)
                .SetProperty(s => s.Username, username));

            return id;
        }

        public async Task<Guid> DeleteStudent(Guid id)
        {
            await _context.Students
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

    }
}
