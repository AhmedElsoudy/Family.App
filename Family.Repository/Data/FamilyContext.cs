using Family.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Family.Repository.Data
{
    public class FamilyContext : DbContext
    {
        public FamilyContext(DbContextOptions<FamilyContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SliderItem> SliderItems { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
    }
}
