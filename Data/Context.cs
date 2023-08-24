using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StudiesAPI.Data.Configuration;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Domain.Entities;

namespace StudiesAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new GuestDbConfigs());
        }

        DbSet<Guest> Guests { get; set; }
    }
}
