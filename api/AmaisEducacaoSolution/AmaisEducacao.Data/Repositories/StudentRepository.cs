using AmaisEducacao.Data.Context;
using AmaisEducacao.Data.Repositories.Interfaces;
using AmaisEducacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmaisEducacao.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AmaisEducacaoContext _amaisEducacaoContext;

        public StudentRepository(AmaisEducacaoContext context)
        {
            _amaisEducacaoContext = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _amaisEducacaoContext.Student
                        .Where(s => s.DeletionDate == null)
                        .OrderByDescending(s => s.CreationDate)
                        .ToListAsync();
        }

        public async Task<Student> GetStudentByRAAsync(string ra)
        {
            return await _amaisEducacaoContext.Student
                .FirstOrDefaultAsync(s => s.RA == ra && s.DeletionDate == null);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _amaisEducacaoContext.Student.AddAsync(student);
            await _amaisEducacaoContext.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _amaisEducacaoContext.Student.Update(student);
            await _amaisEducacaoContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByCPFAsync(string cpf)
        {
            return await _amaisEducacaoContext.Student
                .Where(s => s.DeletionDate == null)
                .AnyAsync(s => s.CPF == cpf);
        }

        public async Task DeleteStudentAsync(Student student)
        {
            student.DeletionDate = DateTime.UtcNow;

            _amaisEducacaoContext.Student.Update(student);

            await _amaisEducacaoContext.SaveChangesAsync();
        }
    }
}
