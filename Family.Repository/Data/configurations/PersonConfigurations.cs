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
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.FatherName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.MotherName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.GrandFatherName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.GrandMotherName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);


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
