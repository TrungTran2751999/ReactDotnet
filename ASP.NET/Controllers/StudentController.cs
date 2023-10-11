using Microsoft.AspNetCore.Mvc;
using app.Services;
using Microsoft.AspNetCore.Authorization;
namespace app.Controllers;
[ApiController]
[Route("api/student")]
public class StudentController:ControllerBase{
     private IStudentService studentService;

     public StudentController(IStudentService studentService){
        this.studentService = studentService;
     }
    [Authorize(Roles ="ADMIN")]
    [HttpGet]
     public async Task<IActionResult> GetAll(){
        var student = await studentService.GetAll();
        return Ok(student);
     }
   [HttpGet]
   [Route("dto")]
   public async Task<IActionResult> GetAllDTO(){
        var student = await studentService.GetAllDTO();
        return Ok(student);
     }
}