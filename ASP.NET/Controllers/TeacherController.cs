using Microsoft.AspNetCore.Mvc;
using app.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
namespace app.Controllers;
[ApiController]
[Route("api/teacher")]
public class TeacherController:ControllerBase{
     private ApplicationMySQLDbContext dbContext;

     public TeacherController(ApplicationMySQLDbContext dbContext){
        this.dbContext = dbContext;
     }

    [HttpGet]
     public async Task<IActionResult> GetAll(){
        var teachers = await dbContext.Teachers.ToListAsync();
        return Ok(teachers);
     }
}