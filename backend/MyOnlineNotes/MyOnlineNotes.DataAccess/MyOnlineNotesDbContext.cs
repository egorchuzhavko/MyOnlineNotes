using Microsoft.EntityFrameworkCore;
using MyOnlineNotes.DataAccess.Configurations;
using MyOnlineNotes.DataAccess.Entities;

namespace MyOnlineNotes.DataAccess {
    public class MyOnlineNotesDbContext : DbContext {
        public MyOnlineNotesDbContext(DbContextOptions<MyOnlineNotesDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NotesEntity> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new NotesConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
