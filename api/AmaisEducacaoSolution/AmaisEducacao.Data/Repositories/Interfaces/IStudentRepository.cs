using AmaisEducacao.Domain.Entities;

namespace AmaisEducacao.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<Student> GetStudentByRAAsync(string ra);

        Task AddStudentAsync(Student student);

        Task UpdateStudentAsync(Student student);

        Task DeleteStudentAsync(Student student);
    }
}
