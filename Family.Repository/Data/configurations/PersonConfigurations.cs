using Family.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family.Repository.Data.configurations
{
    public class PersonConfigurations : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Existing properties
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PhotoUrl).IsRequired().HasMaxLength(255);
            builder.Property(p => p.FatherName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.MotherName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.FacebookAccount).HasMaxLength(100);
            builder.Property(p => p.InstagramAccount).HasMaxLength(100);

            // New properties
            builder.Property(p => p.EmailAddress).IsRequired().HasMaxLength(100);
            builder.Property(p => p.AddressTitle).HasMaxLength(255);
            builder.Property(p => p.FCMToken).HasMaxLength(255);


            // Configure relationship with Branch
            builder.HasOne(p => p.Branch)
                .WithMany(b => b.Persons)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure relationship with Clan
            builder.HasOne(p => p.Clan)
                .WithMany()
                .HasForeignKey(p => p.ClanId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configure one-to-many relationship with Notifications
            builder.HasMany(p => p.Notifications)
                .WithOne(n => n.Person)
                .HasForeignKey(n => n.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
