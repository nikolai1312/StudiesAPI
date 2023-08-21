using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StudiesAPI.Data.Configuration;
using StudiesAPI.Data.Interfaces;
using StudiesAPI.Entities;

namespace StudiesAPI.Data
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new GuestDbConfigs());
        }
    }
}
