using AmaisEducacao.Domain.Entities;

namespace AmaisEducacao.Domain.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<Student> GetStudentByRAAsync(string ra);

        Task AddStudentAsync(Student student);

        Task UpdateStudentAsync(Student student);

        Task<bool> ExistsByCPFAsync(string cpf);

        Task DeleteStudentAsync(Student student);

        Task<IEnumerable<Student>> GetStudentsByNameAsync(string name);
    }
}
