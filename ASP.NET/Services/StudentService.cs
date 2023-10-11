using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.CookiePolicy;
using app.DTO;
namespace app.Services;
public class StudentService : IStudentService
{
    private ApplicationDbContext dbContext;

    public StudentService(ApplicationDbContext dbContext){
        this.dbContext = dbContext;
    }
    public void Create(Student student)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Student>> GetAll()
    {
        var students = await dbContext.Students.Include((c)=>c.Grade).Include(c=>c.Code).ToListAsync();
        return students;
    }

    public async Task<List<StudentDTO>> GetAllDTO()
    {
        var students = await dbContext.StudentDTO.FromSqlRaw(
            "SELECT Students.idSystem as IdSystem, "+
            "Grades.name as Grades, "+
            "Students.studentCode as Code, "+
            "Students.name as Name "+
            "FROM Students JOIN Grades "+
            "ON Students.studentGrade=Grades.idSystem "+
            "ORDER BY Students.idSystem"
        ).ToListAsync();
        return students;
    }

    public Task<Student> GetById()
    {
        throw new NotImplementedException();
    }

    public Task<Student> Update(Student student)
    {
        throw new NotImplementedException();
    }
}