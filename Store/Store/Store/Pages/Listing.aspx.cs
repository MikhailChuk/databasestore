using Store.Models;
using Store.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected IEnumerable<Gadget> GetGadgets()
        {
            return repository.Gadgets;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}