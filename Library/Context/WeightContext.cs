using System.Collections.Generic;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Context
{
    public class WeightContext : DbContext
    {
        public WeightContext(DbContextOptions<WeightContext> options) : base(options)
        {
        }

        //public DbSet<WeightDbModel> WeightDbModels => Set<WeightDbModel>();

        public DbSet<UserDbModel> UserDbModels => Set<UserDbModel>();

    }
}
