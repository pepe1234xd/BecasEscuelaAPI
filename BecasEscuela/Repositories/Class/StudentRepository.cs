using BecasEscuela.Data;
using BecasEscuela.Models.Domain;
using BecasEscuela.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BecasEscuela.Repositories.Class
{
    public class StudentRepository : IStudentRepository
    {
        private readonly dbConnection dbConnection;

        public StudentRepository(dbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<Student> AddAsync(Student student)
        {
            // Agregar el estudiante a la base de datos
            var addedStudent = await dbConnection.Students.AddAsync(student);

            // Guardar los cambios en la base de datos
            await dbConnection.SaveChangesAsync();

            // Devolver el estudiante agregado
            return addedStudent.Entity;
        }

        public async Task<Student> DeleteAsync(int id)
        {
            var studentToDelete = await dbConnection.Students.FirstOrDefaultAsync(x => x.id == id);

            if (studentToDelete == null)
            {
                return null;
            }

            dbConnection.Students.Remove(studentToDelete);
            await dbConnection.SaveChangesAsync();

            return studentToDelete;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var students = await dbConnection.Students.ToListAsync();

            return students;
        }

        public async Task<Student> GetAsync(int id)
        {
            var student = await dbConnection.Students.FindAsync(id);
            return student;
        }

        public async Task<Student> UpdateAsync(int id, Student student)
        {
            var existingStudent = await dbConnection.Students.FindAsync(id);

            if (existingStudent == null)
            {
                throw new Exception("Student not found");
            }

            existingStudent.name = student.name;
            existingStudent.gender = student.gender;
            existingStudent.age = student.age;

            await dbConnection.SaveChangesAsync();

            return existingStudent;
        }
    }
}
