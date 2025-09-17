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
            return await _amaisEducacaoContext.Student.ToListAsync();
        }

        public async Task<Student> GetStudentByRAAsync(string ra)
        {
            return await _amaisEducacaoContext.Student.FirstOrDefaultAsync(s => s.RA == ra);
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

        public async Task DeleteStudentAsync(Student student)
        {
            _amaisEducacaoContext.Student.Remove(student);
            await _amaisEducacaoContext.SaveChangesAsync();
        }
    }
}
