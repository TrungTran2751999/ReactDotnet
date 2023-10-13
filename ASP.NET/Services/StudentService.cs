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
    public async Task<bool> Create(Student student)
    {
        using(var transaction = dbContext.Database.BeginTransaction())
        {
            try{
                var code = new Code
                {
                    code = "oiuoiu",
                    idSystem = 1
                };
                var resultCode = await dbContext.Codes.FirstOrDefaultAsync(item=>item.idSystem == code.idSystem);
                resultCode.code = code.code;
                resultCode.idSystem = code.idSystem;

                var maxId = dbContext.Students.Max(item=>item.idSystem);
                dbContext.Students.Add(student);
                student.idSystem = maxId+1;
                
                dbContext.SaveChanges();
                transaction.Commit();
                return true;
            }catch(Exception e){
                transaction.Rollback();
                Console.WriteLine(e);
                return false;
            }
        }
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