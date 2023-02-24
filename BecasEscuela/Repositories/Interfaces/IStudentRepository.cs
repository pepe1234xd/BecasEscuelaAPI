using BecasEscuela.Models.Domain;

namespace BecasEscuela.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetAsync(int id);
        Task<Student> AddAsync(Student student);
        Task<Student> DeleteAsync(int id);
        Task<Student> UpdateAsync(int id, Student student);
    }
}
