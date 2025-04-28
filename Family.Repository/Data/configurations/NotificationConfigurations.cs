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
    public class NotificationConfigurations : IEntityTypeConfiguration<Notifications>
    {
        public void Configure(EntityTypeBuilder<Notifications> builder)
        {
            builder.Property(n => n.Title)
                 .IsRequired()
                 .HasMaxLength(200);

            builder.Property(n => n.Body)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(n => n.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Configure relationship with Person
            builder.HasOne(n => n.Person)
                .WithMany(p => p.Notifications)
                .HasForeignKey(n => n.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
