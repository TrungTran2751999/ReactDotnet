using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using Microsoft.EntityFrameworkCore;
using app.DTO;
namespace app.Services;
public interface  IStudentService{
    Task<List<Student>> GetAll();
    Task<Student> GetById();
    Task<bool> Create(Student student);
    Task<Student> Update(Student student);
    Task<List<StudentDTO>> GetAllDTO(); 
}