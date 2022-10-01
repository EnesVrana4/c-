#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace PeopleForPeople.Models;
public class MyContext : DbContext 
{ 
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; } 
    public DbSet<Case> Cases { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Case>()
    //         .HasOne(b => b.Chat)
    //         .WithOne(i => i.ConnectedWith)
    //         .HasForeignKey<Chat>(b => b.ChatId);
    // }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //    {
        
        
    //     modelBuilder.Entity<Chat>()
    //         .HasOne(r => r.ConnectedWith)
    //         .WithMany(r => r.User)
    //         .HasForeignKey(r => r.UserId);

        
            
    //     }
    // }

}
