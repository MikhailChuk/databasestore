using System.Collections.Generic;

namespace Store.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Gadget> Gadgets
        {
            get { return context.Gadgets; }
        }
    }
}