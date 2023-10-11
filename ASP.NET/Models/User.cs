using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models;

public class User{
    [Key]
    [Column("Idsystem")]
    public long IdSystem{get;set;}
    [Column("username")]
    public string? Name{get;set;}
    [Column("password")]
    public string? Password{get;set;}
    [Column("role")]
    public string? Role{get;set;}
}
