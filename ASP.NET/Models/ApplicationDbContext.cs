using app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using app.DTO;

public class ApplicationDbContext : DbContext
{
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }
    public virtual DbSet<Student> Students{get;set;}
    public virtual DbSet<User> Users{get;set;}
    public virtual DbSet<Grade> Grades{get;set;}
    public virtual DbSet<Code> Codes{get;set;}
    public virtual DbSet<StudentDTO> StudentDTO{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured){
            
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDTO>(e=>{
            e.HasNoKey();
        });
        // modelBuilder.Ignore<StudentDTO>();
        base.OnModelCreating(modelBuilder);
    }
}