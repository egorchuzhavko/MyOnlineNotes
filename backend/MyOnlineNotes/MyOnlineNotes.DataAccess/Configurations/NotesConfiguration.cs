using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyOnlineNotes.DataAccess.Entities;

namespace MyOnlineNotes.DataAccess.Configurations {
    public class NotesConfiguration : IEntityTypeConfiguration<NotesEntity> {
        public void Configure(EntityTypeBuilder<NotesEntity> builder) {
            builder
                .HasKey(u => u.Id);

            builder
                .HasOne(n => n.User)
                .WithMany(n => n.Notes)
                .HasForeignKey(n => n.UserId);
        }
    }
}
