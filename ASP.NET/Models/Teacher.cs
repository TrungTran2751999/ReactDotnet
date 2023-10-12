using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models;

public class Teacher{
    [Key]
    public long idSystem{get;set;}
    public string? name{get;set;}
}