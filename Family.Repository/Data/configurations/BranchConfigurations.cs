using Family.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Family.Repository.Data.configurations
{
    public class BranchConfigurations : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {

           
             builder.HasOne(b => b.Clan)
            .WithMany(c => c.Branches)
            .HasForeignKey(b => b.ClanId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
