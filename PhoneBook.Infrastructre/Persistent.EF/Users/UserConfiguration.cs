using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain;

namespace PhoneBook.Infrastructre.Persistent.EF.Users;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "user");

        builder.Property(b => b.Name)
            .IsRequired()
           .HasMaxLength(80);

        builder.Property(b => b.Password)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(b => b.Email)
            .IsRequired()
            .HasMaxLength(80);

        builder.OwnsMany(a => a.UserTokens, option =>
        {
            option.ToTable("Tokens", "user");
            option.HasKey(a => a.Id);

            option.Property(a => a.HashedJwtToken)
                 .IsRequired().HasMaxLength(250);
        });

        builder.OwnsMany(c => c.PhoneBooks, option =>
        {
            option.ToTable("PhoneBooks", "phonebook");
            option.HasKey(a => a.Id);

            option.Property(a => a.UserId)
                 .IsRequired();
        });
    }
}