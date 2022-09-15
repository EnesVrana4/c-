#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace FinalExamEnes.Models;
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; } 
    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }

    




    //  protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<User>()
    //         .HasOne(p => p.Post)
            
    //         .WithMany(b => b.Requests)
    //         ;
    // }
}
