using System.Data.Entity;
using System.Web;

namespace Store.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + HttpContext.Current.Server.MapPath("~/App_Data/Store.mdf")
                    + ";Integrated Security=True")
        { }
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}