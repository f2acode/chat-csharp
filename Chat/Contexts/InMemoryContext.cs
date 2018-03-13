using Chat.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Chat.Contexts
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options)
            :base(options){}

        public DbSet<ChatDBModel> Chats { get; set; }
        public DbSet<MessageDBModel> Messages { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ChatDBModel>()
        //        .Property(typeof(string), "Id");
        //}
    }
}
