using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models;

public class Student{
    [Key]
    public long idSystem{get;set;}
    public string? name{get;set;}
    public int age{get;set;}
    public string? phoneNumber{get;set;}
    public long? studentCode{get;set;}
    public long? studentGrade{get;set;}
    [ForeignKey("studentGrade")]
    public Grade? Grade{get;set;}
    [ForeignKey("studentCode")]
    public Code? Code{get;set;}
}