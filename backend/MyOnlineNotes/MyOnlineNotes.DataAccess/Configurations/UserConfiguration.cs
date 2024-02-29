using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyOnlineNotes.Core.Models;
using MyOnlineNotes.DataAccess.Entities;

namespace MyOnlineNotes.DataAccess.Configurations {
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity> {
        public void Configure(EntityTypeBuilder<UserEntity> builder) {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Login)
                .HasMaxLength(Users.MAX_SYMBOLS_LENGTH)
                .IsRequired();

            builder
                .Property(u => u.Password)
                .HasMaxLength(Users.MAX_SYMBOLS_LENGTH)
                .IsRequired();

            builder
                .HasMany(u => u.Notes)
                .WithOne(n => n.User)
                .HasForeignKey(u => u.UserId);
        }
    }
}