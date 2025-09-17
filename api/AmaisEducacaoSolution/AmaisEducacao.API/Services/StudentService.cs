using AmaisEducacao.API.Services.Interfaces;
using AmaisEducacao.Data.Repositories.Interfaces;
using AmaisEducacao.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AmaisEducacao.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetStudentByRAAsync(string ra)
        {

            var Studant = await _studentRepository.GetStudentByRAAsync(ra);

            return Studant == null ? null : Studant;          

        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            var existingStudent = await _studentRepository.GetStudentByRAAsync(student.RA);

            if (existingStudent != null)
                return null;

            await _studentRepository.AddStudentAsync(student);

            return student;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var existingStudent = await _studentRepository.GetStudentByRAAsync(student.RA);

            if (existingStudent == null)
                return null;           

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;

            await _studentRepository.UpdateStudentAsync(existingStudent);
            return existingStudent;
        }

        public async Task<bool> DeleteStudentAsync(string ra)
        {
            var student = await _studentRepository.GetStudentByRAAsync(ra);

            if (student == null)
                return false;

            await _studentRepository.DeleteStudentAsync(student);
            return true;
        }
    }
}
