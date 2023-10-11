using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.DTO;
[NotMapped]
public class StudentDTO{
    public long? IdSystem{get;set;}
    public string? Grades{get;set;}
    public long? Code{get;set;}
    public string? Name{get;set;}
}