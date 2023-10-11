using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Models;

public class Code{
    [Key]
    public long idSystem{get;set;}
    public string? code{get;set;}
}