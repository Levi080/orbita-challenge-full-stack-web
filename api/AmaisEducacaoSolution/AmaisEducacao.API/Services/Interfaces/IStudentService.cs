using AmaisEducacao.Domain.Entities;

namespace AmaisEducacao.API.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<Student> GetStudentByRAAsync(string ra);

        Task<Student> CreateStudentAsync(Student student);

        Task<Student> UpdateStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(string ra);

        Task<IEnumerable<Student>> GetStudentsByNameAsync(string name);
    }
}
