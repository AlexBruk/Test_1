using System.Data.Entity;
using Test_1.DAL.Models;

namespace Test_1.DAL
{
    public class AtlantDbContext : DbContext
    {
        public virtual DbSet<Details> Details { get; set; }

        public virtual DbSet<StoreKeeper> StoreKeepers { get; set; }
    }
}