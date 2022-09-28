===========================================================================================================================================================================================================================================================================================================================public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; } 
    public DbSet<Request> Requests { get;set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentLike> CommentLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       {
        
        
        modelBuilder.Entity<Request>()
            .HasOne(r => r.Reciver)
            .WithMany(u => u.Sender)
            .HasForeignKey(r => r.ReciverId);

        modelBuilder.Entity<Request>()
            .HasOne(r => r.Sender)
            .WithMany(u => u.SenderRequests)
            .HasForeignKey(r => r.SenderId);
            
        }
    }

}
