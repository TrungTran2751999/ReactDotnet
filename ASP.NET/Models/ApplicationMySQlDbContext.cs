using app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using app.DTO;

public class ApplicationMySQLDbContext : DbContext
{
     public ApplicationMySQLDbContext(DbContextOptions<ApplicationMySQLDbContext> options): base(options)
    {
    }
    public virtual DbSet<Teacher> Teachers{get;set;}

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