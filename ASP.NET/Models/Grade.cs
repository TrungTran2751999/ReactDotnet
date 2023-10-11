using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models;

public class Grade{
    [Key]
    [Column("idSystem")]
    public long idSystem{get;set;}
    public string? name{get;set;}
}