using System.Data.Entity;

namespace Store.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Gadget> Gadgets { get; set; }
    }
}